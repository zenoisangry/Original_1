using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPause : MonoBehaviour, IGameUI
{
    public UIManager.GameUI UIType;

    public Button continueButton;
    public Button quitButton;

    public void Init()
    {
        continueButton.onClick.AddListener(OnContinueButtonClick);
        quitButton.onClick.AddListener(OnQuitButtonClick);
    }
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    private void OnContinueButtonClick()
    {
        GameManager.instance.isPauseMenuOpened = false;
        GameManager.instance.isGameStarted = true;
        GameStatesManager.instance.SetCurrentGameState(GameStatesManager.GameStates.Gameplay);
    }
    private void OnQuitButtonClick()
    {
        Application.Quit();
    }
    public UIManager.GameUI GetUIType()
    {
        return UIType;
    }
}
