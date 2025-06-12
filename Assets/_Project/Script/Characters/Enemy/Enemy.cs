using UnityEngine;
using GSU = GameUtility.GameStaticUtility;

public abstract class Enemy : MonoBehaviour
{

    [SerializeField] float _speed = 2;

    Vector2 _dir;
    Vector2 Dir => _dir.normalized;

    public LifeController LifeController { get; set; }
    public PlayerController Player { get; private set; }

    Rigidbody2D _rb;
    [SerializeField] int _dmg;
    public int Dmg => _dmg;

    //[SerializeField] Bullet _bulletPrefab;
    //public Bullet BulletPrefab => _bulletPrefab;

    [SerializeField] float FollowRange = 10f;

    void Awake()
    {

        LifeController = GetComponent<LifeController>();
        _rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        Player = GSU.Player.GetComponent<PlayerController>();
    }


    public virtual bool CheckPlayerInRange()
    {
        if (Player == null) return false;
        float sqrDistance = (Player.transform.position - transform.position).sqrMagnitude;
        return sqrDistance < FollowRange * FollowRange;
    }

    public virtual bool CheckPlayerInRange(out Vector2 playerDirection)
    {
        if (Player == null)
        {
            playerDirection = Vector2.zero;
            return false;
        }

        playerDirection = Player.transform.position - transform.position;
        return playerDirection.sqrMagnitude < FollowRange * FollowRange;
    }
    virtual public void EnemyMovement()
    {
        if (_rb == null) return;
        if (_dir != Vector2.zero)
        {
            _rb.MovePosition(_rb.position + Dir * (_speed * Time.fixedDeltaTime));
        }


    }

    virtual public void EnemyMovement(Vector2 _dir)
    {
        if (_rb == null)
        {
            return;
        }

        if (_dir != Vector2.zero)
        {

            _rb.MovePosition(_rb.position + _dir.normalized * (_speed * Time.fixedDeltaTime));

        }
    }


    virtual public void EnemyAttack()
    {

    }

    public void Setdirection(Vector2 dir)
    {
        _dir = dir.normalized;
    }

    void OnDestroy()
    {
        GSU.RemoveEnemy(this);
    }

}
