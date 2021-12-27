using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CardRoulette.CardLib;
using System.Text;
using System.Linq;
using System;
using System.Collections.Generic;

namespace CardRoulette {
	public class Game1 : Game {
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		private Deck DeckOfCards;
		private Deck DiscardPile;

		private int PlayerChips;
		private IList<Bet> Bets;
		private Vector2 CursorPosition;
		private IEnumerable<Vector2> Points;

		private Texture2D Cursor;
		private Texture2D FullBoard;

		private SpriteFont DefaultFont;

		private KeyboardState LastKeyboardState;

		private TimeSpan DrawTimer;

		public Game1() {
			_graphics = new GraphicsDeviceManager( this );
			_graphics.IsFullScreen = false;
			_graphics.PreferredBackBufferWidth = 1920;
			_graphics.PreferredBackBufferHeight = 1080;
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize() {
			// TODO: Add your initialization logic here

			PlayerChips = 100;
			Bets = new List<Bet>();
			DeckOfCards = new Deck();
			DiscardPile = Deck.PokerDeck( false );
			LastKeyboardState = Keyboard.GetState();

			DrawTimer = TimeSpan.FromSeconds( 3 );
			base.Initialize();
		}

		protected override void LoadContent() {
			_spriteBatch = new SpriteBatch( GraphicsDevice );

			// TODO: use this.Content to load your game content here
			DefaultFont = Content.Load<SpriteFont>( "Default" );

			Cursor = Content.Load<Texture2D>( "Cursor" );
			FullBoard = Content.Load<Texture2D>( "FullBoard" );

			Color[] colors = new Color[FullBoard.Width*FullBoard.Height];
			FullBoard.GetData( colors );
			IEnumerable<int> blah = colors
				.Select( ( c, i ) => ( i, c.R, c.A ) )
				.Where( x => x.R == 0 && x.A == 255 )
				.Select( x => x.i );

			Points = blah
				.Select( t => new Vector2( t % FullBoard.Width, t / FullBoard.Width ) );

			FullBoard.SetData(
				colors
					.Select( c => new Color( c.A == 0 ? 0 : 255, c.G, c.B, c.A ) )
					.ToArray()
			);

			CursorPosition = Points.First();
		}

		protected override void Update( GameTime gameTime ) {
			if( GamePad.GetState( PlayerIndex.One ).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown( Keys.Escape ) )
				Exit();

			Func<Keys,bool> KeyWasPressed = ( key ) =>
				Keyboard.GetState().IsKeyDown( key ) && LastKeyboardState.IsKeyUp( key );

			Func<bool> ShiftDown = () =>
				Keyboard.GetState()
					.GetPressedKeys()
					.Intersect( new[] { Keys.LeftShift, Keys.RightShift } )
					.Any();

			Action<int> UpdateBets = ( betAmount ) => {
				Bet bet = Bets.FirstOrDefault( b => b.Position == CursorPosition );
				if( null == bet ) {
					if( !ShiftDown() ) {
						if( PlayerChips >= betAmount ) {
							PlayerChips -= betAmount;
							Bets.Add( new Bet( betAmount, CursorPosition ) );
						}
					}
				} else {
					if( ShiftDown() ) {
						PlayerChips += Math.Min( bet.Amount, betAmount );
						bet.Amount -= betAmount;
						if( bet.Amount < 1 ) Bets.Remove( bet );
					} else {
						if( PlayerChips >= betAmount ) {
							PlayerChips -= betAmount;
							bet.Amount += betAmount;
						}
					}
				}
			};

			Vector2 FindClosest( IEnumerable<Vector2> possible ) {
				return possible.Any()
					? possible
						.Select( p => (Vector2.Distance( CursorPosition, p ), p) )
						.OrderBy( t => t.Item1 )
						.First()
						.Item2
					: CursorPosition;
			}

			if( KeyWasPressed( Keys.Right ) || KeyWasPressed( Keys.D ) ) {
				CursorPosition = FindClosest(
					Points.Any( p => p.Y == CursorPosition.Y && p.X > CursorPosition.X )
						? Points
							.Where( p => p.Y == CursorPosition.Y )
							.Where( p => p.X > CursorPosition.X )
						: Points
							.Where( p => p.X > CursorPosition.X )
				);
			}

			if( KeyWasPressed( Keys.Left ) || KeyWasPressed( Keys.A ) ) {
				CursorPosition = FindClosest(
					Points.Any( p => p.Y == CursorPosition.Y && p.X < CursorPosition.X )
						? Points
							.Where( p => p.Y == CursorPosition.Y )
							.Where( p => p.X < CursorPosition.X )
						: Points
							.Where( p => p.X < CursorPosition.X )
				);
			}

			if( KeyWasPressed( Keys.Up ) || KeyWasPressed( Keys.W ) ) {
				CursorPosition = FindClosest(
					Points.Any( p => p.X == CursorPosition.X && p.Y < CursorPosition.Y )
						? Points
							.Where( p => p.X == CursorPosition.X )
							.Where( p => p.Y < CursorPosition.Y )
						: Points
							.Where( p => p.Y < CursorPosition.Y )
				);
			}

			if( KeyWasPressed( Keys.Down ) || KeyWasPressed( Keys.S ) ) {
				CursorPosition = FindClosest(
					Points.Any( p => p.X == CursorPosition.X && p.Y > CursorPosition.Y )
						? Points
							.Where( p => p.X == CursorPosition.X )
							.Where( p => p.Y > CursorPosition.Y )
						: Points
							.Where( p => p.Y > CursorPosition.Y )
				);
			}

			// 1 - White - $1
			if( KeyWasPressed( Keys.D1 ) || KeyWasPressed( Keys.NumPad1 ) ) UpdateBets( 1 );

			// 2 - Red - $5
			if( KeyWasPressed( Keys.D2 ) || KeyWasPressed( Keys.NumPad2 ) ) UpdateBets( 5 );

			// 3 - Blue - $10
			if( KeyWasPressed( Keys.D3 ) || KeyWasPressed( Keys.NumPad3 ) ) UpdateBets( 10 );

			// 4 - Green - $25
			if( KeyWasPressed( Keys.D4 ) || KeyWasPressed( Keys.NumPad4 ) ) UpdateBets( 25 );

			if( KeyWasPressed( Keys.Z ) ) {
				UpdateBets( PlayerChips );
			}

			if( KeyWasPressed( Keys.X ) ) {
				Bet bet = Bets.LastOrDefault( b => b.Position == CursorPosition );
				PlayerChips += bet?.Amount ?? 0;
				Bets.Remove( bet );
			}

			//if( TimeSpan.FromMilliseconds( 100 ) > DrawTimer ) {
			//	DrawTimer += gameTime.ElapsedGameTime;
			//} else {
			//	if( !DeckOfCards.Any() ) {
			//		DeckOfCards.Join( DiscardPile );

			//		DeckOfCards.Shuffle();
			//		DeckOfCards.Shuffle();
			//		DeckOfCards.Shuffle();
			//		DeckOfCards.Shuffle();
			//		DeckOfCards.Shuffle();
			//		DeckOfCards.Shuffle();
			//		DeckOfCards.Shuffle();
			//	}

			//	DiscardPile.Append( DeckOfCards.Deal() );
			//	DrawTimer = TimeSpan.Zero;
			//	CalculateOdds( DeckOfCards );
			//}

			LastKeyboardState = Keyboard.GetState();
			base.Update( gameTime );
		}

		protected override void Draw( GameTime gameTime ) {
			GraphicsDevice.Clear( new Color( 15, 109, 57, 255 ) );

			int CenterX = ( GraphicsDevice.Viewport.Width / 2 );
			int CenterY = ( GraphicsDevice.Viewport.Height / 2 );

			Vector2 boardCorner = new Vector2(
				CenterX - ( FullBoard.Width / 2f ),
				CenterY - ( FullBoard.Height / 2f )
			);
			Vector2 trueCursorPos = boardCorner + CursorPosition;

			Vector2 cursorCenter = new Vector2(
				( Cursor.Width / 2f ),
				( Cursor.Height / 2f )
			);

			_spriteBatch.Begin();
			_spriteBatch.Draw( FullBoard, boardCorner, Color.White );

			foreach( Bet bet in Bets )
				_spriteBatch.Draw( Cursor, bet.Position + boardCorner, null, Color.White, 0f, cursorCenter, 1f, SpriteEffects.None, 1f );

			_spriteBatch.Draw( Cursor, trueCursorPos, null, Color.FromNonPremultiplied( 0, 255, 0, 127 ), 0f, cursorCenter, 1f, SpriteEffects.None, 1f );

			_spriteBatch.DrawString( DefaultFont, trueCursorPos.ToString(), new Vector2( CenterX, 0 ), Color.White );
			_spriteBatch.DrawString(
				DefaultFont,
				$@"Player Chips: {PlayerChips}
Current Bet : {Bets.Where( b => b.Position == CursorPosition ).Sum( b => b.Amount )}
Total Bets  : {Bets.Sum( b => b.Amount )}",
				Vector2.Zero,
				Color.White
			);

			_spriteBatch.End();

			base.Draw( gameTime );
		}
	}
}
