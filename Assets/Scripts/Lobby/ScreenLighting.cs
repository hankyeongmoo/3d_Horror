using UnityEngine;
using UnityEngine.UI;

public class ScreenLighting : MonoBehaviour
{
    public Image myImage;
    [Tooltip("전체 불투명해지는 데 걸리는 시간(초)")]
    public float fadeDuration = 3.0f; 

    void Start()
    {
        SetAlpha(0);
    }

    void FixedUpdate()
    {
        // CameraMove.isCameraMove가 true일 때만 실행
        if (CameraMove.isCameraMove)
        {
            float currentAlpha = myImage.color.a;

            if (currentAlpha < 1.0f)
            {
                // 수정된 부분: (1 / 200) 대신 시간 기반으로 증가
                // 1.0f / fadeDuration * Time.fixedDeltaTime을 하면 
                // 설정한 fadeDuration(초) 동안 서서히 불투명해집니다.
                float nextAlpha = currentAlpha + (Time.fixedDeltaTime / fadeDuration);
                SetAlpha(nextAlpha);
            }
        }
    }

    public void SetAlpha(float alpha)
    {
        if (myImage == null) return;
        
        Color color = myImage.color;
        // alpha 값이 1을 넘지 않도록 Clamp 처리
        color.a = Mathf.Clamp01(alpha); 
        myImage.color = color;
    }
}