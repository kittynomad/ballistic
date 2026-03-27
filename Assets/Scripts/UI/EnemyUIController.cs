using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class EnemyUIController : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private GameObject _statusContainer;
    [SerializeField] private GameObject _statusPrefab;
    private List<Image> currentStatusIcons = new List<Image>();
    public void UpdateEnemyUI(ShootableEntity enemy)
    {
        _healthBar.value = enemy.CurrentHealth / enemy.TotalHealth;
        
        while(currentStatusIcons.Count > 0)
        {
            GameObject temp = currentStatusIcons[currentStatusIcons.Count - 1].gameObject ;
            currentStatusIcons.RemoveAt(currentStatusIcons.Count - 1);
            Destroy(temp);
        }

        foreach(IStatusEffect status in enemy.CurrentStatuses)
        {
            GameObject statusIcon = Instantiate(_statusPrefab, _statusContainer.transform);
            statusIcon.GetComponent<Image>().sprite = status.GetIcon();
            currentStatusIcons.Add(statusIcon.GetComponent<Image>());
            //statusIcon.transform.parent = _statusContainer.transform;
        }
    }
}
