using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector2 moveInput;

    [Header("Look Around")]
    public Transform playerCamera;
    public float mouseSensitivity = 2f;
    private float xRotation = 0f;

    [Header("Interaction")]
    public Transform objectToLook_stage2;
    public static bool isLookingAtObject_stage2 = false;
    public Transform objectToLook_stage4;
    public static bool isLookingAtObject_stage4 = false;
    public float rotationSpeed = 5f;
    private float lookTimer = 0f;
    public float requiredLookTime = 2f;
    private bool CanMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // 마우스 커서를 숨기고 중앙에 고정
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // 1. 시선 회전 (마우스)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // 위아래 회전 (카메라만 회전)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // 고개 각도 제한
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 좌우 회전 (플레이어 몸체 전체 회전)
        transform.Rotate(Vector3.up * mouseX);

        // 2. 이동 입력 받기
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // 문 감지 및 상호작용
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, 6f))
        {
            if (hit.collider.CompareTag("Door"))
            {
                ShowInteraction.isCloseToDoor = true;
                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hit.collider.GetComponentInParent<DoorController>().Interact();
                }
            }
        }
        else
        {
            ShowInteraction.isCloseToDoor = false;
        }
    }

    void FixedUpdate()
    {
        if(CanMove == true)
        {
            // 3. 물리 기반 이동 (Rigidbody)
            // 바라보는 방향 기준으로 이동 방향 계산
            Vector3 moveDir = transform.forward * moveInput.y + transform.forward * 0 + transform.right * moveInput.x;
            
            // y값은 기존 속도를 유지(중력 영향)하며 x, z 속도만 변경
            rb.linearVelocity = new Vector3(moveDir.normalized.x * moveSpeed, rb.linearVelocity.y, moveDir.normalized.z * moveSpeed);
        }

        // 4. 특정 오브젝트 바라보기 (책장_stage2)
        if(isLookingAtObject_stage2 && objectToLook_stage2 != null)
        {
            // 이동 불가
            CanMove = false;

            Vector3 direction = objectToLook_stage2.position - transform.position + new Vector3(0, 6f, 0);
            // 해당 방향을 바라보기 위한 회전값 계산
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            // 현재 회전에서 타겟 회전까지 부드럽게 보간
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            
            // 2초 지속
            lookTimer += Time.deltaTime;
            if(lookTimer >= requiredLookTime)
            {
                isLookingAtObject_stage2 = false;
                CanMove = true;
                transform.rotation = Quaternion.Euler(0, 180f, 0);
                lookTimer = 0f;
            }
        }

        // 5. 특정 오브젝트 바라보기 (책장_stage4)
        if(isLookingAtObject_stage4 && objectToLook_stage4 != null)
        {
            // 이동 불가
            CanMove = false;

            Vector3 direction = objectToLook_stage4.position - transform.position;
            // 해당 방향을 바라보기 위한 회전값 계산
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            // 현재 회전에서 타겟 회전까지 부드럽게 보간
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // 2초 지속
            lookTimer += Time.deltaTime;
            if(lookTimer >= requiredLookTime)
            {
                isLookingAtObject_stage4 = false;
                CanMove = true;
                transform.rotation = Quaternion.Euler(0, 180f, 0);
                lookTimer = 0f;
            }
        }  
    }
}