using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSpeedController : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] float speed = 1f;
    [SerializeField] string speedName = "speed";

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
        if (_animator != null)
            _animator.SetFloat(speedName, speed);
        else
            Debug.LogError($"{transform.name}:{GetType().Name} no animator!");
    }
}
