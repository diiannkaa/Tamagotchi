using System;
using UnityEngine;

public class MinigamePetController : MonoBehaviour
{
    public float speed, jumpSpeed;
    private Rigidbody2D r2d;
    public bool grounded;
    private BackgroundController backgroundController;

    private void Awake()
    {
        backgroundController = FindObjectOfType<BackgroundController>();
            r2d = GetComponent<Rigidbody2D>();
            // Другие действия при инициализации
     }


    private void OnEnable()
    {
        if (backgroundController == null)
        {
            backgroundController = FindObjectOfType<BackgroundController>();
            if (backgroundController == null)
            {
                Debug.LogError("BackgroundController not found!");
                return;
            }
        }

        GetComponent<PetController>().enabled = false;
        GetComponent<NeedsController>().enabled = false;
        r2d = GetComponent<Rigidbody2D>();
        r2d.simulated = true;

        backgroundController.SetMainBackgroundActive(false);
        backgroundController.SetMinigameBackgroundActive(true);
    }

    private void OnDisable()
    {
        r2d.velocity = Vector3.zero;
        transform.position = Vector3.zero;
        r2d.simulated = false;
        GetComponent<PetController>().enabled = true;
        GetComponent<NeedsController>().enabled = true;

        if (backgroundController != null)
        {
            backgroundController.SetMinigameBackgroundActive(false);
            backgroundController.SetMainBackgroundActive(true);
        }
    }


    private void Update()
    {
        CheckHorizontalMovement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (!grounded) return;
        grounded = false;
        r2d.velocity = new Vector2(r2d.velocity.x, jumpSpeed);
    }

    private void CheckHorizontalMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        r2d.velocity = new Vector2(horizontal * speed, r2d.velocity.y);

        if (horizontal == 0)
        {
            r2d.velocity = new Vector2(0, r2d.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") &&
            collision.transform.position.y + 1.5f < transform.position.y)
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
