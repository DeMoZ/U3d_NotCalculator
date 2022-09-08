using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalcView : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField = default;
    [SerializeField] private Button checkButton = default;
    
    public void Init(Action<string> onChangeCallback, Action onCheckCallback)
    {
        inputField.onValueChanged.AddListener(s => onChangeCallback?.Invoke(s));
        checkButton.onClick.AddListener(() => { onCheckCallback?.Invoke(); });
    }
    
    private void OnDestroy()
    {
        inputField.onValueChanged.RemoveAllListeners();
        checkButton.onClick.RemoveAllListeners();
    }

    public void Show(string value)
    {
        inputField.text = value;
    }
}