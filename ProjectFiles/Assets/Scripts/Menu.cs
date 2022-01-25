using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject statPanel, startPanel, dialogPanel;
    public Text HighScore, Enemies, Deaths, PickUps, Bullets;

    private void Start()
    {
        if(PlayerPrefs.GetInt("FirstStartUp") != 1)
        {
            PlayerPrefs.SetInt("FirstStartUp", 1);
            PlayerPrefs.SetInt("HighScore", 0);
            PlayerPrefs.SetInt("Enemies", 0);
            PlayerPrefs.SetInt("Deaths", 0);
            PlayerPrefs.SetInt("PickUps", 0);
            PlayerPrefs.SetInt("Bullets", 0);
        }
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void Statistics()
    {
        HighScore.text = "Highscore: " + PlayerPrefs.GetInt("HighScore").ToString();
        Enemies.text = "Enemies killed: " + PlayerPrefs.GetInt("Enemies").ToString();
        Deaths.text = "Deaths: " + PlayerPrefs.GetInt("Deaths").ToString();
        PickUps.text = "Pick-Ups collected: " + PlayerPrefs.GetInt("PickUps").ToString();
        Bullets.text = "Bullets shot: " + PlayerPrefs.GetInt("Bullets").ToString();
        statPanel.SetActive(true);
        startPanel.SetActive(false);
    }

    public void ResetButton()
    {
        dialogPanel.SetActive(true);
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.SetInt("Enemies", 0);
        PlayerPrefs.SetInt("Deaths", 0);
        PlayerPrefs.SetInt("PickUps", 0);
        PlayerPrefs.SetInt("Bullets", 0);

        HighScore.text = "Highscore: 0";
        Enemies.text = "Enemies killed: 0";
        Deaths.text = "Deaths: 0";
        PickUps.text = "Pick-Ups collected: 0";
        Bullets.text = "Bullets shot: 0";
        dialogPanel.SetActive(false);
    }

    public void Abort()
    {
        dialogPanel.SetActive(false);
    }


    public void Back()
    {
        statPanel.SetActive(false);
        startPanel.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
