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
        if(nav.destination != target.transform.position)
        {
            nav.SetDestination(target.transform.position);
        }
        else
        {
            nav.SetDestination(transform.position);
        }
    }

    private void OnCollisionStay(Collision col)
    {
        if(col.gameObject.name == "GAME_CHAR")
       {
            GameManager.Instance.IsPause = true;
        }
    }
}
