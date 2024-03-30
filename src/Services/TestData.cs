using System;
using System.Collections.Generic;
using System.Linq;
using thegame.Models;

namespace thegame.Services;

public class TestData
{
    public static GameDto AGameDto(VectorDto movingObjectPosition)
    {
        var width = 10;
        var height = 8;
        var testCells = new CellDto[8 * 10];
        
        
        //target id: 3
        testCells[0] = new CellDto("0", new VectorDto { X = 7, Y = 5 }, "wall", "", 0);
        testCells[1] = new CellDto("1", new VectorDto { X = 6, Y = 6 }, "wall", "", 0);
        
        //random
        testCells[2] = new CellDto("2", new VectorDto { X = 3, Y = 6 }, "wall", "", 0);
        testCells[3] = new CellDto("3", new VectorDto { X = 6, Y = 6 }, "wall", "", 0);
        
        
        testCells[4] = new CellDto("4", new VectorDto { X = 3, Y = 3 }, "wall", "", 0);
        
        //target id:2
        testCells[5] = new CellDto("5", new VectorDto { X = 2, Y = 2 }, "wall", "", 0);
        testCells[6] = new CellDto("6", new VectorDto { X = 3, Y = 3 }, "wall", "", 0);
        testCells[7] = new CellDto("7", new VectorDto { X = 2, Y = 4 }, "box", "", 0);
        testCells[8] = new CellDto("8", new VectorDto { X = 4, Y = 5 }, "box", "", 0);
        testCells[9] = new CellDto("9", new VectorDto { X = 3, Y = 1 }, "target", "", 20);
        testCells[10] = new CellDto("10", new VectorDto { X = 7, Y = 6 }, "target", "", 20);
        testCells[11] = new CellDto("11", movingObjectPosition, "player", "", 10);
        
        int index = testCells.Count(s => s != null);
        AddWallX(10, 0);
        AddWallY(7, 0);

        AddWallX(10, 7);
        AddWallY(7, 9);

        testCells = testCells.Where(c => c != null).ToArray();
        return new GameDto(testCells, true, true, width, height, Guid.Empty, movingObjectPosition.X == 0,
            movingObjectPosition.Y);

        void AddWallX(int j, int y)
        {
            for (int i = 0; i < j; i++)
            {
                testCells[index] = new CellDto((index).ToString(), new VectorDto { X = i, Y = y }, "wall", "", 20);
                index++;
            }
        }

        void AddWallY(int j, int x)
        {
            for (int i = 0; i < j; i++)
            {
                testCells[index] = new CellDto((index).ToString(), new VectorDto { X = x, Y = i }, "wall", "", 20);
                index++;
            }
        }
    }
}