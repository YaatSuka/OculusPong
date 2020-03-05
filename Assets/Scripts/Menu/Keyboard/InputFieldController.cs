using UnityEngine;
using UnityEngine.UI;

public class InputFieldController : InputField
{
    private GameOptions gameOptions;

    protected override void Start()
    {
        keyboardType = (TouchScreenKeyboardType)(-1);
        base.Start();
        gameOptions = GameObject.Find("Canvas Option").GetComponent<GameOptions>();
        onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }

    public void ValueChangeCheck()
    {
        gameOptions.UpdateName(text);
    }
}