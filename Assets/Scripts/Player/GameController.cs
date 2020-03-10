using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Canvas ui;
	public Canvas gameOverMenu;
    private ScoreController scoreController;
    public static int end_score = 0;


    // Start is called before the first frame update
    void Start()
    {
        scoreController = GameObject.Find("GameController").GetComponent<ScoreController>();
    }

    public void GameOver()
    {
        score = scoreController.GetScore();
        SceneManager.LoadScene(2);
    }
}
