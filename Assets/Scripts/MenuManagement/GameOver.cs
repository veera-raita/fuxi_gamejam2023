using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Button RestartButton;
    public Button MenuButton;

    public AudioClip MenuClick;
    public AudioSource MenuClickPlayer;

    public GameObject GameOverScrn;
    public GameObject StatBlock;
    public GameObject Waveinfo;
    public GameObject healthinfo;


    public void Start()
    {
        
    }

    public void DoStuff()
    {
        GameOverScrn.SetActive(true);
        StatBlock.SetActive(false);        
        Waveinfo.SetActive(false);
        healthinfo.SetActive(false);
        RestartButton.onClick.AddListener(() => Clicker());
        RestartButton.onClick.AddListener(() => SceneRestart());
        MenuButton.onClick.AddListener(() => Clicker());
        MenuButton.onClick.AddListener(() => ReturnMenu());
    }

    private void Clicker()
    {
        MenuClickPlayer.PlayOneShot(MenuClick, 1.0f);
    }

    private void SceneRestart()
    {
        SceneManager.LoadScene(1);
    }
    private void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }
}
