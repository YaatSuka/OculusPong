using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class modeHighScore : MonoBehaviour
{
     private Button o_btn;
    public Dictionary<string, int> gameMode;
	public HighScoreBehavior changeHS;


	void Start () {
        gameMode = new Dictionary<string, int>(){
            {"Button 3", 0}, 
            {"Button 5", 1}, 
            {"Button 10", 2}, 
            {"Button NL", 3}
        }; 

		o_btn = this.GetComponent<Button>();
		o_btn.onClick.AddListener(EventOnClick);
	}

	void EventOnClick(){
        changeHS.UpdateHighScore(gameMode[o_btn.name]);
	}
}
