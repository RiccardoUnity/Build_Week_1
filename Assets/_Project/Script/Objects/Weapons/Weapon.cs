using UnityEngine;
using GSU = GameUtility.GameStaticUtility;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected int Damage = 10; // passato a bullet
    [SerializeField] protected float fireRange = 10;
    protected float fireRate = 0.5f;
    protected float _lastShotTime;
    private Transform _bullets;
    [SerializeField] protected Bullet BulletPrefab;
    protected Vector2 _lastMoveDirection = Vector2.right;
    protected PlayerController _playerController;
    protected Transform enemy;

    public void UpdateDirection(Vector2 moveDirection)
    {
        if (moveDirection != Vector2.zero)
        {
            _lastMoveDirection = moveDirection;
        }
    }
    
protected virtual bool CanShootTarget()
{
    bool isShooterEnemy = CompareTag(GSU.EnemyTag);

    if (isShooterEnemy)
    {
        if (enemy == null) return false;
        return Vector2.Distance(transform.position, enemy.position) <= fireRange;
    }

    return true; // il player può sempre sparare
}

    public virtual void Shoot()
    {
        if (CanShootTarget() && Time.time - _lastShotTime > fireRate)
        {
            _lastShotTime = Time.time;
            Bullet b = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            b.ShootBullet(tag, _lastMoveDirection, Damage);
        }
    }

    protected string GetTargetTag()
    {
        if (CompareTag(GSU.PlayerTag))
        {
            return GSU.EnemyTag;
        }
        else if (CompareTag(GSU.EnemyTag))
        {
            return GSU.PlayerTag;
        }
        return null;
    }

    void Start()
    {
        _playerController = GSU.Player.GetComponent<PlayerController>();
        if (CompareTag(GSU.EnemyTag))
        {
            enemy = GSU.Player.transform;
        }
        
    }

    void Update()
    {
        UpdateDirection(_playerController.Dir);
        Shoot();
    }
}
