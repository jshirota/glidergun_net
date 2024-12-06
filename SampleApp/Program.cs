
using Glidergun;

var dem = new Grid(args[0]);
var hillshade = dem.Hillshade();
hillshade.Save(args[1]);
