using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        ILiveController obj1 = GetComponent<ILiveController>();
        ILiveController obj2 = collider.gameObject.GetComponent<ILiveController>();

        if (obj1 != null || obj2 != null)
        {
            obj1.GetHit(obj2.Damage);
            //obj2.GetHit(obj1.Damage);

            string obj1name = name;
            string obj2name = collider.name;
            Debug.Log($"Trigger: {obj1name} hit {obj2name} by {obj2.Damage}.");
        }
    }


}
