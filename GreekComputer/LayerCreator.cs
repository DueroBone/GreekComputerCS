namespace GreekComputer
{
  class LayerCreator
  {
    // bottom
    private static readonly Layer fifthLayer = new([
        [11, 11, 14, 11, 14, 11, 14, 14, 11, 14, 11, 14],
        [4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15],
        [4, 4, 6, 6, 3, 3, 14, 14, 21, 21, 9, 9],
        [8, 3, 4, 12, 2, 5, 10, 7, 16, 8, 7, 8],
      ], null);
    private static readonly Layer fourthLayer = new([
        [14, 11, 0, 8, 0, 16, 2, 7, 0, 9, 0, 7],
        [0, 14, 12, 3, 8, 9, 0, 9, 20, 12, 3, 6],
        [13, 9, 0, 17, 19, 3, 12, 3, 26, 6, 0, 2],
        [0, 6, 0, 10, 0, 10, 0, 1, 0, 9, 0, 12]
  ], fifthLayer);

    private static readonly Layer thirdLayer = new([
        [21, 17, 4, 5, 0, 7, 8, 9, 13, 9, 7, 13],
        [18, 11, 26, 14, 1, 12, 0, 21, 6, 15, 4, 9],
        [0, 22, 0, 16, 0, 9, 0, 5, 0, 10, 0, 8, ],
        Zeros()
      ], fourthLayer);

    private static readonly Layer secondLayer = new([
        [17, 7, 3, 0, 6, 0, 11, 11, 6, 11, 0, 6],
        [0, 4, 0, 7, 15, 0, 0, 14, 0, 9, 0, 12],
        Zeros(),
        Zeros()
      ], thirdLayer);

    // top
    private static readonly Layer firstLayer = new([
        [7, 0, 15, 0, 8, 0, 3, 0, 6, 0, 10, 0],
        Zeros(),
        Zeros(),
        Zeros()
      ], secondLayer);


    /// <summary>
    /// Grabs the layer based on the layer number
    /// </summary>
    /// <param name="layerNum">Can only be from 1-4</param>
    /// <returns>The layer</returns>
    public static Layer GetLayer(int layerNum)
    {
      switch (layerNum)
      {
        case 1:
          return firstLayer;
        case 2:
          return secondLayer;
        case 3:
          return thirdLayer;
        case 4:
          return fourthLayer;
        case 5:
          return fifthLayer;
        default:
          throw new ArgumentException("Invalid layer number");
      }
    }

    private static int[] Zeros()
    {
      return [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
    }
  }
}