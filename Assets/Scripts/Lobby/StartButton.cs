using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        CameraMove.isCameraMove = true;
        this.gameObject.SetActive(false);
    }
}
