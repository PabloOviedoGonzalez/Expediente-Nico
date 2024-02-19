using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardHighlights : MonoBehaviour
{
    public static BoardHighlights Instance { set; get; }

    public GameObject BlueHighlightPrefab;
    public GameObject YellowHighlightPrefab;
    public GameObject RedHighlightPrefab;
    public GameObject PurpleHighlightPrefab;
    public GameObject CheckHighlightPrefab;

    private GameObject[,] BlueTiles = new GameObject[8, 8];
    private GameObject[,] YellowTiles = new GameObject[8, 8];
    private GameObject[,] RedTiles = new GameObject[8, 8];
    private GameObject[,] PurpleTiles = new GameObject[8, 8];
    private GameObject[,] CheckTiles = new GameObject[8, 8];

    private void Start()
    {
        Instance = this;
        PlaceAllTiles();
    }

    public void PlaceAllTiles()
    {
        GameObject tile;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                tile = Instantiate(BlueHighlightPrefab);
                tile.transform.position = new Vector3(i, 0.0001f, j);
                tile.transform.SetParent(this.transform);
                BlueTiles[i, j] = tile;

                tile = Instantiate(YellowHighlightPrefab);
                tile.transform.position = new Vector3(i, 0.0001f, j);
                tile.transform.SetParent(this.transform);
                YellowTiles[i, j] = tile;

                tile = Instantiate(RedHighlightPrefab);
                tile.transform.position = new Vector3(i, 0.0001f, j);
                tile.transform.SetParent(this.transform);
                RedTiles[i, j] = tile;

                tile = Instantiate(PurpleHighlightPrefab);
                tile.transform.position = new Vector3(i, 0.0001f, j);
                tile.transform.SetParent(this.transform);
                PurpleTiles[i, j] = tile;

                tile = Instantiate(CheckHighlightPrefab);
                tile.transform.position = new Vector3(i, 0.0001f, j);
                tile.transform.SetParent(this.transform);
                CheckTiles[i, j] = tile;
            }
        }
    }

    public void DisableAllHighlights()
    {
        for(int i=0; i<8; i++)
        {
            for(int j=0; j<8; j++)
            {
                BlueTiles[i, j].SetActive(false);
                YellowTiles[i, j].SetActive(false);
                RedTiles[i, j].SetActive(false);
                PurpleTiles[i, j].SetActive(false);
                CheckTiles[i, j].SetActive(false);
            }
        }
    }

    public void SetTileBlue(int x, int y)
    {
        BlueTiles[x, y].SetActive(true);
    }

    public void SetTileYellow(int x, int y)
    {
        YellowTiles[x, y].SetActive(true);
    }

    public void SetTileRed(int x, int y)
    {
        RedTiles[x, y].SetActive(true);
    }

    public void SetTilePurple(int x, int y)
    {
        PurpleTiles[x, y].SetActive(true);
    }

    public void SetTileCheck(int x, int y)
    {
        CheckTiles[x, y].SetActive(true);
    }

    public void HighlightPossibleMoves(bool[,] allowedMoves, bool White)
    {
        for(int i=0; i<8; i++)
        {
            for(int j=0; j<8; j++)
            {
                if(allowedMoves[i,j])
                {

                    if(BoardManager.Instance.Chessplayers[i,j] != null && BoardManager.Instance.Chessplayers[i, j].isWhite != White)
                    {
                        SetTileRed(i, j);
                    }
                    else
                    {

                        if (BoardManager.Instance.EnPassant[0] == i && BoardManager.Instance.EnPassant[1] == j 
                            && BoardManager.Instance.SelectedChessplayer.GetType() == typeof(Pawn))
                            SetTilePurple(i, j);

                        else if (BoardManager.Instance.SelectedChessplayer.GetType() == typeof(King) 
                            && System.Math.Abs(i - BoardManager.Instance.SelectedChessplayer.currentX) == 2)
                            SetTilePurple(i, j);

                        else
                            SetTileBlue(i, j);
                    }
                }
            }
        }
    }

    public void HighlightCheckmate(bool isWhiteTurn)
    {
        ChessPlayer king;
        if(isWhiteTurn)
            king = BoardManager.Instance.WhiteKing;
        else
            king = BoardManager.Instance.BlackKing;

        int x = king.currentX;
        int y = king.currentY;


        HighlightCheckers(x , y, king);

        HighlightCheckers(x , y - 1, king);

        HighlightCheckers(x - 1, y , king);

        HighlightCheckers(x + 1, y , king);

        HighlightCheckers(x , y + 1, king);

        HighlightCheckers(x - 1, y - 1, king);

        HighlightCheckers(x + 1, y - 1, king);

        HighlightCheckers(x - 1, y + 1, king);

        HighlightCheckers(x + 1, y + 1, king);
    }

    private void HighlightCheckers(int x, int y, ChessPlayer king)
    {
        ChessPlayer[,] Chessmans = BoardManager.Instance.Chessplayers;
        ChessPlayer piece = null;

        if(!(x >= 0 && x <= 7 && y >= 0 && y <= 7))
            return;

        int X = x;
        int Y = y;

        if(y - 1 >= 0)
        {
            piece = BoardManager.Instance.Chessplayers[x, y - 1];

            if(piece != null && piece.isWhite != king.isWhite &&  piece.GetType() == typeof(King))
            {
                SetTileRed(x, y - 1);
                return;
            }
        }
        while (y-- > 0)
        {
            piece = BoardManager.Instance.Chessplayers[x, y];

            if (piece == null)
                continue;
            
            else if (piece.isWhite == king.isWhite)
                break;

            if(piece.GetType() == typeof(Tower) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Rook/Queen Down");
                SetTileRed(x, y);
                return;
            }

            break;
        }

        x = X;
        y = Y;

        if(x + 1 <= 7)
        {
            piece = BoardManager.Instance.Chessplayers[x + 1, y];

            if(piece != null && piece.isWhite != king.isWhite &&  piece.GetType() == typeof(King))
            {
                SetTileRed(x + 1, y);
                return;
            }

        }
        while (x++ < 7)
        {
            piece = BoardManager.Instance.Chessplayers[x, y];

            if (piece == null)
                continue;
            

            else if (piece.isWhite == king.isWhite)
                break;


            if(piece.GetType() == typeof(Tower) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Rook/Queen Right");
                SetTileRed(x, y);
                return;
            }

            break;
        }

        x = X;
        y = Y;

        if(x - 1 >= 0)
        {
            piece = BoardManager.Instance.Chessplayers[x - 1, y];

            if(piece != null && piece.isWhite != king.isWhite &&  piece.GetType() == typeof(King))
            {
                SetTileRed(x - 1, y);
                return;
            }

        }
        while (x-- > 0)
        {
            piece = BoardManager.Instance.Chessplayers[x, y];

            if (piece == null)
                continue;
            

            else if (piece.isWhite == king.isWhite)
                break;

            if(piece.GetType() == typeof(Tower) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Rook/Queen Left");
                SetTileRed(x, y);
                return;
            }

            break;
        }

        x = X;
        y = Y;

        if(y + 1 <= 7)
        {
            piece = BoardManager.Instance.Chessplayers[x, y + 1];

            if(piece != null && piece.isWhite != king.isWhite &&  piece.GetType() == typeof(King))
            {
                SetTileRed(x, y + 1);
                return;
            }

        }
        while (y++ < 7)
        {
            piece = BoardManager.Instance.Chessplayers[x, y];

            if (piece == null)
                continue;
            

            else if (piece.isWhite == king.isWhite)
                break;

            if(piece.GetType() == typeof(Tower) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Rook/Queen Up");
                SetTileRed(x, y);
                return;
            }

            break;
        }

        x = X;
        y = Y;

        if(x + 1 <= 7 && y - 1 >= 0 && king.isWhite)
        {
            piece = BoardManager.Instance.Chessplayers[x + 1, y - 1];

            if(piece != null && piece.isWhite != king.isWhite && piece.GetType() == typeof(Pawn))
            {
                SetTileRed(x + 1, y - 1);
                return;
            }

        }
        if(x + 1 <= 7 && y - 1 >= 0)
        {
            piece = BoardManager.Instance.Chessplayers[x + 1, y - 1];

            if(piece != null && piece.isWhite != king.isWhite &&  piece.GetType() == typeof(King))
            {
                SetTileRed(x + 1, y - 1);
                return;
            }

        }
        while (x++ < 7 && y-- > 0)
        {
            piece = BoardManager.Instance.Chessplayers[x, y];

            if (piece == null)
                continue;

            else if (piece.isWhite == king.isWhite)
                break;

            if(piece.GetType() == typeof(Bishup) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Bishup/Queen LR Down");
                SetTileRed(x, y);
                return;
            }

            break;
        }

        x = X;
        y = Y;

        if(x + 1 <= 7 && y + 1 <= 7 && !king.isWhite)
        {
            piece = BoardManager.Instance.Chessplayers[x + 1, y + 1];

            if(piece != null && piece.isWhite != king.isWhite && piece.GetType() == typeof(Pawn))
            {
                SetTileRed(x + 1, y + 1);
                return;
            }

        }
        if(x + 1 <= 7 && y + 1 <= 7)
        {
            piece = BoardManager.Instance.Chessplayers[x + 1, y + 1];

            if(piece != null && piece.isWhite != king.isWhite &&  piece.GetType() == typeof(King))
            {
                SetTileRed(x + 1, y + 1);
                return;
            }

        }
        while (x++ < 7 && y++ < 7)
        {
            piece = BoardManager.Instance.Chessplayers[x, y];

            if (piece == null)
                continue;

            else if (piece.isWhite == king.isWhite)
                break;

            if(piece.GetType() == typeof(Bishup) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Bishup/Queen LR Up");
                SetTileRed(x, y);
                return;
            }

            break;
        }

        x = X;
        y = Y;

        if(x - 1 >= 0 && y - 1 >= 0 && king.isWhite)
        {
            piece = BoardManager.Instance.Chessplayers[x - 1, y - 1];

            if(piece != null && piece.isWhite != king.isWhite && piece.GetType() == typeof(Pawn))
            {
                SetTileRed(x - 1, y - 1);
                return;
            }

        }
        if(x - 1 >= 0 && y - 1 >= 0)
        {
            piece = BoardManager.Instance.Chessplayers[x - 1, y - 1];

            if(piece != null && piece.isWhite != king.isWhite &&  piece.GetType() == typeof(King))
            {
                SetTileRed(x - 1, y - 1);
                return;
            }

        }
        while (x-- > 0 && y-- > 0)
        {
            piece = BoardManager.Instance.Chessplayers[x, y];

            if (piece == null)
                continue;

            else if (piece.isWhite == king.isWhite)
                break;

            if(piece.GetType() == typeof(Bishup) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Bishup/Queen RL Down");
                SetTileRed(x, y);
                return;
            }

            break;
        }

        x = X;
        y = Y;

        if(x - 1 >= 0 && y + 1 <= 7 && !king.isWhite)
        {
            piece = BoardManager.Instance.Chessplayers[x - 1, y + 1];

            if(piece != null && piece.isWhite != king.isWhite && piece.GetType() == typeof(Pawn))
            {
                SetTileRed(x - 1, y + 1);
                return;
            }

        }
        if(x - 1 >= 0 && y + 1 <= 7)
        {
            piece = BoardManager.Instance.Chessplayers[x - 1, y + 1];

            if(piece != null && piece.isWhite != king.isWhite &&  piece.GetType() == typeof(King))
            {
                SetTileRed(x - 1, y + 1);
                return;
            }

        }
        while (x-- > 0 && y++ < 7)
        {
            piece = BoardManager.Instance.Chessplayers[x, y];

            if (piece == null)
                continue;
            
            else if (piece.isWhite == king.isWhite)
                break;


            if(piece.GetType() == typeof(Bishup) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Bishup/Queen RL Up");
                SetTileRed(x, y);
                return;
            }

            break;
        }

        x = X;
        y = Y;

        if(king.KnightThreat(x - 1, y - 2))
        {
            SetTileRed(x - 1, y - 2);
            return;
        }

        if(king.KnightThreat(x + 1, y - 2))
        {
            SetTileRed(x + 1, y - 2);
            return;
        }


        if(king.KnightThreat(x + 2, y - 1))
        {
            SetTileRed(x + 2, y - 1);
            return;
        }

        if(king.KnightThreat(x + 2, y + 1))
        {
            SetTileRed(x + 2, y + 1);
            return;
        }

        if(king.KnightThreat(x - 2, y - 1))
        {
            SetTileRed(x - 2, y - 1);
            return;
        }


        if(king.KnightThreat(x - 2, y + 1))
        {
            SetTileRed(x - 2, y + 1);
            return;
        }


        if(king.KnightThreat(x - 1, y + 2))
        {
            SetTileRed(x - 1, y + 2);
            return;
        }


        if(king.KnightThreat(x + 1, y + 2))
        {
            SetTileRed(x + 1, y + 2);
            return;
        }
    }
}
