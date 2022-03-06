using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Text _rules;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _soccerPong;
    [SerializeField] private Sprite _brickBreaker;
    [SerializeField] private Sprite _foxMan;
    [SerializeField] private Sprite _alienInvasion;
    [SerializeField] private AudioSource _audioSource;
    private string _gameSelected;
    private string _soccerPongRules;
    private string _brickBreakerRules;
    private string _foxManRules;
    private string _alienInvasionRules;
    private GameObject[] _popups;

    private void Start()
    {
        if (Display.displays.Length > 1)
        {
            Display.displays[0].Activate();
        }
        _popups = GameObject.FindGameObjectsWithTag("Popup");
        foreach (GameObject _popup in _popups)
        {
            _popup.gameObject.SetActive(false);
        }
        _brickBreakerRules =
            "Win this game by breaking all the bricks with at least one life left." +
            "\nIf the ball goes below your paddle, you lose a life.\n" +
            "\nControls:" +
            "\nA - Left" +
            "\nD - Right" +
            "\nPress escape to go back.";
        _soccerPongRules =
            "Win this game by getting to 10 points before the opponent." +
            "\nScore a point by hitting the ball past the oppenent.\n" +
            "\nControls:" +
            "\nW - Up" +
            "\nS - Down" +
            "\nPress escape to go back.";
        _foxManRules =
            "Win this game by moving to the right till you find the door." +
            "\nScore points by jumping on enemies, picking up coins, or eating apples." +
            "\nOpen crates by hitting them from the top or bottom, they will give you a surprise.\n" +
            "\nControls:" +
            "\nW - Up" +
            "\nS - Down" +
            "\nA - Left" +
            "\nD - Right" +
            "\nSPACE - Jump" +
            "\nPress escape to go back.";
        _alienInvasionRules = 
            "Win this game by destroying the invading aliens." +
            "Be careful to avoid their shots.\n" +         
            "\nControls:" +
            "\nA - Left" +
            "\nD - Right" +
            "\nSPACE - Shoot" +
            "\nPress escape to go back.";
    }
    public void DropdownValueChanged(Dropdown change)
    {
        _audioSource.Play();
        foreach (GameObject _popup in _popups)
        {
            _popup.gameObject.SetActive(true);
        }
        switch (change.value)
        {
            case 0:
                foreach (GameObject _popup in _popups)
                {
                    _popup.gameObject.SetActive(false);
                }
                break;
            case 1:
                _image.sprite = _soccerPong;
                _gameSelected = "Soccer Pong";
                _rules.text = _soccerPongRules;
                break;
            case 2:
                _image.sprite = _brickBreaker;
                _gameSelected = "Brick Breaker";
                _rules.text = _brickBreakerRules;
                break;
            case 3:
                _image.sprite = _alienInvasion;
                _gameSelected = "Alien Invasion";
                _rules.text = _alienInvasionRules;
                break;
            case 4:
                _image.sprite = _foxMan;
                _gameSelected = "Fox Man";
                _rules.text = _foxManRules;
                break;
        }
    }
    public void ChangeScene()
    {
        if (_gameSelected != null)
        {
            SceneManager.LoadScene(_gameSelected);
        }       
    }

    public void ResetHighScores()
    {
        PlayerPrefs.DeleteAll();
    }
}
