using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour, IInitializable
{
    [SerializeField] private WeaponConfig _config;
    private WeaponStats stats;
    private GameObject bulletPrefab;

    private bool onCooldown = false;

    public WeaponConfig Config { get => _config; set => _config = value; }
    public WeaponStats Stats { get => stats; set => stats = value; }

    public override string ToString()
    {
        return _config.ToString() + "\n" + stats.ToString();
    }

    public void FireWeapon(bool started)
    {
        if(started && !onCooldown)
        {
            if(stats.AutoFire)
            {
                StartCoroutine(AutoFire());
            }
            else
            {
                FireWeapon();
                onCooldown = true;
                StopAllCoroutines();
                StartCoroutine(WeaponCooldown());
            }
            
        }
        if(!started && stats.AutoFire)
        {
            StopAllCoroutines();
            StartCoroutine(WeaponCooldown());
        }
    }

    public void FireWeapon()
    {
        float shots = stats.Multishot;
        do
        {
            shots--;
            GameObject temp = Instantiate(bulletPrefab, Camera.main.transform.position + (Camera.main.transform.forward * 0.5f), Camera.main.transform.rotation);
            temp.transform.Rotate(new Vector3(Random.Range(-stats.Spread, stats.Spread), Random.Range(-stats.Spread, stats.Spread), Random.Range(-stats.Spread, stats.Spread)));
            temp.GetComponent<Rigidbody>().linearVelocity = temp.transform.forward * stats.StartVelocity * 20f;
            temp.GetComponent<BulletController>().Stats = stats;
            temp.GetComponent<BulletController>().Initialize();
            
        }
        while (shots > 0f);

    }

    public async Awaitable Initialize()
    {
        bulletPrefab = Resources.Load("Prefabs/Bullet") as GameObject;
        await Awaitable.EndOfFrameAsync();
        Debug.Log("Weapon initialized");
    }

    public void DeInitialize()
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator AutoFire()
    {
        while(true)
        {
            FireWeapon();
            onCooldown = true;
            float progress = stats.TimeBetweenShots;
            while (progress > 0f)
            {
                progress -= Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }
            onCooldown = false;
        }
        
    }

    public IEnumerator WeaponCooldown()
    {
        onCooldown = true;
        float progress = stats.TimeBetweenShots;
        while(progress > 0f)
        {
            progress -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        onCooldown = false;
    }
}
