using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveText : MonoBehaviour
{
    RectTransform rectTransform;
    private float speed = 3f;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Lobby");
        }
    }

    void FixedUpdate()
    {
        MoveUI(new Vector2(0f, rectTransform.anchoredPosition.y + speed * Time.fixedDeltaTime));
    }

    // 특정 위치로 순간이동 시키는 함수
    public void MoveUI(Vector2 targetPos)
    {
        rectTransform.anchoredPosition = targetPos;
    }
}
