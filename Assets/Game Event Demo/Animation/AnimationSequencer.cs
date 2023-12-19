using Cysharp.Threading.Tasks;
using Glib.NovelGameEditor;
using UnityEngine;
using System;
using System.Collections.Generic;

public class AnimationSequencer : NovelAnimationBehavior
{
    [SerializeField]
    private AnimationBundle[] _animationBundles;

    public async override UniTask PlayAnimationAsync()
    {
        List<UniTask> tasks = new List<UniTask>();

        foreach (var animationBundle in _animationBundles)
        {
            tasks.Clear();

            // アニメーションの並列再生。
            foreach (var animationBehavior in animationBundle.AnimationBehaviors)
            {
                tasks.Add(animationBehavior.PlayAnimationAsync());
            }

            await UniTask.WhenAll(tasks);
        }
    }

    [Serializable]
    public class AnimationBundle
    {
        [SerializeField]
        private NovelAnimationBehavior[] _animationBehaviors;

        public NovelAnimationBehavior[] AnimationBehaviors => _animationBehaviors;
    }
}