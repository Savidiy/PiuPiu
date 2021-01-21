using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Vector2 _direction = new Vector2();
    [SerializeField] float lifetime = 2;

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {        
        float dx = _direction.x * Time.deltaTime;
        float dy = _direction.y * Time.deltaTime;
        transform.Translate(dx, dy, 0);
    }
}
