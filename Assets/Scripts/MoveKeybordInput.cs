using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKeybordInput : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float speed = 300f;
    [SerializeField] private float minX = -200f;
    [SerializeField] private float maxX = 200f;
    [SerializeField] private float minY = -200f;
    [SerializeField] private float maxY = 200f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float oldX = _transform.position.x;
        float oldY = _transform.position.y;

        // чтобы не тереться и замедляться о край экрана
        if (oldX == minX && horizontal < 0) horizontal = 0;
        if (oldX == maxX && horizontal > 0) horizontal = 0;
        if (oldY == minY && vertical < 0) vertical = 0;
        if (oldY == maxY && vertical > 0) vertical = 0;

        Vector2 move = new Vector2(horizontal, vertical);
        move.Normalize();

        float dx = move.x * speed * Time.deltaTime;
        float dy = move.y * speed * Time.deltaTime;

        float newX = Mathf.Round(oldX + dx);
        float newY = Mathf.Round(oldY + dy);
        float newZ = _transform.position.z;

        if (newX < minX) newX = minX;
        if (newX > maxX) newX = maxX;
        if (newY < minY) newY = minY;
        if (newY > maxY) newY = maxY;

        Vector3 newPosition = new Vector3(newX, newY, newZ);

        _transform.position = newPosition;        
    }
}
