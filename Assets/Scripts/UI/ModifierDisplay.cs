using UnityEngine;
using TMPro;

public class ModifierDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _modName;

    public void DisplayModifier(WeaponModifier w)
    {
        string output = w.Mod.ToString() + " " + w.ModOperator.ToString() + " " + w.ModStrength.ToString();
        _modName.text = output;
    }
}
