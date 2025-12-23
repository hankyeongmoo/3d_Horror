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

        // Update 함수 안에 추가
        if (Input.GetKeyDown(KeyCode.E))
        {
            // 레이캐스트(Raycast)를 쏴서 앞에 문이 있는지 확인
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, 3f))
            {
                if (hit.collider.CompareTag("Door")) // 문의 태그를 Door로 설정하세요
                {
                    hit.collider.GetComponent<DoorController>().Interact();
                }
            }
        }
    }

    void FixedUpdate()
    {
        // 3. 물리 기반 이동 (Rigidbody)
        // 바라보는 방향 기준으로 이동 방향 계산
        Vector3 moveDir = transform.forward * moveInput.y + transform.forward * 0 + transform.right * moveInput.x;
        
        // y값은 기존 속도를 유지(중력 영향)하며 x, z 속도만 변경
        rb.linearVelocity = new Vector3(moveDir.normalized.x * moveSpeed, rb.linearVelocity.y, moveDir.normalized.z * moveSpeed);
    }
}