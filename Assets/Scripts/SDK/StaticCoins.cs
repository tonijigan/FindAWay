   public static class StaticCoins
   {
      public static int Coins { get; private set; }

      public static void SetCoins(int coins) => Coins = coins;
   }

