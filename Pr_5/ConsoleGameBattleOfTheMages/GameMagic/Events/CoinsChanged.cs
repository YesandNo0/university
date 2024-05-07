using System;

namespace GameMagic.Events
{
    public delegate void CoinsChangedHandler(object sender, CoinsChangedEventArgs e);
    public class CoinsChangedEventArgs : EventArgs
    {
        public int NewCoins { get; }
        public int OldCoins { get; }

        public CoinsChangedEventArgs(int newCoins, int oldCoins)
        {
            NewCoins = newCoins;
            OldCoins = oldCoins;
        }
    }
}
