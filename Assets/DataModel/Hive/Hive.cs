using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive 
{
    //Properties
    int width;
    int height;

    //Resources
    int HoneyCount=0;
    int BeeBreadCount = 0;

    //Rooms
    Room[,] rooms;

    public Hive(int initialHeight, int initialWidth)
    {
        width = initialWidth;
        height = initialHeight;
        rooms = new Room[width, height];

        for(int x = 0; x<height; x++)
        {
            for(int y = 0; y<width; y++)
            {
                rooms[x, y] = new Room(x, y);

                if(x==(x/2) && y == 0)
                {
                    rooms[x, y].Type = Room.RoomTypes.QueensChamber;
                }
            }
        }

    }

    public Room[,] Rooms
    {
        get { return rooms; }
    }

    public int Width
    {
        get { return width; }
    }

    public int Height
    {
        get { return height; }
    }

}
