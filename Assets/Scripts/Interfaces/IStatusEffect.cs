using UnityEngine;

public interface IStatusEffect
{
    public void OnStartStatus(GameObject effectedEntity);

    public bool UpdateStatus();

    public void OnCompleteStatus();
}
