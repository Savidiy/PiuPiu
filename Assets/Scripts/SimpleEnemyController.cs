using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyController : MonoBehaviour
{
    [SerializeField] float dx = 3;
    float leftScreenBorder;

    // Start is called before the first frame update
    void Start()
    {
        leftScreenBorder = -1 * Camera.main.orthographicSize * Camera.main.aspect; // left border of screen
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dx * Time.deltaTime, 0, 0);

        if (transform.position.x < leftScreenBorder)
            Destroy(gameObject);
    }
}
