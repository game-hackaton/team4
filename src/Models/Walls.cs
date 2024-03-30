using System.Collections.Generic;
using System.Linq;

namespace thegame.Models;

public static class Walls
{
    public static IEnumerable<CellDto> WallsEnum;
    
    public static IEnumerable<CellDto> GetWalls(GameDto game)
    {
        return game.Cells.Where(c => c.Type == "wall");
    }
}