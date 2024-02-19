using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
   
    public (ChessPlayer chessplayer, (int x, int y) oldPosition, (int x, int y) newPosition, bool isMoved) movedChessplayer;
    public (ChessPlayer chessplayer, (int x, int y) Position) capturedChessplayer;
    public (int x, int y) EnPassantStatus;
    public (bool wasPromotion, ChessPlayer promotedChessplayer) PromotionMove;
    public (bool wasCastling, bool isKingSide) CastlingMove;
    public int depth;

    public void SetState((ChessPlayer chessplayer, (int x, int y) oldPosition, (int x, int y) newPosition, bool isMoved) movedChessplayer,
                          (ChessPlayer chessman, (int x, int y) Position) capturedChessplayer,
                          (int x, int y) EnPassantStatus,
                          (bool wasPromotion, ChessPlayer promotedChessman) PromotionMove,
                          (bool wasCastling, bool isKingSide) CastlingMove,
                          int depth)
    {
        this.movedChessplayer = movedChessplayer;
        this.capturedChessplayer = capturedChessplayer;
        this.EnPassantStatus = EnPassantStatus;
        this.PromotionMove = PromotionMove;
        this.CastlingMove = CastlingMove;
        this.depth = depth;
    }
}
