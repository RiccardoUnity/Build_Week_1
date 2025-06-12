using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSU = GameUtility.GameStaticUtility;

public class WeaponNearestTarget : Weapon
{
    public GameObject FindNearestTarget()
    {
        string targetTag = GetTargetTag();
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);  //Vedi lista nemici in using GSU
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

    private string GetTargetTag()
    {
        if (CompareTag(GSU.PlayerTag))
        {
            return GSU.EnemyTag;
        }
        else if (CompareTag(GSU.EnemyTag))
        {
            return GSU.PlayerTag;
        }
        return null;
    }

    void Update()
    {
        Shoot();
    }
}
