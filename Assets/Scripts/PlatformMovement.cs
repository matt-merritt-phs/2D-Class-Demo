using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    // Do display in the editor, it is set on the script
    public float moveSpeed, jumpForce;
    public Rigidbody2D rb;
    public SpriteRenderer spr;
    public Animator anim;
    public float playerHeight;
    public PlayerData data;

    // Do not display this in the editor, the code will manage it
    private int groundLayer = 6;
    private float movementInput;
    private bool canJump;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        groundLayer = 1 << groundLayer;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement with transforms (outside of the physics system)
        // float movementInput = Input.GetAxisRaw("Horizontal");
        // transform.position += Vector3.right * movementInput * moveSpeed * Time.deltaTime;

        // Movement inputs (done every frame for responsiveness)
        movementInput = Input.GetAxisRaw("Horizontal");

        // Simple jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump == true)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                canJump = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log(data.coinsCollected);
        }
    }

    // Called once per PHYSICS frame
    void FixedUpdate()
    {
        // Have the player face the direction they are moving in
        if (movementInput > 0)
        {
            spr.flipX = false;
        }
        if (movementInput < 0)
        {
            spr.flipX = true;
        }

        if (movementInput == 0)
        {
            anim.SetBool("IsMoving", false);
        }
        else
        {
            anim.SetBool("IsMoving", true);
        }

        // Smooth movement between two positions, but adjusts the player back upwards (slows the gravity)
        // rb.MovePosition(rb.position + Vector2.right * movementInput * moveSpeed * Time.fixedDeltaTime);

        // Movement with rigidbody (inside the physics system) 
        rb.position += Vector2.right * movementInput * moveSpeed * Time.fixedDeltaTime;

        // Detect if there is anything below the player
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, playerHeight + 0.01f, groundLayer);

        if (hit)
        {
            // Debug.Log(hit.transform.name);
            canJump = true;
        }
        else
        {
            // Debug.Log("Nothing was hit.");
            canJump = false;
        }
    }

    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "Ground")
    //     {
    //         canJump = true;
    //     }
    // }
}
