using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Button StartButton;
    public Button CreditsButton;
    public Button CloseMenu;
    public Button QuitGame;

    public GameObject CreditsShade;
    public GameObject CreditsScreen;
    public GameObject CloseMenuHandler;

    void Start()
    {
        StartButton.onClick.AddListener(() => SceneChange());
        CreditsButton.onClick.AddListener(() => ShowCredits());
        CloseMenu.onClick.AddListener(() => CloseCredits());
        QuitGame.onClick.AddListener(() => EndGame());
    }

    public void SceneChange()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void ShowCredits()
    {
        CreditsShade.SetActive(true);
        CreditsScreen.SetActive(true);
        CloseMenuHandler.SetActive(true);
    }     

    private void CloseCredits()
    {
        CreditsShade.SetActive(false);
        CreditsScreen.SetActive(false);
        CloseMenuHandler.SetActive(false);
    }

    private void EndGame()
    {
        Application.Quit();
    }

}
