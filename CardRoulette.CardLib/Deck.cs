using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using Microsoft.Xna.Framework.Graphics;

namespace CardRoulette.CardLib {
	public class Deck : IEnumerable<Card> {
		private List<Card> deck;

		//private readonly Texture2D cardBack;
		
		public Deck() =>
			deck = new List<Card>();
		public Deck( Card card )
			: this( new[] { card } ) { }
		public Deck( IEnumerable<Card> cards ) =>
			deck = new List<Card>( cards.Select( card => new Card( card ) ) );

		public static Deck PokerDeck( bool includeJokers ) {
			IEnumerable<Card> newDeck = new Deck( new[] {
				new Card( CardValues.TwoOfClubs ),
				new Card( CardValues.ThreeOfClubs ),
				new Card( CardValues.FourOfClubs ),
				new Card( CardValues.FiveOfClubs ),
				new Card( CardValues.SixOfClubs ),
				new Card( CardValues.SevenOfClubs ),
				new Card( CardValues.EightOfClubs ),
				new Card( CardValues.NineOfClubs ),
				new Card( CardValues.TenOfClubs ),
				new Card( CardValues.JackOfClubs ),
				new Card( CardValues.QueenOfClubs ),
				new Card( CardValues.KingOfClubs ),
				new Card( CardValues.AceOfClubs ),
				new Card( CardValues.TwoOfDiamonds ),
				new Card( CardValues.ThreeOfDiamonds ),
				new Card( CardValues.FourOfDiamonds ),
				new Card( CardValues.FiveOfDiamonds ),
				new Card( CardValues.SixOfDiamonds ),
				new Card( CardValues.SevenOfDiamonds ),
				new Card( CardValues.EightOfDiamonds ),
				new Card( CardValues.NineOfDiamonds ),
				new Card( CardValues.TenOfDiamonds ),
				new Card( CardValues.JackOfDiamonds ),
				new Card( CardValues.QueenOfDiamonds ),
				new Card( CardValues.KingOfDiamonds ),
				new Card( CardValues.AceOfDiamonds ),
				new Card( CardValues.TwoOfHearts ),
				new Card( CardValues.ThreeOfHearts ),
				new Card( CardValues.FourOfHearts ),
				new Card( CardValues.FiveOfHearts ),
				new Card( CardValues.SixOfHearts ),
				new Card( CardValues.SevenOfHearts ),
				new Card( CardValues.EightOfHearts ),
				new Card( CardValues.NineOfHearts ),
				new Card( CardValues.TenOfHearts ),
				new Card( CardValues.JackOfHearts ),
				new Card( CardValues.QueenOfHearts ),
				new Card( CardValues.KingOfHearts ),
				new Card( CardValues.AceOfHearts ),
				new Card( CardValues.TwoOfSpades ),
				new Card( CardValues.ThreeOfSpades ),
				new Card( CardValues.FourOfSpades ),
				new Card( CardValues.FiveOfSpades ),
				new Card( CardValues.SixOfSpades ),
				new Card( CardValues.SevenOfSpades ),
				new Card( CardValues.EightOfSpades ),
				new Card( CardValues.NineOfSpades ),
				new Card( CardValues.TenOfSpades ),
				new Card( CardValues.JackOfSpades ),
				new Card( CardValues.QueenOfSpades ),
				new Card( CardValues.KingOfSpades ),
				new Card( CardValues.AceOfSpades )
			} );

			if( includeJokers ) {
				newDeck =
					newDeck
						.Append( new Card( CardValues.LittleJoker ) )
						.Append( new Card( CardValues.BigJoker ) );
			}

			return new Deck( newDeck );
		}

