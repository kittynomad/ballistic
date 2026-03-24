using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour, IInitializable
{
    [SerializeField] private WeaponConfig _config;
    private WeaponStats stats;
    private GameObject bulletPrefab;

    private bool onCooldown = false;
    private float currentCharge;
    private float maxCharge;

    private Coroutine rechargeCoroutine;

    public WeaponConfig Config { get => _config; set => _config = value; }
    public WeaponStats Stats { get => stats; set => stats = value; }

    public override string ToString()
    {
        return _config.ToString() + "\n" + stats.ToString();
    }

    public void FireWeapon(bool started)
    {
        if(started && !onCooldown && currentCharge >= stats.EnergyCost)
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
        if((currentCharge < stats.EnergyCost || !started) && stats.AutoFire)
        {
            StopAllCoroutines();
            StartCoroutine(WeaponCooldown());
        }
    }

    public void FireWeapon()
    {
        if(currentCharge >= stats.EnergyCost)
        {
            currentCharge -= stats.EnergyCost;
            HudService.Instance.UpdateBatteryMeter(currentCharge, maxCharge);
            float shots = stats.Multishot;
            do
            {
                shots--;
                GameObject temp = Instantiate(bulletPrefab, Camera.main.transform.position + (Camera.main.transform.forward * 0.5f), Camera.main.transform.rotation);
                temp.transform.Rotate(new Vector3(Random.Range(-stats.Spread, stats.Spread), Random.Range(-stats.Spread, stats.Spread), Random.Range(-stats.Spread, stats.Spread)));
                temp.GetComponent<Rigidbody>().linearVelocity = temp.transform.forward * stats.StartVelocity * 20f;
                temp.GetComponent<BulletController>().Stats = stats;
                temp.GetComponent<BulletController>().Initialize();
                //knock back the player slightly
                gameObject.GetComponent<Rigidbody>().AddForce(temp.transform.forward * -0.25f * stats.StartVelocity, ForceMode.Impulse);

            }
            while (shots > 0f);
        }
        

    }

    public async Awaitable Initialize()
    {
        bulletPrefab = Resources.Load("Prefabs/Bullet") as GameObject;
        maxCharge = stats.BatteryCapacity;
        currentCharge = maxCharge;
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
        if(rechargeCoroutine != null)
            StopCoroutine(rechargeCoroutine);

        onCooldown = true;
        float progress = stats.TimeBetweenShots;
        while(progress > 0f)
        {
            progress -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        onCooldown = false;
        rechargeCoroutine = StartCoroutine(WeaponRecharge());
    }

    public IEnumerator WeaponRecharge()
    {
        while(currentCharge < maxCharge)
        {
            currentCharge += Stats.BatteryChargeRate * Time.deltaTime;
            HudService.Instance.UpdateBatteryMeter(currentCharge, maxCharge);
            yield return new WaitForFixedUpdate();
        }
    }
}
