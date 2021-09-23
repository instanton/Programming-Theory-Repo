using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject targetSpherePrefab;
    public TextMeshProUGUI counterText;

    private int redCount = 0;
    private int whiteCount = 0;
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

    public void UpdateScore(int value)
    {
        if (value == 1)
        {
            redCount += 1;
            counterText.text = "Red : " + redCount + "    White: " + whiteCount;
        }
        else if (value == -1)
        {
            whiteCount += 1;
            counterText.text = "Red : " + redCount + "    White: " + whiteCount;
        }
        
        
        Debug.Log("Red Count = " + redCount + ", White Count = " + whiteCount);
    }
}
