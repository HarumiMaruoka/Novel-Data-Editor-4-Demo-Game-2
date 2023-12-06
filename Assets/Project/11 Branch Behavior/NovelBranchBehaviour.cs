// 日本語対応
using UnityEngine;

namespace Glib.NovelGameEditor
{
    public class NovelBranchBehaviour : MonoBehaviour
    {
        public virtual void OnEnter(BranchNode branchNode) { }
        public virtual void OnUpdate(BranchNode branchNode) { }
        public virtual void OnExit(BranchNode branchNode) { }
    }
}