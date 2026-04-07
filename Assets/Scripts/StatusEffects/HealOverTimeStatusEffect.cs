using UnityEngine;

public class HealOverTimeStatusEffect : IStatusEffect
{
    private ShootableEntity entity;
    private float duration = 10f;
    private float statusStrength = 1f;

    public Sprite GetIcon()
    {
        var icon = Resources.Load("Textures/fireIcon") as Texture2D;

        return Sprite.Create(icon, new Rect(0.0f, 0.0f, icon.width, icon.height), new Vector2(0.5f, 0.5f));
    }

    public void OnCompleteStatus()
    {
        Debug.Log("Status on " + entity.name + " has expired");
    }

    public void OnStartStatus(ShootableEntity effectedEntity, float strength)
    {
        entity = effectedEntity;
        statusStrength = strength;
        Debug.Log("Status added to " + entity.name);
    }

    public bool UpdateStatus()
    {
        Debug.Log("Status affecting " + entity.name);
        entity.OnHealingReceived(Time.deltaTime * statusStrength);
        //entity.CurrentHealth += (Time.deltaTime * statusStrength);
        //duration -= Time.deltaTime;
        return duration <= 0f;
    }
}
