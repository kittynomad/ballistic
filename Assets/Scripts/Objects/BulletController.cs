using UnityEngine;

public class BulletController : LimitedLifespanEntity, IInitializable
{
    public void DeInitialize()
    {
        throw new System.NotImplementedException();
    }

    public async Awaitable Initialize()
    {
        StartLifeTimer();
        await Awaitable.FixedUpdateAsync();
    }
}
