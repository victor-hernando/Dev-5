using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Fighter : Entity
{
    public float CurrentHealth;
    public float MaxHealth = 100;
    public float CurrentLevel;

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
        normalColor = Color.white;
    }

    public override void SetEntityManager(EntityManager manager, int idx)
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
        float realDamage = damage - (BaseDefense + RoundDefense);
        realDamage = Mathf.Max(realDamage, 0);

        CurrentHealth -= realDamage;

        OnChange?.Invoke();
        if (CurrentHealth < 0)
            Die();
    }

    public void RestoreDamage(float damage)
    {
        float realDamage = damage - (BaseDefense + RoundDefense);
        realDamage = Mathf.Max(realDamage, 0);

        if (entityManager.Deads.Contains(this))
            Revive(false);
        CurrentHealth += realDamage;

        OnChange?.Invoke();
    }

    public void Upgrade()
    {
        //base.Upgrade();
        CurrentLevel += 1;
        OnChange?.Invoke();
    }

    public override void Die()
    {
        entityManager.RemoveEntity(this);
        base.Die();
    }

    public void Revive(bool heal)
    {
        base.Revive();
        entityManager.AddEntity(this, entityIdx); 
        if (heal)
        {
            CurrentHealth = 10;
        }
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
