using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    public int nbLife = 3;

    private Text ui;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GetComponent<GameController>();
        ui = GameObject.Find("LifeText").GetComponent<Text>();
        ui.text = nbLife.ToString();
    }

    public void decreaseLife()
    {
        nbLife--;
        ui.text = nbLife.ToString();
        if (nbLife <= 0) {
            gameController.GameOver();
        }
    }
}
