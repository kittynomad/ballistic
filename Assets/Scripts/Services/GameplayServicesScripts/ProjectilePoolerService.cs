using UnityEngine;
using UnityEngine.Pool;
using System;

public class ProjectilePoolerService : Service
{
    private ObjectPool<BulletController> playerBulletPool;
    [SerializeField] private BulletController playerBulletPrefab;

    public static ProjectilePoolerService instance;

    public ObjectPool<BulletController> PlayerBulletPool { get => playerBulletPool; set => playerBulletPool = value; }
    public BulletController PlayerBulletPrefab { get => playerBulletPrefab; set => playerBulletPrefab = value; }

    public static Action ProjectileChange;

    public override Awaitable Initialize()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        playerBulletPool = new ObjectPool<BulletController>
            (
                createFunc: CreateFunc,
                //actionOnGet: () => ActionOnGet(),
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
        Destroy(obj.gameObject);
        Destroy(obj);
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

    public void ChangePlayerProjectile(BulletController newProj)
    {
        ProjectileChange?.Invoke();

        playerBulletPool.Clear();
        playerBulletPool.Dispose();
        playerBulletPool.Clear();


        playerBulletPrefab = newProj;
    }
}
