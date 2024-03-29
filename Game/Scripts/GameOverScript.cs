using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Text RoundsText;

    public SceneFader SceneFader;

    public string MenuSceneName = "MainMenu";

    private void OnEnable()
    {
        RoundsText.text = PlayerStats.Rounds.ToString();
    }
    public void Retry()
    {
        SceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneFader.FadeTo(MenuSceneName);
    }
}
