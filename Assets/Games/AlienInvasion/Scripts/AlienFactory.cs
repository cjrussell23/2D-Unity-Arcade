using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienFactory : MonoBehaviour{

    [SerializeField] GameObject _alien;

    void Start() {
        MakeAliens();
    }

    public void MakeAliens() {
        for (int i = 0; i < 15; i++) {
            for (int j = 0; j < 6; j++) {
                Instantiate(_alien,
                    new Vector3((i - 7) * 0.5f, (j - 2) * 0.8f, 0),
                         Quaternion.identity);
            }
        }
    }
    public void DestroyAliens()
    {
        GameObject[] _aliens = GameObject.FindGameObjectsWithTag("Alien");
        foreach (GameObject _alien in _aliens)
        {
            GameObject.Destroy(_alien);
        }
    }
}
