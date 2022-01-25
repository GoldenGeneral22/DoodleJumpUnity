using UnityEngine;
using UnityEngine.UI;

public class Score_LevelCounter : MonoBehaviour
{
    public Text height;

    public GameManager gm;

    public Transform player;

    public int heightValue = 0, oldYPosition, oldValue, heightDifference, enemyworth, highScore, newValue;

    public Text highscoreUI;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highscoreUI.text = "Highscore: " + highScore.ToString();
    }

    void Update()
    {
        heightValue = Mathf.RoundToInt(player.position.y);

        if(heightValue > newValue)
        {
            newValue = heightValue;
        }
        oldValue = newValue + (gm.GetComponent<GameManager>().newenemies * enemyworth);
        height.text = oldValue.ToString();
    }

    public void ResetText()
    {
        height.text = "0";
        if(oldValue > highScore)
        {
            highScore = oldValue;
            highscoreUI.text = "Highscore: " + highScore.ToString();
        }
        newValue = 0;
        oldValue = 0;
        height.text = oldValue.ToString();
    }

    public void EnemyKilled()
    {
        oldValue += enemyworth;
    }
}
