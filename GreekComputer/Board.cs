namespace GreekComputer
{
  class Board
  {
    private readonly Layer[] layers;
    public Board()
    {
      layers = new Layer[5];
      layers[0] = LayerCreator.GetLayer(1);
      layers[1] = LayerCreator.GetLayer(2);
      layers[2] = LayerCreator.GetLayer(3);
      layers[3] = LayerCreator.GetLayer(4);
      layers[4] = LayerCreator.GetLayer(5);
    }
    public void Print()
    {
      // Console.WriteLine("Board:");
      layers[0].Print();
    }
    public void Rotate(int layerNum)
    {
      layers[layerNum].Rotate();
    }

    private int SumSpoke(int spokeNum)
    {
      int sum = 0;
      for (int i = 1; i < 5; i++)
      {
        sum += layers[0].GetNumber(i, spokeNum);
      }
      return sum;
    }

    public bool SumSpokes()
    {
      for (int i = 0; i < 12; i++)
      {
        if (SumSpoke(i) != 42)
        {
          return false;
        }
      }
      return true;
    }

    public override int GetHashCode()
    {
      int hash = 0;
      for (int i = 0; i < 12; i++)
      {
        hash += SumSpoke(i) * (i + 1);
        hash += layers[0].GetRotation() * 152369;
        hash += layers[1].GetRotation() * 72351;
        hash += layers[2].GetRotation() * 8324341;
        hash += layers[3].GetRotation() * 439101;
      }
      return hash;
    }
  }
}