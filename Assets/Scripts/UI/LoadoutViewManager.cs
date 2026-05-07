using UnityEngine;
using TMPro;
using NaughtyAttributes;
using UnityEngine.UI;

public class LoadoutViewManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _loadoutNameDisplay;
    [SerializeField] private TextMeshProUGUI _loadoutDescriptionDisplay;

    private int loadoutIndex = 0;
    private WeaponConfig wc;
    public void InitializeLoadoutDisplay(int index)
    {
        loadoutIndex = index;
        WeaponConfigIDContainer wcID = ComponentDataService.Instance.WeaponLoadouts.WeaponConfigs[loadoutIndex];
        wc = WeaponConfigIDContainer.IDContainerToWeaponConfig(wcID);

        _loadoutNameDisplay.text = "Loadout " + (loadoutIndex + 1);
        _loadoutDescriptionDisplay.text = wc.ToString();
    }

    public void EquipLoadout()
    {
        FindAnyObjectByType<AssemblyUIService>().ReplaceConfigData(wc);
    }

}
