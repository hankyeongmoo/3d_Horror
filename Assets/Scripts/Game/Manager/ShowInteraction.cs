using UnityEngine;
using TMPro;

public class ShowInteraction : MonoBehaviour
{
    static public bool isCloseToDoor;
    public TMP_Text myText;

    void Update()
    {
        if (isCloseToDoor == true)
        {
            myText.enabled = true;
        }
        else
        {
            myText.enabled = false;
        }
    }
}
