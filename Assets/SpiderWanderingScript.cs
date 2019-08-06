using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SpiderWanderingScript : MonoBehaviour
{
    public bool inside;
    private Animator anim;
    private NavMeshAgent navMeshAgent;
    private bool walking;
    private int count;
    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private float timer;

    public Text status;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (!navMeshAgent.hasPath)
        {
            timer += Time.deltaTime;
            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                navMeshAgent.SetDestination(newPos);
                timer = 0;
            }
        }
        status.text = navMeshAgent.hasPath.ToString();
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
