using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] float delay = 0.7f;
    [SerializeField] EnemyType type = EnemyType.Basic;
    [SerializeField] float minX = -300f;
    [SerializeField] float maxX = 300f;
    [SerializeField] float minY = 300f;
    [SerializeField] float maxY = 300f;
    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delay)
        {
            timer = 0;

            var x = Random.Range(minX, maxX);
            var y = Random.Range(minY, maxY);

            EnemyManager.Instance.SpawnEnemy(type, x, y);
        }        
    }
}
