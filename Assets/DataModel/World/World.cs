using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World
{
    Hive hive;
    MapObjects[] mapObjects;
    int MapWidth;
    int MapHeight;

    public World(int mapWidth, int mapHeight, int hiveWidth=3, int hiveHeight=3)
    {
        this.MapHeight = mapHeight;
        this.MapWidth = mapWidth;

        hive = new Hive(hiveHeight, hiveWidth);

        int noOfObjects = 50;

        this.mapObjects = new MapObjects[noOfObjects];

        for (int i = 0; i < noOfObjects; i++)
        {
            float x = Random.Range(-((MapWidth / 2) - 10), (MapWidth / 2) - 10);
            float z = Random.Range(-((MapHeight / 2) - 10), (MapHeight / 2) - 10);
            int type = System.Convert.ToInt32(Mathf.Floor(Random.Range(0, 3)));
            mapObjects[i] = new MapObjects(x, z, (MapObjects.ResourceType)type);
        }

    }

    public MapObjects[] MapObjects
    {
        get { return mapObjects; }
    }

    public Hive Hive
    {
        get { return hive; }
    }

}
