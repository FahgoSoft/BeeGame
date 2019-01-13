using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OutSideBeeMovement : MonoBehaviour
{
    public bool inside;
    private Animator anim;
    private NavMeshAgent navMeshAgent;
    private bool walking;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
        navMeshAgent = GetComponent<NavMeshAgent> ();
        count = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (inside)
        {
            //transform.Rotate(new Vector3(0, 0, 90));
        }
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0)) 
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
            {
                // if (hit.collider.CompareTag("Enemy"))
                // {
                //     targetedEnemy = hit.transform;
                //     enemyClicked = true;
                // }

                // else
                // {
                    walking = true;
                    // enemyClicked = false;
                    navMeshAgent.destination = hit.point;
                    navMeshAgent.isStopped = false;
                // }
            }
        }
    }

    // Destroy everything that enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Pollen"))
        {
            other.gameObject.SetActive (false);
            count+=1;
            // SetCountText();
        }
    }
}
