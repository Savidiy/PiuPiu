using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    static private ExplosionManager _instance;
    static public ExplosionManager Instance
    {
        get
        {
            return _instance;
        }
    }

    [SerializeField] GameObject explosion;

    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            throw new System.Exception($"There are many {GetType().Name} of the entity. There should be only one of them.");
    }

    public void CreateExplosion (ExplosionType type, float x, float y)
    {
        GameObject exp = Instantiate(explosion, transform);
        exp.transform.position = new Vector3(x, y, 0f);
    }
}
