using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStatesManager;

public class GameStatesManager : MonoBehaviour
{
    public IGameStates currentGameState = null;
    private static GameStatesManager _instance;
    public static GameStatesManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<GameStatesManager>();
                if (_instance == null)
                {
                    Debug.LogError("Error can't instantiate singleton");
                }
            }
            return _instance;
        }
    }

    Dictionary<GameStates, IGameStates> registeredGameStates = new Dictionary<GameStates, IGameStates>();
    public enum GameStates
    {
        MainMenu,
        Options,
        Pause,
        Gameplay,
        GameWin,
    }

    public void RegisterState(GameStates gstate, IGameStates state)
    {
        registeredGameStates.Add(gstate, state);
    }
    public void SetCurrentGameState(GameStates gstate)
    {
        if (currentGameState != null)
        {
            currentGameState.OnStateExit();
        }
        IGameStates newState = registeredGameStates[gstate];
        newState.OnStateEnter();
        currentGameState = newState;
    }
    void Update()
    {
        currentGameState?.OnStateUpdate();
    }
}