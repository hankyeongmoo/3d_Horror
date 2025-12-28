using UnityEngine;

public class KeyInteraction : MonoBehaviour
{

    // Update is called once per frame
    void Awake()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("열쇠 획득");

            StageManager.stageIndex += 1;
            StageManager.changeStage = true;
            
            this.enabled = false;
        }
    }
}
