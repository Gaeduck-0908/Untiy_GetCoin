using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public GameObject[] prefabs;

    private BoxCollider size;
    private int count = 30;

    //������ ������Ʈ ����Ʈ
    private List<GameObject> gameObject = new List<GameObject>();

    private void Start()
    {
        size = GetComponent<BoxCollider>();

        for (int i = 0; i < count;  ++i)
        {
            Spawn();
        }

        size.enabled = false;
    }

    //���� ��ǥ ����
    private Vector3 RandomPosition()
    {
        Vector3 basePos = transform.position;
        Vector3 size2 = size.size;

        float posX = basePos.x + Random.Range(-size2.x / 2f, size2.x / 2f);
        float posZ = basePos.z + Random.Range(-size2.x / 2f, size2.x / 2f);

        Vector3 spawnPos = new Vector3(posX, 1, posZ);

        return spawnPos;
    }

    //������Ʈ ����
    private void Spawn()
    {
        int sel = Random.Range(0, prefabs.Length);

        GameObject selPrefab = prefabs[sel];

        Vector3 spawnPos = RandomPosition();

        GameObject instance = Instantiate(selPrefab, spawnPos, Quaternion.identity);
        gameObject.Add(instance);
    }
}
