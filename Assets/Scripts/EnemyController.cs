using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    public float speedRotation;
    public float speedMultiplier;
    public float stoppingDistance;
    public GameObject player;
    public Vector2 newPosition;
    public Rigidbody rb;
    public Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        newPosition = new Vector2(player.transform.position.x, player.transform.position.z);
        RotationEnemy();
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance >= stoppingDistance)
        {
            animator.SetFloat("Velocity", speedMultiplier);
        }
        else
        {
            animator.SetFloat("Velocity", speedMultiplier/2);
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    void RotationEnemy()
    {
        Vector3 lookDirection = player.transform.position - transform.position;
        lookDirection.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speedRotation);
    }
}
