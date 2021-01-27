using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLiveController : MonoBehaviour, ILiveController
{
    [SerializeField] int _lives = 1;
    [SerializeField] int _damage = 1;
    [SerializeField] UnityEvent onDead;
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
            onDead.Invoke();

            _lives = 3;
            float dx = 0; 
            float dy = -0.8f * Camera.main.orthographicSize;
            transform.position = new Vector3(dx, dy, 0);

            FindObjectOfType<ScoreCalc>().ScoreCheck(-200);
        }
    }

    public void SetLives(int lives)
    {
        _lives = lives;
    }
}
