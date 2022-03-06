using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private bool _gameOver;
    private float _speed;
    private float DEFAULTSPEED = 4.5f;
    private float _jumpForce;
    private float DEFAULTJUMPFORCE = 12f;
    private bool _isGrounded;
    private int _jumps;
    private bool _invulnerable;
    private const int WorldBottom = -9;
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private UIController _canvas;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _jumpAudio;
    void Start()
    {
        _gameOver = false;
        _speed = DEFAULTSPEED;
        _jumpForce = DEFAULTJUMPFORCE;
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _canvas = GameObject.Find("Canvas").GetComponent<UIController>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("Main Menu");
        }
        if (!_gameOver)
        {
            float deltaX = Input.GetAxis("Horizontal") * _speed;
            Vector2 movement = new Vector2(deltaX, _rb.velocity.y);
            _rb.velocity = movement;
            _animator.SetFloat("speed", Mathf.Abs(deltaX));
            if (!Mathf.Approximately(deltaX, 0))
            {
                transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
            }
            if (_isGrounded)
            {
                _jumps = 2;
            }
            if (_jumps > 1 && Input.GetKeyDown(KeyCode.Space))
            {
                _audioSource.PlayOneShot(_jumpAudio);
                _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                _jumps--;
            }
            if (gameObject.transform.position.y < WorldBottom)
            {
                _spriteRenderer.color = Color.white;
                _canvas.Respawn();
            }
        }
        else
        {
            _animator.SetFloat("speed", 0);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            _isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Enemy") && !_invulnerable)
        {
            foreach(ContactPoint2D point in collision.contacts)
            {
                if(point.normal.y >= 0.9)
                {
                    collision.collider.GetComponent<EnemyController>().Death();
                }
                else if (!_invulnerable)
                {
                    _invulnerable = true;
                    gameObject.layer = 7; // Put on enemy layer, so player passes through enemies
                    _spriteRenderer.color = new Color(1f, 1f, 1f, .5f);
                    _canvas.LoseLife();
                    Invoke(nameof(MakeVulnerable), 2f);
                }
            }
        }
        if (collision.gameObject.CompareTag("Crate"))
        {
            foreach (ContactPoint2D point in collision.contacts)
            {
                if(point.normal.y >= 0.9 || point.normal.y <= -0.9)
                {
                    collision.collider.GetComponent<CrateController>().OpenCrate();
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obsticle") && !_invulnerable)
        {
            _spriteRenderer.color = new Color(1f, 1f, 1f, .5f);
            _canvas.LoseLife();
            Invoke(nameof(MakeVulnerable), 2f);
        }
        if (collision.gameObject.CompareTag("Door"))
        {
            _canvas.LevelComplete();
            _gameOver = true;
        }
    }
    private void MakeVulnerable()
    {
        _invulnerable = false;
        _spriteRenderer.color = Color.white;
        gameObject.layer = 0;
    }
}
