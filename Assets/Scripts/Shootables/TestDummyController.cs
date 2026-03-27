using UnityEngine;

public class TestDummyController : ShootableEntity
{
    [SerializeField] private EnemyUIController _displayedInfo;

    public override void OnAttacked(BulletController projectile)
    {
        base.OnAttacked(projectile);
        _displayedInfo.UpdateEnemyUI(this);
    }

    public override void UpdateStatusEffects()
    {
        base.UpdateStatusEffects();
        _displayedInfo.UpdateEnemyUI(this);
    }
}
