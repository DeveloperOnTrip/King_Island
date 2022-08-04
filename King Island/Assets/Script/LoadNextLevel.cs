using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public GameObject _find;
    public Transform _this;
    public GameObject _restartButton;
    public int _plusWhat;
    ScoreKeeper _scoreKeeper;
    public int _boxInlevel;

    void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (_scoreKeeper.score >= _boxInlevel)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + _plusWhat);
        else if (_scoreKeeper.score <= _boxInlevel)
        {
            Instantiate(_find,_this);
            _restartButton.SetActive(true);
        }
        
    }
}
