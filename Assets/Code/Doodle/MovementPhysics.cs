using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPhysics : MonoBehaviour
{
    [Header("Physics Settings")]
    [SerializeField] private float _gravityScale = 9.82f;
    [SerializeField] private Vector3 _force;
    [SerializeField] private float _massInKilo = 1f;
    [Header("Raycast Settings")]
    [SerializeField] private float _collisionDetectDistance;
    [SerializeField] private LayerMask _platformLayer;
    [SerializeField] private float _rayDistance;
    [SerializeField] private Transform _rayPoint;

    private bool _isEntered;

    private Vector3 _acceleration, _velocity, _position;

    public event Action<Collider> PlatformCollisionEntered;

    private void OnValidate()
    {
        if (_gravityScale < 0.1f)
            _gravityScale = 0.1f;
        if (_massInKilo < 0.1f)
            _massInKilo = 0.1f;

        if (_collisionDetectDistance < 0.1f)
            _collisionDetectDistance = 0.1f;
        if (_rayDistance < 0.1f)
            _rayDistance = 0.1f;


    }
    private void FixedUpdate()
    {
        CollisionEnter();

        _acceleration = _force / (_massInKilo * _gravityScale);

        _velocity += _acceleration * Time.fixedDeltaTime;

        _velocity -= _velocity * _velocity.magnitude * 0.5f * 10f * Time.fixedDeltaTime;

        _position += _velocity * Time.fixedDeltaTime;

        transform.position += _position;
    }

    private void CollisionEnter()
    {
        var ray = new Ray(_rayPoint.position, Vector3.down * _rayDistance);

        if (Physics.Raycast(ray, out RaycastHit hit, _rayDistance, _platformLayer))
        {

             if (Mathf.Abs((_rayPoint.position - hit.transform.position).magnitude) < _collisionDetectDistance)
             {
                _isEntered = true;
                Debug.Log("ITouch");
                PlatformCollisionEntered?.Invoke(hit.collider);
             }
        }
    }
    public void SetVelocity(Vector3 velocity)
    {
        if(_isEntered == true)
        {
            _velocity = velocity / 50;
            _isEntered = false;
        }
    }

    public void AddAcceleration(Vector3 acceleration)
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(new Ray(_rayPoint.position, Vector3.down * 10));
    }
}
