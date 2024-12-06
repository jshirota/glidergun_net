using CSnakes.Runtime;
using CSnakes.Runtime.Python;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Glidergun;

public static class Glidergun
{
    public static Action<IServiceCollection>? ConfigurePython { get; set; }
}

public partial class Grid
{
    public static readonly IPython _python;

    static Grid()
    {
        CopyFile("python.py");
        CopyFile("requirements.txt");

        var builder = Host.CreateDefaultBuilder()
        .ConfigureServices(Glidergun.ConfigurePython ?? (services =>
        {
            var home = Path.Join(Environment.CurrentDirectory);
            services
            .WithPython()
            .WithHome(home)
            .WithVirtualEnvironment(Path.Join(home, ".venv"))
            .FromNuGet("3.13")
            .WithPipInstaller();
        }));

        var host = builder.Build();
        var environment = host.Services.GetRequiredService<IPythonEnvironment>();

        _python = environment.Python();

        TryRegisteringDotNetInteractiveFormatter();
    }

    private static void CopyFile(string fileName)
    {
        var assembly = typeof(Grid).Assembly;
        using var resourceStream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{fileName}")!;
        using var memoryStream = new MemoryStream();
        resourceStream.CopyTo(memoryStream);
        File.WriteAllBytes(fileName, memoryStream.ToArray());
    }

    private static void TryRegisteringDotNetInteractiveFormatter()
    {
        try
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies()
                .SingleOrDefault(assembly => assembly.GetName().Name == "Microsoft.DotNet.Interactive.Formatting");
            var type = assembly?.GetType("Microsoft.DotNet.Interactive.Formatting.Formatter");
            var method = type?.GetMethods()
                .Where(m => m.Name == "Register" && m.IsGenericMethod && m.GetParameters()[0].ParameterType.Name == "Func`2")
                .SingleOrDefault();
            method?.MakeGenericMethod(typeof(Grid)).Invoke(null, [(Grid g) => g.ToHtml(includeMetadata: true), "text/html"]);
        }
        catch
        {
            Console.WriteLine("Could not register .NET Interactive formatter.");
        }
    }

    internal static Grid Lambda(string expression, params object?[] args)
        => new(_python.Apply(expression, args.Select(o => PyObject.From(o is Grid g ? g._grid : o)).ToArray()));

    internal static Grid Dot(string name, params object?[] args)
        => Lambda($"lambda args: args[0].{name}(*args[1:])", args);

    internal static Grid Infix(string name, params object[] args)
        => Lambda($"lambda args: args[0] {name} args[1]", args);

    private static readonly Func<(Grid, bool, bool), string> toHtml
        = Memoization.Memoize<(Grid, bool, bool), string>(args =>
    {
        var (grid, includeMetadata, interactive) = args;
        var html = interactive
            ? _python!.Map(grid._grid, grid._color.ToString(), 0.8)
            : _python!.Plot(grid._grid, grid._color.ToString());

        if (!includeMetadata)
            return $"<div>{html}</div>";

        return $"""
            <div>
                <p>{grid.ToString().Replace("|", "<br />")}</p>
                {html}
                <p>{grid.Xmin}, {grid.Ymin}, {grid.Xmax}, {grid.Ymax}</p>
            </div>
        """;
    });

    public string ToHtml(bool includeMetadata = false, bool interactive = false)
        => toHtml((this, includeMetadata, interactive));
}
