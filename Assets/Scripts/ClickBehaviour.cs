using System;
using TMPro;
using UnityEngine;

public class ClickBehaviour : MonoBehaviour
{
    public DogBehaviour dogBehaviour;
    private TextMeshProUGUI _text;
    private GameHandler _gameHandler;

    private void Start()
    {
        _gameHandler = GameObject.FindWithTag("scripttag").GetComponent<GameHandler>();
        _text = FindObjectOfType<TextMeshProUGUI>();
    }

    private void OnMouseDown()
    {
        if (_gameHandler.lost) return;
        _gameHandler.DogClicked();
        dogBehaviour.OnClicked();
        
        var currentScore = int.Parse(_text.text);
        currentScore++;
        _text.text = currentScore.ToString();
    }
}
