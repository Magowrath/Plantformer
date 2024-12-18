using UnityEngine;

public class PlantPot : MonoBehaviour
{

    [SerializeField] private int scoreValue; //The descrete score value for each pot, left variable for ease of modification down the line.
    public PlayerController player; //A simple referance to the player, neccesary for 
    private bool scored = false; //A local variable for keeping track of which pots have already been visited
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TagPlayer")
        {
            if (!scored){
                player.gainScore(scoreValue);
                scored = true;
            }
        }
    }
}
