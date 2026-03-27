/*****************************************************************************
// File Name : IStatusEffect.cs
// Author : Pierce Nunnelley
// Creation Date : March 25, 2026
//
// Brief Description : This interface defines the functions which all status
// effects possess.
*****************************************************************************/
using UnityEngine;

public interface IStatusEffect
{
    public Sprite GetIcon();
    public void OnStartStatus(ShootableEntity effectedEntity, float strength);

    public bool UpdateStatus();

    public void OnCompleteStatus();
}
