using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColliderV2 : ColliderV2
{
    //default sphere settings v
    public Vector3 Center = Vector3.zero;
    public float Radius = 0.5f;

    //sphere collider inner variable
    private Vector3 colliderCenter;
    private float radius;

    private void Awake()
    {
        SetCenter();
        SetSize();
    }

    protected override void CheckCollision()
    {
        if (isTrigger)
        {

            {
                //OnTrigger();
            }
        }
        else
        {

            {
                //onCollision();
            }
        }
    }

    private void SetCenter()
    {
        //if pivot point isn't default
        if (Center != Vector3.zero)
        {
            //set collider center data by variables given
            colliderCenter.x = transform.position.x + Center.x;
            colliderCenter.y = transform.position.y + Center.y;
            colliderCenter.z = transform.position.z + Center.z;
        }
        //if collider center is default, use objects' position
        else
        {
            colliderCenter = transform.position;
        }
    }

    private void SetSize()
    {
        #region doesn't work fully, scrapped. ignore.
        //float largestScale = Radius;

        //if (transform.localScale.x > transform.localScale.y)
        //    largestScale = transform.localScale.x;
        //if (transform.localScale.x > transform.localScale.z)
        //    largestScale = transform.localScale.x;
        //if (transform.localScale.y > transform.localScale.x)
        //    largestScale = transform.localScale.y;
        //if (transform.localScale.y > transform.localScale.z)
        //    largestScale = transform.localScale.y;
        //if (transform.localScale.z > transform.localScale.x)
        //    largestScale = transform.localScale.z;
        //if (transform.localScale.z > transform.localScale.y)
        //    largestScale = transform.localScale.z;
        //radius = Radius;
        #endregion

        radius = Radius;
    }

    private void OnDrawGizmosSelected()
    {
        //if bool show is on
        if (ShowCollider)
        {
            //set collider
            SetCenter();
            SetSize();
            //draw collider
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(colliderCenter, radius);
        }
    }
}