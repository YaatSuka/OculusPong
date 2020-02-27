using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int value = 0;

    public GameObject scoreText;

    void OnDestroy()
    {
        GameObject obj = Instantiate(scoreText, transform.position, Quaternion.identity);
        ScoreTarget scoreTarget = obj.GetComponent<ScoreTarget>();

        scoreTarget.score = value;
        scoreTarget.Display();
    }
}
