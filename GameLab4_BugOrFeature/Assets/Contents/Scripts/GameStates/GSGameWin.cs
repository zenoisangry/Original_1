using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStatesManager;

public class GSGameWin : IGameStates
{
    public void OnStateEnter()
    {
        GameManager.instance.Pause(true);
    }
    public void OnStateUpdate() { }
    public void OnStateExit()
    {
        UIManager.instance.ResetCurrentUI();
        //LevelManager.instance.DestroyLevel();
        GameManager.instance.Pause(false);
    }
}
