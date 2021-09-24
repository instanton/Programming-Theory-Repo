using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCounter : MonoBehaviour
{
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            //Debug.Log("other GCIP<Ball> name: " + other.GetComponentInParent<Ball>().name);
            other.GetComponentInParent<Ball>().UpdateScore();
        }
        Destroy(other.gameObject);
    }
}
