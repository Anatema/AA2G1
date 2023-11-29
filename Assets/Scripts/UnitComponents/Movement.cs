using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Transform _transform;

    [SerializeField]
    private float _acceleration;
    [SerializeField]
    private float _maxSpeed;
    [SerializeField]
    private float _rotationSpeed;

    private float _movementForward;
    private float _rotation;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
    }

    public void Move(Vector2 direction) 
    {
        _movementForward = Mathf.Clamp(direction.x, -0.5f, 1);
        _rotation = Mathf.Clamp(direction.y, -1, 1);
    }
    private void FixedUpdate()
    {
        _rigidbody.AddTorque(_transform.up * _rotation * _rotationSpeed, ForceMode.VelocityChange);

        if (_rigidbody.velocity.magnitude > _maxSpeed)
        {
            return;
        }

        _rigidbody.velocity += _transform.forward * _acceleration * _movementForward;

      
        
    }
}
