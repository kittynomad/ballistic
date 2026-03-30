using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TestDummyController : ShootableEntity
{
    [SerializeField] private EnemyUIController _displayedInfo;

    public override void OnAttacked(BulletController projectile)
    {
        base.OnAttacked(projectile);
        _displayedInfo.UpdateEnemyUI(this);
        _displayedInfo.UpdateStatusUI(this);
    }

    public override void UpdateStatusEffects()
    {
        base.UpdateStatusEffects();
        _displayedInfo.UpdateEnemyUI(this);
    }

    public override Awaitable OnStatusEnded(int index)
    {
        _displayedInfo.UpdateStatusUI(this);
        return base.OnStatusEnded(index);
    }

    public override void DeathBehavior()
    {
        base.DeathBehavior();

        if(IsDead)
            StartCoroutine(DespawnTimer());
    }

    public IEnumerator DespawnTimer()
    {
        yield return new WaitForSeconds(25f);
        Destroy(gameObject);
    }
}
