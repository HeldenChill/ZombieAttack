using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

public class PlayerMovement : MonoBehaviour
{
    
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public PlayerData data;

    // Start is called before the first frame update
    void Awake()
    {
        data = ScriptableObject.CreateInstance("PlayerData") as PlayerData;
    }

    private void OnEnable()
    {
        LevelManager.Inst.OnEnemyDie += OnEnemyDie;
    }
    private void Start()
    {
        data.MaxHP = 100;
        data.Kill = 0;
        data.Wave = 1;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);


        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void OnEnemyDie()
    {
        data.Kill += 1;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy1")
        {
            data.CurrentHP -= 1;
            if(data.CurrentHP <= 0)
            {
                UIManager.Inst.UIRestartMenu.SetScore(data.Kill);
                UIManager.Inst.UIRestartMenu.SetActive(true);
                GameManager.Inst.GameStarted = false;
                
            }
        }
    }
    private void OnDisable()
    {
        LevelManager.Inst.OnEnemyDie -= OnEnemyDie;
    }
}
