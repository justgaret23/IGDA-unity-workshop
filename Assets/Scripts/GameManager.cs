using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public int winningScore = 11;
    public GameObject winningUI;
    public TextMeshProUGUI scoreText;
    public Player player;
    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        winningUI.SetActive(false);

        if(instance == null){
            instance = this;
        }
    }

    public void IncreaseScore(int increaseAmount){
        score += increaseAmount;
        scoreText.text = "Score: " + score;
        if(score >= winningScore){
            ActivateWinCondition();
        }
        
    }

    private void ActivateWinCondition(){
        scoreText.gameObject.SetActive(false);
        winningUI.SetActive(true);
        player.canMove = false;
    }
}
