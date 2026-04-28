using UnityEngine;
using System.Collections;

public abstract class LimitedLifespanEntity : MonoBehaviour
{
    [SerializeField] private float _totalLifespan;
    private float currentLifespan;

    public float TotalLifespan { get => _totalLifespan; set => _totalLifespan = value; }
    public float CurrentLifespan { get => currentLifespan; set => currentLifespan = value; }

    //in case inheriting scripts want to do a little something extra
    public virtual void StartLifeTimer()
    {
        StartCoroutine(CountDownLife());
    }

    public virtual void ResetLifeTimer()
    {
        StopAllCoroutines();
        currentLifespan = _totalLifespan;
    }

    public IEnumerator CountDownLife()
    {
        //looping in fixed update so lifespan can be tracked (idk if i'll actually use this)
        currentLifespan = _totalLifespan;
        while(currentLifespan > 0f)
        {
            currentLifespan -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        EndLifeBehavior();
    }

    public virtual void EndLifeBehavior()
    {
        Destroy(gameObject);
    }
}
