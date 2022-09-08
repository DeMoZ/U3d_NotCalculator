using System;
using UnityEngine;
using UnityEngine.UI;

public class PopupView : MonoBehaviour
{
    [SerializeField] private Button newButton = default;
    [SerializeField] private Button quitButton = default;
    
    public void Init(Action onNewCallback, Action onQuitCallback)
    {
        newButton.onClick.AddListener(() => { onNewCallback?.Invoke(); });
        quitButton.onClick.AddListener(() => { onQuitCallback?.Invoke(); });
    }

    public void OnDestroy()
    {
        newButton.onClick.RemoveAllListeners();
        quitButton.onClick.RemoveAllListeners();
    }
}