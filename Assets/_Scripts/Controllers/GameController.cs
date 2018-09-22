using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    [SerializeField]
    private int gameScene;
    private IEnumerator timerCoroutine;

    private float TIMER_INTERVAL = 1;
    private float TIMER_DURATION = 3;
    public static readonly float OBSTACLE_MOVEMENT_SPEED = 5;

    // Use this for initialization
    void Start()
    {

        Checkpoint.CheckpointAction += HandleCheckpoint;
        ObstacleSelectionUI.ObstaclesSelectedEvent += HandleObstacleSelection;
    }

    // Update is called once per frame
    void Update()
    {

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
        // To-do: Show checkpoint UI
        // Assign input handler
        timerCoroutine = RunTimer(TIMER_DURATION);
        StartCoroutine(timerCoroutine);
        HandleSlowdown();
    }

    IEnumerator RunTimer(float duration)
    {
        float startTime = Time.time;
        float endTime = startTime + duration;
        while (Time.time < endTime)
        {
            // Fire events for UI
            yield return new WaitForSeconds(TIMER_INTERVAL);
        }

        // To-do: Hide choice UI
        // Resume with new choices
        ObstacleSelectionUI.Instance.AutoAssignSelection();
    }

    void HandleObstacleSelection(List<ObstacleType> selection)
    {
        StopCoroutine(this.timerCoroutine);
    }
}
