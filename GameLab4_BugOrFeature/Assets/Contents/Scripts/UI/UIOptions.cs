using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOptions : MonoBehaviour, IGameUI
{
    public UIManager.GameUI UIType;

    public Button mainMenuButton;
    public void Init()
    {
        mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
    }
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    private void OnMainMenuButtonClick()
    {
        if (GameManager.instance.isPauseMenuOpened)
        {
            GameStatesManager.instance.SetCurrentGameState(GameStatesManager.GameStates.Pause);
        }
        else
        {
            GameStatesManager.instance.SetCurrentGameState(GameStatesManager.GameStates.MainMenu);
        }
    }
    public UIManager.GameUI GetUIType()
    {
        return UIType;
    }
}
