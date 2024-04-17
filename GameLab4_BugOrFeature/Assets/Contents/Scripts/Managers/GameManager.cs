using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameStatesManager.GameStates startingGameState;
    public bool isPauseMenuOpened = false;
    public bool isGameStarted = false;
    private bool isGamePaused = false;

    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindAnyObjectByType<GameManager>();
            if (_instance == null)
                Debug.LogError("GameManager not found, can't create singleton object");
            return _instance;
        }
    }
    private void Awake()
    {
        GameStatesManager.instance.RegisterState(GameStatesManager.GameStates.MainMenu, new GSMainMenu());
        GameStatesManager.instance.RegisterState(GameStatesManager.GameStates.Options, new GSOptions());
        GameStatesManager.instance.RegisterState(GameStatesManager.GameStates.Pause, new GSPause());
        GameStatesManager.instance.RegisterState(GameStatesManager.GameStates.Gameplay, new GSGameplay());
        GameStatesManager.instance.RegisterState(GameStatesManager.GameStates.GameWin, new GSGameWin());
    }
    private void Start()
    {
        GameStatesManager.instance.SetCurrentGameState(startingGameState);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameStatesManager.instance.SetCurrentGameState(GameStatesManager.GameStates.Pause);
        }
    }
    public void StartGame()
    {
        Debug.Log("Start game");
        //LevelManager.instance.SetCameraCanMove(true);
        isGameStarted = true;
    }
    public void Pause(bool active)
    {
        isGamePaused = active;
        if (active)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public bool IsGameStarted()
    {
        return isGameStarted;
    }
    public bool IsGamePaused()
    {
        return isGamePaused;
    }
}
