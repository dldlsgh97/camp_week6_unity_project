using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] float moveSpeed;
    Vector2 curMovementInput;
    [SerializeField] float jumpForce;
    [SerializeField] bool isGround;
    [SerializeField] LayerMask groundLayerMask;

    [Header("Look")]
    public Transform CameraContainer;
    [SerializeField] float minXLook;
    [SerializeField] float maxXLook;
    private float _camCurXRot;
    [SerializeField] float lookSensitivity;

    private Vector2 mouseDelta;
    private Rigidbody rigidbody;

    [Header("Animation")]
    private Animator playerAnim;
    [SerializeField] bool isJump;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerAnim = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void LateUpdate()
    {
        CameraLook();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
            playerAnim.SetBool("IsRun", true);
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
            playerAnim.SetBool("IsRun", false);
        }
    }

    void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = rigidbody.velocity.y;

        rigidbody.velocity = dir;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    void CameraLook()
    {
        _camCurXRot += mouseDelta.y * lookSensitivity;
        _camCurXRot = Mathf.Clamp(_camCurXRot, minXLook, maxXLook);
        CameraContainer.localEulerAngles = new Vector3(-_camCurXRot, 0, 0);
        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && isGround)
        {
            playerAnim.SetBool("IsJump", true);
        }
    }

    public void Jump()
    {
        rigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);       
    }
    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.layer == 6)
        {
            isGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGround = false;
            playerAnim.SetBool("IsJump", isGround);
        }
    }
}
