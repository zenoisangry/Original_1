using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStatesManager;

public class GSOptions : IGameStates
{
    public void OnStateEnter()
    {
        UIManager.instance.ShowUI(UIManager.GameUI.Options);
        GameManager.instance.Pause(true);
    }
    public void OnStateUpdate() { }
    public void OnStateExit()
    {
        GameManager.instance.Pause(false);
    }
}
