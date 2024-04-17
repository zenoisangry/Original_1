using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPause : MonoBehaviour, IGameUI
{
    public UIManager.GameUI UIType;

    public Button continueButton;
    public Button mainMenuButton;

    public void Init()
    {
        continueButton.onClick.AddListener(OnContinueButtonClick);
        mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
    }
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    private void OnContinueButtonClick()
    {
        GameManager.instance.isPauseMenuOpened = false;
        GameStatesManager.instance.SetCurrentGameState(GameStatesManager.GameStates.Gameplay);
    }
    private void OnMainMenuButtonClick()
    {
        UIManager.instance.ResetCurrentUI();
        //LevelManager.instance.DestroyLevel();
        GameManager.instance.isGameStarted = false;
        GameManager.instance.isPauseMenuOpened = false;
        GameStatesManager.instance.SetCurrentGameState(GameStatesManager.GameStates.MainMenu);
    }
    public UIManager.GameUI GetUIType()
    {
        return UIType;
    }
}
