using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField]
    GameObject[] targets = new GameObject[1];

    private int currentTarget = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Soldier")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (currentTarget == 1)
        {
            currentTarget = 0;
            GoTarget();
        }
        else if (currentTarget == 0)
         {
           currentTarget = 1;
           GoTarget();
         }
        
    }

    void Start()
    {

        targets[0] = GameObject.FindGameObjectWithTag("home1");
        

        agent = GetComponent<NavMeshAgent>();
        GoTarget();
    }

    void GoTarget()
    {
        agent.SetDestination(targets[currentTarget].transform.position);
    }


}

