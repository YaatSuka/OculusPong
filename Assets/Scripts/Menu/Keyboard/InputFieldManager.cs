using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour, IPointerClickHandler
{
    private GameObject keyboard;
    private GameOptions gameOptions;
    
    // Start is called before the first frame update
    void Start()
    {
        keyboard = GameObject.Find("Keyboard");
        gameOptions = GameObject.Find("Canvas Option").GetComponent<GameOptions>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (keyboard.activeSelf) {
            keyboard.SetActive(false);
        } else {
            keyboard.SetActive(true);
        }
    }
}
