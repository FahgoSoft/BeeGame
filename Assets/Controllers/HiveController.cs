using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HiveController : MonoBehaviour
{
    public Material HiveWall;
    public Texture HiveBackground;

    // Start is called before the first frame update
    void Start()
    {
        GameObject worldController = GameObject.Find("WorldController");

        if (worldController == null)
        {
            Debug.Log("Cant find world controller");
        }
        else
        {
            Debug.Log("World controller found");
            drawHive();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void drawHive()
    {
        GameObject worldController = GameObject.Find("WorldController");
        Hive hive = worldController.GetComponent<WorldController>().World.Hive;

        GameObject roomContainer = new GameObject("Rooms");
        roomContainer.transform.SetPositionAndRotation(new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));

        float startX = -10; //-(hive.Width / 2);

        List<NavMeshSurface> surfaces = new List<NavMeshSurface>();

        for (int x = 0; x < hive.Width; x++)
        {
            float startY = 10; //-(hive.Height / 2);

            for (int y = 0; y < hive.Height; y++)
            {
                Vector3 newPosition = new Vector3(startX, 0f, startY);
                //GameObject newRoom = new GameObject(hive.Rooms[x, y].ID);
                GameObject newRoom = GameObject.CreatePrimitive(PrimitiveType.Plane);
                newRoom.name = hive.Rooms[x, y].ID;
                newRoom.transform.SetParent(roomContainer.transform);
                newRoom.transform.SetPositionAndRotation(newPosition, new Quaternion(0f, 0f, 0f, 0f));
                newRoom.GetComponent<MeshRenderer>().material.mainTexture = HiveBackground;
                newRoom.AddComponent<NavMeshSurface>();
                surfaces.Add(newRoom.GetComponent<NavMeshSurface>());

                if (x == 0)
                {
                    GameObject lWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    lWall.name = hive.Rooms[x, y].ID + "_LeftWall";
                    lWall.transform.SetParent(newRoom.transform);
                    lWall.transform.localScale = new Vector3(1, 2, 10);
                    lWall.transform.localPosition = new Vector3(-5, 1, 0);
                    lWall.GetComponent<MeshRenderer>().material = HiveWall;
                }
                if (x < hive.Width - 1)
                {
                    GameObject rDoorTop = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    rDoorTop.name = hive.Rooms[x, y].ID + "_RightDoorTop";
                    rDoorTop.transform.SetParent(newRoom.transform);
                    rDoorTop.transform.localScale = new Vector3(1, 2, 4);
                    rDoorTop.transform.localPosition = new Vector3(5, 1, 3);
                    rDoorTop.GetComponent<MeshRenderer>().material = HiveWall;
                    GameObject rDoorBottom = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    rDoorBottom.name = hive.Rooms[x, y].ID + "_RightDoorBottom";
                    rDoorBottom.transform.SetParent(newRoom.transform);
                    rDoorBottom.transform.localScale = new Vector3(1, 2, 4);
                    rDoorBottom.transform.localPosition = new Vector3(5, 1, -3);
                    rDoorBottom.GetComponent<MeshRenderer>().material = HiveWall;
                }
                if (x == hive.Width-1)
                {
                    GameObject rWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    rWall.name = hive.Rooms[x, y].ID + "_RightWall";
                    rWall.transform.SetParent(newRoom.transform);
                    rWall.transform.localScale = new Vector3(1, 2, 10);
                    rWall.transform.localPosition = new Vector3(5, 1, 0);
                    rWall.GetComponent<MeshRenderer>().material = HiveWall;
                }
                if (y == 0)
                {
                    GameObject tWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    tWall.name = hive.Rooms[x, y].ID + "_TopWall";
                    tWall.transform.SetParent(newRoom.transform);
                    tWall.transform.localScale = new Vector3(10, 2, 1);
                    tWall.transform.localPosition = new Vector3(0, 1, 5);
                    tWall.GetComponent<MeshRenderer>().material = HiveWall;
                }
                if (y < hive.Height - 1)
                {
                    GameObject bDoorLeft = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    bDoorLeft.name = hive.Rooms[x, y].ID + "_BottomDoorLeft";
                    bDoorLeft.transform.SetParent(newRoom.transform);
                    bDoorLeft.transform.localScale = new Vector3(4, 2, 1);
                    bDoorLeft.transform.localPosition = new Vector3(-3, 1, -5);
                    bDoorLeft.GetComponent<MeshRenderer>().material = HiveWall;
                    GameObject bDoorRight = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    bDoorRight.name = hive.Rooms[x, y].ID + "_BottomDoorRight";
                    bDoorRight.transform.SetParent(newRoom.transform);
                    bDoorRight.transform.localScale = new Vector3(4, 2, 1);
                    bDoorRight.transform.localPosition = new Vector3(3, 1, -5);
                    bDoorRight.GetComponent<MeshRenderer>().material = HiveWall;
                }
                if (y == hive.Height-1)
                {
                    GameObject bWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    bWall.name = hive.Rooms[x, y].ID + "_BottomWall";
                    bWall.transform.SetParent(newRoom.transform);
                    bWall.transform.localScale = new Vector3(10, 2, 1);
                    bWall.transform.localPosition = new Vector3(0, 1, -5);
                    bWall.GetComponent<MeshRenderer>().material = HiveWall;
                }


                startY -= 10;
            }
            startX += 10;
        }
        
        foreach(NavMeshSurface surface in surfaces)
        {
            surface.BuildNavMesh();
        }
    }
}
