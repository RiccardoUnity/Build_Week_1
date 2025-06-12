using UnityEngine;
using System.Collections.Generic;

public class Debuffable : MonoBehaviour
{
    public float SpeedMultiplier { get; private set; } = 1f;

    private float _speedTimer = 0f;
    private float _dotTimer = 0f;
    private float _dotInterval = 1f;
    private int _dotDamage = 0;

    private LifeController _life;

    void Awake()
    {
        _life = GetComponent<LifeController>();
    }

    void Update()
    {
        // Gestione moltiplicatore velocità
        if (_speedTimer > 0)
        {
            _speedTimer -= Time.deltaTime;
            if (_speedTimer <= 0)
                SpeedMultiplier = 1f;
        }

        // Gestione danno nel tempo
        if (_dotTimer > 0)
        {
            _dotTimer -= Time.deltaTime;

            if (_dotTimer <= 0 && _life != null)
            {
                _life.TakeDamage(_dotDamage);
                _dotTimer = _dotInterval; 
            }
        }
    }

    public void ApplySpeedDebuff(float multiplier, float duration)
    {
        SpeedMultiplier = multiplier;
        _speedTimer = duration;
    }

    public void ApplyDamageOverTime(int damagePerTick, float tickInterval, float duration)
    {
        _dotDamage = damagePerTick;
        _dotInterval = tickInterval;
        _dotTimer = tickInterval;
        Invoke(nameof(StopDot), duration);
    }

    private void StopDot()
    {
        _dotDamage = 0;
        _dotTimer = 0;
    }

    public float GetSpeedMultiplier()
    {
        return SpeedMultiplier;
    }
}
