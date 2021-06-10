using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterManager : MonoBehaviour
{

    public GameObject[] aircrafts;

    public Transform[] spawnPoints;
    public float rangeMin;
    public float rangeMax;

    private float timeBtwSpawn;

    void Start()
    {
        timeBtwSpawn = Random.Range(rangeMin, rangeMax);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwSpawn >= 0)
        {
            timeBtwSpawn -= Time.deltaTime;
        }
        else
        {
            Instantiate(aircrafts[Random.Range(0, aircrafts.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            timeBtwSpawn = Random.Range(rangeMin, rangeMax);

            if(rangeMin > 0.1f)
            {
                rangeMin -= 0.01f;
            }
            if(rangeMax > 0.1f)
            {
                rangeMax -= 0.01f;
            }
        }
    }
}
