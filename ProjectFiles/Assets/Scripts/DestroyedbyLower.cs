using UnityEngine;

public class DestroyedbyLower : MonoBehaviour
{
    private GameObject lowerBound;

    private void Start()
    {
        lowerBound = GameObject.FindGameObjectWithTag("lower");
    }
    private void Update()
    {
        if (lowerBound.transform.position.y > transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
