using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;

public class GameScript : MonoBehaviour
{
    public GameObject O, X;
    public enum Seed { EMPTY, X, O };
    public Seed turn;
    public Text instructions;
    public Text Win;
    public Text Catgame;
    public bool isGameOver = false;
    private Seed[] board = new[] {/*0*/ Seed.EMPTY, /*1*/ Seed.EMPTY, /*2*/ Seed.EMPTY, /*3*/ Seed.EMPTY, /*4*/ Seed.EMPTY, /*5*/ Seed.EMPTY, /*6*/ Seed.EMPTY, /*7*/ Seed.EMPTY, /*8*/ Seed.EMPTY };
    public int StartingCell;
    public static bool isEasy = false;
    public static bool isSinglePlayer = false;

    System.Random r = new System.Random();



    public void aimove()
    {
        List<int> possibleMoves = new List<int>();
        for (int i = 0; i < board.Length; i++)
        {
            if (board[i] == Seed.EMPTY)
            {
                possibleMoves.Add(i);
            }
        }
        int move = r.Next(0, possibleMoves.Count);
        OnHit[] slots = FindObjectsOfType<OnHit>();
        foreach (var slot in slots)
        {
            if (slot.Index == possibleMoves[move])
            {
                SpawnNew(slot);
                break;
            }
        }
}

    public void aimovemed()
    {
        List<int> possibleMoves = new List<int>();
        for (int i = 0; i < board.Length; i++)
        {
            if (board[i] == Seed.EMPTY)
            {
                possibleMoves.Add(i);
            }
        }
        int move = r.Next(0, possibleMoves.Count);
        OnHit[] slots = FindObjectsOfType<OnHit>();
        foreach (var slot in slots)
        {
            if (slot.Index == possibleMoves[move])
            {
                SpawnNew(slot);
                break;
            }
        }
    }

    private void awake()
    {
        instructions.text = "Turn " + turn.ToString();
    }

    public void DisplayWin()
    {
        if (checkwin())
        {
            if (turn == Seed.O)
            {
                Win.text = ("X Wins!");
            }
            else
            {
                Win.text = ("O Wins!");
            }
            isGameOver = true;
        }
        else if (CheckCat())
        {
            Win.text = "CAT Game!";
            isGameOver = true;
        }
    }

    public bool CheckCat()
    {
        for (int i = 0; i < board.Length; i++)
        {
            if (board[i] == Seed.EMPTY)
            {
                return false;
            }
        }

        return true;
    }

    public bool checkwin()
    {
        if (CheckHorozontal(0) || CheckHorozontal(3) || CheckHorozontal(6))
        {
            Debug.Log("Win Horizontally!");
            return true;
        }
        else if (CheckVerticle(0) || CheckVerticle(1) || CheckVerticle(2))
        {
            Debug.Log("Win Vertically!");
            return true;
        }
        else if (CheckDiagonal())
        {
            Debug.Log("Win Diagonally!");
            return true;
        }
        return false;
    }

   public bool CheckCloseWinDiagonal()
    {
        if (board[0] == Seed.O && board[4] == Seed.O || board[8] == Seed.O && board[4] == Seed.O)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
    
    //public bool CheckCloseWinHorozontal(int StartingCell)
    //{
    //    if (board[StartingCell]  )
    //}
    public bool CheckHorozontal(int StartingCell)
    {
        if (board[StartingCell] != Seed.EMPTY && board[StartingCell] == board[StartingCell + 1] && board[StartingCell + 1] == board[StartingCell + 2])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckDiagonal()
    {
        if (board[0] != Seed.EMPTY && board[0] == board[4] && board[0] == board[8])
        {
            return true;
        }
        else if (board[2] != Seed.EMPTY && board[2] == board[4] && board[2] == board[6])
        {
            return true;
        }

        return false;
    }

    public bool CheckVerticle(int StartingCell)
    {
        if (board[StartingCell] != Seed.EMPTY && board[StartingCell] == board[StartingCell + 3] && board[StartingCell + 6] == board[StartingCell + 3])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SpawnNew(OnHit slot)
    {
        if (isGameOver)
        {
            return;
        }

        board[slot.Index] = turn;
        if (turn == Seed.X)
        {
            Instantiate(X, slot.transform.position, Quaternion.identity);
            turn = Seed.O;
        }
        else if (turn == Seed.O)
        {
            Instantiate(O, slot.transform.position, Quaternion.identity);
            turn = Seed.X;
        }
        else
        {
        }
        Destroy(slot.gameObject);
        DisplayWin();
        instructions.text = "Turn " + turn.ToString();
        if (!isGameOver && turn == Seed.O && isSinglePlayer && isEasy)
        {
            aimove();
        }
    }


}
