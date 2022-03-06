using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject _brick;
    // Start is called before the first frame update
    void Start()
    {
        MakeBricks();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void MakeBricks()
    {
        for(int i = -3; i < 5; i++)
        {
            for (int j = 1; j < 3; j++)
            {
                Instantiate(_brick,
                    new Vector3((i*1.1f) -0.5f, (j * 0.6f), 0),
                    Quaternion.identity);
            }
        }
    }
}
