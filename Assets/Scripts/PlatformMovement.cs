using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    // Do display in the editor, it is set on the script
    public float moveSpeed, jumpForce;
    public Rigidbody2D rb;
    public SpriteRenderer spr;
    public Animator anim;
    public int playerLayer;
    public float distanceToGround;

    // Do not display this in the editor, the code will manage it
    private float movementInput;
    private bool flipped;
    private bool onGround;
    private int physicsLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Creating a layer mask to use
        // Read more about this here: https://docs.unity3d.com/Manual/use-layers.html

        // shifting a bit, necessary for the layers to be understood by program
        playerLayer = 1 << playerLayer;
        // for the physics layer, make it everything that is not in the player layer
        physicsLayer = ~playerLayer;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement with transforms (outside of the physics system)
        // float movementInput = Input.GetAxisRaw("Horizontal");
        // transform.position += Vector3.right * movementInput * moveSpeed * Time.deltaTime;

        // Movement inputs (done every frame for responsiveness)
        movementInput = Input.GetAxisRaw("Horizontal");

        // Flip the player sprite if they are moving in a direction
        if (movementInput > 0)
        {
            flipped = false;
        }
        if (movementInput < 0)
        {
            flipped = true;
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // Called once per PHYSICS frame
    void FixedUpdate()
    {
        // Update the player sprite before moving them
        spr.flipX = flipped;

        if (movementInput != 0)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        // Smooth movement between two positions, but adjusts the player back upwards (slows the gravity)
        // rb.MovePosition(rb.position + Vector2.right * movementInput * moveSpeed * Time.fixedDeltaTime);

        // Movement with rigidbody (inside the physics system) 
        rb.position += Vector2.right * movementInput * moveSpeed * Time.fixedDeltaTime;

        // Raycasts for checking if jump is possible

        // Normal Raycast

        // This will always hit the player, options are to move it down or to use layers
        // RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distanceToGround + 0.1f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distanceToGround + 0.1f, physicsLayer);

        if (hit)
        {
            onGround = true;
            Debug.Log(hit.collider.name);
        }
        else
        {
            onGround = false;
            Debug.Log("No hits");
        }
    }
}
