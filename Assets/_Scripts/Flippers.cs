using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Flippers : MonoBehaviour
{
    [SerializeField] float restPos = 0f, activePos = 45f, hitStrenght = 10000f, damper = 100f;
    [SerializeField] string inputName;

    HingeJoint myHinge;

    private void Awake()
    {
        myHinge = GetComponent<HingeJoint>();
    }

    private void Start()
    {
        myHinge.useSpring = true;
    }

    private void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrenght;
        spring.damper = damper;

        if (Input.GetAxis(inputName) == 1)
            spring.targetPosition = activePos;
        else
            spring.targetPosition = restPos;

        myHinge.spring = spring;
        myHinge.useLimits = true;

    }

}