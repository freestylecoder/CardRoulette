using Microsoft.Xna.Framework;

namespace CardRoulette {
	public class Bet {
		public int Amount;
		public Vector2 Position;

		public Bet( int amount, Vector2 position ) {
			this.Amount = amount;
			this.Position = position;
		}
	}
}
