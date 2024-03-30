﻿using System;
using thegame.Models;

namespace thegame.Services;

public class TestData
{
    public static GameDto AGameDto(VectorDto movingObjectPosition)
    {
        var width = 10;
        var height = 8;
        var testCells = new[]
        {
            new CellDto("1", new VectorDto {X = 2, Y = 4}, "wall", "", 0),
            new CellDto("2", new VectorDto {X = 5, Y = 4}, "wall", "", 0),
            new CellDto("3", new VectorDto {X = 3, Y = 1}, "box", "", 20),
            new CellDto("4", new VectorDto {X = 1, Y = 0}, "box", "", 20),
            new CellDto("5", movingObjectPosition, "player", "☺", 10),
        };
        return new GameDto(testCells, true, true, width, height, Guid.Empty, movingObjectPosition.X == 0, movingObjectPosition.Y);
    }
}