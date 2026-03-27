using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class ShootableEntity : MonoBehaviour, IInitializable, IShootable
{
    [SerializeField] private float _totalHealth;
    private float currentHealth;

    private List<IStatusEffect> currentStatuses = new List<IStatusEffect>();

    public float TotalHealth { get => _totalHealth; set => _totalHealth = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public List<IStatusEffect> CurrentStatuses { get => currentStatuses; set => currentStatuses = value; }


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

    public virtual async Awaitable OnStatusEnded(int index)
    {
        
    }

    public void ApplyPostFireModifiers(List<WeaponModifier> modifiers)
    {
        foreach(WeaponModifier wm in modifiers)
        {
            if(Dictionaries.ModLookup.TryGetValue(wm.ModType, out Func<IStatusEffect> effect))
            {
                IStatusEffect status = effect();
                status.OnStartStatus(this, wm.ModStrength);
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
