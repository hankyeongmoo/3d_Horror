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

    void Start()
    {
        // 마우스 커서를 보이게 하고 고정 해제
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
