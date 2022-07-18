using System;
using UnityEngine;

[RequireComponent(typeof(DoodleInput))]
[RequireComponent(typeof(Rigidbody))]
public class DoodleMovement : MonoBehaviour 
{
    private DoodleInput _input;
    private Rigidbody _rigidbody;
    

    private void Awake()
    {
        _input = GetComponent<DoodleInput>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        _input.PositionChanged += OnPositionChange;
    }

    private void OnDisable()
    {
        _input.PositionChanged -= OnPositionChange;
    }

    private void OnPositionChange(Vector3 position)
    {
        _rigidbody.position += position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
            _rigidbody.velocity = new Vector3(0, SetJumpModify(platform.Bouncness),0);
    }

    public float SetJumpModify(float delta)
    {
        return delta;
    }
}
