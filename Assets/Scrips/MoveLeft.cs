using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public GameObject spawn;
    //public float velocity = 4;
    public float destroyDistance = -30;
    




    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("SpawnPoint");
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.back * Time.deltaTime * SpawnObjet.velocity);
        if (transform.position.z < destroyDistance)
        {
          
            spawn.GetComponent<SpawnObjet>().RandomSpawnTile();
            Destroy(gameObject);
            spawn.GetComponent <SpawnObjet>().Aceleration();
        }
    }

}
