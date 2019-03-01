using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    //Properties
    string id;
    string Label;
    int X, Y;
    private RoomTypes type;

    //Enums
    public enum RoomTypes {QueensChamber,Hatchery,Stockpile,Empty};

    //Todo: Connections/blockages

    public Room(int x, int y)
    {
        this.id = "Room-"+x.ToString()+"_"+y.ToString();
        this.X = x;
        this.Y = y;
        this.type = RoomTypes.Empty;
    }

    public RoomTypes Type
    {
        get
        {
            return type;
        }
        set
        {
            this.type = value;
        }
    }

    public string ID
    {
        get { return id; }
    }
}
