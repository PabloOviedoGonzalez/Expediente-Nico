using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPlayer
{
    public Knight()
    {
        value = 30;
    }

    public override bool[,] PossibleMoves()
    {
        bool[,] moves = new bool[8, 8];
        int x = currentX;
        int y = currentY;

        KnightMove(x - 1, y - 2, ref moves);

        KnightMove(x + 1, y - 2, ref moves);

        KnightMove(x + 2, y - 1, ref moves);

        KnightMove(x + 2, y + 1, ref moves);

        KnightMove(x - 2, y - 1, ref moves);

        KnightMove(x - 2, y + 1, ref moves);

        KnightMove(x - 1, y + 2, ref moves);

        KnightMove(x + 1, y + 2, ref moves);

        return moves;
    }

    private void KnightMove(int x, int y, ref bool[,] moves)
    {
        if (x >= 0 && y >= 0 && x <= 7 && y <= 7)
        {
            ChessPlayer piece = BoardManager.Instance.Chessplayers[x, y];

            if (piece == null)
            {
                if(!this.KingInDanger(x, y))
                    moves[x, y] = true;
            }

            else if (piece.isWhite != isWhite)
            {
                if(!this.KingInDanger(x, y))
                    moves[x, y] = true;
            }

        }
    }
}
