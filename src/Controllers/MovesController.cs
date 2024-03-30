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
    public IActionResult Moves(Guid gameId, [FromBody]UserInputDto userInput)
    {
        var currentPlayerPos = userInput.ClickedPos ?? new VectorDto { X = 1, Y = 1 };
        if (Player.CurrentPlayerPos == null)
        {
            Player.CurrentPlayerPos = currentPlayerPos;
        }
        var game = TestData.AGameDto(currentPlayerPos);
        
        if (userInput.ClickedPos != null)
        {
            if (Math.Abs(userInput.ClickedPos.X - Player.CurrentPlayerPos.X) <= 1
                && Math.Abs(userInput.ClickedPos.Y - Player.CurrentPlayerPos.Y) <= 1)
            {
                Console.WriteLine(userInput.ClickedPos.X + " " + Player.CurrentPlayerPos.X);

                Player.CurrentPlayerPos = userInput.ClickedPos;
                game.Cells.First(c => c.Type == "player").Pos = Player.CurrentPlayerPos;
                return Ok(game);

            }
        }

        return NoContent();
    }
}