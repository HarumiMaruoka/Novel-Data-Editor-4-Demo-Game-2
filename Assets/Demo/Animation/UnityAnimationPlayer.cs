using Cysharp.Threading.Tasks;
using Glib.NovelGameEditor;
using UnityEngine;

public class UnityAnimationPlayer : NovelAnimationBehavior
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private string _animationName;

    public async override UniTask PlayAnimationAsync()
    {
        if (_animator == null)
        {
            Debug.LogError("Animator reference is missing!");
            return;
        }

        if (string.IsNullOrEmpty(_animationName))
        {
            Debug.LogError("Animation name is not specified!");
            return;
        }

        // �A�j���[�V�������Đ�
        _animator.Play(_animationName);

        // �A�j���[�V�����̒������擾���đҋ@
        await UniTask.WaitUntil(() => _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);

    }
}