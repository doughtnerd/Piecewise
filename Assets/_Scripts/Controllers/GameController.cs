using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public static event Action<int> TimerTickEvent;

    public static readonly float OBSTACLE_MOVEMENT_SPEED = 5;

    [SerializeField]
    private int gameScene;

    private static readonly int TIMER_INTERVAL = 1;
    private static readonly int TIMER_DURATION = 3;

    // Use this for initialization
    void Start()
    {
        Checkpoint.CheckpointAction += HandleCheckpoint;
        ObstacleSelectionUI.ObstaclesSelectedEvent += HandleObstacleSelection;
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != Instance)
        {
            Destroy(this);
        }
    }

    void HandleSlowdown()
    {
        Time.timeScale = 0.3f;
    }

    void HandleResumeSpeed()
    {
        Time.timeScale = 1f;
    }

    void OpenDeathMenu()
    {
        // To-do: Call death menu's open function.
    }

    void HandlePlayerDeath()
    {
        // Reset state/scene
        SceneManager.LoadScene(gameScene);
    }

    void HandleCheckpoint()
    {
        // Get pieces to show
        ObstacleSelectionUI.Instance.Show(true);

        StartCoroutine(RunTimer(TIMER_DURATION));
        HandleSlowdown();
    }

    IEnumerator RunTimer(int duration)
    {
        TriggerTimerTickEvent(duration);

        while (duration > 0)
        {
            yield return new WaitForSecondsRealtime(TIMER_INTERVAL);
            duration -= TIMER_INTERVAL;
            TriggerTimerTickEvent(duration);
        }

        TriggerTimerTickEvent(0);

        //ObstacleSelectionUI.Instance.AutoAssignSelection();

        ObstacleSelectionUI.Instance.Show(false);

        HandleResumeSpeed();

        yield return null;
    }

    void TriggerTimerTickEvent(int currentTimerValue)
    {
        if(TimerTickEvent != null)
        {
            TimerTickEvent(currentTimerValue);
        }
    }

    void HandleObstacleSelection(List<Obstacle> selection)
    {
        Spawner spawner = GameObject.FindObjectOfType<Spawner>();
        spawner.SpawnObstacles(selection);
    }
}
