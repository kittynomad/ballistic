using UnityEngine;

public abstract class ShootableEntity : MonoBehaviour, IInitializable, IShootable
{
    [SerializeField] private float _totalHealth;
    private float currentHealth;

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

    public virtual void OnAttacked(BulletController projectile)
    {
        currentHealth -= projectile.Stats.BaseDamage;
        HudService.Instance.PushConsoleMessage(
            "Enemy hit for " + projectile.Stats.BaseDamage + 
            ", health is " + currentHealth + "/" + _totalHealth);

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
