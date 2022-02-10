using System;
using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameHandler : MonoBehaviour
{
    public GameObject dogPrefab;
    public AudioSource dogBark;
    public TextMeshProUGUI text;

    private float _spawnDecrementTimer = 0f;
    public bool lost = false;
    private bool _hasPlayerLostSound = false;

    private void Start()
    {
        text.text = "0";
        RepeatSpawner();
    }

    public void RepeatSpawner()
    {
        if (lost)
        {
            if (!_hasPlayerLostSound)
            {
                dogBark.pitch = 2f;
                dogBark.Play();
                _hasPlayerLostSound = true;
            }
            return;
        }
        
        SpawnDog();
        Invoke(nameof(RepeatSpawner), Mathf.Max(0.4f, 1 - _spawnDecrementTimer));
        _spawnDecrementTimer += 0.005f;
    }

    public void DogClicked()
    {
        dogBark.pitch = 0.5f;
        dogBark.Play();
    }
    

    private void SpawnDog()
    {
        Instantiate(dogPrefab);
        // var currentScore = int.Parse(text.text);
        // currentScore++;
        // text.text = currentScore.ToString();
    }
}
