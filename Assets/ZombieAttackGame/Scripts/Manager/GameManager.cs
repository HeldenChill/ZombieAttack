using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst;
    private bool gameStarted = false;
    public Transform Player
    {
        get => player;
    }
    [SerializeField]
    Transform player;

    private void Awake()
    {
        if(Inst == null)
        {
            Inst = this;
            return;
        }

        Destroy(gameObject);
    }
    private void Start()
    {
        GameStarted = false;
    }

    public bool GameStarted
    {
        set
        {
            gameStarted = value;
            if (gameStarted)
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
            }
        }

        get => gameStarted;
    }

}
