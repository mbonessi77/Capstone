using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Canvas TTCanvas;
    public Canvas TutorialCanvas;
    public Canvas MenuCanvas;
    public Canvas RaceCanvas;
    public Canvas CreditsCanvas;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        MenuCanvas.gameObject.SetActive(true);
        TTCanvas.gameObject.SetActive(false);
        TutorialCanvas.gameObject.SetActive(false);
        RaceCanvas.gameObject.SetActive(false);
        CreditsCanvas.gameObject.SetActive(false);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void MainMenu()
    {
        MenuCanvas.gameObject.SetActive(true);
        TTCanvas.gameObject.SetActive(false);
        TutorialCanvas.gameObject.SetActive(false);
        RaceCanvas.gameObject.SetActive(false);
        CreditsCanvas.gameObject.SetActive(false);
    }

    public void TimeTrial()
    {
        MenuCanvas.gameObject.SetActive(false);
        TTCanvas.gameObject.SetActive(true);
        TutorialCanvas.gameObject.SetActive(false);
        RaceCanvas.gameObject.SetActive(false);
        CreditsCanvas.gameObject.SetActive(false);
    }

    public void Instructions()
    {
        MenuCanvas.gameObject.SetActive(false);
        TTCanvas.gameObject.SetActive(false);
        TutorialCanvas.gameObject.SetActive(true);
        RaceCanvas.gameObject.SetActive(false);
        CreditsCanvas.gameObject.SetActive(false);
    }

    public void Race()
    {
        MenuCanvas.gameObject.SetActive(false);
        TTCanvas.gameObject.SetActive(false);
        TutorialCanvas.gameObject.SetActive(false);
        RaceCanvas.gameObject.SetActive(true);
        CreditsCanvas.gameObject.SetActive(false);
    }

    public void Credits()
    {
        MenuCanvas.gameObject.SetActive(false);
        TTCanvas.gameObject.SetActive(false);
        TutorialCanvas.gameObject.SetActive(false);
        RaceCanvas.gameObject.SetActive(false);
        CreditsCanvas.gameObject.SetActive(true);
    }

    public void SetRaceType(string type)
    {
        RaceManager.instance.SetRaceType(type);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
