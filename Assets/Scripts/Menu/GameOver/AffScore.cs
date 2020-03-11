using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffScore : MonoBehaviour
{
    private Text myScore;

    // Start is called before the first frame update
    void Start()
    {
       myScore = this.GetComponent<Text>();
       myScore.text = GameController.end_score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
