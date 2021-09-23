using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCounter : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Yellow"))
        {
            Debug.Log("Got a YELLOW in a White square");
            gameManager.UpdateScore(-1);
        }

        Destroy(other.gameObject);
    }
}
