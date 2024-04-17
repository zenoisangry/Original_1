using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStatesManager;

public class GSGameplay : IGameStates
{
    public void OnStateEnter()
    {
        if (!GameManager.instance.IsGameStarted())
        {
            //LevelManager.instance.InitializeLevel();
        }
        //MusicManager.instance.leveltheme();
        UIManager.instance.ShowUI(UIManager.GameUI.Gameplay);
    }
    public void OnStateUpdate()
    {
        if (!GameManager.instance.IsGameStarted() && Input.anyKeyDown)
        {
            GameManager.instance.StartGame();
        }
    }
    public void OnStateExit() { }
}
