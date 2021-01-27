using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleLiveController : MonoBehaviour, ILiveController
{
    [SerializeField] GameObject destroyTarget;
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
            //Destroy(destroyTarget);
            onDead.Invoke();
        }
    }

    public void SetLives(int lives)
    {
        _lives = lives;
    }

    public void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }
}
