using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
namespace NovelGameEditor4
{
    // ----- Selection Commands ----- //

    public struct ShowCommand : ICommand
    {
        Selection _selection;
        IEnumerable<SelectableData> _selectableData;
        CancellationToken _cancellationToken;

        public ShowCommand(Selection selection, IEnumerable<SelectableData> selectableData, CancellationToken cancellationToken = default)
        {
            _selection = selection;
            _selectableData = selectableData;
            _cancellationToken = cancellationToken;
        }

        public async UniTask RunCommandAsync()
        {
            await _selection.Show(_selectableData);
        }
    }

    public struct HideCommand : ICommand
    {
        Selection _selection;
        CancellationToken _cancellationToken;

        public HideCommand(Selection selection, CancellationToken cancellationToken = default)
        {
            _selection = selection;
            _cancellationToken = cancellationToken;
        }

        public async UniTask RunCommandAsync()
        {
            await _selection.Hide();
        }
    }
}