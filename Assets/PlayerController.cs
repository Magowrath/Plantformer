using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float movementMultiplyer = 1f;
    public float jumpMultiplyer = 1f;
    public int playerHealth = 100;
    public int playerMaxHealth = 100;



    bool playerJumping = false;
    public bool playerHealthDebug = false; 

    // Start is called before the first frame update
    void Start()
    {
        movementMultiplyer = 1f;
        playerHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            
        }
        if (Input.GetKey(KeyCode.A))
        {

        }
        if (Input.GetKey(KeyCode.D))
        {

        }
        if (Input.GetKey(KeyCode.S))
        {

        }
    }

//===============================================================================================================================================================================
//                +++ Player Health +++
//===============================================================================================================================================================================

    public void loseHealth(int healthLost){
        if (healthLost <= playerHealth){
            instantDeath();
        }
        else {
            playerHealth -= healthLost;
        }
        checkHealth();
    }

    public void instantDeath(){}
    int checkHealth(){

        if (playerHealth > playerMaxHealth){
            playerHealth = playerMaxHealth;
            return 2;
        }
        else if (playerHealth < 0){
            playerHealth = 0;
            return 0;
        }
        else{
            return 1;
        }

        
    }

}
