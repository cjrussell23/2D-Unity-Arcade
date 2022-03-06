using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController: PickUpController
{
    protected float _maxSpeed = 1.5f;
    protected Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector2(_maxSpeed, _rb.velocity.y);
    }
    
    public override void PickUpAction()
    {
        Destroy(gameObject); // Destroy so they arent activated when respawning
        GameObject.Find("Canvas").GetComponent<UIController>().GainLife();
    }
}
