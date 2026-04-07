using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MainHUDReferences : MonoBehaviour
{
    [SerializeField] private Slider _batteryMeter;
    [SerializeField] private Slider _healthMeter;

    public Slider BatteryMeter { get => _batteryMeter; set => _batteryMeter = value; }
    public Slider HealthMeter { get => _healthMeter; set => _healthMeter = value; }
}
