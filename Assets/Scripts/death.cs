using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class death : MonoBehaviour {

    public static event Action PlayerDeathEvent;

    void OnCollisionEnter(Collision  collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            function1();
            function2();

        }
    }

    void function1()
    {

    }
    void function2()
    {

    }
}
