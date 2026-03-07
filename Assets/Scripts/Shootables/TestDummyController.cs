using UnityEngine;

public class TestDummyController : MonoBehaviour, IInitializable, IShootable
{
    public void DeInitialize()
    {
        throw new System.NotImplementedException();
    }

    public Awaitable Initialize()
    {
        throw new System.NotImplementedException();
    }

    public void OnAttacked(BulletController projectile)
    {
        FindAnyObjectByType<ConsoleMessagesController>().PushMessage(
            "Enemy hit for " + projectile.Stats.BaseDamage);
    }
}
