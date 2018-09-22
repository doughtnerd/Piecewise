using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour {

    public static event Action PlayerDeathEvent;

    void OnCollisionEnter(Collision  collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            SceneManager.LoadScene("DeathScreen");

        }
    }

    
}
