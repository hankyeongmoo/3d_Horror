using UnityEngine;

public class BookcaseTrigger_stage4 : MonoBehaviour
{
    public GameObject bookcase;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerMovement.isLookingAtObject_stage4 = true;
            bookcase.GetComponent<Bookcase_stage4>().Interact();
        }
    }
}
