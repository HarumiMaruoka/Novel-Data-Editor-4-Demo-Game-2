// 日本語対応
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Glib.NovelGameEditor
{
    public abstract class NovelAnimationBehavior : MonoBehaviour
    {

        public virtual void OnEneter(AnimationNode node)
        {

        }

#pragma warning disable CS1998
        public virtual async UniTask PlayAnimationAsync() { }
#pragma warning restore CS1998

        public virtual void OnExit(AnimationNode node)
        {

        }
    }
}