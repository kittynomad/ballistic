using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class ShootableEntity : MonoBehaviour, IInitializable, IShootable
{
    [SerializeField] private float _totalHealth;
    private float currentHealth;

    private List<IStatusEffect> currentStatuses = new List<IStatusEffect>();

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
        List<IStatusEffect> effectsToRemove = new List<IStatusEffect>();

        foreach(IStatusEffect effect in currentStatuses)
        {
            if(effect.UpdateStatus())
            {
                effect.OnCompleteStatus();
                effectsToRemove.Add(effect);
                
            }
            
        }
        foreach(IStatusEffect effect in effectsToRemove)
        {
            currentStatuses.Remove(effect);
        }
    }

    public virtual void OnAttacked(BulletController projectile)
    {

        currentHealth -= projectile.Stats.BaseDamage;
        HudService.Instance.PushConsoleMessage(
            "Enemy hit for " + projectile.Stats.BaseDamage + 
            ", health is " + currentHealth + "/" + _totalHealth);

        ApplyPostFireModifiers(projectile.Stats.Effects);

        if (currentHealth <= 0f)
            DeathBehavior();
    }

    public virtual void DeathBehavior()
    {
        if(TryGetComponent<RagdollToggler>(out RagdollToggler r))
        {
            r.EnableRagdoll();
        }

        HudService.Instance.PushConsoleMessage(
            "Enemy died!");
    }

    public void ApplyPostFireModifiers(List<WeaponModifier> modifiers)
    {
        foreach(WeaponModifier wm in modifiers)
        {
            if(Dictionaries.ModLookup.TryGetValue(wm.ModType, out Func<IStatusEffect> effect))
            {
                IStatusEffect status = effect();
                status.OnStartStatus(gameObject);
                currentStatuses.Add(status);
            }
            else
            {
                Debug.Log("modifier " + wm.ModType + " does not have associated postfire effect, ignoring");
            }
        }
        //IStatusEffect status = new DamageOverTimeStatusEffect();
        
    }
}
