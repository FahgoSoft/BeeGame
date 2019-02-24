using System;
using System.Collections;
using System.Collections.Generic;

public class World
{
    public Hive hive;
    MapObjects[,] MapTiles;
    int MapWidth;
    int MapHeight;

    public World(int mapWidth, int mapHeight, int hiveWidth=3, int hiveHeight=3)
    {
        MapTiles = new MapObjects[mapWidth, mapHeight];
        this.MapHeight = mapHeight;
        this.MapWidth = mapWidth;

        hive = new Hive(hiveHeight, hiveWidth);

    }

    void generateTiles()
    {
        Random rnd = new Random();
        for (int x = 0; x < MapWidth; x++)
        {
            for (int z = 0; z < MapHeight; z++)
            {
                int type = rnd.Next(0, 3);
                
                MapTiles[x, z] = new MapObjects(x, z, (MapObjects.ResourceType)type);
            }
        }
    }
}
