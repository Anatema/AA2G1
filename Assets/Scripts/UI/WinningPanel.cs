using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinningPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _messageText;
    private Action _callback;
    public void Show(string message, Action callback)
    {
        gameObject.SetActive(true);
        _messageText.text = message;
        _callback = callback;
    }
    public void ButtonPressed()
    {
        _callback?.Invoke();
    }
}
