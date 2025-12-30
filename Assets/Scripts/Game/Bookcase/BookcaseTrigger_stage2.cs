using UnityEngine;

public class BookcaseTrigger_stage2 : MonoBehaviour
{
    public GameObject bookcase;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            bookcase.GetComponent<Bookcase_stage2>().Interact();
        }
    }
}
