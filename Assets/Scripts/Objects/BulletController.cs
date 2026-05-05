using UnityEngine;

public class BulletController : LimitedLifespanEntity, IInitializable
{
    private WeaponStats stats;

    public WeaponStats Stats { get => stats; set => stats = value; }

    private bool isPooled;

    public void DeInitialize()
    {
        throw new System.NotImplementedException();
    }

    public async Awaitable Initialize()
    {
        isPooled = true;
        StartLifeTimer();
        await Awaitable.FixedUpdateAsync();
        ProjectilePoolerService.ProjectileChange += OnProjectileChange;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out IShootable shot))
        {
            shot.OnAttacked(this);
        }
        HitBehavior(collision);

    }
    public void OnProjectileChange()
    {
        isPooled = false;
        ProjectilePoolerService.ProjectileChange -= OnProjectileChange;
    }

    public void HitBehavior(Collision c)
    {
        /*HudService.Instance.PushConsoleMessage(
            "Hit " + c.gameObject.name);*/
    }

    public override void EndLifeBehavior()
    {
        if(isPooled)
        {
            base.ResetLifeTimer();
            ProjectilePoolerService.instance.PlayerBulletPool.Release(this);
        }
        else
        {
            //ProjectilePoolerService.instance.PlayerBulletPool.
            Destroy(gameObject);
        }
        
    }
}
