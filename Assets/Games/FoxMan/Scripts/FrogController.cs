using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : EnemyController
{
    private float _jumpForce;
    private float _velocity;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _jumpForce = 3;
        _startingXPos = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        _velocity = _rb.velocity.y;
        if (_velocity < 0)
        {
            _animator.SetTrigger("Fall");
        }
        if(_velocity == 0)
        {
            _animator.SetTrigger("Landed");
            if (Mathf.FloorToInt(Random.value * 10000.0f) % 5000 == 0)
            {
                Jump();
            }
        }       
    }
    private void Jump()
    {
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _animator.SetTrigger("Jump");
    }
}
