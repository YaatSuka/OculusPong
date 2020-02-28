using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTarget : MonoBehaviour
{
    public float lifeTime = 1.5f;
    public int score;

    private const int scaleValue = 10;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0) {
            Destroy(gameObject);
        }

        transform.Translate(0.01f, 0.01f, 0.01f);
    }

    public void Display()
    {
        gameObject.AddComponent<TextMesh>();

        TextMesh textMesh = GetComponent<TextMesh>();

        textMesh.text = (score > 0) ? "+" + score.ToString() : score.ToString();

        textMesh.fontSize = 6 * scaleValue;
        textMesh.transform.localScale = textMesh.transform.localScale / scaleValue;

        textMesh.color = (score > 0) ? Color.green : Color.red;
    }
}
