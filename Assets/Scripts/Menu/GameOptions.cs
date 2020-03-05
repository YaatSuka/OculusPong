using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptions : MonoBehaviour
{
    public static string name = "Player";
    public static int timeMode = 0;

    private InputFieldManager inputField;

    // Start is called before the first frame update
    void Start()
    {
        inputField = GameObject.Find("InputField").GetComponent<InputFieldManager>();
    }

    public void UpdateTimeMode(int mode)
    {
        timeMode = mode;
    }

    public void UpdateName(string playerName)
    {
        name = (playerName.Length != 0) ? playerName : "Player";
    }
}
