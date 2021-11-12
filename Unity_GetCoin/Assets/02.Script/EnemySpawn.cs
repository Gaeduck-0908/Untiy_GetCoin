using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyAi;
    private BoxCollider size;
    private int count = 15;

    private void Start()
    {
        size = GetComponent<BoxCollider>();
        for (int i = 0; i < count; ++i)
        {
            Invoke("Spawn", 5f);
        }
        size.enabled = false;
    }

    //오브젝트 생성
    private void Spawn()
    {
        Vector3 basePos = transform.position;
        Vector3 size2 = size.size;
        float posX = basePos.x + Random.Range(-size2.x / 2f, size2.x / 2f);
        float posZ = basePos.z + Random.Range(-size2.x / 2f, size2.x / 2f);
        Vector3 spawnPos = new Vector3(posX, 1, posZ);
        GameObject instance = Instantiate(EnemyAi, spawnPos, Quaternion.identity);
    }
}
