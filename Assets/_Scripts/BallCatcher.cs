using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCatcher : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    [SerializeField] private Transform ballSpawnPos;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = null;

        //resetting velocity
        if (rb = other.gameObject.GetComponent<Rigidbody>())
            rb.velocity = Vector3.zero;

        //resetting position
        if (ballSpawnPos)
            other.gameObject.transform.position = ballSpawnPos.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Ball.transform.position = ballSpawnPos.position;
    }
}