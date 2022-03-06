using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    [SerializeField] private Vector3 _finishPos;
    [SerializeField] private float _speed = .5f;
    [SerializeField] private Vector3 _startPos;
    [SerializeField] private float _trackPercent = 0;
    [SerializeField] private int _direction = 1;
    [SerializeField] private float _distance = 5;
    void Start()
    {
        _startPos = transform.position;
        _finishPos = new Vector3(transform.position.x + _distance,
        transform.position.y, transform.position.z);
    }
    void Update()
    {
        _trackPercent += _direction * _speed * Time.deltaTime;
        float x = (_finishPos.x - _startPos.x) * _trackPercent +
        _startPos.x;
        float y = (_finishPos.y - _startPos.y) * _trackPercent +
        _startPos.y;
        transform.position = new Vector3(x, y, _startPos.z);
        if ((_direction == 1 && _trackPercent > .9f) ||
        (_direction == -1 && _trackPercent < .1f))
        {
            _direction *= -1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
