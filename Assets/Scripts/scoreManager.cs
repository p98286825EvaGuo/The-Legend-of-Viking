using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    private int score;
    [SerializeField] AudioSource pickUpCoin;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void plusScore()
    {
        score++;
        pickUpCoin.Play();
        scoreToString();
    }

    public void scoreToString()
    {
        GameObject.Find("scoreNum").GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}
