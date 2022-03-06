using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private bool _activated;
    private Animator _animator;
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !_activated)
        {
            _audioSource.Play();
            _activated = true;
            _animator.SetTrigger("CheckPoint");
            UIController _canvas = GameObject.Find("Canvas").GetComponent<UIController>();
            _canvas.CheckPoint(this.transform.position);
            switch (gameObject.name) {
                case "Flag1":
                    GameObject.Find("Eagle1").GetComponent<EnemyController>().Initiate();
                    break;
                case "Flag2":
                    GameObject.Find("Eagle2").GetComponent<EnemyController>().Initiate();
                    break;
            }
        }      
    }
    public void Reset()
    {
        _activated = false;
    }
}
