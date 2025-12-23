using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    private bool isAlreadyOpened = false; // 문이 열렸는지 체크하는 변수

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        // 이미 문이 열려 있다면 함수를 종료 (다시 닫히지 않음)
        if (isAlreadyOpened) return;

        // 문 열기 실행
        isAlreadyOpened = true; 
        animator.SetBool("isOpen", true);
        
        // (선택 사항) 더 이상 상호작용이 필요 없다면 스크립트 자체를 비활성화할 수도 있습니다.
        // this.enabled = false; 
    }
}