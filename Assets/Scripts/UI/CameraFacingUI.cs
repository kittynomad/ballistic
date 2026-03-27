using UnityEngine;

public class CameraFacingUI : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
