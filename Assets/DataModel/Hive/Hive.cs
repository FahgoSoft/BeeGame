using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive 
{
    //Properties
    int Width;
    int Height;

    //Resources
    int HoneyCount=0;
    int BeeBreadCount = 0;

    //Rooms
    Rooms[,] rooms;

    public Hive(int initialHeight, int initialWidth)
    {
        Width = initialWidth;
        Height = initialHeight;
        rooms = new Rooms[Width, Height];

        for(int x = 0; x<Height; x++)
        {
            for(int y = 0; y<Width; y++)
            {
                rooms[x, y] = new Rooms(int.Parse(x.ToString() + y.ToString()), x, y);

                if(x==(x/2) && y == 0)
                {
                    rooms[x, y].Type = Rooms.RoomTypes.QueensChamber;
                }
            }
        }

    }

}
