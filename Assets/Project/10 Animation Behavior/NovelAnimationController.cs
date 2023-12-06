using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace Glib.NovelGameEditor
{
    [Serializable]
    public class NovelAnimationController
    {
        [SerializeField]
        private NovelAnimationBehavior[] _animations;

        public void OnEnter(AnimationNode node)
        {
            foreach (var animation in _animations)
            {
                animation.OnEneter(node);
            }
        }

        public async UniTask Play()
        {
            if (_animations == null || _animations.Length == 0)
            {
                Debug.Log("animation is none");
            }

            UniTask[] animationTasks = new UniTask[_animations.Length];

            // アニメーションを並列再生
            for (int i = 0; i < _animations.Length; i++)
            {
                animationTasks[i] = _animations[i].PlayAnimationAsync();
            }

            await UniTask.WhenAll(animationTasks);
        }

        public void OnExit(AnimationNode node)
        {
            foreach (var animation in _animations)
            {
                animation.OnExit(node);
            }
        }
    }
}