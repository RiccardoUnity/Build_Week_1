using UnityEngine;
using GSU = GameUtility.GameStaticUtility;

public class Weapon : MonoBehaviour
{
    protected int _damage; // passato a bullet
    private float _fireRange;
    protected float fireRate = 0.5f;
    protected float _lastShotTime;
    private Transform _bullets;
    [SerializeField] protected Bullet BulletPrefab;
    private Vector2 _lastMoveDirection;

public void UpdateDirection(Vector2 moveDirection)
{
        if (moveDirection != Vector2.zero)
        {
            _lastMoveDirection = moveDirection;
        }
}

    public virtual void Shoot()
    {
        //GameObject enemy = FindNearestTarget();
        //if (enemy == null) return;

        //if (Vector2.Distance(transform.position, enemy.transform.position) <= _fireRange)
        //{
        //    if (Time.time - _lastShotTime > fireRate)
        //    {
        //        _lastShotTime = Time.time;
        //        Bullet b = Instantiate(BulletPrefab, transform.position, transform.rotation);
        //        Vector2 force = (enemy.transform.position - transform.position).normalized;
        //        b.ShootBullet(tag, force, _damage); // nome metodo bullet
        //    }
        //}
        if (Time.time - _lastShotTime > fireRate)
        {
            _lastShotTime = Time.time;
            Bullet b = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            b.ShootBullet(tag, _lastMoveDirection, _damage);
            Debug.Log(_lastMoveDirection);
        }
    }

    void Update()
    {
        Shoot();
    }
}
