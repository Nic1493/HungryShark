using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] IntObject score;
    TextMeshProUGUI scoreText; 

    void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        scoreText.text = score.value.ToString();
    }
}