using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {

    [SerializeField] private KeyCode _moveUp = KeyCode.W;
    [SerializeField] private KeyCode _moveDown = KeyCode.S;
    [SerializeField] private KeyCode _escape = KeyCode.Escape;
    private float _speed = 8;
    private float _boundary = 2.25f;
    Rigidbody2D _rb;

    void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // moves the paddle up or down when key pressed
        Vector2 vel = _rb.velocity;
        if (Input.GetKey(_escape))
        {
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetKey(_moveUp)) {
            vel.y = _speed;
        }
        else if (Input.GetKey(_moveDown)) {
            vel.y = -_speed;
        }
        else {
            vel.y = 0;
        }
        _rb.velocity = vel;

        // limits movement at boundaries
        Vector3 pos = transform.position;
        if (pos.y > _boundary) {
            pos.y = _boundary;
        }
        else if (pos.y < -_boundary) {
            pos.y = -_boundary;
        }
        transform.position = pos;
    }

}
