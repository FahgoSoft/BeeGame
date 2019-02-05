using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms
{
    //Properties
    int ID;
    string Label;
    int X, Y;
    RoomTypes Type;

    //Enums
    enum RoomTypes {QueensChamber,Hatchery,Stockpile,Empty};

    //Todo: Connections/blockages

    public Rooms(int id, int x, int y)
    {
        this.ID = id;
        this.X = x;
        this.Y = y;
        this.Type = RoomTypes.Empty;
    }
}
