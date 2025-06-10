using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnemy : Enemy
{
   
    [SerializeField] float _attackCooldown = 2f;
    [SerializeField] new Bullet BulletPrefab; // Prefab del proiettile da sparare  
    private float _lastAttackTime = 0f;

    private void FixedUpdate()
    {
        if (CheckPlayerInRange())
        {
            EnemyMovement();
            EnemyAttack();
        }
    }

    public override void EnemyMovement()
    {
        // Il TowerEnemy non si muove, quindi non implemento nulla qui.
    }

    public override void EnemyAttack()
    {
        //if (time.time - _lastattacktime >= _attackcooldown && checkplayerinrange( out vector2 playerdirection))
        //{
        //    vector3 direction = playerdirection; //spara verso il giocatore.
        //    bullet bullet = instantiate(bulletprefab, transform.position, quaternion.identity);
        //    bullet.shoot(transform.position, direction); //spara il proiettile nella direzione specificata
        //    _lastattacktime = time.time;
        //}
        
    }
}

