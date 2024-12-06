import base64
from glidergun import Grid, grid, mosaic  # noqa: F401
from glidergun._ipython import _thumbnail
from rasterio import MemoryFile
from rasterio.drivers import driver_from_extension


def from_file(file: str) -> Grid:
    return grid(file)


def from_bytes(data: bytes, ext: str = ".tif") -> Grid:
    with MemoryFile(data, ext=ext) as file:
        return grid(file)


def to_bytes(grid: Grid, ext: str = ".tif") -> bytes:
    with MemoryFile() as file:
        grid.save(file, driver=driver_from_extension("_" + ext))
        return file.read()


def apply(expression: str, *args) -> Grid:
    return eval(expression)(args)


def map(grid: Grid, color: str, opacity: float) -> str:
    html = grid.map(color, opacity).get_root().render()
    return f"""<iframe src='data:text/html;base64,{base64.b64encode(html.encode("utf8")).decode()}'
        width=800 height=600
        style='border:none !important;' 'allowfullscreen' 'webkitallowfullscreen' 'mozallowfullscreen'></iframe>
    """


def plot(grid: Grid, color: str) -> str:
    data = _thumbnail(grid, color)
    return f"<img src='{data}' />"


def save(grid: Grid, path: str) -> None:
    grid.save(path)
