using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTarget : Target
{
    public float rotationSpeed = 0.5f;
    public float lifeTime = 20;

    private bool hit = false;
    private float remainTime;
    private GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(45.0f, 0.0f, 0.0f));
        rotationSpeed = (Random.Range(0, 2) == 0) ? rotationSpeed : -rotationSpeed - 1;
        remainTime = lifeTime;
        gameController = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        remainTime -= Time.deltaTime;
         if (remainTime <= 0) {
             Destroy(gameObject);
         }

        transform.Rotate(new Vector3(0.0f, rotationSpeed, 0.0f), Space.World);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Disk" && !hit) {
            hit = true;
            gameController.GetComponent<ScoreController>().AddScore(value);
            DisplayScore();
        }
    }
}
