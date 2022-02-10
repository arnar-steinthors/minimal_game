using UnityEngine;

public class DogBehaviour : MonoBehaviour
{
    public Rigidbody2D dogBody;
    public AudioSource dogBark;
    public GameObject dogWrapper;
    // public GameHandler gameHandler;

    private float _speed = 0.1f; //0.1
    private void Start()
    {
        dogBark.Play();
        dogWrapper.transform.position = new Vector3(Random.Range(-5.5f, 4.5f), Random.Range(-2.5f, 3.5f), 0);
        dogBody.velocity = Vector2.zero;
        dogBody.gravityScale = 0;
        Invoke(nameof(LoseGame), 5);
        InvokeRepeating(nameof(IncreaseSpeed), 3, 8);
    }

    private void Update()
    {
        if (dogWrapper.transform.localScale.x <= 0)
        {
            LoseGame();
        } else
        {
            dogWrapper.transform.localScale -= new Vector3(_speed, _speed) * Time.deltaTime;
        }
    }

    private void IncreaseSpeed()
    {
        _speed = Mathf.Min(0.5f, _speed + 0.05f);
    }
    

    private void LoseGame()
    {
        GameHandler gameHandler = GameObject.FindWithTag("scripttag").GetComponent<GameHandler>();
        gameHandler.lost = true;
        gameHandler.RepeatSpawner(); // stops spawning
        Destroy(dogWrapper);
    }
    
    public void OnClicked()
    {
        // play sound
        var temp = dogBark;

        dogBark.pitch = 0.5f;
        dogBark.Play();

        dogBark = temp;
        
        // change dir
        dogWrapper.SetActive(false);
        
        Destroy(dogWrapper, 0.5f);
    }
}
