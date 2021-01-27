using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportProvider : MonoBehaviour
{
    [SerializeField] Transform _transform;

    public void SetTransformX(float x)
    {
        if(_transform != null)
        {
            Vector3 p = _transform.position;
            p.x = x;
            _transform.position = p;
        }
        else
        {
            Debug.LogError($"{transform.name}:{GetType().Name} there is not _transform.");
        }
    }
    public void SetTransformY(float y)
    {        
        if (_transform != null)
        {
            Vector3 p = _transform.position;
            p.y = y;
            _transform.position = p;
        }
        else
        {
            Debug.LogError($"{transform.name}:{GetType().Name} there is not _transform.");
        }
    }
    public void SetTransformZ(float z)
    {        
        if (_transform != null)
        {
            Vector3 p = _transform.position;
            p.z = z;
            _transform.position = p;
        }
        else
        {
            Debug.LogError($"{transform.name}:{GetType().Name} there is not _transform.");
        }
    }
}
