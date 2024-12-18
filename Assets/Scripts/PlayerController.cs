using UnityEngine;  //Boilerplate
using UnityEngine.SceneManagement; //Needed for scene reset.

public class PlayerController : MonoBehaviour  //Boilerplate
{

//===============================================================================================================================================================================
//          Declerations
//===============================================================================================================================================================================

    public float movementMultiplyer;  //Linear scale on the players movement speed.
    public bool isAlive {get; private set;} = true; //Used by the animator to set the players dead state, updated by playerVictory() & playerDeath() functions.
    public float jumpMultiplyer; //linear scale on the players jump force.
    public float health {get; private set;} //The players current health.
    public float score ; //Players current score, updated by gainScore(), often called by plantPot.cs.
    public float maxScore ; //The players target score, this initates the win condition to trigger playerVictory().
    public float maxHealth {get; private set;} = 3; //Players maximum health, current UI will accomodate between 1 & 5.

    //A number of referances for components of the player gameObject
    private Rigidbody2D myRigidBody;
    private BoxCollider2D boxCollider;
    public UIManager MyUIManager; //A linking step to allow for calling UI functions within the PlayerController
    private Animator anim;
    [SerializeField] private LayerMask groundLayer; //Serialization makes private variables load from memory, allowing for data to be seved outside runtime.
    
    //Awake is called before Start and runs whenever the script is loaded even if it's disabled. I have used it primarially for obtaing referances to make sure they are
    //loaded before anything else happens.
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
        health = maxHealth; //Does what it says on the tin, ensures players starting health always matches the maximum health for the scene.
        maxScore = 3;
        score = 0;
    }
//===============================================================================================================================================================================
//      Update
//===============================================================================================================================================================================
    private void Update()
    {
        //While the player is alive runs the movement script
        if (isAlive){
            playerMovement();
        }

        //Watches for keypresses on R for the reset code
        if (Input.GetKeyDown(KeyCode.R)){
            restartScene();
        }

        //Update player animation when health drops to 0
        anim.SetBool("Dead", !isAlive);
    }

//===============================================================================================================================================================================
//                +++ Player Health +++
//===============================================================================================================================================================================

    //Simple function for reducing the players health.
    public void loseHealth(int healthLost){
        health -= healthLost;
        checkHealth();
        }
    //Similar function for gaining health, currently unused.
    public void gainHealth(int healthGain){
        health += healthGain;
        checkHealth();
    }

    void checkHealth(){     //Manually clamps the health value and triggers playerDeath() when health hits 0.
        if (health > maxHealth){
            health = maxHealth;
        }
        if (health <= 0){
            health = 0;
            playerDeath();
        }
    }

    //Updates isAlive and calls the death screen from the UIManager.
     public void playerDeath(){
        isAlive = false;
        MyUIManager.UI_UpdateSplat(true);
    }

//===============================================================================================================================================================================
//                +++ Player Score +++
//===============================================================================================================================================================================

    //Simple script for gaining score.
    public void gainScore(int scoreGained){
        score += scoreGained;
        checkScore();
    }


    void checkScore(){     //Limits players score to within certain values and calls playerVictory when 
        if (score >= maxScore){
            score = 3;
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
