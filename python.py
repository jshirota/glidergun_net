from glidergun import grid, Grid


def get_grid(path: str) -> Grid:
    return grid(path)


def apply(expression: str, *args) -> Grid:
    return eval(expression)(args)


def to_string(grid: Grid) -> str:
    return str(grid)


def save(grid: Grid, path: str) -> None:
    grid.save(path)
