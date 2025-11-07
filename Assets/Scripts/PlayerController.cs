using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public float speed;
    public float speedRotation;
    public Transform target;
    public Vector2 moveInput;
    [SerializeField] private PlayerInput inputAction;
    public Rigidbody rb;

    private void Start()
    {
        inputAction = new PlayerInput();
        inputAction.Enable();
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        inputAction.Enable();
    }
    void OnDisable()
    {
        inputAction.Disable();
    }

    void Update()
    {
        moveInput = inputAction.Player.move.ReadValue<Vector2>();
        Debug.Log(moveInput);
        MovePlayer();
    }
    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 direction = new Vector3(moveInput.x, 0, moveInput.y);
        direction.Normalize();

        

        Vector3 velocity = new Vector3 (direction.x * speed, rb.linearVelocity.y, direction.z * speed);
        rb.linearVelocity = velocity;
    }
}
