using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSU = GameUtility.GameStaticUtility;



public class RangerEnemy : Enemy
{
    [SerializeField] private float _stopDistance = 3f;

    private void FixedUpdate()
    {
        if (CheckPlayerInRange(out Vector2 directionToPlayer))
        {
            float distance = Vector2.Distance(transform.position, Player.transform.position);

            if (distance > _stopDistance)
            {
                EnemyMovement(directionToPlayer);
            }
            else
            {
                // Fermati, eventualmente prepara attacco
                EnemyMovement(Vector2.zero);
            }
        }
    }

    public override void EnemyMovement()
    {
        // Non serve: usiamo solo la versione con parametro
    }
}
