using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class EnemyFinder : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject Player;
    public Vector2 playerPosition;
    public float detectionRadius = 10f;
    public float speedRotation = 5f;
    public Rigidbody rb;
    private void Start()
    {
        rb = Player.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        playerPosition = new Vector2(Player.transform.position.x, Player.transform.position.z);
        if(enemies.Length == 0)
        {
            Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, Quaternion.Euler(0,0,0), Time.deltaTime * speedRotation);
        }
        //localiza a los enemigos
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            Vector2 enemyPosition = new Vector2(enemies[i].transform.position.x, enemies[i].transform.position.z);
            float distance = Vector2.Distance(playerPosition, enemyPosition);
            if (distance < detectionRadius)
            {
                Vector3 lookDirection = enemies[i].transform.position - Player.transform.position;
                lookDirection.y = 0;
                Quaternion rotation = Quaternion.LookRotation(lookDirection);
                Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, rotation, Time.deltaTime * speedRotation);
                transform.position = enemies[i].transform.position; //mueve el objeto que representa la deteccion del enemigo
            }
        }
    }
}
