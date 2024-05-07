using System;

namespace GameMagic.Events
{
	public delegate void HealthChangedHandler(object sender, HealthChangedEventArgs e);

	public class HealthChangedEventArgs : EventArgs
	{
		public int NewHp { get; }
		public int OldHp { get; }

		public HealthChangedEventArgs(int newHp, int oldHp)
		{
			NewHp = newHp;
			OldHp = oldHp;
		}
	}
}
