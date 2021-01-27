using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] Transform _transform;
    float _dx;
    float _dy;

    public void PlaceAndShoot(float x, float y, float dx, float dy)
    {
        if (_transform != null)
        {
            _transform.gameObject.SetActive(true);
            _transform.position = new Vector3(x, y, 0f);
        }

        _dx = dx;
        _dy = dy;
    }

    void Update()
    {
        if (_transform != null)
        {
            float dx = _dx * Time.deltaTime;
            float dy = _dy * Time.deltaTime;
            _transform.Translate(dx, dy, 0);
        }
    }
}
