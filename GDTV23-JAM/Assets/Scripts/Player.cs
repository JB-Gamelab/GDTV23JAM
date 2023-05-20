using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpSpeed = 100f;
    [SerializeField] private GameInput gameInput;

    [SerializeField] private LayerMask platformLayerMask;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;



    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D= GetComponent<BoxCollider2D>();
        spriteRenderer= GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(moveSpeed * gameInput.GetMovementVectorX(), rb.velocity.y);

        if (IsGrounded() && gameInput.GetJump()) {
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed));
        }

        if (gameInput.GetMovementVectorX() > 0) {
            spriteRenderer.flipX = true;
        } 
        if (gameInput.GetMovementVectorX() < 0) {
            spriteRenderer.flipX = false;
        }
    }

    private bool IsGrounded() {
        float extraHeightTest = .1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeightTest, platformLayerMask);

        return raycastHit.collider != null;
    }

    private void SetSpriteDirection() {

    }
}
