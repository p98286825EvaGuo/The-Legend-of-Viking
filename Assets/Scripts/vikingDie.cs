using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class vikingDie : MonoBehaviour
{
    [SerializeField] Image vikingHp;
    Animator animator;
    [SerializeField] GameObject gameoverUI;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gameoverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(vikingHp.fillAmount < 0.01)
        {
            Invoke("endGame", 2.0f);
            animator.SetTrigger("die");
        }
        if(transform.position.y < -5)
        {
            endGame();
        }
    }

    void endGame()
    {
        gameoverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void again()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
}
