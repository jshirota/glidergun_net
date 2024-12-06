namespace Glidergun;

public partial class Grid
{
   public static Grid operator +(Grid grid)
      => Lambda("lambda args: +args[0]", grid);

   public static Grid operator -(Grid grid)
      => Lambda("lambda args: -args[0]", grid);

   public static Grid operator +(Grid grid1, Grid grid2)
      => Infix("+", grid1, grid2);

   public static Grid operator +(Grid grid, double n)
      => Infix("+", grid, n);

   public static Grid operator +(Grid grid, int n)
      => Infix("+", grid, n);

   public static Grid operator +(double n, Grid grid)
      => Infix("+", n, grid);

   public static Grid operator +(int n, Grid grid)
      => Infix("+", n, grid);

   public static Grid operator -(Grid grid1, Grid grid2)
      => Infix("-", grid1, grid2);

   public static Grid operator -(Grid grid, double n)
      => Infix("-", grid, n);

   public static Grid operator -(Grid grid, int n)
      => Infix("-", grid, n);

   public static Grid operator -(double n, Grid grid)
      => Infix("-", n, grid);

   public static Grid operator -(int n, Grid grid)
      => Infix("-", n, grid);

   public static Grid operator *(Grid grid1, Grid grid2)
      => Infix("*", grid1, grid2);

   public static Grid operator *(Grid grid, double n)
      => Infix("*", grid, n);

   public static Grid operator *(Grid grid, int n)
      => Infix("*", grid, n);

   public static Grid operator *(double n, Grid grid)
      => Infix("*", n, grid);

   public static Grid operator *(int n, Grid grid)
      => Infix("*", n, grid);

   public static Grid operator /(Grid grid1, Grid grid2)
      => Infix("/", grid1, grid2);

   public static Grid operator /(Grid grid, double n)
      => Infix("/", grid, n);

   public static Grid operator /(Grid grid, int n)
      => Infix("/", grid, n);

   public static Grid operator /(double n, Grid grid)
      => Infix("/", n, grid);

   public static Grid operator /(int n, Grid grid)
      => Infix("/", n, grid);

   public static Grid operator ==(Grid grid1, Grid grid2)
      => Infix("==", grid1, grid2);

   public static Grid operator ==(Grid grid, double n)
      => Infix("==", grid, n);

   public static Grid operator ==(Grid grid, int n)
      => Infix("==", grid, n);

   public static Grid operator ==(double n, Grid grid)
      => Infix("==", n, grid);

   public static Grid operator ==(int n, Grid grid)
      => Infix("==", n, grid);

   public static Grid operator !=(Grid grid1, Grid grid2)
      => Infix("!=", grid1, grid2);

   public static Grid operator !=(Grid grid, double n)
      => Infix("!=", grid, n);

   public static Grid operator !=(Grid grid, int n)
      => Infix("!=", grid, n);

   public static Grid operator !=(double n, Grid grid)
      => Infix("!=", n, grid);

   public static Grid operator !=(int n, Grid grid)
      => Infix("!=", n, grid);

   public static Grid operator >(Grid grid1, Grid grid2)
      => Infix(">", grid1, grid2);

   public static Grid operator >(Grid grid, double n)
      => Infix(">", grid, n);

   public static Grid operator >(Grid grid, int n)
      => Infix(">", grid, n);

   public static Grid operator >(double n, Grid grid)
      => Infix(">", n, grid);

   public static Grid operator >(int n, Grid grid)
      => Infix(">", n, grid);

   public static Grid operator >=(Grid grid1, Grid grid2)
      => Infix(">=", grid1, grid2);

   public static Grid operator >=(Grid grid, double n)
      => Infix(">=", grid, n);

   public static Grid operator >=(Grid grid, int n)
      => Infix(">=", grid, n);

   public static Grid operator >=(double n, Grid grid)
      => Infix(">=", n, grid);

   public static Grid operator >=(int n, Grid grid)
      => Infix(">=", n, grid);

   public static Grid operator <(Grid grid1, Grid grid2)
      => Infix("<", grid1, grid2);

   public static Grid operator <(Grid grid, double n)
      => Infix("<", grid, n);

   public static Grid operator <(Grid grid, int n)
      => Infix("<", grid, n);

   public static Grid operator <(double n, Grid grid)
      => Infix("<", n, grid);

   public static Grid operator <(int n, Grid grid)
      => Infix("<", n, grid);

   public static Grid operator <=(Grid grid1, Grid grid2)
      => Infix("<=", grid1, grid2);

   public static Grid operator <=(Grid grid, double n)
      => Infix("<=", grid, n);

   public static Grid operator <=(Grid grid, int n)
      => Infix("<=", grid, n);

   public static Grid operator <=(double n, Grid grid)
      => Infix("<=", n, grid);

   public static Grid operator <=(int n, Grid grid)
      => Infix("<=", n, grid);

   public static Grid operator &(Grid grid1, Grid grid2)
      => Infix("&", grid1, grid2);

   public static Grid operator |(Grid grid1, Grid grid2)
      => Infix("|", grid1, grid2);
}
