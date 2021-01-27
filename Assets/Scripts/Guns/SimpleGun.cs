using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGun : MonoBehaviour, IGun
{
    [SerializeField] BulletType type;
    [SerializeField] float bulletSpeed = 20;

    public void Fire()
    {

        float gunAngle = transform.rotation.eulerAngles.z / 180f * Mathf.PI; // translate degree to radians
        float dx = Mathf.Cos(gunAngle) * bulletSpeed;
        float dy = Mathf.Sin(gunAngle) * bulletSpeed;
           
        BulletManager.Instance.CreateBullet(
            type,
            x: transform.position.x,
            y: transform.position.y,
            dx: dx,
            dy: dy);

        
    }
}
