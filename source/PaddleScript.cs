using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public bool autoPlay = false;
    BallScript theBall;

    void Start ()
    {
        theBall = GameObject.FindObjectOfType<BallScript>();
    }

    void Update ()
    {
        if (!autoPlay)
        {
            MovieWithMouse();
        }
        else {
            AutoPlay();
        }
    }

    void MovieWithMouse ()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        float mouseInBlock = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mouseInBlock, 0.5f, 15.5f);
        this.transform.position = paddlePos;
    }

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPos = theBall.transform.position;

        paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);
        this.transform.position = paddlePos;
    }
}
