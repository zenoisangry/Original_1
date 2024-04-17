using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStatesManager;

public class GSPause : IGameStates
{
    public void OnStateEnter()
    {
        UIManager.instance.ShowUI(UIManager.GameUI.Pause);
        GameManager.instance.isPauseMenuOpened = true;
        //MusicManager.instance.pausetheme();
        GameManager.instance.Pause(true);
    }
    public void OnStateUpdate() { }
    public void OnStateExit()
    {
        GameManager.instance.Pause(false);
    }
}
