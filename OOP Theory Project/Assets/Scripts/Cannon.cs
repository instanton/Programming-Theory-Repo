using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannonBallPrefab;

    GameObject spawnSphere;
    private Vector3 spawnPos;

    [SerializeField] private float blastForce= 20.0f;
    [SerializeField] private float turnSpeed = 45.0f;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        //spawnSphere = gameObject.transform.GetChild(3);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //add turning based on horizontal input
        transform.Rotate(Vector3.forward, turnSpeed * horizontalInput * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Firing!");
            SpawnCannonBall();
        }


    }

    void SpawnCannonBall()
    {
        //get transform of cannon spawn sphere
        //Debug.Log("Child Count: " + gameObject.transform.childCount);

        Transform spawnLoc = gameObject.transform.GetChild(2);

        GameObject newCannonBall = Instantiate(cannonBallPrefab, spawnLoc.position, cannonBallPrefab.transform.rotation);
        newCannonBall.GetComponent<Rigidbody>().AddRelativeForce(transform.up * blastForce, ForceMode.Impulse);
    }
}
