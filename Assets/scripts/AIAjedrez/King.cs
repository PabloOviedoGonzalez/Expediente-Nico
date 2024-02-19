using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPlayer
{
    public King()
    {
        value = 900;
    }
    
    public override bool[,] PossibleMoves()
    {
        bool[,] moves = new bool[8, 8];
        int x = currentX;
        int y = currentY;

        KingMove(x , y - 1, ref moves);

        KingMove(x - 1, y , ref moves);

        KingMove(x + 1, y , ref moves);

        KingMove(x , y + 1, ref moves);

        KingMove(x - 1, y - 1, ref moves);

        KingMove(x + 1, y - 1, ref moves);

        KingMove(x - 1, y + 1, ref moves);

        KingMove(x + 1, y + 1, ref moves);

        if(!isMoved)
        {
            if(isWhite)
            {
                CheckCastlingMoves(BoardManager.Instance.WhiteTower1, BoardManager.Instance.WhiteTower2, ref moves);
            }
            else
            {
                CheckCastlingMoves(BoardManager.Instance.BlackTower1, BoardManager.Instance.BlackTower2, ref moves);
            }
        }
        

        return moves;
    }
    
    private void KingMove(int x, int y, ref bool[,] moves)
    {
        if (x >= 0 && y >= 0 && x <= 7 && y <= 7)
        {
            ChessPlayer piece = BoardManager.Instance.Chessplayers[x, y];
            if (piece == null)
            {
                if(!KingInDanger(x, y))
                    moves[x, y] = true;
            }
            else if (piece.isWhite != isWhite)
            {
                if(!KingInDanger(x, y))
                    moves[x, y] = true;
            }
        }
    }

    private void CheckCastlingMoves(ChessPlayer Rook1, ChessPlayer Rook2, ref bool[,] moves)
    {
        int x = currentX;
        int y = currentY;
        ChessPlayer[,] Chessmans = BoardManager.Instance.Chessplayers;
        bool conditions;
        bool isInCheck = InDanger();

        if(Rook1 != null)
        {
            conditions = (!Rook1.isMoved) && 
                              (moves[x - 1, y] && Chessmans[x - 2, y] == null);

            conditions = conditions && !isInCheck;

            SetCastlingMove(x, y, x - 2, ref moves, conditions);

        }
        
        if(Rook2 != null)
        {

            conditions = (!Rook2.isMoved) && 
                         (moves[x + 1, y] && Chessmans[x + 2, y] == null && Chessmans[x + 3, y] == null);

            conditions = conditions && !isInCheck;

            SetCastlingMove(x, y, x + 2, ref moves, conditions);

        }
        
    }

    private void SetCastlingMove(int x, int y, int newX, ref bool[,] moves, bool conditions)
    {

        if(conditions)
        {

            BoardManager.Instance.Chessplayers[x, y] = null;
            BoardManager.Instance.Chessplayers[newX, y] = this;
            this.SetPosition(newX, y);

            bool inDanger = false;

            inDanger = InDanger();

            BoardManager.Instance.Chessplayers[x, y] = this;
            BoardManager.Instance.Chessplayers[newX, y] = null;
            this.SetPosition(x, y);

            if(inDanger == false)
                moves[newX, y] = true;
        }
    }

}
