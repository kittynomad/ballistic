/*****************************************************************************
// File Name : GameplayManager.cs
// Author : Pierce Nunnelley
// Creation Date : February 13, 2026
//
// Brief Description : This script initializes services for gameplay related
// functionality.
*****************************************************************************/
using UnityEngine;

public class GameplayManager : Manager
{
    [SerializeField] private GameObject _playerPrefab;

    public override async Awaitable Initialize()
    {
        Instantiate(_playerPrefab);
        await base.Initialize();
    }
}
