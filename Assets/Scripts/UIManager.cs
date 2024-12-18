using UnityEngine.UI;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Image victoryScreen;
    [SerializeField] private Image splatScreen;
    [SerializeField] private Image TotalHealth;
    [SerializeField] private Image CurrentHealth;
 
    // Start is called before the first frame update
    private void Start()
    {
        victoryScreen.fillAmount = 0;
        splatScreen.fillAmount = 0;
    }

    // Update is called once per frame
    public void UI_UpdateVictory(bool state){
        if (state)
            {
                victoryScreen.fillAmount = 1;
                TotalHealth.fillAmount = 0;
                CurrentHealth.fillAmount = 0;
                splatScreen.fillAmount = 0;
            }
        else if (!state)
            {
                victoryScreen.fillAmount = 0;
                TotalHealth.fillAmount = player.maxHealth * 0.2f;
                CurrentHealth.fillAmount = player.health *0.2f;
                splatScreen.fillAmount = 0;
            }
        else {Debug.Log("Error: UI_UpdateVictory recieved non bool argument");}
    }

    public void UI_UpdateSplat(bool state){
        if (state)
        {   
                victoryScreen.fillAmount = 0;
                TotalHealth.fillAmount = 0;
                CurrentHealth.fillAmount = 0;
                splatScreen.fillAmount = 1;
        }
        else if (!state)
            {
                victoryScreen.fillAmount = 0;
                TotalHealth.fillAmount = player.maxHealth * 0.2f;
                CurrentHealth.fillAmount = player.health *0.2f;
                splatScreen.fillAmount = 0;
            }
        else {Debug.Log("Error: UI_UpdateSplat recieved non bool argument");}
    }
}
