using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    //�̵� ����
    [SerializeField] private Transform character;
    private Camera camera;
    private NavMeshAgent agent;
    private bool isMove;
    private Vector3 destination;

    //��������
    public Text scoreT;
    private int score;

    //���ӿ���
    public GameObject LifeT;

    //�⺻����
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    //�����Ȳ �ʱ�ȭ
    private void Start()
    {
        camera = Camera.main;
        GameManager.Instance.IsPause = false;
        agent.updateRotation = false;
        score = 0;
        LifeT.SetActive(false);
    }

    //�̵�ó��
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

    //�浹ó��
    private void OnTriggerEnter (Collider col)
    {
        switch(col.gameObject.layer)
        {
            //����
            case 8: 
                score++;
                scoreT.text = "Score : " + score.ToString();
                Destroy(col.gameObject);
                break;
            //��
            case 7:
                GameManager.Instance.IsPause = true;
                LifeT.SetActive(true);
                break;
        }
    }

    //�׺�
    void SetDestination(Vector3 dest)
    {
        agent.SetDestination(dest);
        destination = dest;
        isMove = true;
    }

    //�̵����� �ٶ󺸱�
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