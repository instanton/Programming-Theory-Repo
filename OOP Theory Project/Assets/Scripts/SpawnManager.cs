using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject targetSpherePrefab;
    private Vector3 spawnPos;

    private float startDelay = 2;
    private float repeatRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnTarget", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnTarget()
    {
        spawnPos = new Vector3(Random.Range(-10.0f, 10.0f), 4, -6);
        Instantiate(targetSpherePrefab, spawnPos, targetSpherePrefab.transform.rotation);
    }
}
