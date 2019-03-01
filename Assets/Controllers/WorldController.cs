using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldController : MonoBehaviour
{
    static World world;
    public bool ready = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("WorldControllers");

        if (objs.Length > 1)
        {
            //destroy any duplicates
            Destroy(this.transform.parent.gameObject);
        }
        else
        {
            //should only be done once
            DontDestroyOnLoad(this.transform.parent.gameObject);
            world = new World(500, 500);
            ready = true;
        }

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            GameObject mapController = GameObject.Find("MapDraw");
            mapController.GetComponent<MapController>().drawMap();
        }
        else
        {
            GameObject hiveController = GameObject.Find("HiveController");
            hiveController.GetComponent<HiveController>().drawHive();

        }

    }

    public World World
    {
        get { return world; }
    }


}
