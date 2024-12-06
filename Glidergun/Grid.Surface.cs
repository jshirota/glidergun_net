namespace Glidergun;

public partial class Grid
{
    public Grid Aspect()
        => Dot("aspect", this);

    public Grid Slope()
        => Dot("slope", this);

    public Grid Hillshade(double azimuth = 315, double altitude = 45)
        => Dot("hillshade", this, azimuth, altitude);
}
