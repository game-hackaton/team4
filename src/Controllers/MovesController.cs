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
                if (game.Cells.First(c => c.Pos.Equals(userInput.ClickedPos)).Type == "box")
                {
                    var step = new VectorDto
                    {
                        X = userInput.ClickedPos.X - Player.CurrentPlayerPos.X,
                        Y = userInput.ClickedPos.Y - Player.CurrentPlayerPos.Y
                    };
                    
                    var boxPos = new VectorDto
                    {
                        X = Player.CurrentPlayerPos.X + step.X,
                        Y = Player.CurrentPlayerPos.Y + step.Y
                    };

                    var nextBoxPos = new VectorDto
                    {
                        X = userInput.ClickedPos.X + step.X,
                        Y = userInput.ClickedPos.Y + step.Y
                    };

                    var nextBoxCell = game.Cells.FirstOrDefault(c => c.Pos.Equals(nextBoxPos), null);
                    if (nextBoxCell != null && nextBoxCell.Type == "wall")
                    {
                        return NoContent();
                    }

                    var isTarget = game.Cells.FirstOrDefault(c => c.Pos.Equals(nextBoxPos), null);
                    if (isTarget != null && isTarget.Type == "target")
                        game.Cells.First(c => c.Pos.Equals(nextBoxPos)).Type = "boxOnTarget";
                    
                    Boxes.BoxesEnum[0] = nextBoxPos;
                    game.Cells.First(c => c.Pos.Equals(boxPos)).Pos = nextBoxPos;
                }
                
                Player.CurrentPlayerPos = userInput.ClickedPos;
                game.Cells.First(c => c.Type == "player").Pos = Player.CurrentPlayerPos;
                return Ok(game);
            }
        }

        return NoContent();
    }
}