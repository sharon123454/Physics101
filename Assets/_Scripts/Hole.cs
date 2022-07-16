using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] Transform newPos;
    private void OnTriggerEnter(Collider other)
    {
        if (newPos)
            other.gameObject.transform.position = newPos.position;
    }
}