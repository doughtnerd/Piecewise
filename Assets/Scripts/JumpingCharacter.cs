using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class JumpingCharacter : MonoBehaviour
{
    public static event Action<AudioClip> PlaySound;

    [SerializeField]
    private float jumpPower = 5f;

    [SerializeField]
    private int jumpCount = 2;

    [SerializeField]
    private AudioClip jumpClip;

    //[SerializeField]
    //private string groundLayerName;

    [SerializeField]
    private LayerMask groundLayer;

    private bool isGrounded;
    private int currentJump = 0;


    private Rigidbody rigid;
    private Animator anim;


    private void Start()
    {
        this.rigid = GetComponent<Rigidbody>();
        //this.anim = GetComponent<Animator>();
    }

    public void Jump()
    {
        if (isGrounded || currentJump < jumpCount)
        {
            this.isGrounded = false;

            if (PlaySound != null)
            {
                PlaySound(jumpClip);
            }

            if (this.currentJump == 0)
            {
                //this.anim.SetBool("jumping", true);
            }
            this.currentJump++;

            if (this.currentJump > 0)
            {
                this.rigid.velocity = Vector3.zero;
            }
            this.rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 collisionDirection = collision.contacts[0].point - new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Debug.DrawRay(transform.position, collisionDirection, Color.red, 2);
        if (collisionDirection.y < 0)
        {
            if (LayerMask.GetMask(LayerMask.LayerToName(collision.gameObject.layer)) == groundLayer.value)
            {
                this.isGrounded = true;
                //this.anim.SetBool("jumping", false);
                this.currentJump = 0;
            }
        }
    }
}