using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlantPot : MonoBehaviour
{

    [SerializeField] private float scoreValue;
    public PlayerController player;
    private bool scored = false;

    
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TagPlayer")
        {
            if (!scored){
                player.gainScore(1);
                scored = true;
            }
        }
    }
}
