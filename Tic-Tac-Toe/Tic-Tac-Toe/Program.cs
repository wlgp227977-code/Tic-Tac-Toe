using System;

char[,] numberBoard = new char[3, 3];
CreateBoard(numberBoard, 3, 3);

int turn = 0;
bool isGameOver = false;

Console.WriteLine("=== 틱택토 게임 · 1단계 ===");
Console.WriteLine("두 사람이 X와 O를 번갈아 놓습니다. X가 먼저 시작합니다.");
Console.WriteLine();
Console.WriteLine("위치 번호");
Console.WriteLine("1 | 2 | 3");
Console.WriteLine("---------");
Console.WriteLine("4 | 5 | 6");
Console.WriteLine("---------");
Console.WriteLine("7 | 8 | 9");
Console.WriteLine();

PrintBoard(numberBoard, 3, 3);

while (turn < 9 && !isGameOver)
{
    char currentPlayer;

    if (turn % 2 == 0)
    {
        currentPlayer = 'X';
    }
    else
    {
        currentPlayer = 'O';
    }

    Console.WriteLine($"{currentPlayer} 차례입니다.");
    Console.Write("놓을 위치를 입력하세요 (1~9): ");

    string? inputText = Console.ReadLine();

    if (!int.TryParse(inputText, out int input) || input < 1 || input > 9)
    {
        Console.WriteLine("1부터 9까지의 숫자를 입력하세요.");
        continue;
    }

    int row = (input - 1) / 3;
    int col = (input - 1) % 3;

    if (numberBoard[row, col] != '.')
    {
        Console.WriteLine("이미 입력한 칸입니다.");
        continue;
    }

    numberBoard[row, col] = currentPlayer;
    turn++;

    PrintBoard(numberBoard, 3, 3);

    char winner = CheckWinner(numberBoard);

    if (winner != '.')
    {
        Console.WriteLine($"{winner} 승리!");
        isGameOver = true;
    }
}

if (!isGameOver)
{
    Console.WriteLine("무승부!");
}

Console.WriteLine("게임 종료");

void CreateBoard(char[,] board, int rowSize, int colSize)
{
    for (int i = 0; i < rowSize; i++)
    {
        for (int j = 0; j < colSize; j++)
        {
            board[i, j] = '.';
        }
    }
}

void PrintBoard(char[,] board, int rowSize, int colSize)
{
    for (int i = 0; i < rowSize; i++)
    {
        for (int j = 0; j < colSize; j++)
        {
            Console.Write(board[i, j]);

            if (j < colSize - 1)
            {
                Console.Write(" | ");
            }
        }

        Console.WriteLine();

        if (i < rowSize - 1)
        {
            Console.WriteLine("---------");
        }
    }

    Console.WriteLine();
}


char CheckWinner(char[,] board)
{
    for (int i = 0; i < 3; i++)
    {
        if (board[i, 0] != '.' &&
            board[i, 0] == board[i, 1] &&
            board[i, 1] == board[i, 2])
        {
            return board[i, 0];
        }
    }
    for (int i = 0; i < 3; i++)
    {
        if (board[0, i] != '.' &&
            board[0, i] == board[1, i] &&
            board[1, i] == board[2, i])
        {
            return board[0, i];
        }
    }
    if (board[0, 0] != '.' &&
        board[0, 0] == board[1, 1] &&
        board[1, 1] == board[2, 2])
    {
        return board[0, 0];
    }
    if (board[0, 2] != '.' &&
        board[0, 2] == board[1, 1] &&
        board[1, 1] == board[2, 0])
    {
        return board[0, 2];
    }
    return '.';
}