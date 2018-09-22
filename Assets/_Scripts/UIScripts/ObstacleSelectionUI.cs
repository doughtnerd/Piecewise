using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObstacleSelectionUI : MonoBehaviour {
    private List<ObstacleType> selection = new List<ObstacleType>();
    private List<ObstacleType> available = new List<ObstacleType>();
    private int selected = 0;

    private int MAX_SELECTION_SIZE = 3;

    public static Action<List<ObstacleType>> ObstaclesSelectedEvent;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Open ()
    {

    }

    void ObstacleSelected(int buttonIndex)
    {
        if (selected != MAX_SELECTION_SIZE)
        {
            selection.Add(available[buttonIndex]);
            selected += 1;
        }
        else
        {
            if (ObstaclesSelectedEvent != null)
            {
                ObstaclesSelectedEvent(selection);
            }
        }
    }
}
