using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UiHealthController : MonoBehaviour
{
    [SerializeField]
    private Image _healthPrefab;
    private List<Unit> _units = new List<Unit>();
    private Dictionary<Unit, Image> _helathBars = new Dictionary<Unit, Image>();
    private Camera _camera;

    [SerializeField]
    private Vector3 _healthbarOffset;
    public void Awake()
    {
        _camera = Camera.main;
    }
    public void Start()
    {
        _units = FindObjectsOfType<Unit>().ToList<Unit>();
        foreach(Unit unit in _units)
        {
            Image healthBatUi = Instantiate(_healthPrefab, transform);
            _helathBars.Add(unit, healthBatUi);
            unit.OnUnitDestroyed.AddListener(RemoveHealthBar);
            unit.OnUnitHealthChanged.AddListener(EditHealthBar);
        }
    }
    private void LateUpdate()
    {
        UpdateHealthPositions();
    }

    private void RemoveHealthBar(Unit unit)
    {
        unit.OnUnitDestroyed?.RemoveListener(RemoveHealthBar);
        unit.OnUnitHealthChanged?.RemoveListener(EditHealthBar);

        Destroy(_helathBars[unit]);
        _helathBars.Remove(unit);
        _units.Remove(unit);

    }
    private void EditHealthBar(Unit unit, float healthValue)
    {
        _helathBars[unit].transform.GetChild(0).GetComponent<Image>().fillAmount = healthValue;
    }
    private void UpdateHealthPositions()
    {
        foreach (Unit unit in _units)
        {
            Vector3 targetVector = unit.transform.position - _camera.transform.position;
            Vector3 playerForward = _camera.transform.forward;
            float angle = Vector3.SignedAngle(playerForward, targetVector, transform.up);
            Vector3 targetVectorPosition;
            if (Mathf.Abs(angle) < 45)
            {
                targetVectorPosition = unit.transform.position + _healthbarOffset;
                targetVectorPosition = Camera.main.WorldToScreenPoint(targetVectorPosition);

                _helathBars[unit].gameObject.SetActive(true);
                _helathBars[unit].rectTransform.position = targetVectorPosition;

            }
            else
            {
                _helathBars[unit].gameObject.SetActive(false);

            }
            //_helathBars[unit].rectTransform.position = _camera.WorldToScreenPoint(unit.transform.position + _healthbarOffset, );

        }
    }
}

