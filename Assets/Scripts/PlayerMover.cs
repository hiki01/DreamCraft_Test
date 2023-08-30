using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float _moveSpeed = 5f;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        Move();
    }
    
    private void Move()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontalInput, 0f, verticalInput) * (_moveSpeed * Time.deltaTime);
        _rb.MovePosition(transform.position + movement);
    }
}
