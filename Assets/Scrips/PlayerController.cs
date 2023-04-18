using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator animator;
    public float lateralSpeed;
    public float jumpForce;
    Vector3 targetPosition = (Vector3.right);
    public float smoothTime = 0.5f;
    public float speed = 10f;
    private bool grounded;
    public int coin;
    public int timeEfect = 5;
    public int coinMultl;
    

    public TMP_Text coinText;

    private int desiredLane = 1; //0:left 1:middle 2:right
    public float laneDistance;



    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        grounded = true;
        coin = 0;
        coinMultl = 1;
    }

    // Update is called once per frame
    void Update()
    {

        coinText.text = "Coins: " + coin.ToString();



        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("IsJumping", true);
            grounded = false;
        }

        
        if (playerRb.velocity.y < 0)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", true);
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            animator.SetBool("IsFalling", false);
            animator.SetTrigger("IsGrouned");
        }

        

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Choque");
            GameManager.gameOver = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
           // Debug.Log("Monedasss");
            coin += coinMultl;
            Destroy(other.gameObject);

        }

        if (other.gameObject.CompareTag("CoinX2"))
        {
            Debug.Log("escudo");
            Destroy(other.gameObject);
            StartCoroutine(CoinX2());
        }
    }

    IEnumerator CoinX2()
    {
        Debug.Log("efect on");
        coinMultl = 2;
        coinText.color = Color.yellow;
        coinText.fontSize = 50;
        coinText.fontStyle = FontStyles.Bold;

        yield return new WaitForSeconds(timeEfect);
        coinMultl = 1;
        coinText.color = Color.black;
        coinText.fontSize = 36;
        coinText.fontStyle = FontStyles.Normal;

        Debug.Log("efect off");

    }


}
