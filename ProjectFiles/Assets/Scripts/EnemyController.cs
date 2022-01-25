using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject gm = GameObject.Find("GameManager");
            gm.GetComponent<GameManager>().enemies++;
            gm.GetComponent<GameManager>().newenemies++;
            GameObject Ui = GameObject.Find("UIpanel");
            if (Ui != null)
            {
                Ui.GetComponent<Score_LevelCounter>().EnemyKilled();
            }
            Destroy(gameObject);
        }
    }
}
