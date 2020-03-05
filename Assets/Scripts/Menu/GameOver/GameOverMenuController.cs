using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOverMenuController : MonoBehaviour
{
    private ScoreController scoreController;
    private Text playerName;
    private Text score;

    // Start is called before the first frame update
    void Start()
    {
        scoreController = GameObject.Find("GameController").GetComponent<ScoreController>();
        playerName = GameObject.Find("PlayerName").GetComponent<Text>();
        score = GameObject.Find("FinalScoreText").GetComponent<Text>();
        gameObject.SetActive(false);
    }

    public void Display()
    {
        playerName.text = GameOptions.name;
        score.text = scoreController.GetScore().ToString();
        gameObject.SetActive(true);

        GameObject.Find("EventSystem").GetComponent<OVRInputModule>().enabled = false;
        GameObject.Find("EventSystem").GetComponent<StandaloneInputModule>().enabled = true;
        GameObject.Find("EventSystem").GetComponent<VRinput>().enabled = true;
        
        GameObject.Find("Vrg Right Grabber").SetActive(false);
        GameObject.Find("RightControllerAnchor").SetActive(false);
        GameObject.Find("RightControllerAnchorMenu").SetActive(true);
        GameObject.Find("RightControllerAnchorLine").SetActive(true);

        // TODO: Save score
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
