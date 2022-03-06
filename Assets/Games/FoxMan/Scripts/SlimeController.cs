using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : EnemyController
{
    private bool _isFacingRight = false;
    private float _maxSpeed = 1.5f;   
    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _startingXPos = this.transform.position.x;
    }
    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 enemyScale = transform.localScale;
        enemyScale.x = enemyScale.x * -1;
        transform.localScale = enemyScale;
    }
    private void FixedUpdate()
    {
        if (_isFacingRight == true)
        {
            _rb.velocity = new Vector2(_maxSpeed, _rb.velocity.y);
        }
        else
        {
            _rb.velocity = new Vector2(_maxSpeed * -1, _rb.velocity.y);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        ;
        if (collider.CompareTag("Wall"))
        {
            Flip();
        }
    } 
}
