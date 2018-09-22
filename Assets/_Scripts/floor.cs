using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{
    public Rigidbody floorRigidBody;
    private float translationSpeed;

    void Start()
    {
        translationSpeed = GameController.OBSTACLE_MOVEMENT_SPEED;
        floorRigidBody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //floorRigidBody.transform.position += Vector3.left * translationSpeed * Time.deltaTime;
        floorRigidBody.MovePosition(transform.position + Vector3.left * translationSpeed * Time.deltaTime);
    }
}
