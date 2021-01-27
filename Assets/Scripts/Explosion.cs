using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Explosion : MonoBehaviour
{
    Animator _animator;
    [SerializeField] float speed = 1f;
    [SerializeField] string speedName = "speed";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
        _animator.SetFloat(speedName, speed);
    }

    public void EndAnimation()
    {
        Destroy(gameObject);
    }
}
