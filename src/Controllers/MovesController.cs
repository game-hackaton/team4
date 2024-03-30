using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers;

[Route("api/games/{gameId}/moves")]
public class MovesController : Controller
{
    [HttpPost]
    public IActionResult Moves(Guid gameId, [FromBody] UserInputDto userInput)
    {
        var game = TestData.AGameDto(userInput.ClickedPos);

        if (Walls.WallsEnum == null)
        {
            Walls.WallsEnum = Walls.GetWalls(game);
        }

        if (userInput.ClickedPos != null)
        {
            foreach (var wall in Walls.WallsEnum)
            {
                if (wall.Pos.Equals(userInput.ClickedPos))
                {
                    return NoContent();
                }
            }
            
            if (Math.Abs(userInput.ClickedPos.X - Player.CurrentPlayerPos.X) +
                Math.Abs(userInput.ClickedPos.Y - Player.CurrentPlayerPos.Y) == 1)
            {
                Player.CurrentPlayerPos = userInput.ClickedPos;
                game.Cells.First(c => c.Type == "player").Pos = Player.CurrentPlayerPos;
                return Ok(game);
            }
        }

        return NoContent();
    }
}