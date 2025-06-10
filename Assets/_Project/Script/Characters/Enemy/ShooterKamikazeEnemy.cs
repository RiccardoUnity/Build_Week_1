using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterKamikazeEnemy : KamikazeEnemy
{

    [SerializeField] float _attackCooldown = 2f;
    [SerializeField] new Bullet BulletPrefab; // Prefab del proiettile da sparare  
    //private float _lastAttackTime = 0f;

    void FixedUpdate()
    {
        if (CheckPlayerInRange())
        {
            EnemyAttack();
        }
    }

    public override void EnemyAttack()
    {
        //if (Time.time - _lastAttackTime >= _attackCooldown && CheckPlayerInRange())
        //{
        //    Vector3 direction = Vector2.up; //Spara in avanti.
        //    Bullet bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        //    bullet.Shoot(transform.position, direction); //Spara il proiettile nella direzione specificata
        //    _lastAttackTime = Time.time;
        //}
    }
}
