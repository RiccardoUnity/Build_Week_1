using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class KamikazeEnemy : Enemy
{

    public override void EnemyMovement()
    {
        if (_player != null)
        {
            

            Vector2 direction = (_player.transform.position - transform.position).normalized;
            // Muovi l'enemy nella direzione del giocatore
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _movement._speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction); // Ruota l'enemy verso il giocatore

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == _player.gameObject)
        {
            collision.gameObject.GetComponent<LifeController>().RemoveHp(10); // Rimuove 10 punti vita al giocatore quando l'enemy lo colpisce
            _lifeController.RemoveHp(_maxHp); // Rimuove 100 punti vita all'enemy quando colpisce il giocatore
        }
    }

}
