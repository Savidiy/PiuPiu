using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] float delay = 0.7f;
    [SerializeField] GameObject enemyPrefab;
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

            Camera camera = Camera.main;

            var x = camera.orthographicSize * camera.aspect;
            float minY = -camera.orthographicSize;
            float maxY = camera.orthographicSize;
            var y = Random.Range(minY, maxY);
            Vector3 spawnPosition = new Vector3(x, y, 0);
            enemy.transform.position = spawnPosition;

            //Debug.Log($"Camera size ({camera.pixelWidth}|{camera.pixelHeight}). Aspect = {camera.aspect}");
        }
        
    }
}
