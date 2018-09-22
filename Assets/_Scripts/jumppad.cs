using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumppad : MonoBehaviour {

    public int jumpmultiplyer;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "jumppad")
        {

            JumpingCharacter jump = GetComponent<JumpingCharacter>();
            jump.Jump(jumpmultiplyer);

        }
    }


}
