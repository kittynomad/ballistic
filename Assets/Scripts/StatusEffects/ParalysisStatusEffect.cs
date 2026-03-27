using UnityEngine;

public class ParalysisStatusEffect : IStatusEffect
{
    private ShootableEntity entity;
    private float duration = 10f;

    public void OnStartStatus(ShootableEntity effectedEntity, float strength)
    {
        entity = effectedEntity;
        duration = strength;
        Debug.Log("Status added to " + entity.name);
        if(entity.gameObject.TryGetComponent<RagdollToggler>(out RagdollToggler rt))
        {
            rt.EnableRagdoll();
        }
    }

    public bool UpdateStatus()
    {
        Debug.Log("Status affecting " + entity.name);
        
        duration -= Time.deltaTime;
        return duration <= 0f;
    }

    public void OnCompleteStatus()
    {
        if (entity.gameObject.TryGetComponent<RagdollToggler>(out RagdollToggler rt) && !entity.IsDead)
        {
            rt.DisableRagdoll();
        }
        Debug.Log("Status on " + entity.name + " has expired");
    }

    public Sprite GetIcon()
    {
        var icon = Resources.Load("Textures/particleCat") as Texture2D;

        return Sprite.Create(icon, new Rect(0.0f, 0.0f, icon.width, icon.height), new Vector2(0.5f, 0.5f));
    }

}
