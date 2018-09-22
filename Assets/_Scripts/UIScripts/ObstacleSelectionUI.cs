using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class ObstacleSelectionUI : MonoBehaviour {

    private List<Obstacle> selection = new List<Obstacle>();
    private List<Obstacle> available = new List<Obstacle>();
    private int selected = 0;

    private int MAX_SELECTION_SIZE = 3;

    public static Action<List<Obstacle>> ObstaclesSelectedEvent;

    public static ObstacleSelectionUI Instance;

    public GameObject buttonContainer;

    [SerializeField]
    private Text timertext;

    [SerializeField]
    private GameObject uiPanel;

    private void Awake()
    {
        Instance = this;
        GameController.TimerTickEvent += HandleTimerTickEvent;
    }

    private void HandleTimerTickEvent(int time)
    {
        this.timertext.text = time + "";
    }

    public void Show (bool setActive)
    {
        uiPanel.SetActive(setActive);
    }

    public void SetAvailableObstacles(List<Obstacle> obstacles)
    {
        this.available = obstacles;

        for(int i = 0; i < 5; i++)
        {
            Image button = buttonContainer.transform.GetChild(i).GetComponent<Image>();
            button.sprite = obstacles[i].obstacleSprite;
        }
    }

    public void AutoAssignSelection()
    {
        for(int i = 0; i < available.Count && selected < MAX_SELECTION_SIZE; i++)
        {
            Obstacle type = available[i];
            if(!selection.Contains(type))
            {
                ObstacleSelected(i);
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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) ObstacleSelected(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) ObstacleSelected(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) ObstacleSelected(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) ObstacleSelected(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) ObstacleSelected(4);
    }


}
