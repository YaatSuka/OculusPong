using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private InputField input;
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(EventOnClick);

        input = GameObject.Find("InputField").GetComponent<InputFieldController>();
    }

    void EventOnClick()
    {
        string letter = GetComponentInChildren<Text>().text;

        if (letter == "Backspace") {
            input.text = input.text.Remove(input.text.Length - 1);
        } else if (letter == "Space") {
            input.text += " ";
        } else {
            input.text += letter;
        }
    }
}
