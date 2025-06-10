using UnityEngine;

public class Weapon : MonoBehaviour
{
    private int _damage; // lo gestisce bullet?
    private float _fireRange;
    private float fireRate;
    private float _lastShotTime;
    private Transform _bullets;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private string targetTag = "Enemy"; // settare "player" da inspector per gli enemy

    public GameObject FindNearestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
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

    public void Shoot()
    {
        GameObject enemy = FindNearestTarget();
        if (enemy == null) return;

        if (Vector2.Distance(transform.position, enemy.transform.position) <= _fireRange)
        {
            if (Time.time - _lastShotTime > fireRate)
            {
                _lastShotTime = Time.time;
                Bullet b = Instantiate(bulletPrefab, transform.position, transform.rotation);
                Vector2 force = (enemy.transform.position - transform.position).normalized;
                b.ShootBullet(force); // nome metodo bullet
            }
        }
    }

    void Update()
    {
        Shoot();
    }
}
