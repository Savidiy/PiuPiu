using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    static public BulletManager Instance
    {
        get
        {
            return _instance;
        }
    }
    static private BulletManager _instance;

    [SerializeField] List<GameObject> prefabs;
    [SerializeField] GameObject folderPrefab;
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

        foreach (var prefab in prefabs)
        {
            GameObject folder = Instantiate(folderPrefab);
            folder.transform.parent = transform;
            folder.name = prefab.name + "_Array";


            for (int i = 0; i < _initialCount; i++)
            {
                GameObject exp = Instantiate(prefab, folder.transform);
                exp.SetActive(false);
            }
        }

    }

    public void CreateBullet(BulletType type, float x, float y, float dx, float dy)
    {
        int typeIndex = (int)type;

        Transform folder = transform.GetChild(typeIndex);

        if (_nextChildIndex[typeIndex] >= 0 && _nextChildIndex[typeIndex] < folder.childCount)
        {
            Transform obj = folder.GetChild(_nextChildIndex[typeIndex]);
            if (obj.gameObject.activeSelf == true)
            {
                obj = Instantiate(prefabs[typeIndex], folder).transform;
                _nextChildIndex[typeIndex] = -1;
            }

            BulletController bullet = obj.GetComponent<BulletController>();
            if (bullet != null)
            {
                bullet.PlaceAndShoot(x, y, dx, dy);
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
