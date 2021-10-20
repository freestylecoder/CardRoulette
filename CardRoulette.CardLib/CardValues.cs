namespace CardRoulette.CardLib {
	public enum CardValues {
		TwoOfClubs			= Ranks.Two		| Suits.Clubs,
		ThreeOfClubs		= Ranks.Three	| Suits.Clubs,
		FourOfClubs			= Ranks.Four	| Suits.Clubs,
		FiveOfClubs			= Ranks.Five	| Suits.Clubs,
		SixOfClubs			= Ranks.Six		| Suits.Clubs,
		SevenOfClubs		= Ranks.Seven	| Suits.Clubs,
		EightOfClubs		= Ranks.Eight	| Suits.Clubs,
		NineOfClubs			= Ranks.Nine	| Suits.Clubs,
		TenOfClubs			= Ranks.Ten		| Suits.Clubs,
		JackOfClubs			= Ranks.Jack	| Suits.Clubs,
		QueenOfClubs		= Ranks.Queen	| Suits.Clubs,
		KingOfClubs			= Ranks.King	| Suits.Clubs,
		AceOfClubs			= Ranks.Ace		| Suits.Clubs,
		TwoOfDiamonds		= Ranks.Two		| Suits.Diamonds,
		ThreeOfDiamonds		= Ranks.Three	| Suits.Diamonds,
		FourOfDiamonds		= Ranks.Four	| Suits.Diamonds,
		FiveOfDiamonds		= Ranks.Five	| Suits.Diamonds,
		SixOfDiamonds		= Ranks.Six		| Suits.Diamonds,
		SevenOfDiamonds		= Ranks.Seven	| Suits.Diamonds,
		EightOfDiamonds		= Ranks.Eight	| Suits.Diamonds,
		NineOfDiamonds		= Ranks.Nine	| Suits.Diamonds,
		TenOfDiamonds		= Ranks.Ten		| Suits.Diamonds,
		JackOfDiamonds		= Ranks.Jack	| Suits.Diamonds,
		QueenOfDiamonds		= Ranks.Queen	| Suits.Diamonds,
		KingOfDiamonds		= Ranks.King	| Suits.Diamonds,
		AceOfDiamonds		= Ranks.Ace		| Suits.Diamonds,
		TwoOfHearts			= Ranks.Two		| Suits.Hearts,
		ThreeOfHearts		= Ranks.Three	| Suits.Hearts,
		FourOfHearts		= Ranks.Four	| Suits.Hearts,
		FiveOfHearts		= Ranks.Five	| Suits.Hearts,
		SixOfHearts			= Ranks.Six		| Suits.Hearts,
		SevenOfHearts		= Ranks.Seven	| Suits.Hearts,
		EightOfHearts		= Ranks.Eight	| Suits.Hearts,
		NineOfHearts		= Ranks.Nine	| Suits.Hearts,
		TenOfHearts			= Ranks.Ten		| Suits.Hearts,
		JackOfHearts		= Ranks.Jack	| Suits.Hearts,
		QueenOfHearts		= Ranks.Queen	| Suits.Hearts,
		KingOfHearts		= Ranks.King	| Suits.Hearts,
		AceOfHearts			= Ranks.Ace		| Suits.Hearts,
		TwoOfSpades			= Ranks.Two		| Suits.Spades,
		ThreeOfSpades		= Ranks.Three	| Suits.Spades,
		FourOfSpades		= Ranks.Four	| Suits.Spades,
		FiveOfSpades		= Ranks.Five	| Suits.Spades,
		SixOfSpades			= Ranks.Six		| Suits.Spades,
		SevenOfSpades		= Ranks.Seven	| Suits.Spades,
		EightOfSpades		= Ranks.Eight	| Suits.Spades,
		NineOfSpades		= Ranks.Nine	| Suits.Spades,
		TenOfSpades			= Ranks.Ten		| Suits.Spades,
		JackOfSpades		= Ranks.Jack	| Suits.Spades,
		QueenOfSpades		= Ranks.Queen	| Suits.Spades,
		KingOfSpades		= Ranks.King	| Suits.Spades,
		AceOfSpades			= Ranks.Ace		| Suits.Spades,
		LittleJoker			= Ranks.Little	| Suits.Joker,
		BigJoker			= Ranks.Big		| Suits.Joker
	}

	public static class CardValueExtensions {
		public static Suits GetSuit( this CardValues value ) =>
			(Suits)((int)value & 0x111);

		public static Ranks GetRank( this CardValues value ) =>
			(Ranks)((int)value & 0x1111000);

		public static CardValues ComposeCardValue( Ranks rank, Suits suit ) =>
			(CardValues)( (int)rank | (int)suit );
	}
}
