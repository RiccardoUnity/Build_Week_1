using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _origin;             // chi spara 
    public float speed = 10f;             // Velocità proiettile
    public float lifeTime = 2f;           // Durata prima che si autodistrugga
    public int damage = 1;                // Danno inflitto
    public string Enemytag = "Enemy";     // Il tag che identifica il bersaglio
    public string Playertag = "Player";   // Il tag che identifica il player

    private Rigidbody2D rigidbody2d;
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime); // Dopo lifeTime secondi si autodistrugge
    }

    private void FixedUpdate()
    {
     
        

    }


    public void ShootBullet (Transform origin, Vector2 force)

    {

        _origin = origin;

        rigidbody2d.AddForce(force * speed, ForceMode2D.Impulse);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {     
       
        if (other.CompareTag(Enemytag))
        {
            
            Destroy(gameObject); // Distrugge il proiettile
        }
        else if (other.CompareTag(Playertag))

                {
                    Destroy(gameObject); // Colpisce muro → distrugge proiettile
                }
        else
            
    {
     

        }
    }
}
