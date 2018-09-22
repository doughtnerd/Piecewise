using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float translationSpeed;
    public float jumpHeight;

    public Rigidbody playerRigidBody;


    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        playerRigidBody.transform.position += Vector3.right * translationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            playerRigidBody.transform.position += Vector3.up * jumpHeight * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //do crouch stuff
        }
    }
    
    /*
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        playerRigidBody.AddForce(movement * speed);
    }
    */
}

