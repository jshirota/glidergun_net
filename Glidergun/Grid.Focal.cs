namespace Glidergun;

public partial class Grid
{
    public Grid FocalCount(double value, int buffer = 1, bool circle = false)
        => Dot("focal_count", this, value, buffer, circle);

    public Grid FocalMax(int buffer = 1, bool circle = false, bool ignore_nan = true)
        => Dot("focal_max", this, buffer, circle, ignore_nan);

    public Grid FocalMean(int buffer = 1, bool circle = false, bool ignore_nan = true)
        => Dot("focal_mean", this, buffer, circle, ignore_nan);

    public Grid FocalMedian(int buffer = 1, bool circle = false, bool ignore_nan = true)
        => Dot("focal_median", this, buffer, circle, ignore_nan);

    public Grid FocalMin(int buffer = 1, bool circle = false, bool ignore_nan = true)
        => Dot("focal_min", this, buffer, circle, ignore_nan);

    public Grid FocalMode(int buffer = 1, bool circle = false, bool ignore_nan = true)
        => Dot("focal_mode", this, buffer, circle, ignore_nan);

    public Grid FocalStd(int buffer = 1, bool circle = false, bool ignore_nan = true)
        => Dot("focal_std", this, buffer, circle, ignore_nan);

    public Grid FocalSum(int buffer = 1, bool circle = false, bool ignore_nan = true)
        => Dot("focal_sum", this, buffer, circle, ignore_nan);
}
