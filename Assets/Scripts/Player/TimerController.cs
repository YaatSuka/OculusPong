using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    float timeLeft = 60.0f;
    private bool isInfinit = false;
    private Text ui;

    // Start is called before the first frame update
  // Start is called before the first frame update
    void Start()
    {
        switch (modeBehavior.TimeMode)
        {
        case 3:
            isInfinit = true;
            break;
        case 2:
            timeLeft = 600.0f;
            break;
        case 1:
            timeLeft = 300.0f;
            break;
        default:
            timeLeft = 180.0f;
            break;
        }
 
        ui = GameObject.Find("TimeText").GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        if(!isInfinit)
        {
            timeLeft -= Time.deltaTime;

            string minutes = Mathf.Floor(timeLeft / 60).ToString("00");
            string seconds = (timeLeft % 60).ToString("00");

            ui.text = minutes + ":" + seconds;
        }
        else
        {
            ui.text = "∞";
        }
    }
}
