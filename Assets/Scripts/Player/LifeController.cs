using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    public int nbLife = 3;

    private Text ui;

    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("LifeText").GetComponent<Text>();
        ui.text = nbLife.ToString();
    }

    public void decreaseLife()
    {
        nbLife--;
        ui.text = nbLife.ToString();
    }
}
