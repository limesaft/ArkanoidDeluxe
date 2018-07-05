using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    PaddleScript paddle;
    Vector3 paddleToBallVector;
    bool hasStarted = false;

    // se över paddlens position för att få bollen att följa med
    void Start ()
    {
        paddle = GameObject.FindObjectOfType<PaddleScript>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
    }

    void Update ()
    {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0))
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
                hasStarted = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(0f, 0.2f));

        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
