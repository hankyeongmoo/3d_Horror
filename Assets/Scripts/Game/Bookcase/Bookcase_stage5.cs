using UnityEngine;

public class Bookcase_stage5 : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        Debug.Log("책5(흔들림) 작동");

        // 작동
        animator.SetBool("goDrop", true);
        
        // 더 이상 상호작용이 필요 없다면 스크립트 자체를 비활성화할 수도 있습니다.
        this.enabled = false; 
    }
}
