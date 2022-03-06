using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _SoccerPong;
    [SerializeField] private Sprite _BrickBreaker;
    private string _gameSelected;
    public void DropdownValueChanged(Dropdown change)
    {
        switch (change.value)
        {
            case 1:
                _image.sprite = _SoccerPong;
                _gameSelected = "Soccer Pong";
                break;
            case 2:
                _image.sprite = _BrickBreaker;
                _gameSelected = "Brick Breaker";
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
