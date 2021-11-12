using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    //이동 변수
    [SerializeField] private Transform character;
    private Camera camera;
    private NavMeshAgent agent;
    private bool isMove;
    private Vector3 destination;

    //점수 변수
    public Text scoreT;
    private int score = 0;

    //기본설정
    private void Awake()
    {
        camera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    //이동처리
    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            RaycastHit hit;
            if(Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                SetDestination(hit.point);
            }
        }
        LookMoveDirection();
    }

    private void OnTriggerEnter (Collider col)
    {
        switch(col.gameObject.layer)
        {
            //코인
            case 8:
                score++;
                scoreT.text = "Score : " + score.ToString();
                Destroy(col.gameObject);
                break;
        }
    }

    //네비
    void SetDestination(Vector3 dest)
    {
        agent.SetDestination(dest);
        destination = dest;
        isMove = true;
    }

    //이동방향 바라보기
    private void LookMoveDirection()
    {
        if(isMove)
        {
            if(agent.velocity.magnitude == 0.0f)
            {
                isMove = false;
                return;
            }
            var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
            character.transform.forward = dir;
        }
    }
}