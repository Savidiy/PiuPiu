using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SetActive = False if object over border
/// </summary>
public class BulletOutCameraCleaner : MonoBehaviour
{
    [SerializeField] float cameraOffset = 10f;
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    void Start()
    {
        var camera = Camera.main;
        xMax = camera.orthographicSize * camera.aspect + cameraOffset;
        xMin = -1 * xMax;
        yMax = camera.orthographicSize + cameraOffset;
        yMin = -1 * yMax;

        StartCoroutine(Clean());
    }

    IEnumerator Clean()
    {
        int i = 0;
        while (true)
        {
            if (transform.childCount > 0)
            {
                if (i < transform.childCount)
                {
                    var t = transform.GetChild(i);
                    if (t.gameObject.activeSelf == true)
                    {
                        if (t.position.x < xMin
                            || t.position.x > xMax
                            || t.position.y < yMin
                            || t.position.y > yMax)
                        {
                            //Debug.Log($"{name}:{Time.time} off {i} bullet.");
                            t.gameObject.SetActive(false);
                        }
                    }
                    i++;
                }
                else
                {
                    i = 0;
                }
                //Debug.Log($"{Time.time}: check{i} bullet.");
                yield return null;
            }
        }
    }
}
