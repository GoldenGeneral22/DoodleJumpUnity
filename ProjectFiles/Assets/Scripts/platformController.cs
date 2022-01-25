using UnityEngine;

public class platformController : MonoBehaviour
{
    GameObject upperBound, lowerBound;
    public GameObject PickUpPrefab, EnemyPrefab;
    public GameObject UIpanel;

    public int likelinessOfPickUps;

    public int likelinessOfEnemies;

    public Score_LevelCounter Score_LevelCounter;

    private void Start()
    {
        upperBound = GameObject.FindGameObjectWithTag("upper");
        lowerBound = GameObject.FindGameObjectWithTag("lower");
        Score_LevelCounter = GameObject.Find("UIpanel").GetComponent<Score_LevelCounter>();
    }

    private void Update()
    {
        if(lowerBound.transform.position.y - 1.5f > transform.position.y)
        {
            Vector3 newPosition = new Vector3(Random.Range(-9f, 9f), upperBound.transform.position.y + 5 + Random.Range(0.5f, 2f), 0);
            transform.position = newPosition;

            int randomNumber = Random.Range(0, (int) Mathf.Round(likelinessOfPickUps/Score_LevelCounter.oldValue));

            print(randomNumber);

            if(randomNumber == 0)
            {
                Instantiate(PickUpPrefab, new Vector3(transform.position.x, transform.position.y + 0.4f, 0), Quaternion.identity);
            }

            int randomNumber2 = Random.Range(0,(int) Mathf.Round(likelinessOfEnemies/Score_LevelCounter.oldValue));
            if(randomNumber2 == 0)
            {
                Instantiate(EnemyPrefab, new Vector3(transform.position.x, transform.position.y + 0.5f, 0), Quaternion.identity);
            }
        }
    }
}
