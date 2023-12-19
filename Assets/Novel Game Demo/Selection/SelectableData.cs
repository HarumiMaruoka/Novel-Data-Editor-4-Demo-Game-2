using UnityEngine;
using System;

namespace NovelGameEditor4
{
    [Serializable]
    public struct SelectableData
    {
        [SerializeField]
        private string _text;
        [SerializeField]
        private Sprite _sprite;

        public string Text => _text;
        public Sprite Background => _sprite;
        public ICommand SelectedCommand => new DebugLogCommand(_text); // Sample
    }
}