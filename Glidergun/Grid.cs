using CSnakes.Runtime.Python;

namespace Glidergun;

public partial class Grid
{
    private readonly PyObject _grid;
    private readonly ColorMap _color;

    private Grid(PyObject grid, ColorMap color = ColorMap.gray)
    {
        _grid = grid;
        _color = color;
    }

    public Grid(string file)
    : this(_python.FromFile(file))
    {
    }

    public override bool Equals(object? obj)
        => base.Equals(obj);

    public override int GetHashCode()
        => base.GetHashCode();

    public override string ToString()
        => _grid.GetAttr("__repr__").Call().As<string>();

    # region Methods

    public static Grid FromBytes(byte[] data, string ext = ".tif")
        => new(_python.FromBytes(data, ext));

    public static byte[] ToBytes(Grid grid, string ext = ".tif")
        => _python.ToBytes(grid._grid, ext);

    public static Grid Con(Grid predicate, Grid trueValue, Grid falseValue)
        => Dot("con", predicate, trueValue, falseValue);

    public static Grid Con(Grid predicate, Grid trueValue, double falseValue)
        => Dot("con", predicate, trueValue, falseValue);

    public static Grid Con(Grid predicate, Grid trueValue, int falseValue)
        => Dot("con", predicate, trueValue, falseValue);

    public static Grid Con(Grid predicate, double trueValue, Grid falseValue)
        => Dot("con", predicate, trueValue, falseValue);

    public static Grid Con(Grid predicate, double trueValue, double falseValue)
        => Dot("con", predicate, trueValue, falseValue);

    public static Grid Con(Grid predicate, double trueValue, int falseValue)
        => Dot("con", predicate, trueValue, falseValue);

    public static Grid Con(Grid predicate, int trueValue, Grid falseValue)
        => Dot("con", predicate, trueValue, falseValue);

    public static Grid Con(Grid predicate, int trueValue, double falseValue)
        => Dot("con", predicate, trueValue, falseValue);

    public static Grid Con(Grid predicate, int trueValue, int falseValue)
        => Dot("con", predicate, trueValue, falseValue);

    public Grid IsNan()
        => Dot("is_nan", this);

    public Grid SetNan(Grid value)
        => Dot("set_nan", this, value);

    public Grid SetNan(double value)
        => Dot("set_nan", this, value);

    public Grid SetNan(int value)
        => Dot("set_nan", this, value);

    public Grid SetNan(Grid value, Grid fallback)
        => Dot("set_nan", this, value, fallback);

    public Grid SetNan(double value, Grid fallback)
        => Dot("set_nan", this, value, fallback);

    public Grid SetNan(int value, Grid fallback)
        => Dot("set_nan", this, value, fallback);

    public Grid SetNan(Grid value, double fallback)
        => Dot("set_nan", this, value, fallback);

    public Grid SetNan(double value, double fallback)
        => Dot("set_nan", this, value, fallback);

    public Grid SetNan(int value, double fallback)
        => Dot("set_nan", this, value, fallback);

    public Grid SetNan(Grid value, int fallback)
        => Dot("set_nan", this, value, fallback);

    public Grid SetNan(double value, int fallback)
        => Dot("set_nan", this, value, fallback);

    public Grid SetNan(int value, int fallback)
        => Dot("set_nan", this, value, fallback);

    public static Grid Mosaic(params Grid[] grids)
        => Lambda($"lambda args: mosaic(*args)", grids);

    public Grid Clip(Extent extent)
        => Dot("clip", this, extent.Xmin, extent.Xmax, extent.Ymin, extent.Ymax);

    public Grid Project(int epsg)
        => Dot("project", this, epsg);

    public Grid Randomize()
        => Dot("randomize", this);

    public Grid Resample(double cellSize, ResamplingMethod resampling = ResamplingMethod.nearest)
        => Dot("resample", this, cellSize, resampling.ToString());

    public Grid Resample(double cellWidth, double cellheight, ResamplingMethod resampling = ResamplingMethod.nearest)
        => Dot("resample", this, (cellWidth, cellheight), resampling.ToString());

    public Grid WithColor(ColorMap color)
        => new(_grid, color);

    public void Save(string path)
        => _python.Save(_grid, path);

    #endregion
}
