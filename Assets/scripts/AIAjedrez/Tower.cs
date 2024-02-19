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

    // Sobrescribe el m�todo PossibleMoves de la clase base Chessman
    public override bool[,] PossibleMoves()
    {
        bool[,] moves = new bool[8, 8]; // Matriz que representa los movimientos posibles
        int x = currentX; // Posici�n X actual de la torre
        int y = currentY; // Posici�n Y actual de la torre

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

    // M�todo privado que verifica y registra los movimientos de la torre
    private bool TowerMove(int x, int y, ref bool[,] moves)
    {
        ChessPlayer piece = BoardManager.Instance.Chessplayers[x, y]; // Obtiene la pieza en la posici�n (x, y)

        // Si la celda est� vac�a
        if (piece == null)
        {
            // Verifica si el movimiento no pone al rey en peligro y marca la posici�n como posible movimiento
            if (!this.KingInDanger(x, y))
                moves[x, y] = true;

            return true; // Contin�a el bucle
        }
        // Si la pieza es del equipo oponente
        else if (piece.isWhite != isWhite)
        {
            // Verifica si el movimiento no pone al rey en peligro y marca la posici�n como posible movimiento
            if (!this.KingInDanger(x, y))
                moves[x, y] = true;
        }

        // Si la pieza es del mismo equipo, no hace nada
        return false; // Detiene el bucle
    }
}
