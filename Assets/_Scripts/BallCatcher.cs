using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCatcher : MonoBehaviour
{
    [SerializeField] private Transform ballSpawnPos;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = ballSpawnPos.position;
    }
}