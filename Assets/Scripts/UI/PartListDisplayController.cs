using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;

public class PartListDisplayController : MonoBehaviour, IInitializable
{
    [SerializeField] private GameObject _listParent;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _statsText;
    [SerializeField] private GameObject _addonListParent;
    private GameObject itemDisplayer;
    private GameObject addonDisplayer;
    private List<GameObject> currentDisplayedParts = new List<GameObject>();
    private List<GameObject> currentEquippedAddons = new List<GameObject>();

    public TextMeshProUGUI Description { get => _description; set => _description = value; }
    public TextMeshProUGUI StatsText { get => _statsText; set => _statsText = value; }

    public async Awaitable Initialize()
    {
        itemDisplayer = Resources.Load("UI/PartUIElement") as GameObject;
        addonDisplayer = Resources.Load("UI/SingleAddonUI") as GameObject;
        await UpdateListDisplay(ComponentDataService.Instance.Parts.WeaponFrames);
        return;
    }

    public void DeInitialize()
    {
        throw new System.NotImplementedException();
    }

    [Button]
    public void LoadMagazineList()
    {
        UpdateListDisplay(ComponentDataService.Instance.Parts.WeaponMagazines);
    }

    [Button]
    public void LoadBatteryList()
    {
        UpdateListDisplay(ComponentDataService.Instance.Parts.WeaponBatteries);
    }

    [Button]
    public void LoadFrameList()
    {
        UpdateListDisplay(ComponentDataService.Instance.Parts.WeaponFrames);
    }

    [Button]
    public void LoadAddonList()
    {
        UpdateListDisplay(ComponentDataService.Instance.Parts.WeaponAddons);
    }

    [Button]
    public void LoadMuzzleList()
    {
        UpdateListDisplay(ComponentDataService.Instance.Parts.WeaponMuzzles);
    }

    public void RandomizeLoadout()
    {
        FindAnyObjectByType<AssemblyUIService>().RandomizeConfig();
    }

    public void RemoveAddons()
    {
        FindAnyObjectByType<AssemblyUIService>().ClearAddons();
    }

    public async Awaitable UpdateEquippedAddonListDisplay(WeaponConfig wc)
    {
        await ClearEquippedAddonListDisplay();

        for(int i = 0; i < wc.Addons.Length; i++)
        {
            if (wc.Addons[i] != null)
            {
                GameObject g = Instantiate(addonDisplayer, _addonListParent.transform);
                g.GetComponent<EquippedAddonViewManager>().InitializeAddonDisplay(wc.Addons[i], i);
                currentEquippedAddons.Add(g);
                await Awaitable.NextFrameAsync();
            }
        }
    }

    public async Awaitable ClearEquippedAddonListDisplay()
    {
        /*for(int i = _addonListParent.transform.childCount; i > 0; i--)
        {
            Destroy(_addonListParent.transform.GetChild(i).gameObject);
        }*/
        while (currentEquippedAddons.Count > 0)
        {
            GameObject temp = currentEquippedAddons[currentEquippedAddons.Count - 1];
            currentEquippedAddons.RemoveAt(currentEquippedAddons.Count - 1);
            Destroy(temp);
            await Awaitable.NextFrameAsync();
        }
    }

    public async Awaitable UpdateListDisplay<T>(List<T> parts)
    {
        await ClearListDisplay();

        foreach (T p in parts)
        {
            if(p is WeaponPart)
            {
                WeaponPart temp = p as WeaponPart;
                GameObject g = Instantiate(itemDisplayer, _listParent.transform);
                g.GetComponent<WeaponPartViewManager>().InitializePartDisplay(temp);
                currentDisplayedParts.Add(g);
                await Awaitable.NextFrameAsync();
            }
                
        }
        
    }

    public async Awaitable ClearListDisplay()
    {
        while(currentDisplayedParts.Count > 0)
        {
            GameObject temp = currentDisplayedParts[currentDisplayedParts.Count - 1];
            currentDisplayedParts.RemoveAt(currentDisplayedParts.Count - 1);
            Destroy(temp);
            await Awaitable.NextFrameAsync();
        }
    }

    public void ConfirmLoadout()
    {
        FindAnyObjectByType<AssemblyUIService>().ConfirmLoadout();
    }
}
