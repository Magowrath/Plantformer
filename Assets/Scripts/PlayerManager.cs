using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float jumpMultiplyer = 1.0f;
    public float movementMultiplyer = 1.0f;
    public Rigidbody2D myRigidBody2D;
    Vector2 moveDirection = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody2D.AddForce(Vector2.up * jumpMultiplyer, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            myRigidBody2D.AddForce(Vector2.left * movementMultiplyer, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            myRigidBody2D.AddForce(Vector2.right * movementMultiplyer, ForceMode2D.Force);
        }
    }
}
