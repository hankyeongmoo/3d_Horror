using UnityEngine;
using TMPro;

public class TextChanger : MonoBehaviour
{
    public TMP_Text myText;
    private float timer = 0.0f;

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (0 <= timer && timer < 0.3f)
        {
            myText.text = "Loading";
        }
        else if (0.3f <= timer && timer < 0.6f)
        {
            myText.text = "Loading.";
        }
        else if (0.6f <= timer && timer < 0.9f)
        {
            myText.text = "Loading..";
        }
        else if (0.9f <= timer && timer < 1.2f)
        {
            myText.text = "Loading...";
        }
        else if (timer >= 1.2f)
        {
            timer = 0.0f;
        }
    }
}
