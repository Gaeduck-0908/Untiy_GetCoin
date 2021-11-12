using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent nav;
    private GameObject target;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.Find("BODY");
    }

    private void Update()
    {
        if (GameManager.Instance.IsPause == false)
        {
            if (nav.destination != target.transform.position)
            {
                nav.SetDestination(target.transform.position);
            }
            else
            {
                nav.SetDestination(transform.position);
            }
        }
    }
}
