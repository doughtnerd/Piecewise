using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public static event Action CheckpointAction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && CheckpointAction != null)
        {
            CheckpointAction.Invoke();
        }
    }
}
