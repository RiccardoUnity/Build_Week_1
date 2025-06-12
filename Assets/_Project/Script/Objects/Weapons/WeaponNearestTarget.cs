using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSU = GameUtility.GameStaticUtility;

public class WeaponNearestTarget : Weapon
{
    private bool isPlayer = false;

    public GameObject FindNearestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(GSU.EnemyTag);  //Vedi lista nemici in using GSU
        GameObject nearest = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject target in targets)
        {

            float distance = Vector2.Distance(transform.position, target.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearest = target;
            }
            if (nearest == null)
            {
                //Debug.Log("Tutti i nemici distrutti");
                return null;
            }
        }
        return nearest;
    }

    public override void Shoot()
    {
        GameObject enemy = FindNearestTarget();
        if (enemy == null) return;

        if (Time.time - _lastShotTime > fireRate)
        {
            _lastShotTime = Time.time;
            Vector2 force = (enemy.transform.position - transform.position).normalized;

            Bullet b = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            b.ShootBullet(tag, force, Damage); // puoi usare _damage se lo esponi come `protected`
        }
    }

    void Update()
    {
        Shoot();
    }
}
