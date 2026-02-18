/*****************************************************************************
// File Name : ComponentDataService.cs
// Author : Pierce Nunnelley
// Creation Date : February 15, 2026
//
// Brief Description : This service distributes data/stats about weapon
// components.
*****************************************************************************/
using UnityEngine;
using System.Collections.Generic;

public class ComponentDataService : Service
{
    [SerializeField] private PartDatabase _parts;
    public PartDatabase Parts { get => _parts; set => _parts = value; }
}
