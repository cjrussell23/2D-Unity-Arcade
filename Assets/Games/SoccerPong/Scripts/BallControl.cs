using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallControl : MonoBehaviour
{
    private Rigidbody2D _rb;
    private AudioSource _audioSource;
    
    void Start(){
        _rb = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        Invoke("GoBall", 2);
    }

    void GoBall() {
        float player = Random.Range(0, 2);
        float angle = Random.Range(-15, 15);
        if (player < 1) // Left
        {
            _rb.AddForce(new Vector2(20, angle));
        }
        else // Right
        {
            _rb.AddForce(new Vector2(-20, angle));
        }
    }

    public void ResetBall() {
        _rb.velocity = Vector2.zero;
        transform.position = Vector3.zero;
    }

    public void Restart() {
        ResetBall();
        Invoke("GoBall", 1);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {            
            _audioSource.Play();
            Vector2 vel;
            vel.x = _rb.velocity.x;           
            ContactPoint2D contact = coll.GetContact(0);
            Vector3 pos = contact.point - coll.collider.attachedRigidbody.position;
            if(_rb.velocity.y > 0) // Make y directions match
            {
                pos.y = Mathf.Abs(pos.y);
            }
            else
            {
                pos.y = -Mathf.Abs(pos.y);
            }          
            if (Mathf.Abs(vel.x) < 2f) // Make sure ball cant get too slow, makes game boring.
            {
                if (vel.x > 0)
                {
                    vel.x = 2f;
                }
                else
                {
                    vel.x = -2f;
                }
            }
            vel.y = (_rb.velocity.y / 2) + (10 * pos.y);
            // Set a cap for velocity
            if (vel.x > 6f)
            {
                vel.x = 6f;
            }
            if (vel.y > 6f)
            {
                vel.y = 6f;
            }
            _rb.velocity = vel;
        }
    }
}
