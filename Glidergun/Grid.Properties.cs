namespace Glidergun;

public partial class Grid
{
    public int Width => Convert.ToInt32(_grid.GetAttr("width").As<long>());
    public int Height => Convert.ToInt32(_grid.GetAttr("height").As<long>());
    public string Dtype => _grid.GetAttr("dtype").As<string>();
    public int Epsg => Convert.ToInt32(_grid.GetAttr("crs").GetAttr("to_epsg").Call().As<long>());
    public double CellWidth => _grid.GetAttr("cell_size").As<(double X, double Y)>().X;
    public double CellHeight => _grid.GetAttr("cell_size").As<(double X, double Y)>().Y;
    public double Nodata => _grid.GetAttr("nodata").As<double>();
    public bool HasNan => _grid.GetAttr("has_nan").As<bool>();
    public string Md5 => _grid.GetAttr("md5").As<string>();
    public double Xmin => _grid.GetAttr("xmin").As<double>();
    public double Ymin => _grid.GetAttr("ymin").As<double>();
    public double Xmax => _grid.GetAttr("xmax").As<double>();
    public double Ymax => _grid.GetAttr("ymax").As<double>();
    public Extent Extent => new(Xmin, Ymin, Xmax, Ymax);
    public double Mean => _grid.GetAttr("mean").As<double>();
    public double Std => _grid.GetAttr("std").As<double>();
    public double Min => _grid.GetAttr("min").As<double>();
    public double Max => _grid.GetAttr("max").As<double>();
}
