using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPlayer : MonoBehaviour
{
    public int currentX { set; get; }
    public int currentY { set; get; }
    public bool isWhite;
    public int value;
    public bool isMoved = false;

    public ChessPlayer Clone()
    {
       return (ChessPlayer) this.MemberwiseClone();
    }

    public void SetPosition(int x, int y)
    {
        currentX = x;
        currentY = y;
    }

    public virtual bool[,] PossibleMoves()
    {
        bool[,] arr = new bool[8,8];
        for(int i=0; i<8; i++)
        {
            for(int j=0; j<8; j++)
            {
                arr[i, j] = false;
            }
        }
        return arr;
    }

    public bool InDanger()
    {
        ChessPlayer piece = null;

        int x = currentX;
        int y = currentY;


        if(y - 1 >= 0)
        {
            piece = BoardManager.Instance.Chessplayers[x, y - 1];

            if(piece != null && piece.isWhite != isWhite &&  piece.GetType() == typeof(King))
                return true;
        }
        while (y-- > 0)
        {
            piece = BoardManager.Instance.Chessplayers[x, y];

            if (piece == null)
                continue;
            

            else if (piece.isWhite == isWhite)
                break;


            if(piece.GetType() == typeof(Tower) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Rook/Queen Down");
                return true;
            }

            break;
        }

        x = currentX;
        y = currentY;

        if(x + 1 <= 7)
        {
            piece = BoardManager.Instance.Chessplayers[x + 1, y];

            if(piece != null && piece.isWhite != isWhite &&  piece.GetType() == typeof(King))
                return true;
        }
        while (x++ < 7)
        {
            piece = BoardManager.Instance.Chessplayers[x, y];

            if (piece == null)
                continue;

            else if (piece.isWhite == isWhite)
                break;


            if(piece.GetType() == typeof(Tower) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Rook/Queen Right");
                return true;
            }

            break;
        }

        x = currentX;
        y = currentY;

        if(x - 1 >= 0)
        {
            piece = BoardManager.Instance.Chessplayers[x - 1, y];

            if(piece != null && piece.isWhite != isWhite &&  piece.GetType() == typeof(King))
                return true;
        }
        while (x-- > 0)
        {
            piece = BoardManager.Instance.Chessplayers[x, y];

            if (piece == null)
                continue;
            

            else if (piece.isWhite == isWhite)
                break;


            if(piece.GetType() == typeof(Tower) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Rook/Queen Left");
                return true;
            }

            break;
        }

        x = currentX;
        y = currentY;

        if(y + 1 <= 7)
        {
            piece = BoardManager.Instance.Chessplayers[x, y + 1];

            if(piece != null && piece.isWhite != isWhite &&  piece.GetType() == typeof(King))
                return true;
        }
        while (y++ < 7)
        {
            piece = BoardManager.Instance.Chessplayers[x, y];

            if (piece == null)
                continue;
            

            else if (piece.isWhite == isWhite)
                break;


            if(piece.GetType() == typeof(Tower) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Rook/Queen Up");
                return true;
            }

            break;
        }

        x = currentX;
        y = currentY;

        if(x + 1 <= 7 && y - 1 >= 0 && isWhite)
        {
            piece = BoardManager.Instance.Chessplayers[x + 1, y - 1];

            if(piece != null && piece.isWhite != isWhite && piece.GetType() == typeof(Pawn))
                return true;
        }
        if(x + 1 <= 7 && y - 1 >= 0)
        {
            piece = BoardManager.Instance.Chessplayers[x + 1, y - 1];

            if(piece != null && piece.isWhite != isWhite &&  piece.GetType() == typeof(King))
                return true;
        }
        while (x++ < 7 && y-- > 0)
        {
            piece = BoardManager.Instance.Chessplayers[x, y];

            if (piece == null)
                continue;
            

            else if (piece.isWhite == isWhite)
                break;


            if(piece.GetType() == typeof(Bishup) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Bishup/Queen LR Down");
                return true;
            }

            break;
        }

        x = currentX;
        y = currentY;

        if(x + 1 <= 7 && y + 1 <= 7 && !isWhite)
        {
            piece = BoardManager.Instance.Chessplayers[x + 1, y + 1];

            if(piece != null && piece.isWhite != isWhite && piece.GetType() == typeof(Pawn))
                return true;
        }
        if(x + 1 <= 7 && y + 1 <= 7)
        {
            piece = BoardManager.Instance.Chessplayers[x + 1, y + 1];

            if(piece != null && piece.isWhite != isWhite &&  piece.GetType() == typeof(King))
                return true;
        }
        while (x++ < 7 && y++ < 7)
        {
            piece = BoardManager.Instance.Chessplayers[x, y];

            if (piece == null)
                continue;
            
            else if (piece.isWhite == isWhite)
                break;

            if(piece.GetType() == typeof(Bishup) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Bishup/Queen LR Up");
                return true;
            }

            break;
        }

        x = currentX;
        y = currentY;

        if(x - 1 >= 0 && y - 1 >= 0 && isWhite)
        {
            piece = BoardManager.Instance.Chessplayers[x - 1, y - 1];

            if(piece != null && piece.isWhite != isWhite && piece.GetType() == typeof(Pawn))
                return true;
        }
        if(x - 1 >= 0 && y - 1 >= 0)
        {
            piece = BoardManager.Instance.Chessplayers[x - 1, y - 1];

            if(piece != null && piece.isWhite != isWhite &&  piece.GetType() == typeof(King))
                return true;
        }
        while (x-- > 0 && y-- > 0)
        {
            piece = BoardManager.Instance.Chessplayers[x, y];

            if (piece == null)
                continue;

            else if (piece.isWhite == isWhite)
                break;

            if(piece.GetType() == typeof(Bishup) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Bishup/Queen RL Down");
                return true;
            }

            break;
        }

        x = currentX;
        y = currentY;

        if(x - 1 >= 0 && y + 1 <= 7 && !isWhite)
        {
            piece = BoardManager.Instance.Chessplayers[x - 1, y + 1];

            if(piece != null && piece.isWhite != isWhite && piece.GetType() == typeof(Pawn))
                return true;
        }
        if(x - 1 >= 0 && y + 1 <= 7)
        {
            piece = BoardManager.Instance.Chessplayers[x - 1, y + 1];

            if(piece != null && piece.isWhite != isWhite &&  piece.GetType() == typeof(King))
                return true;
        }
        while (x-- > 0 && y++ < 7)
        {
            piece = BoardManager.Instance.Chessplayers[x, y];

            if (piece == null)
                continue;
            
            else if (piece.isWhite == isWhite)
                break;

            if(piece.GetType() == typeof(Bishup) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Bishup/Queen RL Up");
                return true;
            }

            break;
        }

        x = currentX;
        y = currentY;

        if(KnightThreat(x - 1, y - 2))
            return true;

        if(KnightThreat(x + 1, y - 2))
            return true;

        if(KnightThreat(x + 2, y - 1))
            return true;

        if(KnightThreat(x + 2, y + 1))
            return true;

        if(KnightThreat(x - 2, y - 1))
            return true;

        if(KnightThreat(x - 2, y + 1))
            return true;

        if(KnightThreat(x - 1, y + 2))
            return true;

        if(KnightThreat(x + 1, y + 2))
            return true;

        return false;
    }

    public bool KnightThreat(int x, int y)
    {
        if (x >= 0 && y >= 0 && x <= 7 && y <= 7)
        {
            ChessPlayer piece = BoardManager.Instance.Chessplayers[x, y];

            if (piece == null)
                return false;

            if (piece.isWhite == isWhite)
                return false;


            if(piece.GetType() == typeof(Knight))
            {
                Debug.Log("Threat from Knight");
                return true;   
            }
        }

        return false;
    }

    public bool KingInDanger(int x, int y)
    {
        ChessPlayer tmpChessman = BoardManager.Instance.Chessplayers[x, y];
        int tmpCurrentX = currentX;
        int tmpCurrentY = currentY;


        BoardManager.Instance.Chessplayers[currentX, currentY] = null;
        BoardManager.Instance.Chessplayers[x, y] = this;
        this.SetPosition(x, y);


        bool result = false;

        if(isWhite)
            result = BoardManager.Instance.WhiteKing.InDanger();
        else
            result = BoardManager.Instance.BlackKing.InDanger();

        this.SetPosition(tmpCurrentX, tmpCurrentY);
        BoardManager.Instance.Chessplayers[tmpCurrentX, tmpCurrentY] = this;
        BoardManager.Instance.Chessplayers[x, y] = tmpChessman;
        

        return result;
    }
}
