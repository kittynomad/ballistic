using UnityEngine;
using NaughtyAttributes;

public class RagdollToggler : MonoBehaviour
{
    [SerializeField] private Collider nonRagdollCollider;
    [SerializeField] private Rigidbody nonRagdollRigidbody;
    [SerializeField] private Rigidbody[] rigidbodies = new Rigidbody[13];
    [SerializeField] private Collider[] colliders = new Collider[13];
    [SerializeField] private CharacterJoint[] chJoints = new CharacterJoint[13];

    private void Start()
    {
        DisableRagdoll();
    }

    [Button]
    public void EnableRagdoll()
    {
        ToggleRagdoll(true);
    }

    [Button]
    public void DisableRagdoll()
    {
        ToggleRagdoll(false);
    }

    public void ToggleRagdoll(bool enable)
    {
        gameObject.GetComponent<Animator>().enabled = !enable;
        nonRagdollCollider.enabled = !enable;
        nonRagdollRigidbody.useGravity = !enable;

        foreach (Rigidbody rb in rigidbodies)
            rb.useGravity = enable;
            
        foreach (Collider coll in colliders)
            coll.enabled = enable;

        foreach (CharacterJoint joint in chJoints) continue;
            //joint. = !enable;
    }
}
