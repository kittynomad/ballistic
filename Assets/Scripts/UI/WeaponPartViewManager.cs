using UnityEngine;
using TMPro;
using NaughtyAttributes;
using UnityEngine.UI;

public class WeaponPartViewManager : MonoBehaviour
{
    [SerializeField] private WeaponPart _item;
    [SerializeField] private TextMeshProUGUI _partNameUI;
    [SerializeField] private TextMeshProUGUI _partDescriptionUI;
    [SerializeField] private TextMeshProUGUI _partStatsUI;
    [SerializeField] private Image _partIconUI;
    [SerializeField] private GameObject _effectsBox;

    [Button]
    public void TestDisplay()
    {
        InitializePartDisplay(_item);
    }

    public void InitializePartDisplay(WeaponPart p)
    {
        _item = p;
        _partNameUI.text = p.ItemName;
        _partDescriptionUI.text = p.ItemDescription; //+ "\n" + p.GetType();
        var icon = Resources.Load(p.ItemIconPath) as Texture2D;
        _partIconUI.sprite = Sprite.Create(icon, new Rect(0.0f, 0.0f, icon.width, icon.height), new Vector2(0.5f, 0.5f));
        //_partIconUI.SetNativeSize();

        //print(p.GetType());

        _partStatsUI.text = GeneratePartSpecificStatText(p);

        /*if(p is WeaponMagazine)
        {
            WeaponMagazine temp = p as WeaponMagazine;
            _partDescriptionUI.text = _partDescriptionUI.text + "\nsize: " + temp.MagSize;
        }*/

        GameObject effectsPrefab = Resources.Load("UI/ModTag") as GameObject;
        foreach(WeaponModifier w in p.Modifiers)
        {
            GameObject mod = Instantiate(effectsPrefab, _effectsBox.transform);
            mod.GetComponent<ModifierDisplay>().DisplayModifier(w);
        }
    }

    public void EquipPart()
    {
        FindAnyObjectByType<AssemblyUIService>().UpdateConfigData(_item);
    }

    public string GeneratePartSpecificStatText(WeaponPart p)
    {
        string statsText = "";

        if (p is WeaponFrame)
        {
            WeaponFrame f = p as WeaponFrame;
            statsText += "max addons: " + f.AddonCapacity + "\n";
            statsText += "base velocity: " + f.FireVelocity + "\n";
            statsText += "crit chance: " + f.BaseCritChance + "\n";
        }
        if(p is WeaponBattery)
        {
            WeaponBattery b = p as WeaponBattery;
            statsText += "capacity: " + b.Capacity + "\n";
            statsText += "recharge rate:" + b.RechargeRate + "\n";
        }
        if(p is WeaponMagazine)
        {
            WeaponMagazine temp = p as WeaponMagazine;
            statsText += "mag size: " + temp.MagSize + "\n";
            statsText += "reloat time: " + temp.ReloadTime + "\n";
            statsText += "damage: " + temp.Damage + "\n";
            statsText += "fire rate: " + (1f / temp.TimeBetweenShots) + "/s\n";
            statsText += "auto fire: " + temp.AutomaticFire + "\n";
        }
        if(p is WeaponMuzzle)
        {
            WeaponMuzzle m = p as WeaponMuzzle;
            statsText += "spread: " + m.Spread;
        }

        return statsText;
    }
}
