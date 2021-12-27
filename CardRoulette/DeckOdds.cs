using System;
using System.Collections.Generic;
using System.Linq;
using CardLibExt = CardRoulette.CardLib.CardValueExtensions;

namespace CardRoulette {
	internal struct DeckOdds {
		// Yes, I could optimize those values / divisions
		// However, this is static and runs once
		// Also, it helps visualize the number for later
		private static readonly IDictionary<BetType,float> DefaultOdds = new[] {
			new KeyValuePair<BetType,float>( BetType.SingleCard, 52f / 1f ),
			new KeyValuePair<BetType,float>( BetType.DoubleCard, 52f / 2f ),
			// A TripleCard bet REQUIRES one of the cards to be a Joker
			// Thus, the payout amount includes the Jokers in the rate
			// This is the ONLY bet that does this
			new KeyValuePair<BetType,float>( BetType.TripleCard, 54f / 3f ),
			new KeyValuePair<BetType,float>( BetType.QuadCard, 52f / 4f ),
			new KeyValuePair<BetType,float>( BetType.OctCard, 52f / 8f ),
			new KeyValuePair<BetType,float>( BetType.High, 52f / 16f ),
			new KeyValuePair<BetType,float>( BetType.Mid, 52f / 20f ),
			new KeyValuePair<BetType,float>( BetType.Low, 52f / 16f ),
			new KeyValuePair<BetType,float>( BetType.Black, 52f / 26f ),
			new KeyValuePair<BetType,float>( BetType.Red, 52f / 26f ),
			new KeyValuePair<BetType,float>( BetType.Clubs, 52f / 13f ),
			new KeyValuePair<BetType,float>( BetType.Diamonds, 52f / 13f ),
			new KeyValuePair<BetType,float>( BetType.Hearts, 52f / 13f ),
			new KeyValuePair<BetType,float>( BetType.Spades, 52f / 13f ),
		}.ToDictionary( k => k.Key, v => v.Value );

		private readonly CardLib.Deck DeckState;

		internal DeckOdds( CardLib.Deck deck = null ) =>
			this.DeckState =
				null == deck
					? null
					: new CardLib.Deck( deck );

		internal int CalculatePayout( Bet bet, CardLib.Card card ) {
			if( !bet.Cards.Contains( card ) )
				return 0;

			if( null == DeckState )
				return Convert.ToInt32( Math.Floor( bet.Amount * DefaultOdds[bet.Type] ) );

			float totalCards =
				BetType.TripleCard == bet.Type
					? DeckState.Count()
					: DeckState.Count( card => CardLib.Suits.Joker != CardLibExt.GetSuit( card.Value ) );

			float existingCards = bet.Cards.Intersect( DeckState ).Count();
			double payoutRate = totalCards / existingCards;

			return Convert.ToInt32( Math.Floor( bet.Amount * payoutRate ) );
		}
	}
}
