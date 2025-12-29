using UnityEngine;

public class CameraMove : MonoBehaviour
{
    static public bool isCameraMove;
    private int moveCount;

    void Awake()
    {
        isCameraMove = false;
        moveCount = 0;
    }

    void FixedUpdate()
    {
        if (isCameraMove)
        {
            transform.position += new Vector3(0, 0, 0.5f * Time.deltaTime);
            moveCount++;
            if (moveCount >= 200)
            {
                Loading.LoadScene("Game");
            }
        }
    }
}
