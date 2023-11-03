using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public GameObject Destination;
    NavMeshAgent Agent;
    
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Agent.SetDestination(Destination.transform.position);
    }
}
