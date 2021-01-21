using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLiveController : MonoBehaviour, ILiveController
{
    [SerializeField] int _lives = 1;
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
            Destroy(gameObject);
    }

    public void SetLives(int lives)
    {
        _lives = lives;
    }
}
