using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Runtime.CompilerServices;
using System.Data;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Image victoryScreen;
    [SerializeField] private Image splatScreen;

    // Start is called before the first frame update
    private void Start()
    {
        victoryScreen.fillAmount = 0;
        splatScreen.fillAmount = 0;
        MethodA(gameObject);
    }

    // Update is called once per frame
    public void UI_UpdateVictory(bool state){
        float fill = 0;
        if (state)
            {
                fill = 1;
            }
        else if (!state)
            {
                fill = 0;
            }
        else {Debug.Log("Error: UI_UpdateVictory recieved non bool argument");}
        victoryScreen.fillAmount = fill;
    }

    public void MethodA(GameObject g)
    {
        Debug.Log("Object " +g.name+ " has called Method A");
    }
}
