using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class StartMenuPanelManager : MonoBehaviour
{
    public MenuSceneController menuController;
    public GameObject OptionsPanel;
    public GameObject PlayBtn;
    public GameObject QuitBtn;
    public GameObject OptionsBtn;

    public void OpenOptionsPanel()
    {
        if(PlayBtn != null && OptionsBtn != null && QuitBtn != null && OptionsPanel != null)
        {
            //Get Active status of all buttons
            bool panelIsActive = OptionsPanel.activeSelf;
            bool playIsActive = PlayBtn.activeSelf;
            bool optionBtnIsActive = OptionsBtn.activeSelf;
            bool quitIsActive = QuitBtn.activeSelf;
            //Set Active & Not Active to buttons
            OptionsPanel.SetActive(!panelIsActive);
            PlayBtn.SetActive(!playIsActive);
            OptionsBtn.SetActive(!optionBtnIsActive);
            QuitBtn.SetActive(!quitIsActive);
        }
    }

    public void IntroLoadNextScene()
    {
        menuController.SetupRun();
        GameSceneManager.Instance.LoadScene("ControlSchemeScene");
    }

    public void StartMenuToIntro()
    {
        menuController.SetupRun();
        GameSceneManager.Instance.LoadScene("IntroductionScene");
    }

    public void ControlToLevelSelect()
    {
        menuController.SetupRun();
        GameSceneManager.Instance.LoadScene("MapDisplayScene");
    }

    public void PauseToMainMenu()
    {
        menuController.SetupRun();
        GameSceneManager.Instance.LoadScene("MapDisplayScene");
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }
}
