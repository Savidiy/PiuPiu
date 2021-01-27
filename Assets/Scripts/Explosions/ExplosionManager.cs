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

    [SerializeField] List<GameObject> prefabs;
    //[SerializeField] GameObject explosionPrefab;
    [SerializeField] int _initialCount;
    int[] _nextChildIndex;

    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            throw new System.Exception($"There are many {GetType().Name} of the entity. There should be only one of them.");
    }

    private void Start()
    {
        _nextChildIndex = new int[prefabs.Count];
        if (_initialCount < 1) _initialCount = 0;

        foreach(var prefab in prefabs)
        {
            GameObject folder = new GameObject();
            folder.transform.parent = transform;
            folder.name = prefab.name + "_Array";

            for (int i = 0; i < _initialCount; i++)
            {
                GameObject exp = Instantiate(prefab, folder.transform);
                exp.SetActive(false);
            }
        }

    }


    public void CreateExplosion (ExplosionType type, float x, float y)
    {
        int typeIndex = (int)type;

        Transform folder = transform.GetChild(typeIndex);

        if (_nextChildIndex[typeIndex] >= 0 && _nextChildIndex[typeIndex] < folder.childCount)
        {            
            Transform exp = folder.GetChild(_nextChildIndex[typeIndex]);
            if (exp.gameObject.activeSelf == true)
            {                
                exp = Instantiate(prefabs[typeIndex], folder).transform;
                _nextChildIndex[typeIndex] = -1;
            }

            Explosion explosion = exp.GetComponent<Explosion>();
            if (explosion != null)
            {
                explosion.StartExplosion(x, y);
            }

            _nextChildIndex[typeIndex]++;
            if (_nextChildIndex[typeIndex] >= folder.childCount)
                _nextChildIndex[typeIndex] = 0;
        }
        else
        {
            Debug.LogError($"{transform.name}:{GetType().Name} index out of range! Index = {_nextChildIndex}, length = {folder.childCount}");
            _nextChildIndex[typeIndex] = 0;
        }        
    }
}
