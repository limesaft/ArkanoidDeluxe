using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHitScript : MonoBehaviour
{
    public AudioClip crack;
    public Sprite[] hitSprites;
    public GameObject smoke;
    public static int breakableCount = 0;

    LevelManagerScript levelManager;
    bool isBreakable;
    int amountHits;

    // Hämtar hem levelManagern samt kollar igenom antal brickor på spelfältet  
    void Start ()
    {
        isBreakable = (this.tag == "Breakable");

        if (isBreakable)
        {
            breakableCount++;
        }
        amountHits = 0;
        levelManager = FindObjectOfType<LevelManagerScript>();
	}

    void OnCollisionExit2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position, 0.8f);

        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        int maxHits = hitSprites.Length + 1;
        amountHits++;

        if (amountHits >= maxHits)
        {
            breakableCount--;
            Destroy(gameObject);
            GameObject smokePuff = Instantiate (smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
            smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
            levelManager.BrickDestroyed(breakableCount);
        }
        else
        {
           LoadSprites();
        }
    }

    // uppdatera blockets sprite om det har liv kvar 
    void LoadSprites()
    {
        int spriteIndex = amountHits - 1;

        if (hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("sprite is missing");
        }
    }

    void SimulateWin()
    {
        levelManager.LoadNextPlayLevel();
    }
}
