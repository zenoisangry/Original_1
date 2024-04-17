using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UIManager;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public Transform UIContainer;

    public static UIManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindAnyObjectByType<UIManager>();
            if (_instance == null)
                Debug.LogError("UIManager not found, can't create singleton object");
            return _instance;
        }
    }

    public enum GameUI
    {
        NONE,
        MainMenu,
        Options,
        Pause,
        Gameplay,
        GameWin,
    }

    private Dictionary<GameUI, IGameUI> registeredUIs = new Dictionary<GameUI, IGameUI>();
    private IGameUI currentUI = null;

    private void Awake()
    {
        foreach (IGameUI enumeratedUI in UIContainer.GetComponentsInChildren<IGameUI>(true))
        {
            RegisterUI(enumeratedUI.GetUIType(), enumeratedUI);
        }
        ShowUI(GameUI.NONE);
    }
    public void RegisterUI(GameUI UIType, IGameUI UIToRegister)
    {
        registeredUIs.Add(UIType, UIToRegister);
        UIToRegister.Init();
    }
    public void ShowUI(GameUI UIType)
    {
        if (currentUI == null)
        {
            foreach (KeyValuePair<GameUI, IGameUI> kvp in registeredUIs)
            {
                kvp.Value.SetActive(kvp.Key == UIType);
                currentUI = kvp.Key == UIType ? kvp.Value : null;
            }
        }
        else
        {
            registeredUIs[currentUI.GetUIType()].SetActive(false);
            registeredUIs[UIType].SetActive(true);
            currentUI = registeredUIs[UIType];
        }
    }
    public void ResetCurrentUI()
    {
        currentUI = null;
    }
}