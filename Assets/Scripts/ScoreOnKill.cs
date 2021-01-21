using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnKill : MonoBehaviour
{
    [SerializeField] int score = 0;

    public void OnKill()
    {
        FindObjectOfType<ScoreCalc>().ScoreCheck(score);
    }


}
