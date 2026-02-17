using UnityEngine;

public interface IInitializable
{
    public abstract Awaitable Initialize();
    public abstract void DeInitialize();
}
