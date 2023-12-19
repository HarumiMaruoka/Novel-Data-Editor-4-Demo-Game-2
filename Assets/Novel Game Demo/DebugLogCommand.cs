using Cysharp.Threading.Tasks;
using UnityEngine;

public struct DebugLogCommand : ICommand
{
    string _logMessage;

    public DebugLogCommand(string logMessage)
    {
        _logMessage = logMessage;
    }
#pragma warning disable CS1998
    public async UniTask RunCommandAsync()
#pragma warning restore CS1998
    {
        Debug.Log(_logMessage);
    }
}