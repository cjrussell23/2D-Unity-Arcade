using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour
{
    private bool _opened = false;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] private GameObject _contents;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCrate()
    {
        if (!_opened)
        {
            _audioSource.Play();
            _opened = true;
            Vector3 pos = transform.position + new Vector3(0, 1, 0);
            GameObject.Instantiate(_contents, pos, Quaternion.identity);
        }       
    }
}
