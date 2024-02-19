using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance { set; get; }

    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFFSET = TILE_SIZE / 2;

    private Camera cam;

    public List<GameObject> ChessPlayerPrefabs;
    private List<GameObject> ActiveChessplayers;
    public ChessPlayer[,] Chessplayers { set; get; }

    public ChessPlayer SelectedChessplayer;

    public ChessPlayer WhiteKing;
    public ChessPlayer BlackKing;
    public ChessPlayer WhiteTower1;
    public ChessPlayer WhiteTower2;
    public ChessPlayer BlackTower1;
    public ChessPlayer BlackTower2;


    public bool[,] allowedMoves;

    public int[] EnPassant { set; get; }


    private int selectionX = -1;
    private int selectionY = -1;


    public bool isWhiteTurn = true;

    private void Start()
    {
        Instance = this;
        cam = FindObjectOfType<Camera>();
        ActiveChessplayers = new List<GameObject>();
        Chessplayers = new ChessPlayer[8, 8];
        EnPassant = new int[2] { -1, -1 };


        SpawnAllChessmans();
    }

    private void Update()
    {
        UpdateSelection();

        DrawChessBoard();

        if (Input.GetMouseButtonDown(0) && isWhiteTurn)
        {
            if (selectionX >= 0 && selectionY >= 0 && selectionX <= 7 && selectionY <= 7)
            {

                if (SelectedChessplayer == null)
                {
                    SelectChessman();
                }

                else
                {
                    MoveChessman(selectionX, selectionY);
                }
            }
        }

        else if (!isWhiteTurn)
        {

            ChessAI.Instance.NPCMove();
        }

    }

    private void SelectChessman()
    {

        if (Chessplayers[selectionX, selectionY] == null) return;

        if (Chessplayers[selectionX, selectionY].isWhite != isWhiteTurn) return;

        SelectedChessplayer = Chessplayers[selectionX, selectionY];
        BoardHighlights.Instance.SetTileYellow(selectionX, selectionY);

        allowedMoves = SelectedChessplayer.PossibleMoves();
        BoardHighlights.Instance.HighlightPossibleMoves(allowedMoves, isWhiteTurn);
    }

    public void MoveChessman(int x, int y)
    {
        if (allowedMoves[x, y])
        {
            ChessPlayer opponent = Chessplayers[x, y];

            if (opponent != null)
            {
                ActiveChessplayers.Remove(opponent.gameObject);
                Destroy(opponent.gameObject);

            }

            if (EnPassant[0] == x && EnPassant[1] == y && SelectedChessplayer.GetType() == typeof(Pawn))
            {
                if (isWhiteTurn)
                    opponent = Chessplayers[x, y + 1];
                else
                    opponent = Chessplayers[x, y - 1];

                ActiveChessplayers.Remove(opponent.gameObject);
                Destroy(opponent.gameObject);

            }

            EnPassant[0] = EnPassant[1] = -1;


            if (SelectedChessplayer.GetType() == typeof(Pawn))
            {

                if (y == 7)
                {
                    ActiveChessplayers.Remove(SelectedChessplayer.gameObject);
                    Destroy(SelectedChessplayer.gameObject);
                    SpawnChessman(10, new Vector3(x, 0, y));
                    SelectedChessplayer = Chessplayers[x, y];
                }
                if (y == 0)
                {
                    ActiveChessplayers.Remove(SelectedChessplayer.gameObject);
                    Destroy(SelectedChessplayer.gameObject);
                    SpawnChessman(4, new Vector3(x, 0, y));
                    SelectedChessplayer = Chessplayers[x, y];
                }

                if (SelectedChessplayer.currentY == 1 && y == 3)
                {
                    EnPassant[0] = x;
                    EnPassant[1] = y - 1;
                }
                if (SelectedChessplayer.currentY == 6 && y == 4)
                {
                    EnPassant[0] = x;
                    EnPassant[1] = y + 1;
                }
            }

            if (SelectedChessplayer.GetType() == typeof(King) && System.Math.Abs(x - SelectedChessplayer.currentX) == 2)
            {
                if (x - SelectedChessplayer.currentX < 0)
                {
                    Chessplayers[x + 1, y] = Chessplayers[x - 1, y];
                    Chessplayers[x - 1, y] = null;
                    Chessplayers[x + 1, y].SetPosition(x + 1, y);
                    Chessplayers[x + 1, y].transform.position = new Vector3(x + 1, 0, y);
                    Chessplayers[x + 1, y].isMoved = true;
                }
                else
                {
                    Chessplayers[x - 1, y] = Chessplayers[x + 2, y];
                    Chessplayers[x + 2, y] = null;
                    Chessplayers[x - 1, y].SetPosition(x - 1, y);
                    Chessplayers[x - 1, y].transform.position = new Vector3(x - 1, 0, y);
                    Chessplayers[x - 1, y].isMoved = true;
                }

            }


            Chessplayers[SelectedChessplayer.currentX, SelectedChessplayer.currentY] = null;
            Chessplayers[x, y] = SelectedChessplayer;
            SelectedChessplayer.SetPosition(x, y);
            SelectedChessplayer.transform.position = new Vector3(x, 0, y);
            SelectedChessplayer.isMoved = true;
            isWhiteTurn = !isWhiteTurn;

        }

        SelectedChessplayer = null;

        BoardHighlights.Instance.DisableAllHighlights();


        if (isWhiteTurn)
        {
            if (WhiteKing.InDanger())
                BoardHighlights.Instance.SetTileCheck(WhiteKing.currentX, WhiteKing.currentY);
        }

        else
        {
            if (BlackKing.InDanger())
                BoardHighlights.Instance.SetTileCheck(BlackKing.currentX, BlackKing.currentY);
        }

        isCheckmate();
    }

    private void UpdateSelection()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 25.0f, LayerMask.GetMask("ChessPlane")))
        {
            selectionX = (int)(hit.point.x + 0.5f);
            selectionY = (int)(hit.point.z + 0.5f);
        }
        else
        {
            selectionX = -1;
            selectionY = -1;
        }
    }

    private void DrawChessBoard()
    {
        Vector3 widthLine = Vector3.right * 8;
        Vector3 heightLine = Vector3.forward * 8;
        Vector3 offset = new Vector3(0.5f, 0f, 0.5f);
        for (int i = 0; i <= 8; i++)
        {
            Vector3 start = Vector3.forward * i - offset;
            Debug.DrawLine(start, start + widthLine);
            for (int j = 0; j <= 8; j++)
            {
                start = Vector3.right * i - offset;
                Debug.DrawLine(start, start + heightLine);
            }
        }


        // Draw Selection
        if (selectionX >= 0 && selectionY >= 0 && selectionX <= 7 && selectionY <= 7)
        {
            Debug.DrawLine(
                Vector3.forward * selectionY + Vector3.right * selectionX - offset,
                Vector3.forward * (selectionY + 1) + Vector3.right * (selectionX + 1) - offset
                );
            Debug.DrawLine(
                Vector3.forward * (selectionY + 1) + Vector3.right * selectionX - offset,
                Vector3.forward * selectionY + Vector3.right * (selectionX + 1) - offset
                );
        }
    }

    private void SpawnChessman(int index, Vector3 position)
    {
        GameObject ChessmanObject = Instantiate(ChessPlayerPrefabs[index], position, ChessPlayerPrefabs[index].transform.rotation) as GameObject;
        ChessmanObject.transform.SetParent(this.transform);
        ActiveChessplayers.Add(ChessmanObject);

        int x = (int)(position.x);
        int y = (int)(position.z);
        Chessplayers[x, y] = ChessmanObject.GetComponent<ChessPlayer>();
        Chessplayers[x, y].SetPosition(x, y);

    }

    private void SpawnAllChessmans()
    {

        SpawnChessman(0, new Vector3(0, 0, 7));

        SpawnChessman(1, new Vector3(1, 0, 7));

        SpawnChessman(2, new Vector3(2, 0, 7));

        SpawnChessman(3, new Vector3(3, 0, 7));

        SpawnChessman(4, new Vector3(4, 0, 7));
 
        SpawnChessman(2, new Vector3(5, 0, 7));
   
        SpawnChessman(1, new Vector3(6, 0, 7));
 
        SpawnChessman(0, new Vector3(7, 0, 7));
   
        for (int i = 0; i < 8; i++)
        {
            SpawnChessman(5, new Vector3(i, 0, 6));
        }

        SpawnChessman(6, new Vector3(0, 0, 0));

        SpawnChessman(7, new Vector3(1, 0, 0));
 
        SpawnChessman(8, new Vector3(2, 0, 0));

        SpawnChessman(9, new Vector3(3, 0, 0));

        SpawnChessman(10, new Vector3(4, 0, 0));

        SpawnChessman(8, new Vector3(5, 0, 0));

        SpawnChessman(7, new Vector3(6, 0, 0));

        SpawnChessman(6, new Vector3(7, 0, 0));

        for (int i = 0; i < 8; i++)
        {
            SpawnChessman(11, new Vector3(i, 0, 1));
        }

        WhiteKing = Chessplayers[3, 7];
        BlackKing = Chessplayers[3, 0];

        WhiteTower1 = Chessplayers[0, 7];
        WhiteTower2 = Chessplayers[7, 7];
        BlackTower1 = Chessplayers[0, 0];
        BlackTower2 = Chessplayers[7, 0];
    }

    public void EndGame()
    {
        if (!isWhiteTurn)
            Debug.Log("White team wins");
        else
            Debug.Log("Black team wins");

        foreach (GameObject go in ActiveChessplayers)
            Destroy(go);

        isWhiteTurn = true;
        BoardHighlights.Instance.DisableAllHighlights();
        SpawnAllChessmans();
    }

    private void isCheckmate()
    {
        bool hasAllowedMove = false;
        foreach (GameObject chessman in ActiveChessplayers)
        {
            if (chessman.GetComponent<ChessPlayer>().isWhite != isWhiteTurn)
                continue;

            bool[,] allowedMoves = chessman.GetComponent<ChessPlayer>().PossibleMoves();

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (allowedMoves[x, y])
                    {
                        hasAllowedMove = true;
                        break;
                    }
                }
                if (hasAllowedMove) break;
            }
        }

        if (!hasAllowedMove)
        {
            BoardHighlights.Instance.HighlightCheckmate(isWhiteTurn);

            Debug.Log("CheckMate");

            Debug.Log("Average Response Time of computer (in seconds): " + (ChessAI.Instance.averageResponseTime / 1000.0));

            // Display Game Over Menu
            GameOver.Instance.GameOverMenu();

            // EndGame();
        }
    }
}