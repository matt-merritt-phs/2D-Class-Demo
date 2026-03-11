using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    // Do display in the editor, it is set on the script
    public float moveSpeed;
    public Rigidbody2D rb;
    public SpriteRenderer spr;
    public Animator anim;

    // Do not display this in the editor, the code will manage it
    private float movementInput;
    private bool flipped;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    }
}
