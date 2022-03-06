using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField]
    private Text _score;
    [SerializeField]
    private Text _lives;
    [SerializeField]
    private Text _gameOver;
    [SerializeField]
    private Text _win;
    [SerializeField]
    private Text _playAgain;
    private int _scoreInt;
    private int _livesInt;
    private bool _gameActive;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private Text _highScore;
    private int _highScoreInt;
    private GameObject[] _aliens;
    void Start()
    {        
        _scoreInt = 0;
        _livesInt = 3;
        _gameActive = true;
        _highScoreInt = PlayerPrefs.GetInt("alienInvasionHighScore");
        _highScore.text = "High Score:\t" + _highScoreInt;
    }
    void Update()
    {
        _aliens = GameObject.FindGameObjectsWithTag("Alien");
        if (_livesInt < 1)
        {
            _gameActive = false;
            GameOver();
        }
        if (_aliens.Length == 0) //no aliens left
        {
            _gameActive = false;
            Win();
        }
        if (!_gameActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Restart();
            }
        }
        _score.text = "Score:\t" + _scoreInt;
        _lives.text = "Lives:\t" + _livesInt;
    }
    private void GameOver()
    {
        _gameOver.gameObject.SetActive(true);
        _playAgain.gameObject.SetActive(true);
    }

    private void Restart()
    {       
        _highScoreInt = Mathf.Max(_highScoreInt, _scoreInt);
        PlayerPrefs.SetInt("alienInvasionHighScore", _highScoreInt);
        _highScore.text = "High Score:\t" + _highScoreInt;
        _gameOver.gameObject.SetActive(false);
        _playAgain.gameObject.SetActive(false);
        _win.gameObject.SetActive(false);
        _livesInt = 3;
        _scoreInt = 0;
        // Remake aliens
        GameObject.Find("AliensFactory").GetComponent<AlienFactory>().DestroyAliens();
        GameObject.Find("AliensFactory").GetComponent<AlienFactory>().MakeAliens();
        GameObject.Find("Ship").GetComponent<ShipController>().MoveToStart();
        GameObject.Find("Ship").GetComponent<ShipController>().Reset();
        _gameActive = true;
    }

    private void Win()
    {
        _win.gameObject.SetActive(true);
        _playAgain.gameObject.SetActive(true);
    }

    public void Score()
    {
        _audioSource.Play();
        _scoreInt += 10;
    }

    public void LoseLife()
    {
        _livesInt--;
    }
}
