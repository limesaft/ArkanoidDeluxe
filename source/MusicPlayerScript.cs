using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{
    // kollar om musikinstansen finns för att inte duplicera den vid nästa sceneladdning
    static bool isThereInstance = false;

    void Awake()
    {
        if (isThereInstance)
        {
            Destroy(gameObject);
        }
        isThereInstance = true;
        GameObject.DontDestroyOnLoad(gameObject);
    }
}
