using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoardBoard : MonoBehaviour
{
    int score;
    TMP_Text textScore;


     void Start()
    {
        textScore = GetComponent<TMP_Text>();
        textScore.text = "0";
    }
    public void IncreaseScore(int amountToIncrease)
    {
        score +=  amountToIncrease;
        textScore.text = score.ToString();

    }

    
}
