using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderV2 : MonoBehaviour
{
    public bool ShowCollider = true;
    public bool isTrigger = false;

    public static List<GameObject> TriggerEvent = new List<GameObject>();
    public static List<GameObject> ActiveCollider = new List<GameObject>();

    private void OnEnable()
    {
        if (isTrigger)
            TriggerEvent.Add(this.gameObject);
        else
            ActiveCollider.Add(this.gameObject);
    }

    private void OnDisable()
    {
        if (isTrigger)
            TriggerEvent.Remove(this.gameObject);
        else
            ActiveCollider.Remove(this.gameObject);
    }

    private void Update()
    {
        CheckCollision();
    }

    protected virtual void CheckCollision()
    {
        if (isTrigger)
        {
            OnTrigger();
        }
        else
        {

            {
                onCollision();
            }
        }
    }

    private void OnTrigger()
    {

    }

    private void onCollision()
    {

    }
}