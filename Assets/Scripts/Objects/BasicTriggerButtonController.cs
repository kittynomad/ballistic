using UnityEngine;
using UnityEngine.Events;

public class BasicTriggerButtonController : MonoBehaviour
{
    [SerializeField] private UnityEvent _triggeredEvents;

    [SerializeField] private bool _canBeRetriggered = true;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerBehaviors>(out PlayerBehaviors pb))
        {
            _triggeredEvents.Invoke();
            if (!_canBeRetriggered)
                this.enabled = false;
        }
    }
}
