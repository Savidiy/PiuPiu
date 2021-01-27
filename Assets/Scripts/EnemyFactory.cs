using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] float delay = 0.7f;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float minX = -300f;
    [SerializeField] float maxX = 300f;
    [SerializeField] float minY = 300f;
    [SerializeField] float maxY = 300f;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delay)
        {
            timer = 0;

            GameObject enemy = Instantiate(enemyPrefab);

            var x = Random.Range(minX, maxX);
            var y = Random.Range(minY, maxY);

            Vector3 spawnPosition = new Vector3(x, y, 0);
            enemy.transform.position = spawnPosition;

            //Debug.Log($"Camera size ({camera.pixelWidth}|{camera.pixelHeight}). Aspect = {camera.aspect}");
        }
        
    }
}
