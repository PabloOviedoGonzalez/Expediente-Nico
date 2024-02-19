using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : ChessPlayer
{
    // Constructor de la clase Tower
    public Tower()
    {
        value = 50; // Establece el valor de la torre en 50
    }

    // Sobrescribe el método PossibleMoves de la clase base Chessman
    public override bool[,] PossibleMoves()
    {
        bool[,] moves = new bool[8, 8]; // Matriz que representa los movimientos posibles
        int x = currentX; // Posición X actual de la torre
        int y = currentY; // Posición Y actual de la torre

        // Bucle para explorar movimientos hacia abajo
        while (y-- > 0)
        {
            if (!TowerMove(x, y, ref moves))
                break;
        }

        x = currentX;
        y = currentY;
        // Bucle para explorar movimientos hacia la derecha
        while (x++ < 7)
        {
            if (!TowerMove(x, y, ref moves))
                break;
        }

        x = currentX;
        y = currentY;
        // Bucle para explorar movimientos hacia la izquierda
        while (x-- > 0)
        {
            if (!TowerMove(x, y, ref moves))
                break;
        }

        x = currentX;
        y = currentY;
        // Bucle para explorar movimientos hacia arriba
        while (y++ < 7)
        {
            if (!TowerMove(x, y, ref moves))
                break;
        }

        return moves; // Devuelve la matriz de movimientos posibles
    }

    // Método privado que verifica y registra los movimientos de la torre
    private bool TowerMove(int x, int y, ref bool[,] moves)
    {
        ChessPlayer piece = BoardManager.Instance.Chessplayers[x, y]; // Obtiene la pieza en la posición (x, y)

        // Si la celda está vacía
        if (piece == null)
        {
            // Verifica si el movimiento no pone al rey en peligro y marca la posición como posible movimiento
            if (!this.KingInDanger(x, y))
                moves[x, y] = true;

            return true; // Continúa el bucle
        }
        // Si la pieza es del equipo oponente
        else if (piece.isWhite != isWhite)
        {
            // Verifica si el movimiento no pone al rey en peligro y marca la posición como posible movimiento
            if (!this.KingInDanger(x, y))
                moves[x, y] = true;
        }

        // Si la pieza es del mismo equipo, no hace nada
        return false; // Detiene el bucle
    }
}
