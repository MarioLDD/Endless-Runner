using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft    : MonoBehaviour
{

    public float velocity = 30;





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left *Time.deltaTime * velocity);
        if (transform.position.x < -18 )
        {
            Destroy(gameObject);
        }

    }
}
