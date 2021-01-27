using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGun : MonoBehaviour, IGun
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 20;

    public void Fire()
    {
        if (bulletPrefab != null)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;

            float gunAngle = transform.rotation.eulerAngles.z / 180f * Mathf.PI; // translate degree to radians
            float dx = Mathf.Cos(gunAngle) * bulletSpeed;
            float dy = Mathf.Sin(gunAngle) * bulletSpeed;

            Vector2 bulletPositionIncrement = new Vector2(dx, dy);

            bullet.GetComponent<BulletController>().SetDirection(bulletPositionIncrement);
        }
    }
}
