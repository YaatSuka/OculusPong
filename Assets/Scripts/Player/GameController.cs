using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Canvas ui;
	public Canvas gameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void GameOver()
    {
        ui.enabled = false;
        gameOverMenu.enabled = true;
        gameOverMenu.GetComponent<GameOverMenuController>().Display();
    }
}
