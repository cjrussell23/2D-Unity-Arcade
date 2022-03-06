using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour{

    private float _scrollspeed = -2;

    void Update() {
        transform.Translate(0, _scrollspeed * Time.deltaTime, 0);
        if (transform.position.y < -10.0f) {
            transform.Translate(0, 20.48f, 0);
        }
    }
}
