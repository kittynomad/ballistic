using UnityEngine;

public class BulletController : LimitedLifespanEntity, IInitializable
{
    private WeaponStats stats;

    public WeaponStats Stats { get => stats; set => stats = value; }

    public void DeInitialize()
    {
        throw new System.NotImplementedException();
    }

    public async Awaitable Initialize()
    {
        StartLifeTimer();
        await Awaitable.FixedUpdateAsync();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out IShootable shot))
        {
            shot.OnAttacked(this);
        }
    }
}
