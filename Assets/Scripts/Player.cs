using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _gravity = 1f;
    [SerializeField]
    private float _jumpHeight = 15f;
  
    private bool _canDoubleJump = false;

    private float _yVelocity;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = horizontalInput * Vector3.right;
        Vector3 velocity = _speed * direction;

        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _canDoubleJump = true;
                _yVelocity = _jumpHeight;
            }
        }
        else if (!_controller.isGrounded)
        {
            if (_canDoubleJump && Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = false;
            }
            else
                _yVelocity -= _gravity;
        }
            
        velocity.y = _yVelocity;

        _controller.Move(velocity * Time.deltaTime);
    }
}
