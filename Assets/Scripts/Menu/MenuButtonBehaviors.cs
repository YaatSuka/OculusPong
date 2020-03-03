using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonBehaviors : MonoBehaviour
{
	private Button clickButton;
	public Canvas thisCanvas;
	public Canvas nextCanvas;


	void Start () {
        //option Button
		Button o_btn = this.GetComponent<Button>();
		o_btn.onClick.AddListener(EventOnClick);
	}

	void EventOnClick(){
        thisCanvas.enabled = false;
       	nextCanvas.enabled = true;
	}

}
