using UnityEngine;
using TMPro;

public class UIDisplay : MonoBehaviour
{

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Update()
    {
        scoreText.text = scoreKeeper.GetScore().ToString("0/16");
    }
}
