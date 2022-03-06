using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    private int _checkPointScore;
    private int _scoreInt;
    private int _livesInt;
    private int _highScoreInt;
    public Vector3 _spawnPoint;
    [SerializeField] private Text _score;
    [SerializeField] private Text _lives;
    [SerializeField] private Text _highScore;
    [SerializeField] private Text _levelComplete;
    [SerializeField] private Text _newHighScore;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _pickupCoinAudio;
    [SerializeField] AudioClip _loseLifeAudio;
    [SerializeField] AudioClip _gainLifeAudio;
    [SerializeField] AudioClip _die;
    private GameObject[] _enemies;
    private GameObject[] _coins;

    // Start is called before the first frame update    
    void Start()
    {
        _highScoreInt = PlayerPrefs.GetInt("FoxManHighScore");
        _highScore.text = "High Score\t" + _highScoreInt;
        _checkPointScore = 0;
        _livesInt = 3;
        _scoreInt = 0;
        _spawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        _coins = GameObject.FindGameObjectsWithTag("PickUp");
    }

    // Update is called once per frame
    void Update()
    {
        _score.text = "Score:\t" + _scoreInt;
        _lives.text = "Lives:\t" + _livesInt;
        if(_livesInt < 1)
        {
            Respawn();
        }
    }
    public void Score()
    {
        _audioSource.PlayOneShot(_pickupCoinAudio);
        _scoreInt += 10;
    }
    public void Kill()
    {
        _scoreInt += 1;
    }
    public void LoseLife()
    {
        _audioSource.PlayOneShot(_loseLifeAudio);
        _livesInt--;
    }
    public void GainLife()
    {
        _audioSource.PlayOneShot(_gainLifeAudio);
        _livesInt++;
    }
    public void Respawn()
    {
        _audioSource.PlayOneShot(_die);
        GameObject.FindGameObjectWithTag("Player").transform.position = _spawnPoint;
        GameObject[] checkPoints = GameObject.FindGameObjectsWithTag("CheckPoint");
        foreach (GameObject checkPoint in checkPoints)
        {
            checkPoint.GetComponent<CheckPoint>().Reset();
        }
        _scoreInt = _checkPointScore;
        _livesInt = 3;
        foreach (GameObject enemy in _enemies)
        {
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            if(enemyController.GetStartingXPos() > _spawnPoint.x) // Only respawn enemies past the checkpoint/spawnpoint
            {
                enemyController.Enable();
            }  
        }
        foreach (GameObject coin in _coins)
        {
            CoinController coinController = coin.GetComponent<CoinController>();
            if(coinController.GetStartingXPos() > _spawnPoint.x)
            {
                coinController.Enable();
            }
        }
    }
    public void CheckPoint(Vector3 checkPoint)
    {
        _checkPointScore = _scoreInt;
        _spawnPoint = checkPoint;
    }
    public void LevelComplete()
    {
        
        _levelComplete.gameObject.SetActive(true);
        _newHighScore.gameObject.SetActive(true);
        _scoreInt += _livesInt * 100;
        _highScoreInt = Mathf.Max(_highScoreInt, _scoreInt);
        PlayerPrefs.SetInt("FoxManHighScore", _highScoreInt);
        _highScore.text = "High Score:\t+" + _highScoreInt;
    }
}
