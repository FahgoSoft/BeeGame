using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjects
{
    string ID;
    int X, Z;
    ResourceType Type;

    public enum ResourceType {Flowers, Trees, PollenBlobs}

    public MapObjects(int x, int z, ResourceType type)
    {
        this.ID = "MapObject " + x.ToString() + "_" + z.ToString();
        this.X = x;
        this.Z = z;
        this.Type = type;

    }


    
}
