
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementMultiplyer = 5f;
    public float jumpMultiplyer = 5f;
    public int playerHealth = 100;
    public int playerMaxHealth = 100;
    private Rigidbody2D myRigidBody;
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    public bool playerHealthDebug = false; 

    // Start is called before the first frame update
    void Start()
    {
        movementMultiplyer = 5f;
        playerHealth = playerMaxHealth;
    }

    private void Update()
    {
        //===============================================================================================================================================================================
        //                +++ Player Movement +++
        //===============================================================================================================================================================================
        float HorizontalInput  = Input.GetAxis("Horizontal");   

        myRigidBody.velocity = new Vector2 (Input.GetAxis("Horizontal") * movementMultiplyer, myRigidBody.velocity.y); //Takes the player input along the horizontal axis and adds that to the players current velocity * movementMultiplyer
    
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            if (!isAirborne())
            {
                myRigidBody.AddForce(transform.up * jumpMultiplyer, ForceMode2D.Impulse); //Applies upforce once when jump buttons are pressed
            }
        }

        //Scales the player sprite along the x axis to flip it into facing the right direction.
        if(HorizontalInput > 0.01f)
            transform.localScale = Vector3.one * 5;
        else if(HorizontalInput < -0.01f)
            transform.localScale = new Vector3(-5,5,5);


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

}
