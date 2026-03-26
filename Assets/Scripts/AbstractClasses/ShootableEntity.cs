using UnityEngine;
using System.Collections.Generic;

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

        IStatusEffect status = new DamageOverTimeStatusEffect();
        status.OnStartStatus(gameObject);
        currentStatuses.Add(status);

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
}
