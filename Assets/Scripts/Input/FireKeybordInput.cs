using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireKeybordInput : MonoBehaviour
{
    private IGun[] guns;
    [SerializeField] private float cooldown = 0.5f;
    [SerializeField] AudioSource fireSound;

    private float cooldownTimer;

    private void Start()
    {
        guns = transform.GetComponentsInChildren<IGun>();
        cooldownTimer = cooldown;
    }

    void Update()
    {
        if (cooldownTimer < cooldown)
        {
            cooldownTimer += Time.deltaTime;
        }
        else
        {
            if (Input.GetButton("Fire1"))
            {
                if (fireSound != null)
                    fireSound.Play();
                foreach (var g in guns)
                {
                    g.Fire();
                }
                cooldownTimer = 0;

                //FindObjectOfType<ScoreCalc>().ScoreCheck(-1);
            }
        }
    }
}
