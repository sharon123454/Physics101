using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Spring2 : MonoBehaviour
{
    [SerializeField] float minusK = 20f, forceInMeter = 0.5f, minPower = 0f, maxPower = 50f;
    [SerializeField] Slider powerSlider;

    List<Rigidbody> ballList;
    bool readyToFire = false;
    float power;

    private void Start()
    {
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
            UpdateSpring();
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
        if (ballList.Count > 0)
        {
            powerSlider.gameObject.SetActive(true);
            readyToFire = true;
        }
        else
        {
            powerSlider.gameObject.SetActive(false);
            readyToFire = false;
            power = 0f;
        }
    }

    private void PlayerInput()
    {
        if (Input.GetKey(KeyCode.Space))
            if (power <= maxPower)
                power += minusK * forceInMeter * Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.Space))
            foreach (Rigidbody rb in ballList)
                rb.AddForce(power * Vector3.forward);
    }

    private void UpdateSpring()
    {

        //Vector3.Lerp(startPos, endPos, power / maxPower);
    }

}