using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerB : MonoBehaviour {
    private int _score;
    private int _lives;
    private int DEFAULTLIVES = 3;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _livesText;
    [SerializeField] private Text _gameOverText;
    private GameObject _ball;
    [SerializeField]
    private AudioClip _winAudioClip;
    [SerializeField]
    private AudioClip _loseAudioClip;
    [SerializeField]
    private AudioSource _audioSource;

    void Start() {
        _ball = GameObject.Find("BallB");
        _lives = DEFAULTLIVES;
        _audioSource = GetComponent<AudioSource>();
    }

    public void Score()
    {
        _audioSource.PlayOneShot(_winAudioClip);
        _score += 10;
        _scoreText.text = "Score:\t" + _score;
        if(_score >= 160)
        {
            GameOver();
        }
    }
    public void LoseLife() {
        _audioSource.PlayOneShot(_loseAudioClip);
        _lives--;
        _livesText.text = "Lives:\t" + _lives;
        if (_lives < 1)
        {
            GameOver();
        }
        else
        {
            _ball.GetComponent<BallControlB>().Restart();
        }
    }

    public void GameOver() {
        if (_score == 160) {
            _gameOverText.text = "YOU WIN!";
        }
        else if (_lives < 1) {
            _gameOverText.text = "YOU LOSE!";
        }
        _gameOverText.gameObject.SetActive(true);
        _ball.GetComponent<BallControlB>().ResetBall();
    }

}
