using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace ActorCommands
{
    public struct ChangeTextureCommand : ICommand
    {
        Actor _actor;
        int _index;
        float _duration;
        CancellationToken _cancellationToken;

        public ChangeTextureCommand(Actor actor, int index, float duration, CancellationToken cancellationToken = default)
        {
            _actor = actor;
            _index = index;
            _duration = duration;
            _cancellationToken = cancellationToken;
        }

        public async UniTask RunCommandAsync()
        {
            await _actor.ChangeTextureAsync(_index, _duration, _cancellationToken);
        }
    }

    public struct RotateCommand : ICommand
    {
        Actor _actor;
        Vector3 _rot;
        float _duration;
        CancellationToken _cancellationToken;

        public RotateCommand(Actor actor, Vector3 rot, float duration, CancellationToken cancellationToken = default)
        {
            _actor = actor;
            _rot = rot;
            _duration = duration;
            _cancellationToken = cancellationToken;
        }

        public async UniTask RunCommandAsync()
        {
            await _actor.RotateAsync(_rot, _duration, _cancellationToken);
        }
    }

    public struct MoveCommand : ICommand
    {
        Actor _actor;
        Vector2 _to;
        float _duration;
        CancellationToken _cancellationToken;

        public MoveCommand(Actor actor, Vector2 to, float duration, CancellationToken cancellationToken = default)
        {
            _actor = actor;
            _to = to;
            _duration = duration;
            _cancellationToken = cancellationToken;
        }

        public async UniTask RunCommandAsync()
        {
            await _actor.MoveAsync(_to, _duration, _cancellationToken);
        }
    }

    public struct ShowCommand : ICommand
    {
        Actor _actor;
        float _duration;
        CancellationToken _cancellationToken;

        public ShowCommand(Actor actor, float duration, CancellationToken cancellationToken = default)
        {
            _actor = actor;
            _duration = duration;
            _cancellationToken = cancellationToken;
        }

        public async UniTask RunCommandAsync()
        {
            await _actor.ShowAsync(_duration, _cancellationToken);
        }
    }

    public struct HideAsyncCommand : ICommand
    {
        Actor _actor;
        float _duration;
        CancellationToken _cancellationToken;

        public HideAsyncCommand(Actor actor, float duration, CancellationToken cancellationToken = default)
        {
            _actor = actor;
            _duration = duration;
            _cancellationToken = cancellationToken;
        }

        public async UniTask RunCommandAsync()
        {
            await _actor.HideAsync(_duration, _cancellationToken);
        }
    }
}