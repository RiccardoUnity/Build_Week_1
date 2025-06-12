using UnityEngine;
using System.Collections.Generic;

public class Debuffable : MonoBehaviour
{
    public float SpeedMultiplier { get; private set; } = 1f;

    private float _speedTimer = 0f;
    private float _dotTimer = 0f;
    private float _dotInterval = 1f;
    private int _dotDamage = 0;
    private float _dotDuration = 0f;

    private LifeController _life;
    private SpriteRenderer _renderer;

    void Awake()
    {
        _life = GetComponent<LifeController>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        HandleSpeedDebuff();
        HandleDamageOverTime();
    }

    private void HandleSpeedDebuff() // Gestisce il debuff di velocità
    {
        if (_speedTimer > 0) // se il timer del debuff di velocità è attivo
        {
            _speedTimer -= Time.deltaTime; // decrementa il timer del debuff di velocità

            if (_renderer != null)
                _renderer.color = Color.blue; // cambia il colore del renderer per indicare il debuff

            if (_speedTimer <= 0) // se il timer è scaduto
            {
                SpeedMultiplier = 1f;
                if (_renderer != null)
                    _renderer.color = Color.white;// ripristina il colore originale
            }
        }
    }

    private void HandleDamageOverTime() // Gestisce il DoT (Danni nel tempo)
    {
        if (_dotDuration > 0)
        {
            _dotDuration -= Time.deltaTime;
            _dotTimer -= Time.deltaTime;

            // Se il timer è scaduto, infliggi danni
            if (_dotTimer <= 0 && _life != null)
            {
                _life.TakeDamage(_dotDamage);
                _dotTimer = _dotInterval;
            }

            if (_dotDuration <= 0)
                StopDot(); // Ferma il DoT quando la durata finisce
        }
    }

    public void ApplySpeedDebuff(float multiplier, float duration)
    {
        SpeedMultiplier = multiplier; // imposta il moltiplicatore di velocità
        _speedTimer = Mathf.Max(_speedTimer, duration); // evita che uno più corto sovrascriva
    }

    public void ApplyDamageOverTime(int damagePerTick, float tickInterval, float duration)
    {
        _dotDamage = damagePerTick;// imposta i danni per tick
        _dotInterval = tickInterval;// imposta l'intervallo tra i tick
        _dotTimer = 0f; // infligge subito il primo tick
        _dotDuration = Mathf.Max(_dotDuration, duration); // evita override prematuri
    }

    private void StopDot()
    {
        _dotDamage = 0;
        _dotTimer = 0;
        _dotDuration = 0;
    }
}