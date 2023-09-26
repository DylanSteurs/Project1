using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
public class ScoreCounter : MonoBehaviour
{
    private int currentScore;
    public Text scoreText;
    // Use this for initialization
    void Start()
    {
        currentScore = 0;

    }

    private void HandleScore()
    {
        scoreText.text = "Score: " + currentScore;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "FoodPrefab")
        {
            currentScore++;
            HandleScore();
        }
    }
}