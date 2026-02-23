using UnityEngine;
using TMPro;
using NaughtyAttributes;
using UnityEngine.UI;

public class WeaponPartViewManager : MonoBehaviour
{
    [SerializeField] private WeaponFrame _testItem;
    [SerializeField] private TextMeshProUGUI _partNameUI;
    [SerializeField] private TextMeshProUGUI _partDescriptionUI;
    [SerializeField] private Image _partIconUI;
    [SerializeField] private GameObject _effectsBox;

    [Button]
    public void TestDisplay()
    {
        InitializePartDisplay(_testItem);
    }

    public void InitializePartDisplay(WeaponPart p)
    {
        _partNameUI.text = p.ItemName;
        _partDescriptionUI.text = p.ItemDescription + "\n" + p.GetType();
        var icon = Resources.Load(p.ItemIconPath) as Texture2D;
        _partIconUI.sprite = Sprite.Create(icon, new Rect(0.0f, 0.0f, icon.width, icon.height), new Vector2(0.5f, 0.5f));
        //_partIconUI.SetNativeSize();

        print(p.GetType());

        if(p is WeaponMagazine)
        {
            WeaponMagazine temp = p as WeaponMagazine;
            _partDescriptionUI.text = _partDescriptionUI.text + "\nsize: " + temp.MagSize;
        }

        GameObject effectsPrefab = Resources.Load("UI/ModTag") as GameObject;
        foreach(WeaponModifier w in p.Modifiers)
        {
            GameObject mod = Instantiate(effectsPrefab, _effectsBox.transform);
            mod.GetComponent<ModifierDisplay>().DisplayModifier(w);
        }
    }
}
