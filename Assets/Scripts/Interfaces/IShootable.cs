using UnityEngine;

public interface IShootable
{
    public abstract void OnAttacked(BulletController projectile);
}
