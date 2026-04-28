using UnityEngine;
using UnityEngine.Pool;

public class ProjectilePoolerService : Service
{
    private ObjectPool<BulletController> playerBulletPool;
    private BulletController playerBulletPrefab;

    public ObjectPool<BulletController> PlayerBulletPool { get => playerBulletPool; set => playerBulletPool = value; }
    public BulletController PlayerBulletPrefab { get => playerBulletPrefab; set => playerBulletPrefab = value; }

    public override Awaitable Initialize()
    {
        playerBulletPool = new ObjectPool<BulletController>
            (
                createFunc: CreateFunc,
                ActionOnGet,
                ActionOnRelease,
                ActionOnDestroy

            );
        return base.Initialize();
    }

    public BulletController CreateFunc()
    {
        BulletController obj = Instantiate(playerBulletPrefab);
        obj.gameObject.SetActive(false);
        return obj;
    }
    public void ActionOnDestroy(BulletController obj)
    {
        throw new System.NotImplementedException();
    }

    public void ActionOnRelease(BulletController obj)
    {
        obj.transform.gameObject.SetActive(false);
    }

    public void ActionOnGet(BulletController obj)
    {
        //obj.transform.position = SpawnPos.position;
        obj.transform.gameObject.SetActive(true);
        //obj.Fire();
    }
}
