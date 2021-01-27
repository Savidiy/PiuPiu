using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateExplosion : MonoBehaviour
{
    [SerializeField] ExplosionType type;

    public void CreateExplosionThere()
    {
        ExplosionManager.Instance.CreateExplosion(type, transform.position.x, transform.position.y);
    }
}
