namespace GreekComputer
{
  /// <summary>
  /// The layer
  /// </summary>
  /// <param name="circles">A nested array for each 'circle' around the center, 
  /// should be a 4x12 grid with the first list the inner circle</param>
  class Layer
  {
    private readonly int[] k_circle1;
    private readonly int[] k_circle2;
    private readonly int[] k_circle3;
    private readonly int[] k_circle4;

    private int[] circle1;
    private int[] circle2;
    private int[] circle3;
    private int[] circle4;

    private int rotation = 0;

    private readonly Layer? layerBelow;


    public Layer(int[][] circles, Layer? layerBelow)
    {
      k_circle1 = circles[0];
      k_circle2 = circles[1];
      k_circle3 = circles[2];
      k_circle4 = circles[3];

      circle1 = k_circle1.Clone() as int[];
      circle2 = k_circle2.Clone() as int[];
      circle3 = k_circle3.Clone() as int[];
      circle4 = k_circle4.Clone() as int[];

      this.layerBelow = layerBelow;
    }

    public void Print(bool fullInfo = false)
    {
      if (fullInfo) {
      Console.WriteLine("Circles: rotation " + rotation);
      }
      Console.WriteLine($"Inner circle: {PrintCircle(1)}");
      Console.WriteLine($"Circle 2:     {PrintCircle(2)}");
      Console.WriteLine($"Circle 3:     {PrintCircle(3)}");
      Console.WriteLine($"Outer circle: {PrintCircle(4)}");
    }

    public void Rotate()
    {
      rotation++;
      rotation %= 12;
      for (int i = 0; i < 12; i++)
      {
        int pos = (i + rotation) % 12;
        circle1[i] = k_circle1[pos];
        circle2[i] = k_circle2[pos];
        circle3[i] = k_circle3[pos];
        circle4[i] = k_circle4[pos];
      }
    }

    public void RotateTo(int position)
    {
      rotation = position;
      for (int i = 0; i < 12; i++)
      {
        circle1[i] = k_circle1[(i + rotation) % 12];
        circle2[i] = k_circle2[(i + rotation) % 12];
        circle3[i] = k_circle3[(i + rotation) % 12];
        circle4[i] = k_circle4[(i + rotation) % 12];
      }
    }

    public int GetNumber(int circle, int position)
    {
      int number = GetCircle(circle)[position];
      if (number == 0)
      {
        if (layerBelow == null)
        {
          throw new NullReferenceException("Trying to get a number from a below layer that doesn't exist");
        }
        return layerBelow.GetNumber(circle, position);
      }
      return number;
    }
    public string GetNumberString(int circle, int position)
    {
      string downSignal = "*";
      int number = GetCircle(circle)[position];
      if (number == 0)
      {
        if (layerBelow == null)
        {
          throw new NullReferenceException("Trying to get a number from a below layer that doesn't exist");
        }
        return layerBelow.GetNumberString(circle, position) + downSignal;
      }
      return "" + number;
    }

    private string PrintCircle(int circle)
    {
      string result = "";
      for (int i = 0; i < 12; i++)
      {
        string numberString = GetNumberString(circle, i);

        // From what layer is the number
        int depth = numberString.Count(c => c == '*');
        char depthChar = (char)('A' + depth);
        string thisOne = GetNumber(circle, i) + "*" + depthChar;
        bool spaceAfter = false;
        while (thisOne.Length < 6)
        {
          if (spaceAfter)
          {
            thisOne = " " + thisOne;
          }
          else
          {
            thisOne += " ";
          }
          spaceAfter = !spaceAfter;
        }
        result += thisOne + "|";
      }
      return result;
    }

    private int[] GetCircle(int circle)
    {
      switch (circle)
      {
        case 1:
          return circle1;
        case 2:
          return circle2;
        case 3:
          return circle3;
        case 4:
          return circle4;
        default:
          throw new ArgumentException("Invalid circle number");
      }
    }

    public int GetRotation()
    {
      return rotation;
    }
  }
}