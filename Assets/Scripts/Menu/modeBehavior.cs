using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class modeBehavior : MonoBehaviour
{
    public Dictionary<string, int> gameMode;

    private GameOptions gameOptions;
    private Button o_btn;

	void Start () {
        gameMode = new Dictionary<string, int>(){
            {"Button 3", 0}, 
            {"Button 5", 1}, 
            {"Button 10", 2}, 
            {"Button NL", 3}
        };

        gameOptions = GameObject.Find("Canvas Option").GetComponent<GameOptions>();

		o_btn = this.GetComponent<Button>();
		o_btn.onClick.AddListener(EventOnClick);
	}

	void EventOnClick(){
        gameOptions.UpdateTimeMode(gameMode[o_btn.name]);
	}
}
