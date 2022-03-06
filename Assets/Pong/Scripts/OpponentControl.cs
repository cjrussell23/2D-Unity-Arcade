using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentControl : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Rigidbody2D _ball;
    private float _speed;
    private float _boundary = 2.25f;
    private float DEFAULTSPEED = 4f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();
        _speed = DEFAULTSPEED;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 vel = _rb.velocity;
        if (_ball.velocity == Vector2.zero) // When game resets, reset paddle.
        {
            transform.position = new Vector3(4, 0, 0);
            vel.y = 0;
            _speed = DEFAULTSPEED;
        }
        else if (_rb.transform.position.y > _ball.transform.position.y + 0.5f)
        {
            vel.y = -_speed;
        }
        else if (_rb.transform.position.y < _ball.transform.position.y - 0.5f)
        {
            vel.y = _speed;
        }
        else
        {
            vel.y = 0;
        }
        _rb.velocity = vel;


        Vector3 pos = transform.position;
        if (pos.y > _boundary)
        {
            pos.y = _boundary;
        }
        else if (pos.y < -_boundary)
        {
            pos.y = -_boundary;
        }
        transform.position = pos;
    }

    // When the Opponent hits the ball, change the speed.
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Ball")
        {
            float rand = Random.Range(DEFAULTSPEED-1, DEFAULTSPEED+2);
            _speed = rand;
        }
    }
}
