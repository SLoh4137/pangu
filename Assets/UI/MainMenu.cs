using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace pangu
{
    public enum Scenes
    {
        Main,
        MainMenu,
    }
    public class MainMenu : MonoBehaviour
    {
        public GameObject MenuPage;
        public GameObject CreditsPage;
        public void PlayGame()
        {
            SceneManager.LoadScene(Scenes.Main.ToString());
        }

        public void QuitGame()
        {
            Debug.Log("Game exited");
            Application.Quit();
        }

        public void ShowCredits()
        {
            MenuPage.SetActive(false);
            CreditsPage.SetActive(true);
        }

        public void Back()
        {
            MenuPage.SetActive(true);
            CreditsPage.SetActive(false);
        }
    }
}

