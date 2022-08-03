using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHealth : MonoBehaviour
{
    ScoreKeeper _scoreKeeper;

    private void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void DestroyMe()
    {
        _scoreKeeper.modifyScore(+1);
        Destroy(gameObject);
    }
}
