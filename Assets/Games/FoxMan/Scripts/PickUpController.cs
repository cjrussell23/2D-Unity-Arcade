using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUpController : MonoBehaviour
{
    protected float _startingXPos;
    protected bool _pickedUp;
    
    // Start is called before the first frame update
    void Start()
    {
        
        _pickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !_pickedUp)
        {
            _pickedUp = true;           
            PickUpAction();
        }
    }
    abstract public void PickUpAction();
    public float GetStartingXPos()
    {
        return _startingXPos;
    }
}
