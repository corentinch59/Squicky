using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _chicken;

    private Vector2 _mDirection;

    public void Move(InputAction.CallbackContext ctx)
    {
        _mDirection = ctx.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 input = new Vector3(_mDirection.x, 0, _mDirection.y);
        Vector3 camForward = _camera.transform.forward;
        Vector3 camRight = _camera.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 move = (camForward * input.z + camRight * input.x).normalized;
        move.y = _rb.velocity.y;
        _rb.velocity = new Vector3(move.x * _speed, _rb.velocity.y, move.z * _speed);

        _animator.SetFloat("Speed", input.sqrMagnitude);

        Vector3 look = _rb.velocity.normalized;
        look.y = 0;

        if (look == Vector3.zero)
            return;

        Quaternion targetRotation = Quaternion.LookRotation(look);
        _rb.rotation = targetRotation;
        _chicken.rotation = targetRotation;
    }

}