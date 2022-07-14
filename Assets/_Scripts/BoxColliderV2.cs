using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BoxColliderV2 : MonoBehaviour
{
    public bool ShowCollider = true;
    public bool isTrigger = false;
    public Vector3 Center = Vector3.zero;
    public Vector3 Size = Vector3.one;

    private Vector3 colliderCenter;
    private Vector3 colliderSize;

    private void Awake()
    {
        SetCenter();
        SetSize();
    }

    private void SetCenter()
    {
        if (Center != Vector3.zero)
        {
            colliderCenter.x = transform.position.x + Center.x;
            colliderCenter.y = transform.position.y + Center.y;
            colliderCenter.z = transform.position.z + Center.z;
        }
        else
        {
            colliderCenter = transform.position;
        }
    }

    private void SetSize()
    {
        if (Size != Vector3.one)
        {
            colliderSize.x = transform.localScale.x * Size.x;
            colliderSize.y = transform.localScale.y * Size.y;
            colliderSize.z = transform.localScale.z * Size.z;
        }
        else
        {
            colliderSize = transform.localScale;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (ShowCollider)
        {
            SetCenter();
            SetSize();
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(colliderCenter, colliderSize);
        }
    }
}