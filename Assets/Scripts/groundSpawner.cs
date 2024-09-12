using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundPrefab;
    private Transform playerTransform;
    private float spawnX1 = 107f;
    private float spawnX2 = -107f;
    private float spawnZ1 = 62f;
    private float spawnZ2 = -62f;
    private float lengthX = 107f;
    private float lengthZ = 62f;
    private float distanceX = 87f;
    private float distanceZ = 42f;

    [SerializeField] Transform[] enemyPosition;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject[] enemies;
    private int[] createOrNot;

    void Start()
    {
        createOrNot = new int[enemyPosition.Length];
        enemies = new GameObject[enemyPosition.Length];
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < createOrNot.Length; i++)
        {
            createOrNot[i] = (int)Random.Range(0, 2);
        }
        for (int i = 0; i < enemyPosition.Length; i++)
        {
            if(createOrNot[i] == 0)
            {
                enemies[i] = ins_enemy(i);
            }
        }
    }

    void Update()
    {
        if (playerTransform.position.x > (spawnX1 - distanceX) && playerTransform.position.x >= 0)
        {
            createGroundX1();

            for(int i = 0; i < createOrNot.Length; i++)
            {
                createOrNot[i] = (int)Random.Range(0, 2);
            }

            for(int i = 0; i < enemyPosition.Length; i++)
            {
                if(createOrNot[i] == 0)
                {
                    enemies = new GameObject[enemyPosition.Length];
                    enemies[i] = ins_enemy(i);
                }
            }
        }
        /*
        else if (playerTransform.position.z > (spawnZ1 - distanceZ) && playerTransform.position.z >= 0)
        {
            createGroundZ1();
        }
        else if (playerTransform.position.x > (spawnX2 - distanceX) && playerTransform.position.x < 0)
        {
            createGroundX2();
        }
        else if (playerTransform.position.z > (spawnZ2 - distanceZ) && playerTransform.position.z < 0)
        {
            createGroundZ2();
        }
        */
    }

    GameObject ins_enemy(int index)
    {
        GameObject enemy = Instantiate(enemyPrefab) as GameObject;
        //enemy.transform.SetParent(transform);
        enemy.transform.position = enemyPosition[index].position + Vector3.right * (spawnX1 - lengthX);
        return enemy;
    }

    void createGroundX1()
    {
        GameObject ground;
        ground = Instantiate(groundPrefab) as GameObject;
        ground.transform.SetParent(transform);
        ground.transform.position = Vector3.right * spawnX1;
        spawnX1 += lengthX;
    }

    void createGroundZ1()
    {
        GameObject ground;
        ground = Instantiate(groundPrefab) as GameObject;
        ground.transform.SetParent(transform);
        ground.transform.position = Vector3.forward * spawnZ1;
        spawnX1 += lengthZ;
    }

    void createGroundX2()
    {
        GameObject ground;
        ground = Instantiate(groundPrefab) as GameObject;
        ground.transform.SetParent(transform);
        ground.transform.position = Vector3.right * spawnX2;
        spawnX1 -= lengthX;
    }

    void createGroundZ2()
    {
        GameObject ground;
        ground = Instantiate(groundPrefab) as GameObject;
        ground.transform.SetParent(transform);
        ground.transform.position = Vector3.forward * spawnZ2;
        spawnX1 -= lengthZ;
    }
}
