using UnityEngine;
using GSU = GameUtility.GameStaticUtility;

[RequireComponent(typeof(Rigidbody2D), typeof(LifeController))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float baseSpeed = 2f;
    [SerializeField] private int damage = 1;
    [SerializeField] private float followRange = 10f;

    private Rigidbody2D rb;
    private Vector2 dir;
    private Debuffable debuffable;

    public LifeController LifeController { get; private set; }
    public PlayerController Player { get; private set; }

    public int Dmg => damage;
    private Vector2 Dir => dir.normalized;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        LifeController = GetComponent<LifeController>();
        debuffable = GetComponent<Debuffable>(); // opzionale
    }

    protected virtual void Start()
    {
        Player = GSU.Player?.GetComponent<PlayerController>();
    }

    protected float GetCurrentSpeed()
    {
        return baseSpeed * (debuffable != null ? debuffable.GetSpeedMultiplier() : 1f);
    }

    public virtual bool CheckPlayerInRange()
    {
        if (Player == null) return false;
        float sqrDist = (Player.transform.position - transform.position).sqrMagnitude;
        return sqrDist < followRange * followRange;
    }

    public virtual bool CheckPlayerInRange(out Vector2 playerDirection)
    {
        playerDirection = Player != null ? (Vector2)(Player.transform.position - transform.position) : Vector2.zero;
        return playerDirection.sqrMagnitude < followRange * followRange;
    }

    public virtual void EnemyMovement()
    {
        if (rb == null || dir == Vector2.zero) return;
        rb.MovePosition(rb.position + Dir * (GetCurrentSpeed() * Time.fixedDeltaTime));
    }

    public virtual void EnemyMovement(Vector2 newDir)
    {
        if (rb == null || newDir == Vector2.zero) return;
        rb.MovePosition(rb.position + newDir.normalized * (GetCurrentSpeed() * Time.fixedDeltaTime));
    }

    public virtual void EnemyAttack() { }

    public void SetDirection(Vector2 newDir)
    {
        dir = newDir.normalized;
    }

    protected virtual void OnDestroy()
    {
        GSU.RemoveEnemy(this);
    }
}
