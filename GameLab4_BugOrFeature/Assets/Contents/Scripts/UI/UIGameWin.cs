using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameWin : MonoBehaviour, IGameUI
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
        GameStatesManager.instance.SetCurrentGameState(GameStatesManager.GameStates.MainMenu);
    }
    public UIManager.GameUI GetUIType()
    {
        return UIType;
    }
}
