using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ILiveController))]
[RequireComponent(typeof(Collider2D))]
public class TriggerController : MonoBehaviour
{
    ILiveController liveController;

    private void Start()
    {
        liveController = GetComponent<ILiveController>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        ILiveController obj2 = collider.gameObject.GetComponent<ILiveController>();

        if (liveController != null || obj2 != null)
        {
            liveController.GetHit(obj2.Damage);

            string obj1name = name;
            string obj2name = collider.name;
            Debug.Log($"Trigger: {obj1name} hit {obj2name} by {obj2.Damage}.");
        }
    }


}
