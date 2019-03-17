using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    private Transform target;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
            {
                navMeshAgent.destination = hit.point;
                navMeshAgent.isStopped = false;
            }
        }

    }
}
