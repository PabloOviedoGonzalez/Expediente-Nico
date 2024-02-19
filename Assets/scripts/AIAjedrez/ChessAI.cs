using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessAI : MonoBehaviour
{
    public static ChessAI Instance { set; get; }

    private List<ChessPlayer> ActiveChessplayers;
    private ChessPlayer[,] Chessplayers;
    private int[] EnPassant;

    private ChessPlayer[,] ActualChessplayersReference;
    private ChessPlayer ActualWhiteKing;
    private ChessPlayer ActualBlackKing;
    private ChessPlayer ActualWhiteTower1;
    private ChessPlayer ActualWhiteTower2;
    private ChessPlayer ActualBlackTower1;
    private ChessPlayer ActualBlackTower2;
    private int[] ActualEnPassant;

    private Stack< State> History;

    private int maxDepth;

    private ChessPlayer NPCSelectedChessplayer = null;
    private int moveX = -1;
    private int moveY = -1;
    private int winningValue = 0;

    private long totalTime = 0;
    private long totalRun = 0;
    public  long averageResponseTime = 0;

    string detail, board;

    private void Start()
    {
        Instance = this;
    }

    public void NPCMove()
    {
        System.Diagnostics.Stopwatch stopwatch  = new System.Diagnostics.Stopwatch();
        stopwatch.Start();

        History = new Stack< State>();
        
        ActualChessplayersReference = BoardManager.Instance.Chessplayers;
        ActualWhiteKing = BoardManager.Instance.WhiteKing;
        ActualBlackKing = BoardManager.Instance.BlackKing;
        ActualWhiteTower1 = BoardManager.Instance.WhiteTower1;
        ActualWhiteTower2 = BoardManager.Instance.WhiteTower2;
        ActualBlackTower1 = BoardManager.Instance.BlackTower1;
        ActualBlackTower2 = BoardManager.Instance.BlackTower2;
        ActualEnPassant = BoardManager.Instance.EnPassant;

        ActiveChessplayers = new List<ChessPlayer>();
        Chessplayers = new ChessPlayer[8, 8];

        for(int x=0; x<8; x++)
            for(int y=0; y<8; y++)
            {
                if(ActualChessplayersReference[x, y] != null)
                {
                    ChessPlayer currChessplayer = ActualChessplayersReference[x, y].Clone();
                    ActiveChessplayers.Add(currChessplayer);
                    Chessplayers[x, y] = currChessplayer;
                }
                else
                {
                    Chessplayers[x, y] = null;
                }
            }

        Shuffle(ActiveChessplayers);

        EnPassant = new int[2]{ActualEnPassant[0], ActualEnPassant[0]};
        
        BoardManager.Instance.Chessplayers = Chessplayers;
        BoardManager.Instance.WhiteKing = Chessplayers[ActualWhiteKing.currentX, ActualWhiteKing.currentY];
        BoardManager.Instance.BlackKing = Chessplayers[ActualBlackKing.currentX, ActualBlackKing.currentY];
        if(ActualWhiteTower1 != null) BoardManager.Instance.WhiteTower1 = Chessplayers[ActualWhiteTower1.currentX, ActualWhiteTower1.currentY];
        if(ActualWhiteTower2 != null) BoardManager.Instance.WhiteTower2 = Chessplayers[ActualWhiteTower2.currentX, ActualWhiteTower2.currentY];
        if(ActualBlackTower1 != null) BoardManager.Instance.BlackTower1 = Chessplayers[ActualBlackTower1.currentX, ActualBlackTower1.currentY];
        if(ActualBlackTower2 != null) BoardManager.Instance.BlackTower2 = Chessplayers[ActualBlackTower2.currentX, ActualBlackTower2.currentY];
        BoardManager.Instance.EnPassant = EnPassant;

        Think();

        BoardManager.Instance.Chessplayers = ActualChessplayersReference;
        BoardManager.Instance.WhiteKing = ActualWhiteKing;
        BoardManager.Instance.BlackKing = ActualBlackKing;
        BoardManager.Instance.WhiteTower1 = ActualWhiteTower1;
        BoardManager.Instance.WhiteTower2 = ActualWhiteTower2;
        BoardManager.Instance.BlackTower1 = ActualBlackTower1;
        BoardManager.Instance.BlackTower2 = ActualBlackTower2;
        BoardManager.Instance.EnPassant = ActualEnPassant;


        Debug.Log(NPCSelectedChessplayer.GetType() + " to (" + moveX + ", " + moveY + ") " + winningValue + "\n"); // remove this line
        BoardManager.Instance.SelectedChessplayer = BoardManager.Instance.Chessplayers[NPCSelectedChessplayer.currentX, NPCSelectedChessplayer.currentY];
        BoardManager.Instance.allowedMoves = BoardManager.Instance.SelectedChessplayer.PossibleMoves();

        BoardManager.Instance.MoveChessman(moveX, moveY);

        stopwatch.Stop();
        totalTime += stopwatch.ElapsedMilliseconds;
        totalRun++;

        averageResponseTime = totalTime / totalRun;
    }

    private void Think()
    {
        maxDepth = 5;
        int depth = maxDepth-1;
        winningValue = AlphaBeta(depth, true, System.Int32.MinValue, System.Int32.MaxValue);
    }

    private int MiniMax(int depth, bool isMax)
    {
        if(depth == 0 || isGameOver())
        {
            int value = StaticEvaluationFunction();
            
            return value;
        }


        if(isMax)
        {
            int hValue = System.Int32.MinValue;

            foreach(ChessPlayer chessplayer in ActiveChessplayers.ToArray())
            {
                
                if(chessplayer.isWhite) continue;

                bool[,] allowedMoves = chessplayer.PossibleMoves();

                for(int x=0; x<8; x++)
                {
                    for(int y=0; y<8; y++)
                    {
                        if(allowedMoves[x, y])
                        {
                            Move(chessplayer, x, y, depth);

                            int thisMoveValue = MiniMax(depth-1, !isMax);

                            if(hValue < thisMoveValue) 
                            {
                                hValue = thisMoveValue;

                                if(depth == maxDepth-1)
                                {
                                    NPCSelectedChessplayer = chessplayer;
                                    moveX = x;
                                    moveY = y;
                                }
                            }

                            Undo(depth);
                        }
                    }
                }
            }


            return hValue;
        }
        else
        {
            int hValue = System.Int32.MaxValue;

            foreach(ChessPlayer chessplayer in ActiveChessplayers.ToArray())
            {

                if(!chessplayer.isWhite) continue;

                bool[,] allowedMoves = chessplayer.PossibleMoves();


                for(int x=0; x<8; x++)
                {
                    for(int y=0; y<8; y++)
                    {
                        if(allowedMoves[x, y])
                        {
                            Move(chessplayer, x, y, depth);

                            int thisMoveValue = MiniMax(depth-1, !isMax);

                            if(hValue > thisMoveValue) 
                            {
                                hValue = thisMoveValue;
                            }

                            Undo(depth);
                        }
                    }
                }
            }


            return hValue;
        }
    }

    private int AlphaBeta(int depth, bool isMax, int alpha, int beta)
    {
        if(depth == 0 || isGameOver())
        {
            int value = StaticEvaluationFunction();
            
            return value;
        }

        if(isMax)
        {
            int hValue = System.Int32.MinValue;
            
            foreach(ChessPlayer chessplayer in ActiveChessplayers.ToArray())
            {

                if(chessplayer.isWhite) continue;

                bool[,] allowedMoves = chessplayer.PossibleMoves();

                for(int x=0; x<8; x++)
                {
                    for(int y=0; y<8; y++)
                    {
                        if(allowedMoves[x, y])
                        {
                            Move(chessplayer, x, y, depth);

                            int thisMoveValue = AlphaBeta(depth-1, !isMax, alpha, beta);

                            Undo(depth);

                            if(hValue < thisMoveValue) 
                            {
                                hValue = thisMoveValue;

                                if(depth == maxDepth-1)
                                {
                                    NPCSelectedChessplayer = chessplayer;
                                    moveX = x;
                                    moveY = y;
                                }
                            }

                            if(hValue > alpha) 
                                alpha = hValue;

                            if(beta <= alpha)
                                break;
                        }
                    }

                    if(beta <= alpha)
                        break;
                }

                if(beta <= alpha)
                    break;
            }

            return hValue;
        }
        else
        {
            int hValue = System.Int32.MaxValue;

            foreach(ChessPlayer chessplayer in ActiveChessplayers.ToArray())
            {

                if(!chessplayer.isWhite) continue;

                bool[,] allowedMoves = chessplayer.PossibleMoves();

                for(int x=0; x<8; x++)
                {
                    for(int y=0; y<8; y++)
                    {
                        if(allowedMoves[x, y])
                        {
                            Move(chessplayer, x, y, depth);

                            int thisMoveValue = AlphaBeta(depth-1, !isMax, alpha, beta);

                            Undo(depth);

                            if(hValue > thisMoveValue) 
                            {
                                hValue = thisMoveValue;

                            }

                            if(hValue < beta) 
                                beta = hValue;

                            if(beta <= alpha)
                                break;
                        }
                    }

                    if(beta <= alpha)
                        break;
                }

                if(beta <= alpha)
                    break;
            }


            return hValue;
        }
    }

    private int StaticEvaluationFunction()
    {
        int TotalScore = 0;
        int curr = 0;
        foreach(ChessPlayer chessplayer in ActiveChessplayers)
        {
            if(chessplayer.GetType() == typeof(King))
                curr = 900;
            if(chessplayer.GetType() == typeof(Queen))
                curr = 90;
            if(chessplayer.GetType() == typeof(Tower))
                curr = 50;
            if(chessplayer.GetType() == typeof(Bishup))
                curr = 30;
            if(chessplayer.GetType() == typeof(Knight))
                curr = 30;
            if(chessplayer.GetType() == typeof(Pawn))
                curr = 10;

            if(chessplayer.isWhite)
                TotalScore -= curr;
            else
                TotalScore += curr;
        }
        return TotalScore;
    }

    private bool isGameOver()
    {
        int currScore = StaticEvaluationFunction();
        if((currScore < -290 ) || (currScore > 290))
            return true;
        return false;
    }

    private void Move(ChessPlayer chessplayer, int x, int y, int depth)
    {

        (ChessPlayer chessplayer, (int x, int y) oldPosition, (int x, int y) newPosition, bool isMoved) movedChessplayer;

        (ChessPlayer chessplayer, (int x, int y) Position) capturedChessplayer = (null, (-1, -1));

        (int x, int y) EnPassantStatus;

        (bool wasPromotion, ChessPlayer promotedChessplayer) PromotionMove = (false, null);

        (bool wasCastling, bool isKingSide) CastlingMove;

        movedChessplayer.chessplayer = chessplayer;
        movedChessplayer.oldPosition = (chessplayer.currentX, chessplayer.currentY);
        movedChessplayer.newPosition = (x, y);
        movedChessplayer.isMoved = chessplayer.isMoved;

        EnPassantStatus = (EnPassant[0], EnPassant[1]);

        // Capturing
        ChessPlayer opponent = Chessplayers[x, y];
        if(opponent != null)
        {
            capturedChessplayer.chessplayer = opponent;
            capturedChessplayer.Position = (x, y);

            Chessplayers[x, y] = null;
            ActiveChessplayers.Remove(opponent);
        }

        if (EnPassant[0] == x && EnPassant[1] == y && chessplayer.GetType() == typeof(Pawn))
        {           
            if(chessplayer.isWhite)
            {
                opponent = Chessplayers[x, y + 1];

                capturedChessplayer.chessplayer = opponent;
                capturedChessplayer.Position = (x, y + 1);
                Chessplayers[x, y + 1] = null;
            }
            else
            {
                opponent = Chessplayers[x, y - 1];

                capturedChessplayer.chessplayer = opponent;
                capturedChessplayer.Position = (x, y - 1);
                Chessplayers[x, y - 1] = null;
            }

            ActiveChessplayers.Remove(opponent);
        }

        EnPassant[0] = EnPassant[1] = -1;

        if(chessplayer.GetType() == typeof(Pawn))
        {
            if (y == 7 || y == 0)
            {
                ActiveChessplayers.Remove(chessplayer);
                Chessplayers[x, y] = gameObject.AddComponent<Queen>(); 
                Chessplayers[x, y].SetPosition(x, y);
                Chessplayers[x, y].isWhite = chessplayer.isWhite;
                chessplayer = Chessplayers[x, y];
                ActiveChessplayers.Add(chessplayer);

                PromotionMove = (true, chessplayer);
            }

            if (chessplayer.currentY == 1 && y == 3)
            {
                EnPassant[0] = x;
                EnPassant[1] = y - 1;
            }
            if (chessplayer.currentY == 6 && y == 4)
            {
                EnPassant[0] = x;
                EnPassant[1] = y + 1;
            }
        }

        CastlingMove = (false, false);

        if(chessplayer.GetType() == typeof(King) && System.Math.Abs(x - chessplayer.currentX) == 2)
        {          
            if(x - chessplayer.currentX < 0)
            {
                Chessplayers[x + 1, y] = Chessplayers[x - 1, y];
                Chessplayers[x - 1, y] = null;
                Chessplayers[x + 1, y].SetPosition(x + 1, y);
                Chessplayers[x + 1, y].isMoved = true;

                CastlingMove = (true, true);
            }
            else
            {
                Chessplayers[x - 1, y] = Chessplayers[x + 2, y];
                Chessplayers[x + 2, y] = null;
                Chessplayers[x - 1, y].SetPosition(x - 1, y);
                Chessplayers[x - 1, y].isMoved = true;

                CastlingMove = (true, false);
            }
        }

        Chessplayers[chessplayer.currentX, chessplayer.currentY] = null;
        Chessplayers[x, y] = chessplayer;
        chessplayer.SetPosition(x, y);
        chessplayer.isMoved = true;

        State currentState = new State();
        currentState.SetState(movedChessplayer, capturedChessplayer, EnPassantStatus, PromotionMove, CastlingMove, depth);
        History.Push(currentState);
    }

    private void Undo(int depth)
    {
        State currentState = History.Pop();

        if(depth != currentState.depth)
        {
            Debug.Log("Depth not matched!!!");
            return;
        }

        var movedChessman = currentState.movedChessplayer;
 
        var capturedChessman = currentState.capturedChessplayer;
 
        var EnPassantStatus = currentState.EnPassantStatus;

        var PromotionMove = currentState.PromotionMove;
 
        var CastlingMove = currentState.CastlingMove;

        EnPassant[0] = EnPassantStatus.x;
        EnPassant[1] = EnPassantStatus.y;

        ChessPlayer chessman = movedChessman.chessplayer;
        chessman.isMoved = movedChessman.isMoved;
        chessman.SetPosition(movedChessman.oldPosition.x, movedChessman.oldPosition.y);
        Chessplayers[movedChessman.oldPosition.x, movedChessman.oldPosition.y] = chessman;
        Chessplayers[movedChessman.newPosition.x, movedChessman.newPosition.y] = null;


        if(PromotionMove.wasPromotion)
        {
            ActiveChessplayers.Remove(PromotionMove.promotedChessplayer);
            ActiveChessplayers.Add(chessman);
        }

        var opponent = capturedChessman;
        if(opponent.chessplayer != null)
        {
            Chessplayers[opponent.Position.x, opponent.Position.y] = opponent.chessplayer;
            opponent.chessplayer.SetPosition(opponent.Position.x, opponent.Position.y);
            ActiveChessplayers.Add(opponent.chessplayer);
        }
        

        if(CastlingMove.wasCastling)
        {
            int x = movedChessman.newPosition.x;
            int y = movedChessman.newPosition.y;

            if(CastlingMove.isKingSide)
            {

                Chessplayers[x - 1, y] = Chessplayers[x + 1, y];
                Chessplayers[x + 1, y] = null;
                Chessplayers[x - 1, y].SetPosition(x - 1, y);
                Chessplayers[x - 1, y].isMoved = false;
            }

            else
            {

                Chessplayers[x + 2, y] = Chessplayers[x - 1, y];
                Chessplayers[x - 1, y] = null;
                Chessplayers[x + 2, y].SetPosition(x + 2, y);
                Chessplayers[x + 2, y].isMoved = false;
            }

        }
    }

    public void Shuffle(List<ChessPlayer> list)  
    {  
        System.Random rng = new System.Random();

        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);
            ChessPlayer value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }

}
