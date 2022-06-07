using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Animator _rightTrigger;
    [SerializeField] private Animator _leftTrigger;

    public bool GameInSession { get => _gameInSession; set => _gameInSession = value; }

    private bool _gameInSession;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
    }

    private void Update()
    {
        
    }

    public void RightTriggerTogggle()
    {
        if (_rightTrigger)
            _rightTrigger.SetTrigger("Trigger");
    }

    public void LeftTriggerTogggle()
    {
        if (_leftTrigger)
            _leftTrigger.SetTrigger("Trigger");
    }

}