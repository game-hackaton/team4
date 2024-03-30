using System;
using System.Collections.Generic;
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
            //     // new CellDto("100", new VectorDto {X = 0, Y = 0}, "wall", "", 0),
            //     // new CellDto("101", new VectorDto {X = 0, Y = 1}, "wall", "", 0),
            //     // new CellDto("110", new VectorDto {X = 0, Y = 2}, "wall", "", 0),
            //     // new CellDto("102", new VectorDto {X = 0, Y = 3}, "wall", "", 0),
            //     // new CellDto("103", new VectorDto {X = 0, Y = 4}, "wall", "", 0),
            //     // new CellDto("104", new VectorDto {X = 0, Y = 5}, "wall", "", 0),
            //     // new CellDto("105", new VectorDto {X = 1, Y = 0}, "wall", "", 0),
            //     // new CellDto("106", new VectorDto {X = 2, Y = 0}, "wall", "", 0),
            //     // new CellDto("107", new VectorDto {X = 3, Y = 0}, "wall", "", 0),
            //     // new CellDto("108", new VectorDto {X = 4, Y = 0}, "wall", "", 0),
            //     // new CellDto("109", new VectorDto {X = 5, Y = 0}, "wall", "", 0),
            new CellDto("100", new VectorDto { X = 2, Y = 4 }, "wall", "", 0),
            new CellDto("200", new VectorDto { X = 5, Y = 4 }, "wall", "", 0),
            new CellDto("300", new VectorDto { X = 3, Y = 1 }, "box", "", 20),
            new CellDto("400", new VectorDto { X = 6, Y = 1 }, "box", "", 20),
            new CellDto("500", movingObjectPosition, "player", "", 10), //☺️
        };
        // testCells[0] = new CellDto("100", new VectorDto { X = 2, Y = 4 }, "color1", "", 0);
        // testCells[1] = new CellDto("200", new VectorDto { X = 5, Y = 4 }, "color1", "", 0);
        // testCells[2] = new CellDto("300", new VectorDto { X = 3, Y = 1 }, "color2", "", 20);
        // testCells[3] = new CellDto("400", new VectorDto { X = 1, Y = 1 }, "color2", "", 20);
        // testCells[4] = new CellDto("500", movingObjectPosition, "player", "", 10);
        // int index = 5;
        // AddWallX(height, 0);
        // AddWallX(height, width);
        // AddWallY(width, 0);
        // AddWallY(width, height);
        //
        return new GameDto(testCells, true, true, width, height, Guid.Empty, movingObjectPosition.X == 0,
            movingObjectPosition.Y);
        //
        // void AddWallX(int j, int y)
        // {
        //     for (int i = 0; i < j; i++)
        //     {
        //         testCells[index] = new CellDto((index).ToString(), new VectorDto { X = i, Y = y }, "color1", "", 0);
        //         index++;
        //     }
        // }
        //
        // void AddWallY(int j, int x)
        // {
        //     for (int i = 0; i < j; i++)
        //     {
        //         testCells[index] = new CellDto((index).ToString(), new VectorDto { X = x, Y = i }, "color1", "", 0);
        //         index++;
        //     }
        // }
    }
}