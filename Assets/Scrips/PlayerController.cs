using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float horizontalInput;
    public float lateralSpeed;
    public float jumpForce;




    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

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

        }



    }
}
