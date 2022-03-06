using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController: PickUpController
{
    // Start is called before the first frame update
    void Start()
    {
        _startingXPos = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void PickUpAction()
    {
        gameObject.SetActive(false);
        GameObject.Find("Canvas").GetComponent<UIController>().Score();
    }
    public void Enable()
    {
        gameObject.SetActive(true);
        _pickedUp = false;
    }
}
