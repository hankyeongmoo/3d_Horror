using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    
    // Update is called once per frame
    void Awake()
    {
        
    }

    void OntriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("열쇠 획득");

            Destroy(gameObject);
        }
    }
}
