using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vikingMoveScript : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] float speed;
    [SerializeField] float walkSpeed = 8f;
    [SerializeField] float runSpeed = 15f;
    [SerializeField] KeyCode runInput;
    [SerializeField] bool isRun;

    [SerializeField] Transform groundCheck;
    [SerializeField] string jumpInput = "Jump";
    [SerializeField] bool isJump;
    [SerializeField] float jumpForce = 3f; //跳躍的力
    [SerializeField] Vector3 velocity; //y軸的衝量變化(向上的力)
    [SerializeField] float gravity = -15f;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] bool isGround;
    [SerializeField] LayerMask groundMash;

    Animator animator;
    [SerializeField] AudioSource footStep;
    [SerializeField] AudioSource jumpSound;
    bool isMoving;

    [SerializeField] Image hp;
    [SerializeField] Image screenHp;

    [SerializeField] AudioSource BGM;

    [SerializeField] AudioSource attackSound;
    void Start()
    {
        Time.timeScale = 1.0f;
        characterController = GetComponent<CharacterController>();
        runInput = KeyCode.LeftShift;
        groundCheck = GameObject.Find("viking/CheckGround").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        hp.fillAmount = 1f;
        screenHp.fillAmount = 1f;
        //isMute = false;
        //footStep = GetComponent<AudioSource>();
        //jumpSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        animator.SetFloat("speed", 0f);
        isMoving = false;
        checkGround();

        if (Input.GetMouseButton(0))
        {
            animator.SetTrigger("normalAttack");
            attackSound.Play();
        }

        Move();

        if(isMoving && !footStep.isPlaying && isGround)
        {
            footStep.Play();
        }
        if(!isMoving && footStep.isPlaying)
        {
            footStep.Stop();
        }
        if(!isGround && footStep.isPlaying)
        {
            footStep.Stop();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            BGM.mute = !BGM.mute;
        }
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");   //input水平
        float z = Input.GetAxis("Vertical");       //input垂直
        isRun = Input.GetKey(runInput);
        speed = isRun ? runSpeed : walkSpeed;

        moveDirection = (transform.right * x + transform.forward * z).normalized;
        characterController.Move(moveDirection * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            if(speed == walkSpeed)
            {
                animator.SetFloat("speed", 1f);
            }
            else
            {
                animator.SetFloat("speed", 2f);
            }
            
            isMoving = true;
        }

        if (isGround == false)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        characterController.Move(velocity * Time.deltaTime);
        Jump();
        
    }

    void Jump()
    {
        animator.SetBool("jump", false);
        isJump = Input.GetButtonDown(jumpInput);
        if (isJump && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f  * gravity);
            animator.SetBool("jump", true);
            jumpSound.Play();
        }
    }

    void checkGround()
    {
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMash);
        if (isGround && velocity.y <= 0)
        {
            velocity.y = -2f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "sword")
        {
            hp.fillAmount -= 0.1f;
            screenHp.fillAmount -= 0.1f;
        }
    }
}
