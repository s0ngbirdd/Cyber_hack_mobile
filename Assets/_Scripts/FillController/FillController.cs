using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FillController : MonoBehaviour
{
    // Serialize
    [SerializeField] private Image _fillBarImage;
    [SerializeField] private TextMeshProUGUI _fillBarText;

    // Private
    private float _maxFill = 0.0f;
    private float _currentFill = 0.0f;

    private void OnEnable()
    {
        LevelGenerator.OnTileSpawn += IncreaseMaxFill;
    }

    private void OnDisable()
    {
        LevelGenerator.OnTileSpawn -= IncreaseMaxFill;
    }

    private void Update()
    {
        _fillBarImage.fillAmount = _currentFill / _maxFill;
        _fillBarText.text = $"{Mathf.Round(_currentFill / _maxFill * 100)}";
    }

    private void IncreaseMaxFill()
    {
        _maxFill += 1;

        Debug.Log(_maxFill);
    }

    public void IncreaseCurrentFill()
    {
        if (_currentFill < _maxFill)
        {
            _currentFill += 1;
        }

        if (_currentFill > _maxFill)
        {
            _currentFill = _maxFill;
        }

        Debug.Log(_currentFill);
    }

    public void DecreaseCurrentFill()
    {
        if (_currentFill > 0)
        {
            _currentFill -= 1;
        }

        if (_currentFill < 0)
        {
            _currentFill = 0;
        }

        Debug.Log(_currentFill);
    }
}
