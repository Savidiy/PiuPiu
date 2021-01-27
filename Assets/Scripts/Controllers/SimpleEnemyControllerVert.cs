using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyControllerVert : MonoBehaviour
{
    [SerializeField] float dy = -3;
    [SerializeField] float offset = -30;
    [SerializeField] Transform _transform;
    [SerializeField] SimpleLiveController _liveController;
    float downScreenBorder;

    // Start is called before the first frame update
    void Start()
    {
        downScreenBorder = -1 * Camera.main.pixelHeight / 2 + offset; // left border of screen
        if (_liveController == null)
        {
            Debug.LogError($"{transform.parent.name}:{transform.name}:{GetType().Name} there is not _liveController.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        _transform.Translate(0, dy * Time.deltaTime, 0);

        if (_transform.position.y < downScreenBorder)
        {
            _liveController.ResetLives();
            _transform.gameObject.SetActive(false);
        }
    }
}
