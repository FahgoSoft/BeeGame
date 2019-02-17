using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideCamera : MonoBehaviour
{
    float camSpeed = 100.0f; //regular speed
    private float totalRun = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Keyboard commands
        Vector3 p = GetBaseInput();
        totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
        p = p * camSpeed;

        p = p * Time.deltaTime;
        Vector3 newPosition = transform.position;
        Vector3 posCheck = transform.position + p;
        if (posCheck.x <= 20 && posCheck.x >= -20)
        {
            newPosition.x = transform.position.x + p.x;
        }
        if (posCheck.z <= 20 && posCheck.z >= -20)
        {
            newPosition.z = transform.position.z + p.z;
        }
        if (posCheck.y <= 40 && posCheck.y >= 5)
        {
            newPosition.y = transform.position.y + p.y;
        }
        transform.position = newPosition;
    }

    private Vector3 GetBaseInput()
    { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            p_Velocity += new Vector3(0, 1, 0);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            p_Velocity += new Vector3(0, -1, 0);
        }
        return p_Velocity;
    }
}
