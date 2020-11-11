using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    /// <summary>
    /// These are the menu function for the buttons.
    /// 
    /// Made by Rashad Patterson 10/14/20
    /// 
    /// </summary>

    public GameObject CreditsPanel;
    public bool isPanelOpen;

    public void StartGame() 
    {
        //Logic to start the game
        const string gameLevel = "SampleScene";

        SceneManager.LoadScene(gameLevel);

    }

    public void OpenCredits() 
    {
        //Logic opens the How to Play and Credits panel of the game
        isPanelOpen = true;
        if (isPanelOpen) 
        {
            CreditsPanel.SetActive(true);
        }

    }

    public void CloseCredits()
    {
        //Logic close the How to Play and Credits panel of the game
        isPanelOpen = false;
        if (isPanelOpen == false && Input.GetKeyDown(KeyCode.Backspace))
        {
            CreditsPanel.SetActive(false);
        }

    }

    public void QuitGame()
    {
        //Quits the Game
        Application.Quit();

    }
}
