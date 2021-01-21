using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLiveController : MonoBehaviour, ILiveController
{
    int _lives = 1;
    [SerializeField] int _damage = 1;    
    public int Damage
    {
        get { return _damage; }
        private set { _damage = value; }
    }

    public void GetHit(int incomeDamage)
    {
        _lives -= incomeDamage;
        if (_lives <= 0)
        {
            var obj = GetComponent<ScoreOnKill>();
            if (obj != null)
                obj.OnKill();
            Destroy(gameObject);
        }
        else
        {
            SetColor();
        }
    }

    public void SetLives(int lives)
    {
        _lives = lives;
        SetColor();
    }

    void SetColor()
    {
        var spr = gameObject.GetComponent<SpriteRenderer>();

        switch (_lives)
        {
            case 1: spr.color = Color.green; break;
            case 2: spr.color = Color.yellow; break;
            default: spr.color = Color.red; break;
        }
         
    }
}

