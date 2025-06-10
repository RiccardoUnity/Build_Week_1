using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class KamikazeEnemy : Enemy
{

    private void FixedUpdate()
    {
        if (CheckPlayerInRange())
        {
            EnemyMovement(_player.transform.position - transform.position);
            EnemyAttack();
        }
    }
    

    public override void EnemyMovement()
    {
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == _player.gameObject)
        {
            collision.gameObject.GetComponent<LifeController>().TakeDamage(Dmg); // Rimuove 10 punti vita al giocatore quando l'enemy lo colpisce
            _lifeController.TakeDamage(_lifeController.MaxHp); // Rimuove tutti i punti vita all'enemy quando colpisce il giocatore
        }
    }

}

