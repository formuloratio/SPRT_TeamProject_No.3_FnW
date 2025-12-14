using Features.Entities;
using UnityEngine;

public class BaseController : MonoBehaviour
{

    [Header("Movement Settings")]
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected float jumpForce = 4f;
    [SerializeField] protected LayerMask groundLayer;//바닥 감지용 레이어
    [SerializeField] protected float groundCheckDistance = 0.2f; // 바닥감지 거리용

    [Header("Selection Icon")]
    [SerializeField] private GameObject selectionIcon; // 하위 아이콘 연결

    [SerializeField] private PlayerType playerType; // 플레이어 속성

    protected Rigidbody2D rb;
    protected SpriteRenderer sr;
    protected Animator anim;

    protected bool isGrounded = false;
    protected bool isActive = false;

    //입력값 저장
    private float moveInput;
    private bool jumpPressed;

    //연속점프 방지
    private float jumpCooldown = 0.1f;
    private float jumpTimer = 0f;

    [SerializeField]private AudioSource audioSource;
    [SerializeField]private AudioClip jumpSfx;

    public PlayerType Element => playerType;
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    public void SetActive(bool value)
    {
        isActive = value;
        rb.velocity = Vector2.zero; //전환시 관성 0 
    }

    protected virtual void Update()
    {
        if (!isActive) return;

        //입력감지
        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.W))
            jumpPressed = true;

        UpdateAnimation();
    }

    protected virtual void FixedUpdate()
    {
        if (!isActive) return;

        if (jumpTimer > 0)
            jumpTimer -= Time.fixedDeltaTime;
        //바닥감지
        CheckGround();
        //이동
        Move();

        //점프
        if (jumpPressed && isGrounded && jumpTimer <= 0)
        {
            Jump();
            jumpPressed = false;
            jumpTimer = jumpCooldown; // 점프하고 0.1초간 바닥감지 X
        }
        else
        {
            // 공중에 있을 땐 입력을 바로 초기화
            if (!isGrounded)
                jumpPressed = false;
        }
    }

    protected virtual void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);

        if (x != 0)
        {
            sr.flipX = x < 0;
        }
    }

    protected virtual void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;
        audioSource.PlayOneShot(jumpSfx);
    }

    protected virtual void CheckGround()
    {
        //캐릭터 아래로 레이 쏘기

        float extraHeight = 0.15f;
        Collider2D col = GetComponent<Collider2D>();
        Vector2 FootRay = new Vector2(transform.position.x, col.bounds.min.y + 0.05f);

        RaycastHit2D hit = Physics2D.Raycast(FootRay, Vector2.down, extraHeight, groundLayer);
        isGrounded = hit.collider != null;

        // 디버그용 레이 표시 
        Color color = isGrounded ? Color.green : Color.red;
        Debug.DrawRay(FootRay, Vector2.down * extraHeight, color);
    }

    protected virtual void UpdateAnimation()
    {
        if (anim == null) return;
        
        if (!isGrounded)
        {
            anim.SetBool("isJump", true);
            anim.SetBool("isMove", false); // 공중에서는 Move 끄기
        }
        else
        {
            anim.SetBool("isMove", Mathf.Abs(rb.velocity.x) > 0.1f);
            anim.SetBool("isJump", false);
        }
    }

    public void Selected(bool isSelected)
    {
        if(selectionIcon != null)
            selectionIcon.SetActive(isSelected);
    }

    //착지 확인용
    public bool IsGrounded()
    {
        return isGrounded;
    }

}

