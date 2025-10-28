using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float runSpeed = 5f;
    public float jumpForce = 5f;
    public Animator animator;
    public Rigidbody rb;

    private bool isGrounded = true;

    void Update()
    {
        // Input dasar
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, 0, v).normalized;

        // Tentukan apakah karakter sedang berjalan / berlari
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float currentSpeed = isRunning ? runSpeed : moveSpeed;

        // Gerakkan karakter
        if (move.magnitude > 0)
        {
            transform.Translate(move * currentSpeed * Time.deltaTime, Space.World);
            transform.forward = move; // Hadapkan karakter ke arah gerakan
        }

        // Lompat
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            animator.SetBool("IsJumping", true);
        }

        // Kirim nilai Speed ke Animator
        animator.SetFloat("Speed", move.magnitude * (isRunning ? 1f : 0.5f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Kalau menyentuh tanah, berarti sudah mendarat
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
        }
    }
}

