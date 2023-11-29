using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float _distance = 7.0f;
    [SerializeField]
    private float height = 3.0f;
    [SerializeField]
    public Vector3 CenterOffset = Vector3.zero;
    [SerializeField]
    private bool followOnStart = false;    
    [SerializeField]
    private float smoothSpeed = 0.125f;

    [SerializeField]
    private Transform _target;
    private Transform _transform;


    private bool _isFollowing;
    private Vector3 _cameraOffset = Vector3.zero;


    private void Awake()
    {
        _transform = transform;
    }

    void Start()
    {
        if (followOnStart)
        {
            OnStartFollowing();
        }
    }
    void LateUpdate()
    {
        if (_isFollowing && _target)
        {
            Follow();
        }
    }
    public void OnStartFollowing()
    {
        _transform = Camera.main.transform;
        _isFollowing = true;
        Cut();
    }

    void Follow()
    {
        _cameraOffset.z = -_distance;
        _cameraOffset.y = height;

        _transform.position = Vector3.Lerp(_transform.position, _target.position + _target.TransformVector(_cameraOffset), smoothSpeed * Time.deltaTime);

        _transform.LookAt(_target.position + CenterOffset);

    }


    void Cut()
    {
        _cameraOffset.z = -_distance;
        _cameraOffset.y = height;

        _transform.position = _target.position + _target.TransformVector(_cameraOffset);

        _transform.LookAt(_target.position + CenterOffset);
    }
}
