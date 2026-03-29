using UnityEngine;

public class MapLoaderService : Service
{
    [SerializeField] private GameObject _map;

    public override Awaitable Initialize()
    {
        Instantiate(_map);
        return base.Initialize();
    }
}
