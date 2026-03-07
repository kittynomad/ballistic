using UnityEngine;

public class Weapon : MonoBehaviour, IInitializable
{
    [SerializeField] private WeaponConfig _config;
    private WeaponStats stats;
    private GameObject bulletPrefab;

    public WeaponConfig Config { get => _config; set => _config = value; }
    public WeaponStats Stats { get => stats; set => stats = value; }

    public override string ToString()
    {
        return _config.ToString() + "\n" + stats.ToString();
    }

    public void FireWeapon()
    {
        float shots = stats.Multishot;
        do
        {
            shots--;
            GameObject temp = Instantiate(bulletPrefab, Camera.main.transform.position, Camera.main.transform.rotation);
            temp.GetComponent<Rigidbody>().linearVelocity = temp.transform.forward * stats.StartVelocity * 20f;
        }
        while (shots >= 0f);

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
}
