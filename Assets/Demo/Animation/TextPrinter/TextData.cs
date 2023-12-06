using UnityEngine;
using System;

[Serializable]
public class TextData
{
    [SerializeField]
    private bool _isClearText = true;
    [SerializeField]
    private string _caption;
    [SerializeField]
    private string _text;
    [SerializeField, Range(0f, 2f)]
    private float _interval = 0.1f;

    public bool IsClearText => _isClearText;
    public string Caption => _caption;
    public string Text => _text;
    public float Interval => _interval; // ˆê•¶š‚ğo—Í‚·‚éŠÔŠuB
}