using UnityEngine;

public class PlantPot : MonoBehaviour
{

    [SerializeField] private int scoreValue;
    public PlayerController player;
    private bool scored = false;
    
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
