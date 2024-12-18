using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private PlayerController player;
    [SerializeField] private Image totalhealthbar;
    [SerializeField] private Image currenthealthbar;
    // Start is called before the first frame update
    void Start()
    {
        //Sets the background of the healthbar to be the correct length for the number of hit points available in a level.
        //Making this dynamic allows for easier modification of the game and an easier time iterating the design in future.
        totalhealthbar.fillAmount = player.maxHealth * 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        //Update the length of the healthbar to match the players current health.
        currenthealthbar.fillAmount = player.health *0.2f;
    }
}
