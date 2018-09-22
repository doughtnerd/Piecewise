using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    //public float jumpHeight;

    private Rigidbody playerRigidBody;
    private Vector3 crouchHeight = new Vector3 (1,.5f,1);
    private Vector3 normalHeight = new Vector3(1, 1, 1);


    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        //playerRigidBody.transform.position += Vector3.right * translationSpeed * Time.deltaTime;

        //if (Input.GetKey(KeyCode.W))
        //{
        //    //playerRigidBody.transform.position += Vector3.up * jumpHeight * Time.deltaTime;
        //    playerRigidBody.AddForce(Vector3.up * jumpHeight * Time.deltaTime * 2, ForceMode.Impulse);
        //}

        if (Input.GetKey(KeyCode.S))
        {
            //do crouch stuff
            gameObject.transform.localScale = crouchHeight;
        }
        else
        {
            gameObject.transform.localScale = normalHeight;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpingCharacter jump = GetComponent<JumpingCharacter>();
            jump.Jump();
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

