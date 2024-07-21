using UnityEngine;
using TMPro;

public class DisplayGameUi : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gazeText;
    [SerializeField] TextMeshProUGUI itemText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = DisplayScore();
        gazeText.text = DisplayGaze();
        itemText.text = DisplayItem();
    }

    string DisplayScore() {
        float score = GameManager.Instance.GetTotalScore();
        //3åÖÇ≈ÉJÉìÉ}ãÊêÿÇË
        return "Score " + score.ToString("N0");
    }
    string DisplayGaze() {
        float gaze = GameManager.Instance.GetGazeNum();
        return "Gaze " + gaze.ToString("N0");
    }
    string DisplayItem() {
        float item = GameManager.Instance.GetItemNum();
        return "Item " + item.ToString("N0");
    }
}
