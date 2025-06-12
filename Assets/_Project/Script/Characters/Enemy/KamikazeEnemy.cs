using UnityEngine;
using GSU = GameUtility.GameStaticUtility;


public class KamikazeEnemy : Enemy
{

    private void FixedUpdate()
    {
        if (CheckPlayerInRange())
        {
            Vector2 direction = Player.transform.position - transform.position;

            EnemyMovement(direction);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.gameObject)
        {
            collision.gameObject.GetComponent<LifeController>().TakeDamage(Dmg); // Rimuove 10 punti vita al giocatore quando l'enemy lo colpisce
            LifeController.TakeDamage(LifeController.Hp); // Rimuove tutti i punti vita all'enemy quando colpisce il giocatore
        }
    }

}
