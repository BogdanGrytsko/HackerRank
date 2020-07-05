using Xunit;

namespace XTest.Training
{
    public class Task4
    {
        [Fact]
        public void Test()
        {
            var arr = new int [4][];
            arr[0] = new[] {0, 0, 0, 0};
            arr[1] = new[] {0, -1, -1, 0};
            arr[2] = new[] {0, -1, 0, 0};
            arr[3] = new[] {0, 0, 0, 0};
            Solution(arr);
            Assert.Equal(3, arr[2][2]);
        }

        public void Solution(int[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                var row = board[i];
                for (int j = 0; j < row.Length; j++)
                {
                    if (row[j] == -1)
                        continue;
                    var cnt = 0;
                    for (int ki = -1; ki <= 1; ki++)
                    {
                        var ni = i + ki;
                        for (int kj = -1; kj <= 1; kj++)
                        {
                            var nj = j + kj;
                            if (ni >= 0 && ni < board.Length && nj >= 0 && nj < row.Length && board[ni][nj] == -1)
                                cnt++;
                        }
                    }

                    row[j] = cnt;
                }
            }
        }
    }
}