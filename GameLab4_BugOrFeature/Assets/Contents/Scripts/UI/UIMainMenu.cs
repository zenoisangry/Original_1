using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    public Button playButton;
    public Button optionsButton;
    public Button exitButton;

    public void Init()
    {
        //playButton.onClick.AddListener(OnPlayButtonClick);
        optionsButton.onClick.AddListener(OnOptionsButtonClick);
        //exitButton.onClick.AddListener(OnExitButtonClick);
    }
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    private void OnOptionsButtonClick()
    {
        GameStatesManager.instance.SetCurrentGameState(GameStatesManager.GameStates.Options);
    }
    private void OnQuitButtonClick()
    {
        Application.Quit();
    }
    //public UIManager.GameUI GetUIType() { return UIType; }
}