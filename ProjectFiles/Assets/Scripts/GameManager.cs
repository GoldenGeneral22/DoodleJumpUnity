using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Prefab, GameOverPanel, UIPanel, pausePanel;

    public bool dead, paused;

    public int enemies, deaths, pickUps, bullets, newenemies;

    public Transform mainCamera, player;
    Transform upperBound, lowerBound, leftBound, rightBound;

    private void Start()
    {
        upperBound = mainCamera.Find("UpperBoundary");
        lowerBound = mainCamera.Find("LowerBoundary");
        leftBound = mainCamera.Find("LeftBoundary");
        rightBound = mainCamera.Find("RightBoundary");

        RenderPlatforms();
    }

    private void Update()
    {
        if(dead != true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseGame();
            }
        }
    }

    private void RenderPlatforms()
    {
        Vector3 spawnPosition = new Vector3(0, lowerBound.position.y + 0.5f, 0);

        Instantiate(Prefab, spawnPosition, Quaternion.identity);

        float test = upperBound.position.y + 5f;

        while(spawnPosition.y < test == true)
        {
            spawnPosition.x = Random.Range(-9f, 9f);
            spawnPosition.y += Random.Range(0.5f, 1.5f);
            Instantiate(Prefab, spawnPosition, Quaternion.identity);
        }
    }
    public void BackToMenu()
    {
        PlayerPrefs.SetInt("HighScore", UIPanel.GetComponent<Score_LevelCounter>().highScore);
        enemies += PlayerPrefs.GetInt("Enemies");
        PlayerPrefs.SetInt("Enemies", enemies);
        deaths += PlayerPrefs.GetInt("Deaths");
        PlayerPrefs.SetInt("Deaths", deaths);
        pickUps += PlayerPrefs.GetInt("PickUps");
        PlayerPrefs.SetInt("PickUps", pickUps);
        bullets += PlayerPrefs.GetInt("Bullets");
        PlayerPrefs.SetInt("Bullets", bullets);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        paused = false;
        Time.timeScale = 1;
        UIPanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void pauseGame()
    {
        paused = true;
        Time.timeScale = 0;
        UIPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void EndGame()
    {
        paused = true;
        deaths++;
        dead = true;
        Time.timeScale = 0f;
        GameOverPanel.SetActive(true);
        UIPanel.SetActive(false);
        UIPanel.GetComponent<Score_LevelCounter>().ResetText();
    }

    public void Restart()
    {
        newenemies = 0;
        paused = false;
        dead = false;
        Time.timeScale = 1f;
        GameOverPanel.SetActive(false);
        UIPanel.SetActive(true);

        Vector3 camPosition = new Vector3(0, 0, -10);
        mainCamera.position = camPosition;

        Vector3 playerPosition = new Vector3(0, lowerBound.position.y + 2.5f, 0);
        player.position = playerPosition;

        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Plattform");
        GameObject[] pickUps = GameObject.FindGameObjectsWithTag("pickUp");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");

        foreach (GameObject platform in platforms)
            GameObject.Destroy(platform);

        foreach (GameObject pickup in pickUps)
            GameObject.Destroy(pickup);

        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);

        foreach (GameObject bullet in bullets)
                GameObject.Destroy(bullet);

        RenderPlatforms();
    }
}
