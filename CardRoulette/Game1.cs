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

		private Vector2 CursorPosition;
		private IEnumerable<Vector2> Points;

		private Texture2D Cursor;
		private Texture2D FullBoard;
		private Texture2D WhiteSquare;

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
			WhiteSquare = Content.Load<Texture2D>( "WhiteSquare" );

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
			//CursorPosition = new Vector2( 360 - 12.5F, 340 - 12.5F );
		}

		protected override void Update( GameTime gameTime ) {
			if( GamePad.GetState( PlayerIndex.One ).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown( Keys.Escape ) )
				Exit();

			Func<Keys,bool> KeyWasPressed = ( key ) =>
				Keyboard.GetState().IsKeyDown( key ) && LastKeyboardState.IsKeyUp( key );

			Func<IEnumerable<Vector2>,Vector2> FindClosest = ( possible ) =>
				possible.Any()
					? possible
						.Select( p => ( Vector2.Distance( CursorPosition, p ), p ) )
						.OrderBy( t => t.Item1 )
						.First()
						.Item2
					: CursorPosition;

			if( KeyWasPressed( Keys.Right ) ) {
				CursorPosition = FindClosest(
					Points.Any( p => p.Y == CursorPosition.Y && p.X > CursorPosition.X )
						? Points
							.Where( p => p.Y == CursorPosition.Y )
							.Where( p => p.X > CursorPosition.X )
						: Points
							.Where( p => p.X > CursorPosition.X )
				);
			}

			if( KeyWasPressed( Keys.Left ) ) {
				CursorPosition = FindClosest(
					Points.Any( p => p.Y == CursorPosition.Y && p.X < CursorPosition.X )
						? Points
							.Where( p => p.Y == CursorPosition.Y )
							.Where( p => p.X < CursorPosition.X )
						: Points
							.Where( p => p.X < CursorPosition.X )
				);
			}

			if( KeyWasPressed( Keys.Up ) ) {
				CursorPosition = FindClosest(
					Points.Any( p => p.X == CursorPosition.X && p.Y < CursorPosition.Y )
						? Points
							.Where( p => p.X == CursorPosition.X )
							.Where( p => p.Y < CursorPosition.Y )
						: Points
							.Where( p => p.Y < CursorPosition.Y )
				);
			}

			if( KeyWasPressed( Keys.Down ) ) {
				CursorPosition = FindClosest(
					Points.Any( p => p.X == CursorPosition.X && p.Y > CursorPosition.Y )
						? Points
							.Where( p => p.X == CursorPosition.X )
							.Where( p => p.Y > CursorPosition.Y )
						: Points
							.Where( p => p.Y > CursorPosition.Y )
				);
			}

			// TODO: Add your update logic here

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

		private void CalculateOdds( Deck deck ) {
			IDictionary<Ranks,int> ranks = new Dictionary<Ranks, int>( 
				Enum.GetValues( typeof( Ranks ) )
					.OfType<Ranks>()
					.Select(
						r => new KeyValuePair<Ranks,int>(
							r,
							deck.Count( c => r == c.Value.GetRank() )
						)
					)
			);

			IDictionary<Suits,int> suits = new Dictionary<Suits, int>( 
				Enum.GetValues( typeof( Suits ) )
					.OfType<Suits>()
					.Select(
						s => new KeyValuePair<Suits,int>(
							s,
							deck.Count( c => s == c.Value.GetSuit() )
						)
					)
			);

			int red = deck.Count( c =>
				new[] { Suits.Hearts, Suits.Diamonds }
					.Contains( c.Value.GetSuit() )
			);
			int black = deck.Count( c =>
				new[] { Suits.Clubs, Suits.Spades }
					.Contains( c.Value.GetSuit() )
			);

			return;
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
			_spriteBatch.Draw( Cursor, trueCursorPos, null, Color.White, 0f, cursorCenter, 1f, SpriteEffects.None, 1f );

			_spriteBatch.DrawString( DefaultFont, trueCursorPos.ToString(), Vector2.Zero, Color.White );
			_spriteBatch.End();

			base.Draw( gameTime );
		}
	}
}
