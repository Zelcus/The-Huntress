using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawn : MonoBehaviour
{

    public GameObject Star;

    public float spawnRate = 2f;

    private int numberOfItems;
    private int whatToSpawn;
    private float nextSpawn = 0f;

    public Transform target;

    public float scaleX;
    public float scaleY;

    private float spawnBarrierX;
    private float spawnBarrierY;
    private int posOrNegX;
    private int posOrNegY;
    // Start is called before the first frame update
    void Start()
    {
        numberOfItems = 10;
        spawnBarrierX = Random.Range(4f, 8f);


    }

    // Update is called once per frame
    void Update()
    {
        numberOfItems = GameObject.FindGameObjectsWithTag("Star").Length;

        scaleX = Random.Range(1, 10);

        scaleX = (scaleX * -20);

        transform.localScale += new Vector3(scaleX, scaleX, scaleX);

        transform.position = new Vector3((target.position.x + spawnBarrierX), (target.position.y + spawnBarrierY), transform.position.z);

        if (Time.time > nextSpawn && numberOfItems <= 40)
        {
            posOrNegX = Random.Range(1, 3);
            posOrNegY = Random.Range(1, 3);

            if (posOrNegX == 1)
            {
                spawnBarrierX = Random.Range(0f, 9.6f);
            }
            else if (posOrNegX == 2)
            {
                spawnBarrierX = Random.Range(0f, -9.6f);
            }

            if (posOrNegY == 1)
            {
                spawnBarrierY = Random.Range(0f, 16f);
            }

            else if (posOrNegY == 2)
            {
                spawnBarrierY = Random.Range(0f, -16f);
            }

            whatToSpawn = Random.Range(1, 3);
            
            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(Star, transform.position, Quaternion.identity);
                    break;
            }
            nextSpawn = Time.time + spawnRate;
        }
    }
}
