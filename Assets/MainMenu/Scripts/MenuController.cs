using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Text _rules;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _SoccerPong;
    [SerializeField] private Sprite _BrickBreaker;
    private string _gameSelected;
    private string _soccerPongRules;
    private string _brickBreakerRules;
    private GameObject[] _popups;

    private void Start()
    {
        _popups = GameObject.FindGameObjectsWithTag("Popup");
        foreach (GameObject _popup in _popups)
        {
            _popup.gameObject.SetActive(false);
        }
        _brickBreakerRules =
            "Win this game by breaking all the bricks with at least one life left." +
            "\nIf the ball goes below your paddle, you lose a life." +
            "\nControls:" +
            "\nA - Left" +
            "\nD - Right" +
            "\nPress escape to go back.";
        _soccerPongRules =
            "Win this game by getting to 10 points before the opponent." +
            "\nScore a point by hitting the ball past the oppenent." +
            "\nControls:" +
            "\nW - Up" +
            "\nS - Down" +
            "\nPress escape to go back.";
    }
    public void DropdownValueChanged(Dropdown change)
    {
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
                _image.sprite = _SoccerPong;
                _gameSelected = "Soccer Pong";
                _rules.text = _soccerPongRules;
                break;
            case 2:
                _image.sprite = _BrickBreaker;
                _gameSelected = "Brick Breaker";
                _rules.text = _brickBreakerRules;
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
}
