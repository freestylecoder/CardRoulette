using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CardRoulette.CardLib;
using System.Text;
using System.Linq;
using System;

namespace CardRoulette {
	public class Game1 : Game {
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		private Deck DeckOfCards;
		private SpriteFont DefaultFont;

		private TimeSpan ShuffleTimer;

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
			DeckOfCards = Deck.PokerDeck( false );
			ShuffleTimer = TimeSpan.Zero;
			base.Initialize();
		}

		protected override void LoadContent() {
			_spriteBatch = new SpriteBatch( GraphicsDevice );
			DefaultFont = Content.Load<SpriteFont>( "Default" );

			// TODO: use this.Content to load your game content here
		}

		protected override void Update( GameTime gameTime ) {
			if( GamePad.GetState( PlayerIndex.One ).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown( Keys.Escape ) )
				Exit();

			// TODO: Add your update logic here

			if( TimeSpan.FromSeconds( 3 ) > ShuffleTimer ) {
				ShuffleTimer += gameTime.ElapsedGameTime;
			} else {
				DeckOfCards.Shuffle();
				ShuffleTimer = TimeSpan.Zero;
			}

			base.Update( gameTime );
		}

		protected override void Draw( GameTime gameTime ) {
			GraphicsDevice.Clear( Color.Black );

			StringBuilder col1 = new StringBuilder();
			foreach( Card card in DeckOfCards.Take( 13 ) ) {
				col1.AppendLine( card.ToString() );
			}
			StringBuilder col2 = new StringBuilder();
			foreach( Card card in DeckOfCards.Skip( 13 ).Take( 13 ) ) {
				col2.AppendLine( card.ToString() );
			}
			StringBuilder col3 = new StringBuilder();
			foreach( Card card in DeckOfCards.Skip( 26 ).Take( 13 ) ) {
				col3.AppendLine( card.ToString() );
			}
			StringBuilder col4 = new StringBuilder();
			foreach( Card card in DeckOfCards.Skip( 39 ) ) {
				col4.AppendLine( card.ToString() );
			}

			_spriteBatch.Begin();
			_spriteBatch.DrawString( DefaultFont, col1, new Vector2( 0, 0 ), Color.White );
			_spriteBatch.DrawString( DefaultFont, col2, new Vector2( 480, 0 ), Color.White );
			_spriteBatch.DrawString( DefaultFont, col3, new Vector2( 960, 0 ), Color.White );
			_spriteBatch.DrawString( DefaultFont, col4, new Vector2( 1440, 0 ), Color.White );
			_spriteBatch.End();

			base.Draw( gameTime );
		}
	}
}
