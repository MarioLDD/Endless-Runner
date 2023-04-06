using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjet : MonoBehaviour
{
    public GameObject Obstacle;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 3, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle ()
    {
        Instantiate(Obstacle);

    }


}
