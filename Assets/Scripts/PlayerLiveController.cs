using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLiveController : MonoBehaviour, ILiveController
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
        {
            _lives = 3;
            float dx = -0.9f * Camera.main.orthographicSize * Camera.main.aspect ;
            float dy = 0;
            transform.position = new Vector3(dx, dy, 0);

            FindObjectOfType<ScoreCalc>().ScoreCheck(-200);
        }
    }

    public void SetLives(int lives)
    {
        _lives = lives;
    }
}
