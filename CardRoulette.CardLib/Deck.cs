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
				new Card( CardValue.TwoOfClubs ),
				new Card( CardValue.ThreeOfClubs ),
				new Card( CardValue.FourOfClubs ),
				new Card( CardValue.FiveOfClubs ),
				new Card( CardValue.SixOfClubs ),
				new Card( CardValue.SevenOfClubs ),
				new Card( CardValue.EightOfClubs ),
				new Card( CardValue.NineOfClubs ),
				new Card( CardValue.TenOfClubs ),
				new Card( CardValue.JackOfClubs ),
				new Card( CardValue.QueenOfClubs ),
				new Card( CardValue.KingOfClubs ),
				new Card( CardValue.AceOfClubs ),
				new Card( CardValue.TwoOfDiamonds ),
				new Card( CardValue.ThreeOfDiamonds ),
				new Card( CardValue.FourOfDiamonds ),
				new Card( CardValue.FiveOfDiamonds ),
				new Card( CardValue.SixOfDiamonds ),
				new Card( CardValue.SevenOfDiamonds ),
				new Card( CardValue.EightOfDiamonds ),
				new Card( CardValue.NineOfDiamonds ),
				new Card( CardValue.TenOfDiamonds ),
				new Card( CardValue.JackOfDiamonds ),
				new Card( CardValue.QueenOfDiamonds ),
				new Card( CardValue.KingOfDiamonds ),
				new Card( CardValue.AceOfDiamonds ),
				new Card( CardValue.TwoOfHearts ),
				new Card( CardValue.ThreeOfHearts ),
				new Card( CardValue.FourOfHearts ),
				new Card( CardValue.FiveOfHearts ),
				new Card( CardValue.SixOfHearts ),
				new Card( CardValue.SevenOfHearts ),
				new Card( CardValue.EightOfHearts ),
				new Card( CardValue.NineOfHearts ),
				new Card( CardValue.TenOfHearts ),
				new Card( CardValue.JackOfHearts ),
				new Card( CardValue.QueenOfHearts ),
				new Card( CardValue.KingOfHearts ),
				new Card( CardValue.AceOfHearts ),
				new Card( CardValue.TwoOfSpades ),
				new Card( CardValue.ThreeOfSpades ),
				new Card( CardValue.FourOfSpades ),
				new Card( CardValue.FiveOfSpades ),
				new Card( CardValue.SixOfSpades ),
				new Card( CardValue.SevenOfSpades ),
				new Card( CardValue.EightOfSpades ),
				new Card( CardValue.NineOfSpades ),
				new Card( CardValue.TenOfSpades ),
				new Card( CardValue.JackOfSpades ),
				new Card( CardValue.QueenOfSpades ),
				new Card( CardValue.KingOfSpades ),
				new Card( CardValue.AceOfSpades )
			} );

			if( includeJokers ) {
				newDeck =
					newDeck
						.Append( new Card( CardValue.LittleJoker ) )
						.Append( new Card( CardValue.BigJoker ) );
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

		public Card BottomDeal() {
			Card returnValue = deck.Last();
			deck.RemoveAt( deck.Count - 1 );
			return returnValue;
		}

		public Deck BottomDeal( int count = 1 ) {
			Deck returnValue = new Deck( deck.Skip( deck.Count - count ) );
			deck = deck.Take( deck.Count - count ).ToList();
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
			deck = deck.Concat( that ).ToList();
			that.deck.Clear();
		}

		public void Shuffle() {
			Random r = new Random();
			Deck that = Split();
			List<Card> shuffledDeck = new List<Card>();

			Func<int> howManyCards = () => ( r.Next( 0, 5 ) % 3 ) + 1;

			while( that.Any() || this.Any() ) {
				shuffledDeck.InsertRange( 0, that.BottomDeal( howManyCards() ) );
				shuffledDeck.InsertRange( 0, this.BottomDeal( howManyCards() ) );
			}

			deck = shuffledDeck;
		}

		public void Prepend( Card card ) =>
			Insert( card, 0 );

		public void Insert( Card card ) =>
			Insert( card, new Random().Next( this.deck.Count ) );

		public void Append( Card card ) =>
			Insert( card, this.deck.Count );

		public void Insert( Card card, int position ) =>
			this.deck.Insert( position, card );
	}
}