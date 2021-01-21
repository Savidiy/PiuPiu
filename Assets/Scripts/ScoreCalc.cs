using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalc : MonoBehaviour
{
    int score = 0;

    public void ScoreCheck(float value)
    {
        int.TryParse(value.ToString(), out int d);
        score += d;
        if (score < 0)
            score = 0;
        GetComponent<Text>().text = $"Score: {score}";
    }

    
}
