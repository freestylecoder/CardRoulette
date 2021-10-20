using System;
using System.Collections.Generic;
using System.Linq;
using CardLibExt = CardRoulette.CardLib.CardValueExtensions;

namespace CardRoulette {
	internal struct DeckOdds {
		private readonly int Count;

		private readonly int Red;
		private readonly int Black;

		private readonly IDictionary<CardLib.Ranks,float> Ranks;
		private readonly IDictionary<CardLib.Suits,float> Suits;
		private readonly IDictionary<CardLib.CardValues,float> Cards;

		internal DeckOdds( bool includeJokers = false ) {
			this.Count = 52;

			this.Red = 26;
			this.Black = 26;

			this.Ranks = new Dictionary<CardLib.Ranks, float>( new[] {
				new KeyValuePair<CardLib.Ranks,float>( CardLib.Ranks.Two, 4 ),
				new KeyValuePair<CardLib.Ranks,float>( CardLib.Ranks.Three, 4 ),
				new KeyValuePair<CardLib.Ranks,float>( CardLib.Ranks.Four, 4 ),
				new KeyValuePair<CardLib.Ranks,float>( CardLib.Ranks.Five, 4 ),
				new KeyValuePair<CardLib.Ranks,float>( CardLib.Ranks.Six, 4 ),
				new KeyValuePair<CardLib.Ranks,float>( CardLib.Ranks.Seven, 4 ),
				new KeyValuePair<CardLib.Ranks,float>( CardLib.Ranks.Eight, 4 ),
				new KeyValuePair<CardLib.Ranks,float>( CardLib.Ranks.Nine, 4 ),
				new KeyValuePair<CardLib.Ranks,float>( CardLib.Ranks.Ten, 4 ),
				new KeyValuePair<CardLib.Ranks,float>( CardLib.Ranks.Jack, 4 ),
				new KeyValuePair<CardLib.Ranks,float>( CardLib.Ranks.Queen, 4 ),
				new KeyValuePair<CardLib.Ranks,float>( CardLib.Ranks.King, 4 ),
				new KeyValuePair<CardLib.Ranks,float>( CardLib.Ranks.Ace, 4 ),
				new KeyValuePair<CardLib.Ranks,float>(
					CardLib.Ranks.Little,
					includeJokers ? 1 : 0
				),
				new KeyValuePair<CardLib.Ranks,float>(
					CardLib.Ranks.Big,
					includeJokers ? 1 : 0
				)
			} );

			this.Suits = new Dictionary<CardLib.Suits,float>( new[] {
				new KeyValuePair<CardLib.Suits,float>( CardLib.Suits.Clubs, 13 ),
				new KeyValuePair<CardLib.Suits,float>( CardLib.Suits.Spades, 13 ),
				new KeyValuePair<CardLib.Suits,float>( CardLib.Suits.Hearts, 13 ),
				new KeyValuePair<CardLib.Suits,float>( CardLib.Suits.Diamonds, 13 ),
				new KeyValuePair<CardLib.Suits,float>(
					CardLib.Suits.Joker,
					includeJokers ? 2 : 0
				)
			} );

			this.Cards = new Dictionary<CardLib.CardValues,float>( 
				CardLib.Deck.PokerDeck( includeJokers )
					.Select(
						c => new KeyValuePair<CardLib.CardValues,float>( c.Value, 1 )
					)
			);
		}

		internal DeckOdds( CardLib.Deck deck, bool includeJokers = false ) {
			this.Count = deck
				.Count( c => CardLib.Suits.Joker != CardLibExt.GetSuit( c.Value ) );

			this.Red = deck.Count( c =>
				new[] { CardLib.Suits.Hearts, CardLib.Suits.Diamonds }
					.Contains( CardLibExt.GetSuit( c.Value ) )
			);
			this.Black = deck.Count( c =>
				new[] { CardLib.Suits.Clubs, CardLib.Suits.Spades }
					.Contains( CardLibExt.GetSuit( c.Value ) )
			);

			this.Ranks = new Dictionary<CardLib.Ranks,float>( 
				Enum.GetValues( typeof( CardLib.Ranks ) )
					.OfType<CardLib.Ranks>()
					.Except( new[] { CardLib.Ranks.Big, CardLib.Ranks.Little } )
					.Select(
						r => new KeyValuePair<CardLib.Ranks,float>(
							r,
							deck.Count( c => r == CardLibExt.GetRank( c.Value ) )
						)
					)
			);

			this.Suits = new Dictionary<CardLib.Suits,float>( 
				Enum.GetValues( typeof( CardLib.Suits ) )
					.OfType<CardLib.Suits>()
					.Except( new[] { CardLib.Suits.Joker } )
					.Select(
						s => new KeyValuePair<CardLib.Suits,float>(
							s,
							deck.Count( c => s == CardLibExt.GetSuit( c.Value ) )
						)
					)
			);

			this.Cards = new Dictionary<CardLib.CardValues,float>( 
				CardLib.Deck.PokerDeck( includeJokers )
					.Select(
						c => new KeyValuePair<CardLib.CardValues,float>(
							c.Value,
							deck.Count( c2 => c.Value == c2.Value )
						)
					)
			);

			if( includeJokers ) {
				this.Suits.Add(
					CardLib.Suits.Joker,
					deck.Count( c => CardLib.Suits.Joker == CardLibExt.GetSuit( c.Value ) )
				);
			}
		}

		internal int CalculatePayout( int bet, CardLib.Card card ) =>
			this.Cards.ContainsKey( card.Value )
				? Payout( bet, this.Cards[card.Value], this.Count )
				: 0;

		internal int CalculatePayout( int bet, CardLib.Suits suit ) =>
			this.Suits.ContainsKey( suit )
				? Payout( bet, this.Suits[suit], this.Count )
				: 0;

		internal int CalculatePayout( int bet, CardLib.Ranks rank ) =>
			this.Ranks.ContainsKey( rank )
				? Payout( bet, this.Ranks[rank], this.Count )
				: 0;

		internal int CalculatePayout( int bet, CardLib.Card card, bool betOnBlack ) =>
			CardLib.Suits.Joker == CardLibExt.GetSuit( card.Value )
			? 0
			: new[] { CardLib.Suits.Clubs, CardLib.Suits.Spades }
				.Contains( CardLibExt.GetSuit( card.Value ) )
				^ betOnBlack
					? Payout(
						bet,
						betOnBlack
							? Black
							: Red,
						this.Count
					)
					: 0;

		private static int Payout( int bet, float numberAvailable, int deckSize ) =>
			Convert.ToInt32( Math.Floor( bet / numberAvailable ) ) * deckSize;
	}
}
