using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMultipleBullets : Weapon
{
    [SerializeField] private float spreadAngle = 15f;
    public override void Shoot()
    {
        if (Time.time - _lastShotTime > fireRate)
        {
            _lastShotTime = Time.time;
            Bullet b1 = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            Bullet b2 = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            Bullet b3 = Instantiate(BulletPrefab, transform.position, Quaternion.identity);

            Vector2 dirLeft = Quaternion.Euler(0, 0, spreadAngle) * _lastMoveDirection;
            Vector2 dirRight = Quaternion.Euler(0, 0, -spreadAngle) * _lastMoveDirection;

            b1.ShootBullet(tag, _lastMoveDirection, Damage);
            b2.ShootBullet(tag, dirLeft, Damage);
            b3.ShootBullet(tag, dirRight, Damage);
        }
    }

    void Update()
    {
        UpdateDirection(_playerController.Dir);
        Shoot();
    }
}
