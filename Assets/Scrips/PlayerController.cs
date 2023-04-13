using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator animator;
    private float horizontalInput;
    public float lateralSpeed;
    public float jumpForce;
    Vector3 targetPosition = (Vector3.right);
    public float smoothTime = 0.5f;
    public float speed = 10f;
    Vector3 velocity;

    private bool IsJumping;
    private bool IsGrounded;



    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
       animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
            
      //hacer que se mueva por pulsaciones una cantidad fija para un lado o para el otro
        transform.Translate(Vector3.forward * horizontalInput * lateralSpeed * Time.deltaTime);
        transform.position = new Vector3 (transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -2.5f, 2.5f));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("IsJumping");
        }
        if (playerRb.velocity.y <0)
        {
            animator.SetTrigger("IsJumping");
        }
        






        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, speed);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = Vector3.SmoothDamp(transform.position, -targetPosition, ref velocity, smoothTime, speed);
        }
    }
}
 