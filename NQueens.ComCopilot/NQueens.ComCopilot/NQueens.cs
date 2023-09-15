namespace NQueens.ComCopilot;

public class NQueens
{
    //Metodo para resolver o problema das N-Rainhas com o algoritmo de backtracking e imprimir o tabuleiro com as soluções encontradas 

    public static void SolveNQueens(int n)
    {
        int[,] board = new int[n, n];
        if (SolveNQueensUtil(board, 0) == false)
        {
            Console.WriteLine("Solution does not exist");
            return;
        }

        PrintSolution(board);
    }

    //Função para verificar se uma rainha pode ser colocada em board[row,col]. Note que esta função é chamada quando "col" rainhas já estão colocadas em colunas de 0 a col-1. Então precisamos verificar apenas as colunas à esquerda para a rainha atual. Podemos verificar as diagonais esquerda e direita para verificar se uma rainha pode ser colocada lá ou não

    public static bool IsSafe(int[,] board, int row, int col)
    {
        int i, j;
        int N = board.GetLength(0);

        // Verifica esta linha à esquerda
        for (i = 0; i < col; i++)
            if (board[row, i] == 1)
                return false;

        // Verifica a diagonal superior à esquerda
        for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            if (board[i, j] == 1)
                return false;

        // Verifica a diagonal inferior à esquerda
        for (i = row, j = col; j >= 0 && i < N; i++, j--)
            if (board[i, j] == 1)
                return false;

        return true;
    }

    //Uma função recursiva para resolver o problema das N-Rainhas

    public static bool SolveNQueensUtil(int[,] board, int col)
    {
        int N = board.GetLength(0);
        // Caso base: Se todas as rainhas forem colocadas, retorne true
        if (col >= N)
            return true;

        // Considere esta coluna e tente colocar esta rainha em todas as linhas uma por uma
        for (int i = 0; i < N; i++)
        {
            // Verifique se a rainha pode ser colocada em board[i,col]
            if (IsSafe(board, i, col))
            {
                // Coloque esta rainha em board[i,col]
                board[i, col] = 1;

                // Recursivamente coloque outras rainhas
                if (SolveNQueensUtil(board, col + 1) == true)
                    return true;

                // Se colocar a rainha em board[i,col] não levar a uma solução, então remova a rainha de board[i,col]
                board[i, col] = 0; // BACKTRACK
            }
        }

        // Se a rainha não puder ser colocada em nenhuma linha nesta coluna col, retorne false
        return false;
    }

    //Uma função de utilidade para imprimir a solução

    public static void PrintSolution(int[,] board)
    {
        int N = board.GetLength(0);
        for (int i = 0; i < N; i++)
        {
            Console.Write("\n");
            for (int j = 0; j < N; j++)
                Console.Write(" " + board[i, j] + " ");
        }

        Console.WriteLine("\n");
    }
}