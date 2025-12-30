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
        Debug.Log("작동");

        // 문 열기 실행
        animator.SetBool("isOpen", true);
        
        // 더 이상 상호작용이 필요 없다면 스크립트 자체를 비활성화할 수도 있습니다.
        this.enabled = false; 
    }
}