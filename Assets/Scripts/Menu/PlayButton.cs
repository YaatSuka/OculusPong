using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
     private Button playButton;
     private GameOptions options;

	void Start() {
		Button play = this.GetComponent<Button>();
		play.onClick.AddListener(LoadGame);
	}

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
