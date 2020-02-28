using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private int score = 0;
    private Text ui;
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("ScoreText").GetComponent<Text>();
        ui.text = score.ToString();
    }

    public void AddScore(int points)
    {
        score += points;
        ui.text = score.ToString();
    }

    public int GetScore()
    {
        return score;
    }
}