		//public static Deck PokerDeck( bool includeJokers ) {
		//	IEnumerable<Card> newDeck = new Deck( new[] {
		//		new Card( CardValues.TwoOfClubs, null, null ),
		//		new Card( CardValues.ThreeOfClubs, null, null ),
		//		new Card( CardValues.FourOfClubs, null, null ),
		//		new Card( CardValues.FiveOfClubs, null, null ),
		//		new Card( CardValues.SixOfClubs, null, null ),
		//		new Card( CardValues.SevenOfClubs, null, null ),
		//		new Card( CardValues.EightOfClubs, null, null ),
		//		new Card( CardValues.NineOfClubs, null, null ),
		//		new Card( CardValues.TenOfClubs, null, null ),
		//		new Card( CardValues.JackOfClubs, null, null ),
		//		new Card( CardValues.QueenOfClubs, null, null ),
		//		new Card( CardValues.KingOfClubs, null, null ),
		//		new Card( CardValues.AceOfClubs, null, null ),
		//		new Card( CardValues.TwoOfDiamonds, null, null ),
		//		new Card( CardValues.ThreeOfDiamonds, null, null ),
		//		new Card( CardValues.FourOfDiamonds, null, null ),
		//		new Card( CardValues.FiveOfDiamonds, null, null ),
		//		new Card( CardValues.SixOfDiamonds, null, null ),
		//		new Card( CardValues.SevenOfDiamonds, null, null ),
		//		new Card( CardValues.EightOfDiamonds, null, null ),
		//		new Card( CardValues.NineOfDiamonds, null, null ),
		//		new Card( CardValues.TenOfDiamonds, null, null ),
		//		new Card( CardValues.JackOfDiamonds, null, null ),
		//		new Card( CardValues.QueenOfDiamonds, null, null ),
		//		new Card( CardValues.KingOfDiamonds, null, null ),
		//		new Card( CardValues.AceOfDiamonds, null, null ),
		//		new Card( CardValues.TwoOfHearts, null, null ),
		//		new Card( CardValues.ThreeOfHearts, null, null ),
		//		new Card( CardValues.FourOfHearts, null, null ),
		//		new Card( CardValues.FiveOfHearts, null, null ),
		//		new Card( CardValues.SixOfHearts, null, null ),
		//		new Card( CardValues.SevenOfHearts, null, null ),
		//		new Card( CardValues.EightOfHearts, null, null ),
		//		new Card( CardValues.NineOfHearts, null, null ),
		//		new Card( CardValues.TenOfHearts, null, null ),
		//		new Card( CardValues.JackOfHearts, null, null ),
		//		new Card( CardValues.QueenOfHearts, null, null ),
		//		new Card( CardValues.KingOfHearts, null, null ),
		//		new Card( CardValues.AceOfHearts, null, null ),
		//		new Card( CardValues.TwoOfSpades, null, null ),
		//		new Card( CardValues.ThreeOfSpades, null, null ),
		//		new Card( CardValues.FourOfSpades, null, null ),
		//		new Card( CardValues.FiveOfSpades, null, null ),
		//		new Card( CardValues.SixOfSpades, null, null ),
		//		new Card( CardValues.SevenOfSpades, null, null ),
		//		new Card( CardValues.EightOfSpades, null, null ),
		//		new Card( CardValues.NineOfSpades, null, null ),
		//		new Card( CardValues.TenOfSpades, null, null ),
		//		new Card( CardValues.JackOfSpades, null, null ),
		//		new Card( CardValues.QueenOfSpades, null, null ),
		//		new Card( CardValues.KingOfSpades, null, null ),
		//		new Card( CardValues.AceOfSpades, null, null )
		//	} );

		//	if( includeJokers ) {
		//		newDeck =
		//			newDeck
		//				.Append( new Card( CardValues.LittleJoker, null, null ) )
		//				.Append( new Card( CardValues.BigJoker, null, null ) );
		//	}

		//	return new Deck( newDeck );
		//}

		public IEnumerator<Card> GetEnumerator() => deck.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => deck.GetEnumerator();

		public Card Deal() {
			Card returnValue = deck[0];
			deck.RemoveAt( 0 );
			return returnValue;
		}

		public Deck Deal( int count = 1 ) {
			Deck returnValue = new Deck( deck.Take( count ) );
			deck.RemoveRange( 0, Math.Min( count, deck.Count ) );
			return returnValue;
		}

		/// <summary>Splits a Deck into 2 Decks at a random position</summary>
		/// <returns>A new deck, which is the TOP half of the split</returns>
		/// <remarks><code>this</code> becomes the bottom half of the split</remarks>
		public Deck Split() {
			Random r = new Random();
			int position = r.Next( 0, deck.Count + 1 );

			Deck newDeck = new Deck( deck.Take( position ).ToList() );

			deck = deck
				.Skip( position )
				.ToList();

			return newDeck;
		}

		public void Cut() {
			Deck half = this.Split();
			deck.Concat( half );
		}

		public void Join( Deck that ) {
			deck.Concat( that );
			that.deck.Clear();
		}

		public void Shuffle() {
			Random r = new Random();
			Deck that = Split();
			List<Card> shuffledDeck = new List<Card>();

			Func<int> howManyCards = () => ( r.Next( 0, 5 ) % 3 ) + 1;

			while( that.Any() || this.Any() ) {
				shuffledDeck.AddRange( that.Deal( howManyCards() ) );
				shuffledDeck.AddRange( this.Deal( howManyCards() ) );
			}

			deck = shuffledDeck;
		}

		public void Prepend( Card card ) =>
			Insert( card, 0 );

		public void Insert( Card card ) =>
			Insert( card, new Random().Next( this.deck.Count ) );

		public void Append( Card card ) =>
			Insert( card, this.deck.Count - 1 );

		public void Insert( Card card, int position ) =>
			this.deck.Insert( position, card );
	}
}