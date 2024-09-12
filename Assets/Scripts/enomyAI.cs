using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enomyAI : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] float attackDistance = 2f;
    [SerializeField] float attackArea = 30f;
    Animator animator;
    [SerializeField] float speed = 6;
    private CharacterController characterController;
    private float attackTime = 2f;
    private float attackCounter = 0f;
    [SerializeField] float gravity = 20f;
    private Vector3 moveDirection = Vector3.zero;

    [SerializeField] Image hp;

    [SerializeField] GameObject coinPrefab;
    [SerializeField] Transform coinPos;
    private GameObject coin;
    private bool isCreate = false;
    private bool isDead = false;
    //[SerializeField] AudioSource pickupCoin;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        attackCounter = attackTime;
        hp.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = playerTransform.position;
        targetPosition.y = playerTransform.position.y;

        float dis = Vector3.Distance(targetPosition, transform.position);

        if(isCreate == true)
        {
            animator.SetBool("die", true);
        }
        else if (dis <= attackDistance)
        {
            animator.SetBool("walk", false);
            attackCounter += Time.deltaTime;
            if(attackCounter > attackTime)
            {
                animator.SetTrigger("attack");
                attackCounter = 0;
            }
        }
        else if (dis <= attackArea && dis > attackDistance)
        {
            transform.LookAt(playerTransform);
            characterController.Move(gameObject.transform.forward * speed * Time.deltaTime);
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }

        if (!characterController.isGrounded)
        {
            if(isCreate == true)
            {
                moveDirection = Vector3.zero;
                moveDirection.y -= gravity * Time.deltaTime;
                characterController.Move(moveDirection * Time.deltaTime * speed);
            }
        }

        if(hp.fillAmount < 0.2)
        {
            
            if (isCreate == false)
            {
                isCreate = true;
                coin = Instantiate(coinPrefab) as GameObject;
                coin.transform.position = coinPos.transform.position;
                //speed = 0;
            }
            //Destroy(gameObject);
        }

            if (Input.GetKey(KeyCode.F) && isDead == false)
            {
                if(Vector3.Distance(coin.transform.position, playerTransform.position) < 3)
                {
                    GameObject.Find("gamingCanvas").GetComponent<scoreManager>().plusScore();
                    Destroy(coin);
                    Destroy(gameObject);
                    isDead = true;
                }
            }
            
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "axes")
        {
            hp.fillAmount -= 0.2f;
        }

        
    }

    void destroyCoin()
    {
        Destroy(coin);
        Destroy(gameObject);
        isDead = true;
    }
}
