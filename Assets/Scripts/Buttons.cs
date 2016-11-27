using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class Buttons : MonoBehaviour
{
    public GameObject popUp;
    public Text titleText;
    public Text creditsText;
    public Text helpText;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        ClosePopUp();
        popUp.SetActive(true);
        titleText.text = "Credits";
        creditsText.enabled = true;
    }

    public void ClosePopUp()
    {
        popUp.SetActive(false);
        creditsText.enabled = false;
        helpText.enabled = false;
    }

    public void Help()
    {
        ClosePopUp();
        popUp.SetActive(true);
        titleText.text = "Help";
        helpText.enabled = true;
    }
}
