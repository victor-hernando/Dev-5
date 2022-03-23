using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Entity
{
    private EntityManager entityManager;
    private int entityIdx;

    public float CurrentHealth;
    public float MaxHealth = 100;

    [SerializeField]
    private float BaseDefense=5;
    [SerializeField]
    private float RoundDefense;
    public float Defense => BaseDefense + RoundDefense;

    [SerializeField]
    private float BaseAttack=10;
    [SerializeField]
    private float RoundAttack;
    public float Attack => BaseAttack + RoundAttack;

    [SerializeField]
    private float BaseSpeed;
    [SerializeField]
    private float RoundSpeed;
    public float Speed => BaseSpeed + RoundSpeed;

    public List<FightCommandTypes> PossibleCommands;

    public static Action OnChange;

    // Start is called before the first frame update
    void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void SetEntityManager(EntityManager manager, int idx)
    {
        entityManager = manager;
        entityIdx = idx;
    }

    public void Heal(float amout)
    {
        float nextHealth = CurrentHealth + amout;
        CurrentHealth = Math.Min(nextHealth, MaxHealth);
        OnChange?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("attack");
        float realDamage = damage - (BaseDefense + RoundDefense);
        realDamage = Mathf.Max(realDamage, 0);

        CurrentHealth -= realDamage;

        OnChange?.Invoke();
        if (CurrentHealth < 0)
            Die();
    }

    public void Upgrade(float level)
    {

    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void AddDefense(float amount)
    {
        RoundDefense += amount;
        OnChange?.Invoke();
    }

    public void AddAttack(float amount)
    {
        RoundAttack += amount;
        OnChange?.Invoke();
    }

    public void AddDefensePermanent(float amount)
    {
        BaseDefense += amount;
        OnChange?.Invoke();
    }

    public void AddAttackPermanent(float amount)
    {
        BaseAttack += amount;
        OnChange?.Invoke();
    }

    public void AddSpeed(float amount)
    {
        RoundSpeed += amount;
        OnChange?.Invoke();
    }

    public void ResetFighter()
    {
        RoundDefense = 0;
        RoundAttack = 0;
        RoundSpeed = 0;
        OnChange?.Invoke();
    }
}
