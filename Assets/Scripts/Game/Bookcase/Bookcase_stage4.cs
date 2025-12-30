using UnityEngine;

public class Bookcase_stage4 : MonoBehaviour
{
    private Animator animator;
    private bool isAlreadyOperated;

    void Awake()
    {
        animator = GetComponent<Animator>();
        isAlreadyOperated = false;
    }

    public void Interact()
    {
        Debug.Log("책4(흔들림) 작동");
        // 이미 작동했다면 함수를 종료 (다시 작동하지 않음)
        if (isAlreadyOperated) return;

        // 작동
        isAlreadyOperated = true; 
        animator.SetBool("goDrop", true);
        
        // 더 이상 상호작용이 필요 없다면 스크립트 자체를 비활성화할 수도 있습니다.
        this.enabled = false; 
    }
}
