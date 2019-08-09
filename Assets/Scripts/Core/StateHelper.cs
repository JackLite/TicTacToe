using Core;
using Game.Field;

public static class StateHelper
{
    public static PlayerType Convert(CellState state)
    {
        return state == CellState.Zero ? PlayerType.zero : PlayerType.cross;
    }

    public static CellState Convert(PlayerType playerType)
    {
        return playerType == PlayerType.zero ? CellState.Zero : CellState.Cross;
    }
}
