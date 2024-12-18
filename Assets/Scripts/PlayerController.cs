using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
public class PlayerController : MonoBehaviour
{

//===============================================================================================================================================================================
//          Declerations
//===============================================================================================================================================================================

    public float movementMultiplyer;
    public bool isAlive {get; private set;} = true;
    public float jumpMultiplyer;
    public float health {get; private set;}
    public float score = 0;
    public float maxScore = 3;
    public float maxHealth {get; private set;} = 3;
    private Rigidbody2D myRigidBody;
    private BoxCollider2D boxCollider;
    public UIManager MyUIManager;
    private Animator anim;
    [SerializeField] private LayerMask groundLayer; //Serialization makes private variables load from memory, allowing for data to be seved outside runtime.
    private void Awake()
    {
        //Grabs referances from self
        myRigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

        //Grabs Referances scripts on other GameObjects
        MyUIManager = GameObject.FindGameObjectWithTag("TagUIManager").GetComponent<UIManager>();
    }

    void Start()
    {
        health = maxHealth; //Does what it says on the tin
    }
//===============================================================================================================================================================================
//      Update
//===============================================================================================================================================================================
    private void Update()
    {
        if (isAlive){
            playerMovement();
        }

        if (Input.GetKeyDown(KeyCode.R)){
            restartScene();
        }

        if (Input.GetKeyDown(KeyCode.E)){
            gainScore(1);
        }
        if (Input.GetKeyDown(KeyCode.Q)){
            loseHealth(1);
        }
        anim.SetBool("Dead", !isAlive);
    }

//===============================================================================================================================================================================
//                +++ Player Health +++
//===============================================================================================================================================================================

    public void loseHealth(int healthLost){
        health -= healthLost;
        checkHealth();
        }

    public void gainHealth(int healthGain){
        health += healthGain;
        checkHealth();
    }

    void checkHealth(){     //Limits players health to within certain values
        if (health > maxHealth){
            health = maxHealth;
        }
        if (health <= 0){
            health = 0;
            playerDeath();
        }
    }

     public void playerDeath(){
        isAlive = false;
        MyUIManager.UI_UpdateSplat(true);
    }

//===============================================================================================================================================================================
//                +++ Player Score +++
//===============================================================================================================================================================================

    public void gainScore(int scoreGained){
        score += scoreGained;
        checkScore();
    }

    void checkScore(){     //Limits players health to within certain values
        if (score >= 3f){
            score = 3f;
            playerVictory();
        }
        else if (score <= 0){
            score = 0;
        }
    }

    void playerVictory()
    {   
        isAlive = false;
        MyUIManager.UI_UpdateVictory(true);
    }

//===============================================================================================================================================================================
//                +++ Player Movement +++
//===============================================================================================================================================================================

    private void playerMovement()
    {
        
        float HorizontalInput  = Input.GetAxis("Horizontal");   

        myRigidBody.velocity = new Vector2 (Input.GetAxis("Horizontal") * movementMultiplyer, myRigidBody.velocity.y); //Takes the player input along the horizontal axis and adds that to the players current velocity * movementMultiplyer
    
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            if (!isAirborne())
            {
                myRigidBody.AddForce(transform.up * jumpMultiplyer, ForceMode2D.Impulse); //Applies upforce once when jump buttons are pressed
            }
        }

        myRigidBody.rotation = 0; //prevents player from falling on its side 

        //Scales the player sprite along the x axis to flip it into facing the right direction.

        if(HorizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one ;
        }

        else if(HorizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        
        //Set Animator params

        anim.SetBool("Walking", HorizontalInput != 0);

    }

    private bool isAirborne()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        if (raycastHit.collider == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

//===============================================================================================================================================================================
//          Extras
//===============================================================================================================================================================================
    
    public void restartScene()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
