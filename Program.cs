bool isItXTurn = true;
int[] boardArray = new int[9];
int positionToUpdate = 0;
Start();

void Start()
{
    // Clears the board array values
    for (int i = 0; i < boardArray.Length; i++)
    {
        boardArray[i] = 0;
    }
    isItXTurn = true ;
    Play();
}

void Play()
{
    Console.Clear();
    UpdateBoard(positionToUpdate);
    PlayerTurn();
    CheckForWin();
}

void IsBoardFull()
{
    bool isBoardFull = true;
    for (int i = 0; i < boardArray.Length; i++)
    {
        if (boardArray[i] == 0) { isBoardFull = false; }
    }
    if (isBoardFull)
    {
        GameOver("tie");
    }
}

void PlayerTurn()
{
    if (isItXTurn)
    {
        Console.WriteLine("Player X's Turn");
    } else if (!isItXTurn)
    {
        Console.WriteLine("Player O's Turn");
    }
    // Get just the number from ReadKey, removing "NumPad" text
    try
    {
        string key = Console.ReadKey().Key.ToString().Substring(6);
        positionToUpdate = Int32.Parse(key);
    } catch
    {
        //throw new Exception();
        //throw new NotImplementedException();
    }
    try
    {
        if (isItXTurn && boardArray[positionToUpdate - 1] == 0)
        {
            boardArray[positionToUpdate - 1] = 1;
        }
        else if (!isItXTurn && boardArray[positionToUpdate - 1] == 0)
        {
            boardArray[positionToUpdate - 1] = 2;
        }

        // Prevent using a turn if an invalid placement is attempted
        else
        {
            isItXTurn = !isItXTurn;
        }
    }
    catch { Console.WriteLine("ERROR"); }
    isItXTurn = !isItXTurn;
}
void UpdateBoard(int position)
{
    
    Console.WriteLine("{6}|{7}|{8}\n" +
              "-+-+-+\n" +
              "{3}|{4}|{5}\n" +
              "-+-+-+\n" +
              "{0}|{1}|{2}", GetChar(boardArray[0]), GetChar(boardArray[1]), GetChar(boardArray[2]), GetChar(boardArray[3]), GetChar(boardArray[4]), GetChar(boardArray[5]), GetChar(boardArray[6]), GetChar(boardArray[7]), GetChar(boardArray[8]));

}
void CheckForWin()
{

    // Horizontal
    if (boardArray[0] == boardArray[1] && boardArray[0] == boardArray[2] && boardArray[0] != 0)
    {
        GameOver(GetChar(boardArray[0]));
    }
    else if (boardArray[3] == boardArray[4] && boardArray[3] == boardArray[5] && boardArray[3] != 0)
    {
        GameOver(GetChar(boardArray[0]));
    }
    else if (boardArray[6] == boardArray[7]&& boardArray[6] == boardArray[8] && boardArray[6] != 0)
    {
        GameOver(GetChar(boardArray[6]));
    }

    // Diagonal
    else if (boardArray[6] == boardArray[4] && boardArray[6] == boardArray[2] && boardArray[6] != 0)
    {
        GameOver(GetChar(boardArray[6]));
    }
    else if (boardArray[0] == boardArray[4] && boardArray[0] == boardArray[8] && boardArray[0] != 0)
    {
        GameOver(GetChar(boardArray[0]));
    }

    // Vertical
    else if (boardArray[6] == boardArray[3] && boardArray[6] == boardArray[0] && boardArray[6] != 0)
    {
        GameOver(GetChar(boardArray[6]));
    }
    else if (boardArray[7] == boardArray[4] && boardArray[7] == boardArray[1] && boardArray[7] != 0)
    {
        GameOver(GetChar(boardArray[7]));
    }
    else if (boardArray[8] == boardArray[5] && boardArray[8] == boardArray[2] && boardArray[8] != 0)
    {
        GameOver(GetChar(boardArray[8]));
    }
    else { IsBoardFull(); }
    Play();
    Console.WriteLine(".");
}
void GameOver(string winner)
{
    if(winner == "tie")
    {
        Console.WriteLine("\n\nIt's a tie!\n\nPress Any Key To Play Again\n\n", winner);
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("\n\nThe winner is Player {0}!!!\n\nPress Any Key To Play Again\n\n", winner);
        Console.ReadKey();
    }

    Start();

}
string GetChar(int i)
{
    if (i == 0)
    {
        return " ";
    }
    else if (i == 1)
    {
        return "x";
    }else if(i == 2)
    {
        return "o";
    }
    else { throw new NotImplementedException(); }
}