using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour{

    [SerializeField] GameObject _shot;
    private float _speed = 5;
    private float _boundary = 3.5f;
    Rigidbody2D _rb;
    private bool _alive;
    private Animator _animator;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _explosionAudio;
    [SerializeField]
    private AudioClip _shotAudio;
    private Vector3 _STARTINGPOSITION = new Vector3(0, -2.8f, 0);
    
    void Start(){
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _alive = true;      
    }

    void Update(){
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }
        if (_alive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(_shot, new Vector3(transform.position.x,
                    transform.position.y, 0.5f), Quaternion.identity);
                _audioSource.PlayOneShot(_shotAudio);
            }          
        }
        Vector2 vel = _rb.velocity;
        if (Input.GetKey(KeyCode.D))
        {
            vel.x = _speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            vel.x = -_speed;
        }
        else
        {
            vel.x = 0;
        }
        _rb.velocity = vel;
        Vector3 pos = transform.position;
        if (pos.x > _boundary)
        {
            pos.x = _boundary;
        }
        else if (pos.x < -_boundary)
        {
            pos.x = -_boundary;
        }
        transform.position = pos;
             
    }
    
    private void OnTriggerEnter2D(Collider2D other) {       
        
        if (other.CompareTag("AShot") && _alive)
        {
            GameObject.Find("Canvas").GetComponent<UIBehaviour>().LoseLife();
            _audioSource.PlayOneShot(_explosionAudio);
            _alive = false;
            Destroy(other.gameObject);
            _animator.SetTrigger("Dead");
            Invoke(nameof(Reset), 3f);
        }       
    }
    public void Reset()
    {     
        _alive = true;
        _animator.SetTrigger("Alive");

    }
    public void MoveToStart()
    {
        transform.position = _STARTINGPOSITION;
    }
}
