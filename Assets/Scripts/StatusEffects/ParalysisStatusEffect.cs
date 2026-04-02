using UnityEngine;

public class ParalysisStatusEffect : StackableStatusEffect
{
    //private ShootableEntity entity;
    //private float duration = 10f;

    public override void OnStartStatus(ShootableEntity effectedEntity, float strength)
    {
        base.OnStartStatus(effectedEntity, strength);
        Debug.Log("Status added to " + Target.name);
        if(Target.gameObject.TryGetComponent<RagdollToggler>(out RagdollToggler rt))
        {
            rt.EnableRagdoll();
        }
    }

    public override bool UpdateStatus()
    {
        Debug.Log("Status affecting " + Target.name);

        return base.UpdateStatus();
    }

    public override void OnCompleteStatus()
    {
        if (Target.gameObject.TryGetComponent<RagdollToggler>(out RagdollToggler rt) && !Target.IsDead)
        {
            rt.DisableRagdoll();
        }
        Debug.Log("Status on " + Target.name + " has expired");
    }

    public override Sprite GetIcon()
    {
        var icon = Resources.Load("Textures/paralysisIcon") as Texture2D;

        return Sprite.Create(icon, new Rect(0.0f, 0.0f, icon.width, icon.height), new Vector2(0.5f, 0.5f));
    }

}
