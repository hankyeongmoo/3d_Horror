using UnityEngine;

public class BookcaseTrigger_stage2 : MonoBehaviour
{
    public GameObject bookcase;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerMovement.isLookingAtObject_stage2 = true;
            bookcase.GetComponent<Bookcase_stage2>().Interact();
        }
    }
}
