namespace GreekComputer
{
  class Program
  {
    static void Main(string[] args)
    {
      Board board = new();
      int solutionCount = 0;
      List<int> boardList = new();
      int attempts = 0;
      for (int i = 0; i < 12; i++)
      {
        for (int j = 0; j < 12; j++)
        {
          for (int k = 0; k < 12; k++)
          {
            for (int l = 0; l < 12; l++)
            {
              for (int m = 0; m < 12; m++)
              {
                attempts++;
                int hash = board.GetHashCode();
                if (!boardList.Contains(hash))
                {
                  boardList.Add(hash);
                }
                else
                {
                  // continue;
                }
                if (board.SumSpokes())
                {
                  Console.WriteLine("Found a solution!");
                  board.Print();
                  solutionCount++;
                  Console.WriteLine();
                }
                board.Rotate(4);
              }
              board.Rotate(3);
            }
            board.Rotate(2);
          }
          board.Rotate(1);
        }
        board.Rotate(0);
      }
      Console.WriteLine($"Found {solutionCount} solutions");
      Console.WriteLine($"Took {attempts} attempts");
    }
  }
}