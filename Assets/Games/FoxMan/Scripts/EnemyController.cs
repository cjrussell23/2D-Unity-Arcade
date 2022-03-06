using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected float _startingXPos;
    protected Rigidbody2D _rb;
    protected Animator _animator;
    [SerializeField] protected AudioSource _audioSource;
    [SerializeField] protected AudioClip _deathAudio;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Death()
    {
        _audioSource.PlayOneShot(_deathAudio);
        _animator.SetTrigger("Death");
        Invoke(nameof(Disable), 0.5f);
    }
    private void Disable()
    {      
        gameObject.SetActive(false);
        GameObject.Find("Canvas").GetComponent<UIController>().Kill();
    }
    public void Enable()
    {
        gameObject.SetActive(true);
        _animator.SetTrigger("Alive");
    }
    public virtual void Initiate()
    {

    }
    public float GetStartingXPos()
    {
        return _startingXPos;
    }
}
