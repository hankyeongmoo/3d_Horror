using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        // 문 열기 실행
        Debug.Log("문 작동");   
        animator.SetBool("isOpen", true);
        
        // 스크립트 종료
        this.enabled = false; 
    }
}