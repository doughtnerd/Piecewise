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

    public static ObstacleSelectionUI Instance;

    [SerializeField]
    private GameObject uiPanel;


    private void Awake()
    {
        Instance = this;
    }

    void Show (bool setActive)
    {
        uiPanel.SetActive(setActive);
    }

    public void AutoAssignSelection()
    {
        while(selected != MAX_SELECTION_SIZE)
        {
            for(int i = 0; i < available.Count; i++)
            {
                ObstacleType type = available[i];
                if(!selection.Contains(type))
                {
                    ObstacleSelected(i);
                    break;
                }
            }
        }
    }

    public void ObstacleSelected(int buttonIndex)
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
