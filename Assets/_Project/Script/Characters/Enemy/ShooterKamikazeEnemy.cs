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

    }
}
