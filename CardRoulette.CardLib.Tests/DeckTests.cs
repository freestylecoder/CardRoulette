using System.Linq;
using Xunit;

namespace CardRoulette.CardLib.Tests {
	public class DeckTests {
		[Fact]
		public void Cut_Sanity() {
			Deck actual = Deck.PokerDeck( false );
			actual.Cut();
			Assert.Equal( actual.Count(), actual.Distinct().Count() );
		}

		[Fact]
		public void Split_Sanity() {
			Deck right = Deck.PokerDeck( false );

			int expectedTotalSize = right.Count();

			Deck left = right.Split();

			Assert.Equal( expectedTotalSize, left.Count() + right.Count() );
			Assert.NotEmpty( left );
			Assert.NotEmpty( right );
			Assert.Empty( left.Intersect( right ) );
		}

		[Fact]
		public void Shuffle_Sanity() {
			Deck actual = Deck.PokerDeck( false );
			int expectedSize = actual.Count();

			actual.Shuffle();
			Assert.Equal( expectedSize, actual.Count() );
			Assert.Equal( expectedSize, actual.Distinct().Count() );
		}
	}
}
