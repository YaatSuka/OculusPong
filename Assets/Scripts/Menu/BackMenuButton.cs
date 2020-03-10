using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackMenuButton : MonoBehaviour
{
    private Button playButton;
     private GameOptions options;

	void Start() {
		Button play = this.GetComponent<Button>();
		play.onClick.AddListener(LoadGame);
        options = GameObject.Find("Canvas Option").GetComponent<GameOptions>();
	}

    public void LoadGame()
    {
        SceneManager.LoadScene(0);
    }
}
