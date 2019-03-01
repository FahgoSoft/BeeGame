using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject[] prefabs;
    //public GameObject worldController;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void drawMap()
    {
        GameObject worldController = GameObject.Find("WorldController");
        World world = worldController.GetComponent<WorldController>().World;

        GameObject worldObjects = new GameObject("WorldObjects");
        worldObjects.transform.SetPositionAndRotation(new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));

        foreach (MapObjects mObject in world.MapObjects)
        {
            Vector3 objectPosition = new Vector3(mObject.X, 0f, mObject.Z);
            switch (mObject.Type)
            {
                case MapObjects.ResourceType.Flowers:
                    foreach (GameObject gameObject in prefabs)
                    {
                        objectPosition.y = 5f;
                        if (gameObject.name == "Flower")
                        {
                            Instantiate(gameObject, objectPosition, new Quaternion(0f, 0f, 0f, 0f), worldObjects.transform);
                        }
                    }
                    break;

                case MapObjects.ResourceType.PollenBlobs:
                    foreach (GameObject gameObject in prefabs)
                    {
                        objectPosition.y = 10f;
                        if (gameObject.name == "Pollen")
                        {
                            Instantiate(gameObject, objectPosition, new Quaternion(0f, 0f, 0f, 0f), worldObjects.transform);
                        }
                    }
                    break;

                case MapObjects.ResourceType.Trees:
                    foreach (GameObject gameObject in prefabs)
                    {
                        objectPosition.y = 10f;
                        if (gameObject.name == "Tree")
                        {
                            Instantiate(gameObject, objectPosition, new Quaternion(0f, 0f, 0f, 0f), worldObjects.transform);
                        }
                    }
                    break;
            }

        }

    }
}
