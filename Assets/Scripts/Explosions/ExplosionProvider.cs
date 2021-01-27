using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionProvider : MonoBehaviour
{
    [SerializeField] ExplosionType type;

    public void CreateExplosionHere()
    {
        ExplosionManager.Instance.CreateExplosion(type, transform.position.x, transform.position.y);
    }
}
