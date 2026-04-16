using UnityEngine;

public class PlayerBehaviors : MonoBehaviour
{
    public bool IsGrounded()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1f))
        {
            return true;
        }
        return false;
    }
}
