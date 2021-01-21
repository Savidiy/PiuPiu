using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKeybordInput : MonoBehaviour
{
    [SerializeField] private float speed = 6;

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        //if (vertical != 0 || horizontal != 0)
        //    Debug.Log($"vert = {vertical}, hoz = {horizontal}");

        Vector2 move = new Vector2(horizontal, vertical);
        move.Normalize();

        float dx = move.x * speed * Time.deltaTime;
        float dy = move.y * speed * Time.deltaTime;

        float newX = transform.position.x + dx;
        float newY = transform.position.y + dy;
        float newZ = transform.position.z;

        Vector3 newPosition = new Vector3(newX, newY, newZ);

        transform.position = newPosition;        
    }
}
