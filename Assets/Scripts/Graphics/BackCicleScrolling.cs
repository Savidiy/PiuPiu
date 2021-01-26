using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCicleScrolling : MonoBehaviour
{
    [SerializeField] GameObject _spriteObject;    
    [SerializeField] float _speedY = -50f;

    Camera _camera;
    float _currentY = 0f;
    float _spriteHeight = 0f;
        
    void Start()
    {
        _camera = Camera.main;

        SpriteRenderer spriteRenderer = _spriteObject.GetComponent<SpriteRenderer>();

        _spriteHeight = spriteRenderer.sprite.rect.height;
        float windowHeight = _camera.pixelHeight;

        int _childAmount = Mathf.CeilToInt(windowHeight / _spriteHeight + 2);

        float startY = Mathf.Floor(-1 * windowHeight / 2 - _spriteHeight / 2);

        for (int i = 0; i < _childAmount; i++)
        {
            float newX = 0f;
            float newY = startY + i * _spriteHeight;
            float newZ = 0f;

            GameObject back = Instantiate(_spriteObject, transform);
            back.transform.position = new Vector3(newX, newY, newZ);
        }
    }

    void Update()
    {
        float dy = _speedY * Time.deltaTime;
        _currentY += dy;
        _currentY %= _spriteHeight;

        float newX = 0f;
        float newY = Mathf.Round(_currentY);
        float newZ = 0f;
        Vector3 newPosition = new Vector3(newX, newY, newZ);

        transform.position = newPosition;
    }
}
