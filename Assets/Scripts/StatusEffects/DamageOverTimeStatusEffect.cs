using UnityEngine;
using System.Collections;

public class DamageOverTimeStatusEffect : IStatusEffect
{
    private ShootableEntity entity;
    private float duration = 10f;
    private float statusStrength = 1f;

    public void OnStartStatus(ShootableEntity effectedEntity, float strength)
    {
        entity = effectedEntity;
        statusStrength = strength;
        Debug.Log("Status added to " + entity.name);
    }

    public bool UpdateStatus()
    {
        Debug.Log("Status affecting " + entity.name);
        entity.CurrentHealth -= (Time.deltaTime * statusStrength);
        entity.DeathBehavior();
        duration -= Time.deltaTime;
        return duration <= 0f;
    }

    public void OnCompleteStatus()
    {
        Debug.Log("Status on " + entity.name + " has expired");
    }

    public Sprite GetIcon()
    {
        var icon = Resources.Load("Textures/particleCat") as Texture2D;

        return Sprite.Create(icon, new Rect(0.0f, 0.0f, icon.width, icon.height), new Vector2(0.5f, 0.5f));
    }
}
