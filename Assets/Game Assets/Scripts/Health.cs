using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] bool _debug;
    [Tooltip("Health value is set to Max Health at Start (Unless debug value is checked)")]
    [SerializeField] private int _maxHealth;
    [Tooltip("Enable debug to set custom health value at Start")]
    [SerializeField] private int _health;
    
    // events for future use
    public event Action OnHealthChanged;
    //public event Action OnDeath;
    [Space]
    public UnityEvent OnDeath;

    private void Awake()
    {
        if (!_debug)
        {
            //sets the current health to max
            _health = _maxHealth;
        }
    }

    //returns health value
    public int GetHealth()
    {
        return _health;
    }
    //returns health as a percent of maxHealth
    public float GetHealthPercent()
    {
        return (float)_health / _maxHealth;
    }

    public void Damage(int damage)
    {
        _health -= damage;
        if (_health < 0) _health = 0;
        OnHealthChanged?.Invoke();

        if (_health == 0) Die();
    }

    public void Heal(int amount)
    {
        _health += amount;
        if (_health > _maxHealth) _health = _maxHealth;
        OnHealthChanged?.Invoke();
    }

    public void Die()
    {
        OnDeath?.Invoke();
        //Destroy(gameObject);
    }





}
