using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Spring2 : MonoBehaviour
{
    [SerializeField] float minusK = 20f, forceInMeter = 0.5f, minPower = 0f, maxPower = 50f;
    [SerializeField] Slider powerSlider;

    private List<Rigidbody> ballList;
    KeyCode FireButton = KeyCode.Space;
    bool readyToFire = false;
    float power;

    private void Start()
    {
        //creating a new list and setting slider min and max points
        ballList = new List<Rigidbody>();
        powerSlider.minValue = minPower;
        powerSlider.maxValue = maxPower;
    }

    private void Update()
    {
        ReadyCheck();

        if (readyToFire)
        {
            PlayerInput();
            powerSlider.value = power;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
            ballList.Add(other.gameObject.GetComponent<Rigidbody>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
            ballList.Remove(other.gameObject.GetComponent<Rigidbody>());
    }

    private void ReadyCheck()
    {
        //is the ball inside his launch point, and added to the list?
        if (ballList.Count > 0)
        {
            //turning on UI & allowing the player to shoot
            powerSlider.gameObject.SetActive(true);
            readyToFire = true;
        }
        else
        {
            //turning off UI & disabling players ability to shoot
            powerSlider.gameObject.SetActive(false);
            readyToFire = false;
            power = 0f;
        }
    }

    private void PlayerInput()
    {
        //while Player holds Fire button calculate the Force (F = -kx) using elasticity formula
        if (Input.GetKey(FireButton))
            if (power <= maxPower)
                power += minusK * forceInMeter * Time.deltaTime;

        //on release, add force to any ball at their lunch point
        if (Input.GetKeyUp(FireButton))
            foreach (Rigidbody rb in ballList)
                rb.AddForce(power * Vector3.forward);
    }

}