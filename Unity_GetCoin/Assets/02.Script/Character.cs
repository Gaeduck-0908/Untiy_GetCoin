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

    //점수변수
    public Text scoreT;
    private int score;

    //게임오버
    public GameObject LifeT;

    //기본설정
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    //진행상황 초기화
    private void Start()
    {
        camera = Camera.main;
        GameManager.Instance.IsPause = false;
        agent.updateRotation = false;
        score = 0;
        LifeT.SetActive(false);
    }

    //이동처리
    private void Update()
    {
        if(GameManager.Instance.IsPause == false)
        {
            if (Input.GetMouseButton(1))
            {
                RaycastHit hit;
                if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    SetDestination(hit.point);
                }
            }
            LookMoveDirection();
        }
    }

    //충돌처리
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
            //적
            case 7:
                GameManager.Instance.IsPause = true;
                LifeT.SetActive(true);
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