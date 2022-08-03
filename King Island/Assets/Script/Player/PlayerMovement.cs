using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Reference")]
    public Rigidbody2D _rb;
    public Animator _anim;
    public AudioSource _audioSource;

    [Header("Ground Check")]
    public Transform _groundCheck;
    public LayerMask _stepLayer;
    public float _checkRadius = 0.2f;// Ground Check Radius

    [Header("Movement")]
    public float _moveSpeed = 10f;
    //public AudioSource _runAudio;
    float _horizontal;

    [Header("Jump")]
    public float _jumpForce = 16f; // Jump power
    public float _holdJump = 0.5f; // if the player hold the jump button he will jump higher 
    public AudioClip _jumpAudio;
    bool _isJumping = false;

    bool _isFacingRight = true;

    private void Update()
    {
        /*if (_horizontal != 0 && !_runAudio.isPlaying)
            _runAudio.Play();
        else
            _runAudio.Stop();
        */

        Animations();
        //Flip the player when the player go right or left
        if (_horizontal > 0 && !_isFacingRight)
            Flip();
        else if (_horizontal < 0 && _isFacingRight)
            Flip();
    }

    private void FixedUpdate()
    {
        //move the player horizontal
        _rb.velocity = new Vector2(_horizontal * _moveSpeed, _rb.velocity.y);
    }

    //Player move input
    public void Move(InputAction.CallbackContext context)
    {
        _horizontal = context.ReadValue<Vector2>().x;
    }

    //Sprint(If the button pressed the player will have more speed)
    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.performed)
            _moveSpeed = 22f;
        else
            _moveSpeed = 15f;
    }

    //Player Jump
    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && IsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _isJumping = true;
            _audioSource.PlayOneShot(_jumpAudio, 1f);
        }

        if(context.canceled)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * _holdJump);
            _isJumping = false;
        }
    }

    //Flip the player sprite 
    void Flip()
    {
        transform.Rotate(0, 180, 0);
        _isFacingRight = !_isFacingRight;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _stepLayer);
    }

    void Animations()
    {
        _anim.SetBool("isRunning", _horizontal != 0);

        if (_isJumping)
            _anim.SetTrigger("Jump");
        else
            _anim.SetBool("isIdleing",true);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(_groundCheck.position, _checkRadius);
    }
}
