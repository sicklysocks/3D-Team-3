using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveChild : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public Transform childLocation;
    NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        childLocation = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(target.position);

        if (childLocation == target)
        {
            nav.SetDestination(target2.position); 
        }

        if (childLocation == target2)
        {
            nav.SetDestination(target.position);
        }


    }
}
