using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public GameObject _find;
    public Transform _this;
    ScoreKeeper _scoreKeeper;

    void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (_scoreKeeper.score >= 24)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else if (_scoreKeeper.score <= 24)
        {
            Instantiate(_find,_this);
        }
        
    }
}
