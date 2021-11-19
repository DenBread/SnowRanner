using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _powerJump;
    private bool _isGround, _isSpace;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _isSpace = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _isSpace = true;
        }
    }


    private void FixedUpdate()
    {
        Jump();
        Movement();
    }

    private void Movement()
    {
        Vector3 forwarMove = transform.forward * _speed * Time.deltaTime;
        _rb.MovePosition(_rb.position + forwarMove);
    }

    private void Jump()
    {
        if(_isGround && _isSpace)
                _rb.AddForce(Vector3.up * _powerJump, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Ground>())
        {
            Debug.Log("Стоит на земле");
            _isGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.GetComponent<Ground>())
        {
            Debug.Log("Прыжок");
            _isGround = false;
            _isSpace = false;
        }
    }
}
