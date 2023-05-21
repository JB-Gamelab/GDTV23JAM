using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player instance { get; private set; }

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpSpeed = 100f;
    [SerializeField] private float teleportDistance = 5f;

    [SerializeField] private LayerMask platformLayerMask;

    [SerializeField] private ProjectileBehaviour projectilePrefab;
    [SerializeField] private Transform projectileOffset;

    [SerializeField] private SecondaryShield secondarySkillShield;
    [SerializeField] private SecondaryTeleport secondarySkillTeleport;

    [SerializeField] private GameInput gameInput;

    [SerializeField] private GameObject lightWizard;
    [SerializeField] private GameObject darkWizard;

    private Rigidbody2D _rigidbody;
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;

    private Quaternion directionQuaternion = new Quaternion(0f, 0f, 0f, 1f);

    private bool isFacingRight = false;
    [SerializeField] private bool isDark;

    private void Awake() {
        instance = this;

        _rigidbody = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();


        gameInput.OnPrimaryPressed += GameInput_OnPrimaryPressed;
        gameInput.OnSecondaryPressed += GameInput_OnSecondaryPressed;
        gameInput.OnJumpPressed += GameInput_OnJumpPressed;
    }

    private void GameInput_OnJumpPressed(object sender, System.EventArgs e) {
        if (IsGrounded()) {
            Jump();
        }
    }

    private void GameInput_OnSecondaryPressed(object sender, System.EventArgs e) {
        if (isDark) {
            //teleport script
            CastTeleport();
        } else {
            //shield script
            CastShield();
        }
        
    }

    private void GameInput_OnPrimaryPressed(object sender, System.EventArgs e) {        
            Instantiate(projectilePrefab, projectileOffset.position, directionQuaternion);
    }


    private void Update()
    {
        _rigidbody.velocity = new Vector2(moveSpeed * gameInput.GetMovementVectorX(), _rigidbody.velocity.y);

        if (isFacingRight) {
            directionQuaternion = new Quaternion(0f, 0f, 0f, 1f);
        } else {
            directionQuaternion = new Quaternion(0f, 1f, 0f, 0f);
        }

        Flip();

       
    }

    private void LateUpdate() {
        if (isDark) {
            lightWizard.SetActive(false);
            darkWizard.SetActive(true);
        } else {
            lightWizard.SetActive(true);
            darkWizard.SetActive(false);
        }
    }

    private bool IsGrounded() {
        float extraHeightTest = .1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeightTest, platformLayerMask);

        return raycastHit.collider != null;
    }

    private void Jump() {
        _rigidbody.AddForce(new Vector2(_rigidbody.velocity.x, jumpSpeed));
    }


    private void Flip() {
        if (isFacingRight && _rigidbody.velocity.x < 0f || !isFacingRight && _rigidbody.velocity.x > 0f) {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    public bool GetIsDark() {
        return isDark;
    }

    private void CastShield() {
        if (!GameObject.Find("SecondaryShield(Clone)")) {
            Instantiate(secondarySkillShield, this.transform);
        }
    }

    private void CastTeleport() {
        if (!GameObject.Find("SecondaryTeleport(Clone)")) {
            Instantiate(secondarySkillTeleport, this.transform);
            if (isFacingRight) {
                this.transform.position = this.transform.position + new Vector3(teleportDistance, 0, 0);
            }
        }
    }

}
