using UnityEngine;

[System.Serializable]
public class WeaponMagazine : WeaponPart
{
    [Tooltip("The base damage of projectiles fired by a weapon using this magazine.")]
    [SerializeField] private float _damage;

    [Tooltip("The amount of bullets which can be fired before reloading.")]
    [SerializeField] private int _magSize;

    [Tooltip("The amount of time it takes to reload the weapon.")]
    [SerializeField] private float _reloadTime;

    [Tooltip("The amount of time after firing the weapon until it can be fired again-- i.e. fire rate.")]
    [SerializeField] private float _timeBetweenShots = 1f;

    [Tooltip("If true, the weapon will fire constantly while the trigger is held. if false, trigger must be pulled for each shot.")]
    [SerializeField] private bool _automaticFire = false;

    [SerializeField] private string _projectilePrefabDirectory = "Prefabs/Bullet";

    public int MagSize { get => _magSize; set => _magSize = value; }
    public float ReloadTime { get => _reloadTime; set => _reloadTime = value; }
    public bool AutomaticFire { get => _automaticFire; set => _automaticFire = value; }
    public float Damage { get => _damage; set => _damage = value; }
    public float TimeBetweenShots { get => _timeBetweenShots; set => _timeBetweenShots = value; }
    public string ProjectilePrefabDirectory { get => _projectilePrefabDirectory; set => _projectilePrefabDirectory = value; }
}
