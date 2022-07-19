using System;
using UnityEngine;

[RequireComponent(typeof(DoodleInput))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MovementPhysics))]
public class DoodleMovement : MonoBehaviour 
{
    private DoodleInput _input;
    private Rigidbody _rigidbody;
    private MovementPhysics _rb;
    

    private void Awake()
    {
        _input = GetComponent<DoodleInput>();
        _rigidbody = GetComponent<Rigidbody>();
        _rb = GetComponent<MovementPhysics>();
    }
    private void OnEnable()
    {
        _input.PositionChanged += OnPositionChange;
        //_rb.PlatformCollisionEntered += OnColliderEnter;
    }

    private void OnDisable()
    {
        _input.PositionChanged -= OnPositionChange;
        //_rb.PlatformCollisionEntered -= OnColliderEnter;
    }

    private void OnPositionChange(Vector3 position)
    {
        transform.position += position;
    }

   // private void OnColliderEnter(Collider collision)
   // {
   //    if (collision.gameObject.TryGetComponent(out Platform platform))
   //    {
   //         _rb.AddVelocity(new Vector3(0, SetJumpModify(platform.Bouncness), 0));
   //         Debug.Log("Itouch");
   //     }
   // }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            _rigidbody.velocity = new Vector3(0, SetJumpModify(platform.Bouncness), 0);
            Debug.Log("Itouch");
        }
    }
    public float SetJumpModify(float delta)
    {
        return delta;
    }
}
