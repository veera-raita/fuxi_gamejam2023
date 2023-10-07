using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Button StartButton;

    void Start()
    {
        Button btn = StartButton.GetComponent<Button>();
        btn.onClick.AddListener(() => SceneChange());
    }

    public void SceneChange()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

}
