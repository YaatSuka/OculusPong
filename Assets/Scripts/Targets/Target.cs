using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int value = 0;

    public GameObject scoreText;

    public void DisplayScore()
    {
        GameObject obj = Instantiate(scoreText, transform.position, Quaternion.identity);
        ScoreTarget scoreTarget = obj.GetComponent<ScoreTarget>();

        scoreTarget.score = value;
        scoreTarget.Display();

        GetComponent<TargetSound>().Play();

        Destroy(gameObject);
    }
}
