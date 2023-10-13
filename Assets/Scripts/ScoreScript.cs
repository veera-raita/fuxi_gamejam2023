using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

public class ScoreScript : MonoBehaviour
{
    public TMP_Text ScoreDisplay;
    public int ScoreCount;

    //public event Action<int> Points;

    private void Update()
    {
        ScoreDisplay.text = ScoreCount.ToString();
    }

    public void AddPoints(int t_amount)
    {
        ScoreCount += t_amount;
    }
}
