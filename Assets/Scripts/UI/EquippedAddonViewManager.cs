using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquippedAddonViewManager : MonoBehaviour
{
    [SerializeField] private Image _addonSprite;
    [SerializeField] private TextMeshProUGUI _addonName;
    private WeaponAddon addon;
    private int index;
    public void InitializeAddonDisplay(WeaponAddon wa, int i)
    {
        _addonName.text = wa.ItemName;
        var icon = Resources.Load(wa.ItemIconPath) as Texture2D;
        _addonSprite.sprite = Sprite.Create(icon, new Rect(0.0f, 0.0f, icon.width, icon.height), new Vector2(0.5f, 0.5f));
        addon = wa;
        index = i;
    }

    public void RemoveHeldAddon()
    {
        FindAnyObjectByType<AssemblyUIService>().RemoveAddon(index);
    }
}
