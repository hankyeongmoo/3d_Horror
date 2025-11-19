using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        Loading.LoadScene("Game");
    }
}
