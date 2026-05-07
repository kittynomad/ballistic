using UnityEngine;
using TMPro;
using NaughtyAttributes;
using UnityEngine.UI;

public class LoadoutViewManager : MonoBehaviour
{
    private int loadoutIndex = 0;
    private WeaponConfig wc;
    public void InitializeLoadoutDisplay(int index)
    {
        loadoutIndex = index;
        WeaponConfigIDContainer wcID = ComponentDataService.Instance.WeaponLoadouts.WeaponConfigs[loadoutIndex];
        wc = WeaponConfigIDContainer.IDContainerToWeaponConfig(wcID);


    }

    public void EquipLoadout()
    {
        FindAnyObjectByType<AssemblyUIService>().ReplaceConfigData(wc);
    }

}
