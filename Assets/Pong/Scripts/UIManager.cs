using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour { 
    private int _playerScore1;
    private int _playerScore2;
    [SerializeField] private Text _p1Score;
    [SerializeField] private Text _p2Score;
    private int _gameWinScore = 10;
    [SerializeField] private Text _gameOverText;
    private GameObject _ball;
    [SerializeField]
    private AudioClip _winAudioClip;
    [SerializeField]
    private AudioClip _loseAudioClip;
    [SerializeField]
    private AudioSource _audioSource;


    void Start() {
        _ball = GameObject.Find("Ball");
        _audioSource = GetComponent<AudioSource>();
    }

    public void Score(string wallID) {
        if (wallID == "RightWall") {
            _audioSource.PlayOneShot(_winAudioClip);
            _playerScore1++;
            _p1Score.text = "" + _playerScore1;
        }
        else {
            _audioSource.PlayOneShot(_loseAudioClip);
            _playerScore2++;
            _p2Score.text = "" + _playerScore2;
        }
        if (_playerScore1 < _gameWinScore && _playerScore2 < _gameWinScore) {
            _ball.GetComponent<BallControl>().Restart();
        }
        else
            GameOver();
    }

    public void GameOver() {
        if (_playerScore1 == _gameWinScore) {
            _gameOverText.text = "YOU WIN!";
        }
        else if (_playerScore2 == _gameWinScore) {
            _gameOverText.text = "YOU LOSE!";
        }
        _gameOverText.gameObject.SetActive(true);
        _ball.GetComponent<BallControl>().ResetBall();
    }

}
