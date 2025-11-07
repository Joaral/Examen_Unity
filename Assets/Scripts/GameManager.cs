using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawner;
    public double maxEnemies;
    public int RandomPosition;
    public GameObject Prefab;

    private void Awake()
    {
        spawner = GameObject.FindGameObjectsWithTag("Spawner");
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
        {
            RandomPosition = Random.Range(0, spawner.Length);
            spawn(spawner[RandomPosition]);
        }
        if(GameObject.FindGameObjectsWithTag("Enemy").Length == maxEnemies)
        {
            maxEnemies *= 1.2;
        }

    }

    void spawn(GameObject spawner)
    {
        Instantiate(Prefab, spawner.transform.position, spawner.transform.rotation);
        Debug.Log("Spawned Enemy");
    }
}
