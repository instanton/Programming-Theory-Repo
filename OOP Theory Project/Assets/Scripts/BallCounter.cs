using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallCounter : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        //counterText.text = "Count : " + count;
        //Debug.Log("Count = " + count);

        Destroy(other.gameObject);
    }
}
