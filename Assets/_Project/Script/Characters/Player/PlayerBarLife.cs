using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSU = GameUtility.GameStaticUtility;

public class PlayerBarLife : MonoBehaviour
{
    private LifeController _lifeController;
    [SerializeField] private Transform _bar;
    private float _unit;
    private float _total;

    void Start()
    {
        _lifeController = GetComponent<LifeController>();
        _total = _lifeController.Hp;
    }

    private void SetBarX()
    {
        _bar.localScale = new Vector3(_lifeController.Hp / _total, _bar.localScale.y, _bar.localScale.z);
        //Debug.Log(_lifeController.Hp / _total);
    }

    void Update()
    {
        if (_bar != null)
        {
            SetBarX();
        }
    }
}
