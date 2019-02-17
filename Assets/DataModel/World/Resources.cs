using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjects
{
    int ID;
    int X, Z;
    ResourceType Type;

    public enum ResourceType {Flowers, Trees, PollenBlobs}

    public MapObjects( int id, int x, int z, ResourceType type)
    {
        this.ID = id;
        this.X = x;
        this.Z = z;
        this.Type = type;

    }


    
}
