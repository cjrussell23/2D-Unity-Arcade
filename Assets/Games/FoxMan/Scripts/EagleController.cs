using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : EnemyController
{
    private float _maxSpeed = 2.5f;
    private Vector3 _startingPos;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _startingPos = gameObject.transform.position;
        _startingXPos = this.transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    public override void Initiate()
    {
        gameObject.transform.position = _startingPos;
        _rb.velocity = new Vector2(_maxSpeed * -1, _rb.velocity.y);
    }
}
