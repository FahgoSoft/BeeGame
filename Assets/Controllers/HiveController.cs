using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveController : MonoBehaviour
{
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

        float startX = -(hive.Width / 2);
        float startY = -(hive.Height / 2);

        for (int x = 0; x < hive.Width; x++)
        {
            for (int y = 0; y < hive.Height; y++)
            {
                Vector3 newPosition = new Vector3(startX, 0f, startY);
                GameObject newRoom = new GameObject(hive.Rooms[x, y].ID);
                newRoom.transform.SetParent(roomContainer.transform);
                newRoom.transform.SetPositionAndRotation(newPosition, new Quaternion(0f, 0f, 0f, 0f));


            }

        }

    }
}
