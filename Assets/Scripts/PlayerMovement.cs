using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed;

    private Vector2 _mDirection;

    public void Move(InputAction.CallbackContext ctx)
    {
        _mDirection = ctx.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(_mDirection.x * _speed, _rb.velocity.y, _mDirection.y * _speed);
        if (_rb.velocity.sqrMagnitude > 0.01f)
        {
            Vector3 look = _rb.velocity.normalized;
            look.y = 0;

            if (look == Vector3.zero)
                return;

            Quaternion targetRotation = Quaternion.LookRotation(look);
            _rb.rotation = targetRotation;
        }
    }

}