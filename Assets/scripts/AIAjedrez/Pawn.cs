using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPlayer
{
    public Pawn()
    {
        value = 10;
    }
    
    public override bool[,] PossibleMoves()
    {
        bool[,] moves = new bool[8, 8];
        int x = currentX;
        int y = currentY;

        ChessPlayer leftChessplayer = null;
        ChessPlayer rightChessplayer = null;
        ChessPlayer forwardChessplayer = null;

        int[] EnPassant = BoardManager.Instance.EnPassant;

        if (isWhite)
        {
            if(y > 0)
            {
                if (x > 0) leftChessplayer = BoardManager.Instance.Chessplayers[x - 1, y - 1];
                if (x < 7) rightChessplayer = BoardManager.Instance.Chessplayers[x + 1, y - 1];
                forwardChessplayer = BoardManager.Instance.Chessplayers[x, y - 1];
            }
            if (forwardChessplayer == null) 
            {
                if(!this.KingInDanger(x, y - 1))
                    moves[x, y - 1] = true;
            }

            if(leftChessplayer != null && !leftChessplayer.isWhite)
            {
                if(!this.KingInDanger(x - 1, y - 1))
                    moves[x - 1, y - 1] = true;
            }
            else if(leftChessplayer == null && EnPassant[1] == y - 1 &&  EnPassant[0] == x - 1)
            {
                if(!this.KingInDanger(x - 1, y - 1))
                    moves[x - 1, y - 1] = true;
            }

            if(rightChessplayer != null && !rightChessplayer.isWhite)
            {
                if(!this.KingInDanger(x + 1, y - 1))
                    moves[x + 1, y - 1] = true;
            }
            else if (rightChessplayer == null && EnPassant[1] == y - 1 && EnPassant[0] == x + 1)
            {
                if(!this.KingInDanger(x + 1, y - 1))
                    moves[x + 1, y - 1] = true;
            }

            if (y == 6 && forwardChessplayer == null && BoardManager.Instance.Chessplayers[x, y - 2] == null)
            {
                if(!this.KingInDanger(x, y - 2))
                    moves[x, y - 2] = true;
            }
        }
        else
        {
            if (y < 7)
            {

                if (x > 0) leftChessplayer = BoardManager.Instance.Chessplayers[x - 1, y + 1];

                if (x < 7) rightChessplayer = BoardManager.Instance.Chessplayers[x + 1, y + 1];

                forwardChessplayer = BoardManager.Instance.Chessplayers[x, y + 1];
            }

            if (forwardChessplayer == null)
            {
                if(!this.KingInDanger(x, y + 1))
                    moves[x, y + 1] = true;
            }

            if (leftChessplayer != null && leftChessplayer.isWhite)
            {
                if(!this.KingInDanger(x - 1, y + 1))
                    moves[x - 1, y + 1] = true;
            }
            else if (leftChessplayer == null && EnPassant[1] == y + 1 && EnPassant[0] == x - 1)
            {
                if(!this.KingInDanger(x - 1, y + 1))
                    moves[x - 1, y + 1] = true;
            }

            if (rightChessplayer != null && rightChessplayer.isWhite)
            {
                if(!this.KingInDanger(x + 1, y + 1))
                    moves[x + 1, y + 1] = true;
            }
            else if (rightChessplayer == null && EnPassant[1] == y + 1 && EnPassant[0] == x + 1)
            {
                if(!this.KingInDanger(x + 1, y + 1))
                    moves[x + 1, y + 1] = true;
            }

            if (y == 1 && forwardChessplayer == null && BoardManager.Instance.Chessplayers[x, y + 2] == null)
            {
                if(!this.KingInDanger(x, y + 2))
                    moves[x, y + 2] = true;
            }
        }

        return moves;
    }
}
