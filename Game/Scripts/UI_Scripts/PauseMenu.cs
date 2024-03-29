using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject UI;

    public string MenuSceneName = "MainMenu";

    public SceneFader SceneFader;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        if (GameManager.GameIsOver)
            return;

        UI.SetActive(!UI.activeSelf);

        if (UI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Menu()
    {
        Toggle();
        SceneFader.FadeTo(MenuSceneName);
    }

    public void Retry()
    {
        //WaveSpawner.enemiesAlive = 0;

        Toggle();
        SceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
}
