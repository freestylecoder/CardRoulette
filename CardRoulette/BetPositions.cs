using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using CardRoulette.CardLib;
using Microsoft.Xna.Framework;

using KVP = System.Collections.Generic.KeyValuePair<Microsoft.Xna.Framework.Vector2, CardRoulette.Bet>;

namespace CardRoulette {
	public static class BetPositions {
		public static readonly IDictionary<Vector2,Bet> MainList;

		static BetPositions() {
			IEnumerable<Vector2> whateves = Enumerable.Empty<Vector2>()
				.Concat( Enumerable.Range( 0, 27 ).Select( i => i * 50 ).Select( i => new Vector2( 309 + i, 339 ) ) )
				.Concat( Enumerable.Range( 0, 26 ).Select( i => i * 50 ).Select( i => new Vector2( 309 + i, 389 ) ) )
				.Concat( Enumerable.Range( 0, 27 ).Select( i => i * 50 ).Select( i => new Vector2( 309 + i, 439 ) ) )
				.Concat( Enumerable.Range( 0, 26 ).Select( i => i * 50 ).Select( i => new Vector2( 309 + i, 489 ) ) )
				.Concat( Enumerable.Range( 0, 27 ).Select( i => i * 50 ).Select( i => new Vector2( 309 + i, 539 ) ) )
				.Concat( Enumerable.Range( 0, 26 ).Select( i => i * 50 ).Select( i => new Vector2( 309 + i, 589 ) ) )
				.Concat( Enumerable.Range( 0, 27 ).Select( i => i * 50 ).Select( i => new Vector2( 309 + i, 639 ) ) )
				.Concat( Enumerable.Range( 0, 25 ).Select( i => i * 50 ).Select( i => new Vector2( 359 + i, 689 ) ) )
				.Concat( new[] {
					new Vector2(  259, 389 ),
					new Vector2(  259, 489 ),
					new Vector2(  259, 589 ),
					new Vector2( 1659, 389 ),
					new Vector2( 1659, 589 ),
					new Vector2(  509, 739 ),
					new Vector2(  959, 739 ),
					new Vector2( 1409, 739 )
				} );

			MainList = whateves
				.ToDictionary(
					k => k,
					v => new Bet( 0, v )
				);

/*
{X:309 Y:339}	BetType.DoubleCard
{X:359 Y:339}	BetType.SingleCard
{X:409 Y:339}	BetType.DoubleCard
{X:459 Y:339}	BetType.SingleCard
{X:509 Y:339}	BetType.DoubleCard
{X:559 Y:339}	BetType.SingleCard
{X:609 Y:339}	BetType.DoubleCard
{X:659 Y:339}	BetType.SingleCard
{X:709 Y:339}	BetType.DoubleCard
{X:759 Y:339}	BetType.SingleCard
{X:809 Y:339}	BetType.DoubleCard
{X:859 Y:339}	BetType.SingleCard
{X:909 Y:339}	BetType.DoubleCard
{X:959 Y:339}	BetType.SingleCard
{X:1009 Y:339}	BetType.DoubleCard
{X:1059 Y:339}	BetType.SingleCard
{X:1109 Y:339}	BetType.DoubleCard
{X:1159 Y:339}	BetType.SingleCard
{X:1209 Y:339}	BetType.DoubleCard
{X:1259 Y:339}	BetType.SingleCard
{X:1309 Y:339}	BetType.DoubleCard
{X:1359 Y:339}	BetType.SingleCard
{X:1409 Y:339}	BetType.DoubleCard
{X:1459 Y:339}	BetType.SingleCard
{X:1509 Y:339}	BetType.DoubleCard
{X:1559 Y:339}	BetType.SingleCard
{X:1609 Y:339}	BetType.Spades

{X:309 Y:389}	BetType.TripleCard
{X:359 Y:389}	BetType.DoubleCard
{X:409 Y:389}	BetType.QuadCard
{X:459 Y:389}	BetType.DoubleCard
{X:509 Y:389}	BetType.QuadCard
{X:559 Y:389}	BetType.DoubleCard
{X:609 Y:389}	BetType.QuadCard
{X:659 Y:389}	BetType.DoubleCard
{X:709 Y:389}	BetType.QuadCard
{X:759 Y:389}	BetType.DoubleCard
{X:809 Y:389}	BetType.QuadCard
{X:859 Y:389}	BetType.DoubleCard
{X:909 Y:389}	BetType.QuadCard
{X:959 Y:389}	BetType.DoubleCard
{X:1009 Y:389}	BetType.QuadCard
{X:1059 Y:389}	BetType.DoubleCard
{X:1109 Y:389}	BetType.QuadCard
{X:1159 Y:389}	BetType.DoubleCard
{X:1209 Y:389}	BetType.QuadCard
{X:1259 Y:389}	BetType.DoubleCard
{X:1309 Y:389}	BetType.QuadCard
{X:1359 Y:389}	BetType.DoubleCard
{X:1409 Y:389}	BetType.QuadCard
{X:1459 Y:389}	BetType.DoubleCard
{X:1509 Y:389}	BetType.QuadCard
{X:1559 Y:389}	BetType.DoubleCard

{X:309 Y:439}	BetType.DoubleCard
{X:359 Y:439}	BetType.SingleCard
{X:409 Y:439}	BetType.DoubleCard
{X:459 Y:439}	BetType.SingleCard
{X:509 Y:439}	BetType.DoubleCard
{X:559 Y:439}	BetType.SingleCard
{X:609 Y:439}	BetType.DoubleCard
{X:659 Y:439}	BetType.SingleCard
{X:709 Y:439}	BetType.DoubleCard
{X:759 Y:439}	BetType.SingleCard
{X:809 Y:439}	BetType.DoubleCard
{X:859 Y:439}	BetType.SingleCard
{X:909 Y:439}	BetType.DoubleCard
{X:959 Y:439}	BetType.SingleCard
{X:1009 Y:439}	BetType.DoubleCard
{X:1059 Y:439}	BetType.SingleCard
{X:1109 Y:439}	BetType.DoubleCard
{X:1159 Y:439}	BetType.SingleCard
{X:1209 Y:439}	BetType.DoubleCard
{X:1259 Y:439}	BetType.SingleCard
{X:1309 Y:439}	BetType.DoubleCard
{X:1359 Y:439}	BetType.SingleCard
{X:1409 Y:439}	BetType.DoubleCard
{X:1459 Y:439}	BetType.SingleCard
{X:1509 Y:439}	BetType.DoubleCard
{X:1559 Y:439}	BetType.SingleCard
{X:1609 Y:439}	BetType.Clubs

{X:309 Y:489}	BetType.QuadCard
{X:359 Y:489}	BetType.DoubleCard
{X:409 Y:489}	BetType.QuadCard
{X:459 Y:489}	BetType.DoubleCard
{X:509 Y:489}	BetType.QuadCard
{X:559 Y:489}	BetType.DoubleCard
{X:609 Y:489}	BetType.QuadCard
{X:659 Y:489}	BetType.DoubleCard
{X:709 Y:489}	BetType.QuadCard
{X:759 Y:489}	BetType.DoubleCard
{X:809 Y:489}	BetType.QuadCard
{X:859 Y:489}	BetType.DoubleCard
{X:909 Y:489}	BetType.QuadCard
{X:959 Y:489}	BetType.DoubleCard
{X:1009 Y:489}	BetType.QuadCard
{X:1059 Y:489}	BetType.DoubleCard
{X:1109 Y:489}	BetType.QuadCard
{X:1159 Y:489}	BetType.DoubleCard
{X:1209 Y:489}	BetType.QuadCard
{X:1259 Y:489}	BetType.DoubleCard
{X:1309 Y:489}	BetType.QuadCard
{X:1359 Y:489}	BetType.DoubleCard
{X:1409 Y:489}	BetType.QuadCard
{X:1459 Y:489}	BetType.DoubleCard
{X:1509 Y:489}	BetType.QuadCard
{X:1559 Y:489}	BetType.DoubleCard

{X:309 Y:539}	BetType.DoubleCard
{X:359 Y:539}	BetType.SingleCard
{X:409 Y:539}	BetType.DoubleCard
{X:459 Y:539}	BetType.SingleCard
{X:509 Y:539}	BetType.DoubleCard
{X:559 Y:539}	BetType.SingleCard
{X:609 Y:539}	BetType.DoubleCard
{X:659 Y:539}	BetType.SingleCard
{X:709 Y:539}	BetType.DoubleCard
{X:759 Y:539}	BetType.SingleCard
{X:809 Y:539}	BetType.DoubleCard
{X:859 Y:539}	BetType.SingleCard
{X:909 Y:539}	BetType.DoubleCard
{X:959 Y:539}	BetType.SingleCard
{X:1009 Y:539}	BetType.DoubleCard
{X:1059 Y:539}	BetType.SingleCard
{X:1109 Y:539}	BetType.DoubleCard
{X:1159 Y:539}	BetType.SingleCard
{X:1209 Y:539}	BetType.DoubleCard
{X:1259 Y:539}	BetType.SingleCard
{X:1309 Y:539}	BetType.DoubleCard
{X:1359 Y:539}	BetType.SingleCard
{X:1409 Y:539}	BetType.DoubleCard
{X:1459 Y:539}	BetType.SingleCard
{X:1509 Y:539}	BetType.DoubleCard
{X:1559 Y:539}	BetType.SingleCard
{X:1609 Y:539}	BetType.Hearts

{X:309 Y:589}	BetType.TripleCard
{X:359 Y:589}	BetType.DoubleCard
{X:409 Y:589}	BetType.QuadCard
{X:459 Y:589}	BetType.DoubleCard
{X:509 Y:589}	BetType.QuadCard
{X:559 Y:589}	BetType.DoubleCard
{X:609 Y:589}	BetType.QuadCard
{X:659 Y:589}	BetType.DoubleCard
{X:709 Y:589}	BetType.QuadCard
{X:759 Y:589}	BetType.DoubleCard
{X:809 Y:589}	BetType.QuadCard
{X:859 Y:589}	BetType.DoubleCard
{X:909 Y:589}	BetType.QuadCard
{X:959 Y:589}	BetType.DoubleCard
{X:1009 Y:589}	BetType.QuadCard
{X:1059 Y:589}	BetType.DoubleCard
{X:1109 Y:589}	BetType.QuadCard
{X:1159 Y:589}	BetType.DoubleCard
{X:1209 Y:589}	BetType.QuadCard
{X:1259 Y:589}	BetType.DoubleCard
{X:1309 Y:589}	BetType.QuadCard
{X:1359 Y:589}	BetType.DoubleCard
{X:1409 Y:589}	BetType.QuadCard
{X:1459 Y:589}	BetType.DoubleCard
{X:1509 Y:589}	BetType.QuadCard
{X:1559 Y:589}	BetType.DoubleCard

{X:309 Y:639}	BetType.DoubleCard
{X:359 Y:639}	BetType.SingleCard
{X:409 Y:639}	BetType.DoubleCard
{X:459 Y:639}	BetType.SingleCard
{X:509 Y:639}	BetType.DoubleCard
{X:559 Y:639}	BetType.SingleCard
{X:609 Y:639}	BetType.DoubleCard
{X:659 Y:639}	BetType.SingleCard
{X:709 Y:639}	BetType.DoubleCard
{X:759 Y:639}	BetType.SingleCard
{X:809 Y:639}	BetType.DoubleCard
{X:859 Y:639}	BetType.SingleCard
{X:909 Y:639}	BetType.DoubleCard
{X:959 Y:639}	BetType.SingleCard
{X:1009 Y:639}	BetType.DoubleCard
{X:1059 Y:639}	BetType.SingleCard
{X:1109 Y:639}	BetType.DoubleCard
{X:1159 Y:639}	BetType.SingleCard
{X:1209 Y:639}	BetType.DoubleCard
{X:1259 Y:639}	BetType.SingleCard
{X:1309 Y:639}	BetType.DoubleCard
{X:1359 Y:639}	BetType.SingleCard
{X:1409 Y:639}	BetType.DoubleCard
{X:1459 Y:639}	BetType.SingleCard
{X:1509 Y:639}	BetType.DoubleCard
{X:1559 Y:639}	BetType.SingleCard
{X:1609 Y:639}	BetType.Diamonds	Deck.PokerDeck.Where( c => Suit.Diamonds == c.CardValue & Suit.Diamonds )
         
{X:359 Y:689}	BetType.QuadCard
{X:409 Y:689}	BetType.OctCard
{X:459 Y:689}	BetType.QuadCard
{X:509 Y:689}	BetType.OctCard
{X:559 Y:689}	BetType.QuadCard
{X:609 Y:689}	BetType.OctCard
{X:659 Y:689}	BetType.QuadCard
{X:709 Y:689}	BetType.OctCard
{X:759 Y:689}	BetType.QuadCard
{X:809 Y:689}	BetType.OctCard
{X:859 Y:689}	BetType.QuadCard
{X:909 Y:689}	BetType.OctCard
{X:959 Y:689}	BetType.QuadCard
{X:1009 Y:689}	BetType.OctCard
{X:1059 Y:689}	BetType.QuadCard
{X:1109 Y:689}	BetType.OctCard
{X:1159 Y:689}	BetType.QuadCard
{X:1209 Y:689}	BetType.OctCard
{X:1259 Y:689}	BetType.QuadCard
{X:1309 Y:689}	BetType.OctCard
{X:1359 Y:689}	BetType.QuadCard
{X:1409 Y:689}	BetType.OctCard
{X:1459 Y:689}	BetType.QuadCard
{X:1509 Y:689}	BetType.OctCard
{X:1559 Y:689}	BetType.QuadCard

{X:259 Y:389}	BetType.SingleCard	new[] { CardValue.BigJoker }
{X:259 Y:489}	BetType.DoubleCard	new[] { CardValue.BigJoker, CardValue.LittleJoker }
{X:259 Y:589}	BetType.SingleCard	new[] { CardValue.BigJoker }
{X:1659 Y:389}	BetType.Black		new[] {}
{X:1659 Y:589}	BetType.Red			new[] {}
{X:509 Y:739}	BetType.Low
{X:959 Y:739}	BetType.Mid
{X:1409 Y:739}	BetType.High
*/
		}
	}
}
