using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class MoveHero : MonoBehaviour
{
    [SerializeField] private InputActionAsset actions;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private InputAction xAxis;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    private bool isJumping = false;
    private bool isCrouching = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        xAxis = actions.FindActionMap("ControlerActionMap").FindAction("XAxis");
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        actions.FindActionMap("ControlerActionMap").Enable();
        actions.FindActionMap("ControlerActionMap").FindAction("Jump").performed += OnJump;
        actions.FindActionMap("ControlerActionMap").FindAction("Crouch").performed += OnCrouch;
        actions.FindActionMap("ControlerActionMap").FindAction("Crouch").canceled += OnRise;
    }

    private void OnDisable()
    {
        actions.FindActionMap("ControlerActionMap").Disable();
        actions.FindActionMap("ControlerActionMap").FindAction("Jump").performed -= OnJump;
        actions.FindActionMap("ControlerActionMap").FindAction("Crouch").performed -= OnCrouch;
        actions.FindActionMap("ControlerActionMap").FindAction("Crouch").canceled -= OnRise;
    }

    // Update is called once per frame
    void Update()
    {
        MoveX();
        if (isJumping)
        {
            // donne vitesse linéaire en Y
            if (rb.linearVelocityY < 0)
            {
                isJumping = false;
                animator.SetBool("onJump", false);
            }
        }
    }

    private void MoveX()
    {
        spriteRenderer.flipX = xAxis.ReadValue<float>() < 0;
        if (isCrouching) return;
        animator.SetFloat("speed", Mathf.Abs(xAxis.ReadValue<float>()));
        transform.Translate(xAxis.ReadValue<float>() * speed * Time.deltaTime, 0f, 0f);
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        rb.AddForce(Vector3.up * jumpForce);
        animator.SetBool("onJump", true);
        isJumping = true;
    }

    private void OnCrouch(InputAction.CallbackContext context)
    {
        isCrouching = true;
        animator.SetBool("onCrouch", true);
    }

    private void OnRise(InputAction.CallbackContext context)
    {
        isCrouching = false;
        animator.SetBool("onCrouch", false);
    }
}
