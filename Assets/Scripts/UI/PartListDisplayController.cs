using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;

public class PartListDisplayController : MonoBehaviour, IInitializable
{
    [SerializeField] private GameObject _listParent;
    private GameObject itemDisplayer;
    private List<GameObject> currentDisplayedParts = new List<GameObject>();

    public async Awaitable Initialize()
    {
        itemDisplayer = Resources.Load("UI/PartUIElement") as GameObject;
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
}
