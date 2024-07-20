using UnityEngine;
using TMPro;

public class DisplayGameUi : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore();
    }

    void DisplayScore() {
        float score = GameManager.Instance.GetTotalScore();
        string scoreString = "Score " + score.ToString("N0");
        scoreText.text = scoreString;
    }
}
