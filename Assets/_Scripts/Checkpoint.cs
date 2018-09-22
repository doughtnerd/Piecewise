using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public static event Action CheckpointAction;

	// Use this for initialization
	void Start () {
	}

    private void OnTriggerEnter(Collider other)
    {
        CheckpointAction.Invoke();
    }

    // Update is called once per frame
    void Update () {
	}
}
