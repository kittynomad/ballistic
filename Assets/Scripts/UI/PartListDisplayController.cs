using UnityEngine;
using System.Collections.Generic;

public class PartListDisplayController : MonoBehaviour, IInitializable
{
    [SerializeField] private GameObject _listParent;
    private GameObject itemDisplayer;
    private List<GameObject> currentDisplayedParts;

    public async Awaitable Initialize()
    {
        itemDisplayer = Resources.Load("UI/PartUIElement") as GameObject;
        UpdateListDisplay(ComponentDataService.Instance.Parts.WeaponFrames);
        return;
    }

    public void DeInitialize()
    {
        throw new System.NotImplementedException();
    }


    public async Awaitable UpdateListDisplay<T>(List<T> parts)
    {
        foreach (T p in parts)
        {
            if(p is WeaponPart)
            {
                WeaponPart temp = p as WeaponPart;
                GameObject g = Instantiate(itemDisplayer, _listParent.transform);
            }
                
        }
        
    }
}
