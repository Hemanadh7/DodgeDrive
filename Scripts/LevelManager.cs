using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public GameObject helpPanel;
    private bool helpActive = false;
    public GameObject creditsPanel;
    private bool creditsActive;

    private void Update()
    {
        if (helpActive && Input.GetKeyDown(KeyCode.X))
        {
            helpPanel.SetActive(false);
            helpActive = false;
        }

        if(creditsActive && Input.GetKeyDown(KeyCode.X))
        {
            creditsPanel.SetActive(false);
            creditsActive = false;
        }

    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit Requested!");
    }

    public void HelpPanelActive()
    {
        helpPanel.SetActive(true);
        helpActive = true;
    }

    public void CreditsPanelActive()
    {
        creditsPanel.SetActive(true);
        creditsActive = true;
    }

}
