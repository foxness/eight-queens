using System.Collections.Generic;

namespace EightQueens
{
    public static class Solver
    {
        public static List<bool[,]> GetSolutions(int N)
        {
            var field = new bool[N, N];
            for (int y = 0; y < N; ++y)
                for (int x = 0; x < N; ++x)
                    field[x, y] = false;

            var solutions = new List<bool[,]>();
            Solve(N, field, 0, ref solutions);
            return solutions;
        }

        private static void Solve(int N, bool[,] field, int currentRow, ref List<bool[,]> solutions)
        {
            if (currentRow == N)
            {
                var clone = new bool[N, N];
                for (int y = 0; y < N; ++y)
                    for (int x = 0; x < N; ++x)
                        clone[x, y] = field[x, y];

                solutions.Add(clone);
                return;
            }

            for (int x = 0; x < N; ++x)
            {
                bool queenFits = true;

                for (int ox = -1; ox <= 1; ++ox)
                {
                    for (int i = 1; true; ++i)
                    {
                        int nx = x + ox * i;
                        int ny = currentRow - i;

                        if (nx >= 0 && nx < N && ny >= 0 && ny < N)
                        {
                            if (field[nx, ny])
                            {
                                queenFits = false;
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (!queenFits)
                        break;
                }

                if (!queenFits)
                    continue;

                field[x, currentRow] = true;
                Solve(N, field, currentRow + 1, ref solutions);
                field[x, currentRow] = false;
            }
        }
    }
}
