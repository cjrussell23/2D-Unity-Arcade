using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallControlB : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 STARTINGVELOCITY = Vector2.zero;
    private Vector3 STARTINGPOSITION = new Vector3(0, -3.6f, 0);
    void Start(){
        _rb = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 1);
    }

    void GoBall() {
        float angle = Random.Range(-15f, 15f);
        _rb.AddForce(new Vector2(angle, 50));
    }

    public void ResetBall() {
        _rb.velocity = STARTINGVELOCITY;
        transform.position = STARTINGPOSITION;
    }

    public void Restart() {
        ResetBall();
        Invoke("GoBall", 1);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {            
            Vector2 vel;
            vel.y = _rb.velocity.y;           
            ContactPoint2D contact = coll.GetContact(0);
            Vector3 pos = contact.point - coll.collider.attachedRigidbody.position;
            if(_rb.velocity.x > 0) // Make x directions match
            {
                pos.x = Mathf.Abs(pos.x);
            }
            else
            {
                pos.x = -Mathf.Abs(pos.x);
            }
            vel.x = (_rb.velocity.x / 2) + (10 * pos.x);

            if (Mathf.Abs(vel.y) < 2f) // Make sure ball cant get too slow, makes game boring.
            {
                if (vel.y > 0)
                {
                    vel.y = 2f;
                }
                else
                {
                    vel.y = -2f;
                }
            }          
            // Set a cap for velocity
            if (vel.y > 8f)
            {
                vel.y = 8f;
            }
            if (vel.x > 8f)
            {
                vel.x = 8f;
            }
            _rb.velocity = vel;
        }
    }
}
