using System;
//using Microsoft.Xna.Framework.Graphics;

namespace CardRoulette.CardLib {
	public class Card : IEquatable<Card> {
		public readonly CardValue Value;
		//public readonly Texture2D Face;
		//public readonly Texture2D Back;

		public Card (
			CardValue value = default //,
			//Texture2D face = default,
			//Texture2D back = default
		) {
			this.Value = value;
			//this.Face = face;
			//this.Back = back;
		}

		public Card( Card copy )
			//: this( copy.Value, copy.Face, copy.Back ) { }
			: this( copy.Value ) { }

		public Card WithValue( CardValue value ) =>
			new Card( value );//, this.Face, this.Back );
		//public Card WithFace( Texture2D face ) =>
		//	new Card( this.Value, face, this.Back );
		//public Card WithBack( Texture2D back ) =>
		//	new Card( this.Value, this.Face, back );

		public override bool Equals( object obj ) {
			if( obj is Card that )
				return this.Equals( that );

			return base.Equals( obj );
		}

		private int? _hash = null;
		private const int _bigPrime = 12641;
		private const int _littlePrime = 7717;
		public override int GetHashCode() {
			Func<object, int> SafeHashCode = ( obj ) =>
				obj is object ish
				? ish.GetHashCode()
				: 0;

			if( !_hash.HasValue ) {
				unchecked {
					_hash = _bigPrime;

					_hash = _hash * _littlePrime + SafeHashCode( this.Value );
					//_hash = _hash * _littlePrime + SafeHashCode( this.Face );
					//_hash = _hash * _littlePrime + SafeHashCode( this.Back );
				}
			}

			return _hash.Value;
		}

		public override string ToString() =>
			this.Value.ToString();

		public bool Equals( Card that ) {
			if( ReferenceEquals( that, null ) )
				return false;

			return this.Value == that.Value;
		}

		public static bool operator ==( Card left, Card right ) =>
			ReferenceEquals( left, null )
				? ReferenceEquals( right, null )
				: left.Equals( right );

		public static bool operator !=( Card left, Card right ) =>
			!( left == right );
	}
}