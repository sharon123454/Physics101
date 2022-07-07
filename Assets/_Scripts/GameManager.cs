using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    Collider kek;

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

}