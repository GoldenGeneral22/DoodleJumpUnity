using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform upperBound, lowerBound, leftBound, rightBound;
    public Transform player;

    private void Start()
    {
        upperBound = transform.Find("UpperBoundary");
        lowerBound = transform.Find("LowerBoundary");
        leftBound = transform.Find("LeftBoundary");
        rightBound = transform.Find("RightBoundary");
    }
    void Update()
    {
        if(player.position.y > (upperBound.position.y + lowerBound.position.y)/2)
        { 
            float newY = player.position.y;
            transform.position = new Vector3(0, newY, -10);
        }
    }
}

