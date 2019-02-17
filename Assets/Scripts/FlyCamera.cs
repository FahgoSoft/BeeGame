using UnityEngine;
using System.Collections;
 
public class FlyCamera : MonoBehaviour {
 
    /*
    Writen by Windexglow 11-13-10.  Use it, edit it, steal it I don't care.  
    Converted to C# 27-02-13 - no credit wanted.
    Simple flycam I made, since I couldn't find any others made public.  
    Made simple to use (drag and drop, done) for regular keyboard layout  
    wasd : basic movement
    shift : Makes camera accelerate
    space : Moves camera on X and Z axis only.  So camera doesn't gain any height*/
     
     
    float mainSpeed = 100.0f; //regular speed
    float shiftAdd = 250.0f; //multiplied by how long shift is held.  Basically running
    float maxShift = 1000.0f; //Maximum speed when holdin gshift
    float camSens = 0.25f; //How sensitive it with mouse
    public float rotateSpeed;
    private Vector3 lastMouse;// = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)
    private float totalRun= 1.0f;
    public float maxHeight = 80;

    //private void Start()
    //{
    //////    lastMouse = transform.localEulerAngles;
    //}

    void OnMouseDown() {
    }
     
    void Update () {
        //if(Input.GetMouseButton(2)){
        //    lastMouse = Input.mousePosition - lastMouse ;
        //    lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0 );
        //    lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x , transform.eulerAngles.y + lastMouse.y, 0);
        //    transform.eulerAngles = lastMouse;
        //    lastMouse =  Input.mousePosition;
        //    // if(Input.GetMouseButtonUp(2)) break;
        //}

        //Mouse  camera angle done.  
       
        //Keyboard commands
        float f = 0.0f;
        Vector3 p = GetBaseInput();
        if (Input.GetKey (KeyCode.LeftShift)){
            totalRun += Time.deltaTime;
            p  = p * totalRun * shiftAdd;
            p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
            p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
            p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
        }
        else{
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p = p * mainSpeed;
        }
       
        p = p * Time.deltaTime;
       Vector3 newPosition = transform.position;
        Vector3 newpos = transform.position + p;
        // if (Input.GetKey(KeyCode.Space)){ //If player wants to move on X and Z axis only
        //transform.Translate(p);
        if (newpos.x >= -240 && newpos.x <= 240)
            newPosition.x = transform.position.x + p.x;
        if (newpos.z >= -240 && newpos.z <= 240)
            newPosition.z = transform.position.z + p.z;
       if (newpos.y <= maxHeight && newpos.y >= 5)
        
        {
            newPosition.y = transform.position.y + p.y;
        }
            transform.position = newPosition;

        // }
        // else{
        //     transform.Translate(p);
        // }

        Vector3 newRotation = GetNewRotation();
        transform.eulerAngles= transform.eulerAngles + (newRotation * rotateSpeed * Time.deltaTime);

    }
     
    private Vector3 GetBaseInput() { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey (KeyCode.W)){
            p_Velocity += new Vector3(0, 0 , 1);
        }
        if (Input.GetKey (KeyCode.S)){
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey (KeyCode.A)){
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey (KeyCode.D)){
            p_Velocity += new Vector3(1, 0, 0);
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0 ||Input.GetKey (KeyCode.PageUp)) 
        {
            p_Velocity += new Vector3(0, 1, 0);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetKey (KeyCode.PageDown))
        {
            p_Velocity += new Vector3(0, -1, 0);
        }
        return p_Velocity;
    }

    private Vector3 GetNewRotation()
    {
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.Q))
        {
            p_Velocity += new Vector3(0,-1,0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            p_Velocity += new Vector3(0,1,0);
        }
        return p_Velocity;
    }
}