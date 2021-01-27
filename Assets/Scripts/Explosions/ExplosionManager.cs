using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    static public ExplosionManager Instance
    {
        get
        {
            return _instance;
        }
    }
    static private ExplosionManager _instance;

    [SerializeField] GameObject explosionPrefab;
    [SerializeField] int _initialCount;
    int _nextChildIndex;

    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            throw new System.Exception($"There are many {GetType().Name} of the entity. There should be only one of them.");
    }

    private void Start()
    {
        _nextChildIndex = 0;
        if (_initialCount < 1) _initialCount = 0;
        for (int i = 0; i < _initialCount; i++)
        {
            GameObject exp = Instantiate(explosionPrefab, transform);
            exp.SetActive(false);
        }
    }


    public void CreateExplosion (ExplosionType type, float x, float y)
    {
        if (_nextChildIndex >= 0 && _nextChildIndex < transform.childCount)
        {            
            Transform exp = transform.GetChild(_nextChildIndex);
            if (exp.gameObject.activeSelf == true)
            {                
                exp = Instantiate(explosionPrefab, transform).transform;
                _nextChildIndex++;
            }

            Explosion explosion = exp.GetComponent<Explosion>();
            if (explosion != null)
            {
                explosion.StartExplosion(x, y);
            }

            _nextChildIndex++;
            if (_nextChildIndex >= transform.childCount)
                _nextChildIndex = 0;
        }
        else
        {
            Debug.LogError($"{transform.name}:{GetType().Name} index out of range! Index = {_nextChildIndex}, length = {transform.childCount}");
            _nextChildIndex = 0;
        }
        
    }
}
