using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomWall : MonoBehaviour{

    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.name == "BallB") {
            GameObject.Find("Canvas").GetComponent<UIManagerB>().LoseLife();         
        }
    }
}
