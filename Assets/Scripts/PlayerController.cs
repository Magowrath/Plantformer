using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementMultiplyer = 1f;
    public float jumpMultiplyer = 1f;
    public int playerHealth = 100;
    public int playerMaxHealth = 100;
    private Vector3 moveVector;
    private Rigidbody2D myRigidBody;
    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }
    bool playerJumping = false;
    public bool playerHealthDebug = false; 

    // Start is called before the first frame update
    void Start()
    {
        movementMultiplyer = 1f;
        playerHealth = playerMaxHealth;
    }

    private void Update()
    {
        //===============================================================================================================================================================================
        //                +++ Player Movement +++
        //===============================================================================================================================================================================
        moveVector = new Vector3 (0f, 0f, 0f);
        
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!playerJumping)
            {
                myRigidBody.AddForce(transform.up * jumpMultiplyer, ForceMode2D.Impulse); 
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveVector += new Vector3(-1,0,0) * movementMultiplyer;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveVector += new Vector3(1,0,0) * movementMultiplyer;
        }
        // if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        // {
            
        // }
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
