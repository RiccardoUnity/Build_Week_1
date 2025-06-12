using UnityEngine;

public class ApplyDebuff : MonoBehaviour
{
    public enum DebuffType
    {
        None,
        VelocityModifier,
        DamageOverTime,
        SlowAndDoT
    }

    [SerializeField] private DebuffType _debuffType = DebuffType.None;
    [SerializeField] private float _duration = 3f;

    [SerializeField] private float _speedMultiplier = 0.5f;


    [SerializeField] private int _damagePerTick = 1;
    [SerializeField] private float _tickInterval = 1f;

    [SerializeField] private bool _destroyOnHit = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Debuffable debuffable))
            AppDebuff(debuffable);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Debuffable debuffable))
            AppDebuff(debuffable);
    }


    private void AppDebuff(Debuffable target)
    {
        switch (_debuffType)
        {
            case DebuffType.VelocityModifier:
                target.ApplySpeedDebuff(_speedMultiplier, _duration);
                Debug.Log($"Ho applicato un cambio di speed a {target.SpeedMultiplier} da {target.name}");
                break;

            case DebuffType.DamageOverTime:
                target.ApplyDamageOverTime(_damagePerTick, _tickInterval, _duration);
                Debug.Log($"Ho applicato un DoT di {_damagePerTick} ogni {_tickInterval} secondi per {_duration} secondi a {target.name}");
                break;

            case DebuffType.SlowAndDoT:
                Debug.Log($"Ho applicato un DoT di {_damagePerTick} ogni {_tickInterval} secondi e un cambio di speed a {target.SpeedMultiplier} per {_duration} secondi a {target.name}");
                target.ApplySpeedDebuff(_speedMultiplier, _duration);
                target.ApplyDamageOverTime(_damagePerTick, _tickInterval, _duration);
                break;
        }
    }
}
