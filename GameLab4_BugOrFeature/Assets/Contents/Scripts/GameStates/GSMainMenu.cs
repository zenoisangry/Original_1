using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStatesManager;

public class GSMainMenu : IGameStates
{
    public void OnStateEnter()
    {
        UIManager.instance.ShowUI(UIManager.GameUI.MainMenu);
        //MusicManager.instance.menutheme();
    }
    public void OnStateUpdate() { }
    public void OnStateExit() { }
}
