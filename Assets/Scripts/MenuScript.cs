using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject howToPlayUI;
    // Start is called before the first frame update
    void Start()
    {
        howToPlayUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playGame()
    {
        SceneManager.LoadScene(1);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void howToPlay()
    {
        howToPlayUI.SetActive(true);
    }

    public void back()
    {
        howToPlayUI.SetActive(false);
    }
}
