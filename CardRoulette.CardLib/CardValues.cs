namespace CardRoulette.CardLib {
	public enum CardValues {
		TwoOfClubs			= 0x0001000,
		ThreeOfClubs		= 0x0010000,
		FourOfClubs			= 0x0011000,
		FiveOfClubs			= 0x0100000,
		SixOfClubs			= 0x0101000,
		SevenOfClubs		= 0x0110000,
		EightOfClubs		= 0x0111000,
		NineOfClubs			= 0x1000000,
		TenOfClubs			= 0x1001000,
		JackOfClubs			= 0x1010000,
		QueenOfClubs		= 0x1011000,
		KingOfClubs			= 0x1100000,
		AceOfClubs			= 0x1101000,
		TwoOfDiamonds		= 0x0001001,
		ThreeOfDiamonds		= 0x0010001,
		FourOfDiamonds		= 0x0011001,
		FiveOfDiamonds		= 0x0100001,
		SixOfDiamonds		= 0x0101001,
		SevenOfDiamonds		= 0x0110001,
		EightOfDiamonds		= 0x0111001,
		NineOfDiamonds		= 0x1000001,
		TenOfDiamonds		= 0x1001001,
		JackOfDiamonds		= 0x1010001,
		QueenOfDiamonds		= 0x1011001,
		KingOfDiamonds		= 0x1100001,
		AceOfDiamonds		= 0x1101001,
		TwoOfHearts			= 0x0001010,
		ThreeOfHearts		= 0x0010010,
		FourOfHearts		= 0x0011010,
		FiveOfHearts		= 0x0100010,
		SixOfHearts			= 0x0101010,
		SevenOfHearts		= 0x0110010,
		EightOfHearts		= 0x0111010,
		NineOfHearts		= 0x1000010,
		TenOfHearts			= 0x1001010,
		JackOfHearts		= 0x1010010,
		QueenOfHearts		= 0x1011010,
		KingOfHearts		= 0x1100010,
		AceOfHearts			= 0x1101010,
		TwoOfSpades			= 0x0001011,
		ThreeOfSpades		= 0x0010011,
		FourOfSpades		= 0x0011011,
		FiveOfSpades		= 0x0100011,
		SixOfSpades			= 0x0101011,
		SevenOfSpades		= 0x0110011,
		EightOfSpades		= 0x0111011,
		NineOfSpades		= 0x1000011,
		TenOfSpades			= 0x1001011,
		JackOfSpades		= 0x1010011,
		QueenOfSpades		= 0x1011011,
		KingOfSpades		= 0x1100011,
		AceOfSpades			= 0x1101011,
		LittleJoker			= 0x1110100,
		BigJoker			= 0x1111100
	}
}
/*
0x0aaaabbb

bbb = suit
100 = Joker
011 = Spades
010 = Hearts
001 = Diamonds
000 = Clubs

aaaa = rank
0010 = 2
...
0110 = 10

1000 = Jack
1001 = Queen
1010 = King
1011 = Ace

1100 = Small
1101 = Big
*/
