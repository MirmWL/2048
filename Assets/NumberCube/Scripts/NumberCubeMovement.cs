using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class NumberCubeMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    
    [SerializeField]
    private float _jumpForce;
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        _rigidbody.AddForce(-Vector3.forward * _jumpForce, ForceMode.Impulse);
    }
    
    public void Move(Vector3 direction)
    {
        _rigidbody.velocity = direction * _speed;
    }
}