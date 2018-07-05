using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseColliderScript : MonoBehaviour
{
    LevelManagerScript levelManager;
    void OnTriggerEnter2D(Collider2D trigger)
    {
        levelManager = GameObject.FindObjectOfType<LevelManagerScript>();
        levelManager.LoadState("Loose Screen");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        print("collision");
    }
}
