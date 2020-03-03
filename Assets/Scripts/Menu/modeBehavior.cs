using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class modeBehavior : MonoBehaviour
{
    private Button o_btn;
    public static int TimeMode = 0;
    public Dictionary<string, int> gameMode;


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
        TimeMode = gameMode[o_btn.name];
		Debug.Log ("You have clicked the option button! The actual mode is " + TimeMode.ToString());
	}
}
