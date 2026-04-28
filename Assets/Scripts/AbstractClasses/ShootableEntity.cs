/*****************************************************************************
// File Name : ShootableEntity.cs
// Author : Pierce Nunnelley
// Creation Date : March 7, 2026
//
// Brief Description : An abstract class which is implemented for any entity
// which can be hit by modularWeapon projectiles, including status effects.
*****************************************************************************/
using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class ShootableEntity : MonoBehaviour, IInitializable, IShootable
{
    [SerializeField] private float _totalHealth;
    private float currentHealth;

    private List<IStatusEffect> currentStatuses = new List<IStatusEffect>();

    private bool isDead = false;

    public float TotalHealth { get => _totalHealth; set => _totalHealth = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public List<IStatusEffect> CurrentStatuses { get => currentStatuses; set => currentStatuses = value; }
    public bool IsDead { get => isDead; set => isDead = value; }

    private void Start()
    {
        Initialize();
    }

    public void DeInitialize()
    {
        throw new System.NotImplementedException();
    }

    public async Awaitable Initialize()
    {
        currentHealth = _totalHealth;
    }

    public void FixedUpdate()
    {
        UpdateStatusEffects();
    }

    public virtual async void UpdateStatusEffects()
    {
        List<IStatusEffect> effectsToRemove = new List<IStatusEffect>();

        for (int i = 0; i < currentStatuses.Count; i++)
        {
            if (currentStatuses[i].UpdateStatus())
            {
                currentStatuses[i].OnCompleteStatus();
                effectsToRemove.Add(currentStatuses[i]);
                //await OnStatusEnded(i);

            }
        }
        foreach (IStatusEffect effect in effectsToRemove)
        {
            currentStatuses.Remove(effect);
        }
        if (effectsToRemove.Count > 0) await OnStatusEnded(-1);
    }

    public virtual void OnAttacked(BulletController projectile)
    {
        int critHits = projectile.Stats.CalculateCritAmount();
        float damageToDeal = projectile.Stats.BaseDamage * Mathf.Pow(2, critHits);
        OnDamageReceived(damageToDeal);
        //currentHealth -= damageToDeal;
        HudService.Instance.PushConsoleMessage(
            gameObject.name + " hit for " + damageToDeal + " (crit * " + critHits + ")"+
            ", health is " + currentHealth + "/" + _totalHealth);
        

        ApplyPostFireModifiers(projectile.Stats.Effects);

        ProjectilePoolerService.instance.PlayerBulletPool.Release(projectile);
        //Destroy(projectile.gameObject);

        //if (currentHealth <= 0f)
            //DeathBehavior();
    }

    public virtual void DeathBehavior()
    {
        if (currentHealth <= 0f && !isDead)
        {
            //ragdoll entity if possible (death indicator)
            if (TryGetComponent<RagdollToggler>(out RagdollToggler r))
            {
                r.EnableRagdoll();
            }

            HudService.Instance.PushConsoleMessage(
                "Enemy died!");
            isDead = true;
        }
            
    }

    public virtual void OnDamageReceived(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0f)
            DeathBehavior();
    }

    public virtual float OnHealingReceived(float healing)
    {
        currentHealth += healing;
        if(currentHealth > _totalHealth)
        {
            float overheal = currentHealth - _totalHealth;
            currentHealth = _totalHealth;
            return overheal;
        }
        return 0f;
    }


    public virtual async Awaitable OnStatusEnded(int index){ }

    public void ApplyPostFireModifiers(List<WeaponModifier> modifiers)
    {
        foreach(WeaponModifier wm in modifiers)
        {   //apply any postfire modifiers within the list, ignore non-postfire modifiers
            if(wm.Mod != null && wm.Mod.GetType().IsSubclassOf(typeof(PostfireModifierDef)))
            {
                PostfireModifierDef q = (PostfireModifierDef)wm.Mod;
                q.ApplyModifier(wm.ModStrength, wm.ModOperator, this);
            }
            else
            {
                Debug.Log("modifier " + wm.Mod + " does not have associated postfire effect, ignoring");
            }
        }
        
    }
}
