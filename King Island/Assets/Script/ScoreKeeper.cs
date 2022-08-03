using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [HideInInspector] public int score; 

    static ScoreKeeper instance;

    void Awake()
    {
        MangeSingleton();
    }

    void MangeSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void modifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        //Debug.Log(score);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
