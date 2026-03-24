using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MainHUDReferences : MonoBehaviour
{
    [SerializeField] private Slider _batteryMeter;

    public Slider BatteryMeter { get => _batteryMeter; set => _batteryMeter = value; }
}
