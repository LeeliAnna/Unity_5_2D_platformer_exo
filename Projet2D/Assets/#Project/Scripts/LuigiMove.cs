using UnityEngine;
using UnityEngine.InputSystem;

public class LuigiMove : MonoBehaviour
{
    [SerializeField] private InputActionAsset actions;
    [SerializeField] private float speed = 1f;
    [SerializeField] private bool goRight = true;
    [SerializeField] private float jumpForce = 50f;

    private InputAction xAxis;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        xAxis = actions.FindActionMap("ControlerActionMap").FindAction("XAxis");
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        actions.FindActionMap("ControlerActionMap").Enable();
    }

    void OnDisable()
    {
        actions.FindActionMap("ControlerActionMap").Disable();
    }

    // Update is called once per frame
    void Update()
    {
        MoveX();
    }

    private void MoveX()
    {
        float xMove = xAxis.ReadValue<float>();
        if (xMove == 1)
        {
            transform.Translate(xMove * speed * (goRight ? 1f : -1f) * Time.deltaTime, 0f, 0f);
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
        else if (xMove == -1){
            transform.Translate(xMove * speed * (goRight ? 1f : -1f) * Time.deltaTime, 0f, 0f);
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }


}
