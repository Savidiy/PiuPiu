using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform _transform;
    public void Spawn(float x, float y)
    {
        if (_transform != null)
        {
            _transform.gameObject.SetActive(true);
            _transform.position = new Vector3(x, y, 0f);
        }
        else
        {
            Debug.LogError($"{transform.name}:{GetType().Name} there is not _transform.");
        }
    }
}
