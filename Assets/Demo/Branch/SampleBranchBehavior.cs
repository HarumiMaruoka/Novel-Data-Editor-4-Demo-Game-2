// 日本語対応
using Glib.NovelGameEditor;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SampleBranchBehavior : NovelBranchBehaviour
{
    private BranchNode _branchNode;

    public override void OnEnter(BranchNode branchNode)
    {
        _branchNode = branchNode;
        this.ShowSelections(branchNode.Elements);
    }

    public override void OnExit(BranchNode branchNode)
    {
        this.HideSelections();
    }

    private void OnSelectedElement(SelectableView selectionView)
    {
        _branchNode.Controller.MoveTo(selectionView.Selectable.Child);
    }

    [SerializeField]
    private Transform _selectionViewParent; // 選択肢ビューの親オブジェクト
    [SerializeField]
    private SelectableView _selectionViewPrefab; // 選択肢ビューのプレハブ

    private Stack<SelectableView> _alives = new Stack<SelectableView>();   // 表示中の選択肢ビュー
    private Stack<SelectableView> _disposed = new Stack<SelectableView>(); // 破棄された選択肢ビュー

    public void ShowSelections(IEnumerable<BranchElement> branchElements)
    {
        foreach (var branchElement in branchElements)
        {
            SelectableView instance = null;
            if (_disposed.Count != 0)
            {
                instance = _disposed.Pop();
            }
            else
            {
                instance = GameObject.Instantiate(_selectionViewPrefab, _selectionViewParent);
            }

            instance.OnSelected += OnSelectedElement;
            instance.OnShow();
            instance.Initialize(branchElement);

            _alives.Push(instance);
        }
    }

    public void HideSelections()
    {
        while (_alives.Count > 0)
        {
            var dispose = _alives.Pop();
            dispose.OnHide();
            dispose.Dispose();
            _disposed.Push(dispose);
        }
    }

}