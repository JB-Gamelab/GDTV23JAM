using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpSpeed = 100f;

    [SerializeField] private LayerMask platformLayerMask;

    [SerializeField] private ProjectileBehaviour projectilePrefab;
    [SerializeField] private Transform projectileOffset;

    [SerializeField] private GameInput gameInput;

    private Rigidbody2D _rigidbody;
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;



    private void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        boxCollider2D= GetComponent<BoxCollider2D>();
        spriteRenderer= GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector2(moveSpeed * gameInput.GetMovementVectorX(), _rigidbody.velocity.y);

        if (IsGrounded() && gameInput.GetJump()) {
            _rigidbody.AddForce(new Vector2(_rigidbody.velocity.x, jumpSpeed));
        }

        if (gameInput.GetMovementVectorX() > 0) {
            spriteRenderer.flipX = true;
            projectileOffset.position = new Vector3(0.819f, 0.127f, 0f);
        } 
        if (gameInput.GetMovementVectorX() < 0) {
            spriteRenderer.flipX = false;
            projectileOffset.position = new Vector3(-0.819f, 0.127f, 0f);
        }

        if (gameInput.GetPrimary()) {
            Instantiate(projectilePrefab, projectileOffset.position, transform.rotation);
        }
    }

    private bool IsGrounded() {
        float extraHeightTest = .1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeightTest, platformLayerMask);

        return raycastHit.collider != null;
    }


}
