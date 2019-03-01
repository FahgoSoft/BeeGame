using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjects
{
    string id;
    float x, z;
    ResourceType type;

    public enum ResourceType {Flowers, Trees, PollenBlobs}

    public MapObjects(float x, float z, ResourceType type)
    {
        this.id = "MapObject " + x.ToString() + "_" + z.ToString();
        this.x = x;
        this.z = z;
        this.type = type;

    }

    public string ID
    {
        get { return this.ID; }
    }

    public float X
    {
        get { return this.x; }
    }

    public float Z
    {
        get { return this.z; }
    }
    public ResourceType Type
    {
        get { return this.type; }
    }


}
