using Unity.VisualScripting;
using UnityEngine;
using static UIManager;
public class PlayerController : MonoBehaviour
{
    public float movementMultiplyer;
    public bool isAlive {get; private set;} = true;
    public float jumpMultiplyer;
    public float health {get; private set;}
    public float maxHealth {get; private set;} = 3;
    private Rigidbody2D myRigidBody;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    public UIManager MyUIManager;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Sprite deathSprite;
    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public bool playerHealthDebug = false; 

    void Start()
    {
        health = maxHealth;
        MyUIManager = GameObject.FindGameObjectWithTag("TagUIManager").GetComponent<UIManager>();
        MyUIManager.MethodA(gameObject);
    }

    private void Update()
    {
        if (isAlive){
            playerMovement();

        }

        if (Input.GetKeyDown(KeyCode.E)){
            loseHealth(1);
        }
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
        Debug.Log(health);
    }

     public void playerDeath(){
        spriteRenderer.sprite = deathSprite;
        Debug.Log("PlayerController has been killed");
        isAlive = false;
    }




    private void playerMovement()
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

        myRigidBody.rotation = 0;

        //Scales the player sprite along the x axis to flip it into facing the right direction.
        if(HorizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one ;
        }

        else if(HorizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
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
