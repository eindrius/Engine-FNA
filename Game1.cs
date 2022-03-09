using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace GameEngine
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics; //da acesso às configurações gráficas do PC que está rodando esse jogo, como resoluções por ex.
        SpriteBatch spriteBatch; //pega todos os sprites diferentes e enfileira eles em um só batch e executar eles em uma iteration.

        Texture2D image;
        Vector2 position;
        public Game1() //Constructor, chamada toda vez que a classe game é criada. 
        {
            graphics = new GraphicsDeviceManager(this); 
            Content.RootDirectory = "Content"; //seta a pasta raiz pro gerenciador de conteúdo. 
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
            graphics.IsFullScreen = false;
            
        }

        protected override void Initialize() //inicializa as variáveis não gráficas, tipo string, variáveis de data etc
        {
            position = new Vector2(800, 450);
            base.Initialize(); 
        }
        protected override void LoadContent() //carrega o conteúdo gráfico do jogo e game assets como audio
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            image = TextureLoader.Load("sprite", Content);
        }
        protected override void Update(GameTime gameTime) //executado em cada frame do jogo, geralmente em 60fps, cada frame roda as lógicas do jogo, como colisão, updates no mundo, etc. 
        {
            Input.Update();

            if (Input.IsKeyDown(Keys.D) == true)
                position.X += 5;
            else if (Input.IsKeyDown(Keys.A) == true)
                position.X -= 5;
            if (Input.IsKeyDown(Keys.S) == true)
                position.Y += 5;
            else if (Input.IsKeyDown(Keys.W) == true)
                position.Y -= 5;
                            
            base.Update(gameTime); //faz os updates das funções que o FNA roda no background
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black); //seta cor de fundo no executável e da clear nos frames passados. executa a cada 1 frame.

            spriteBatch.Begin();
            //entre esses dois comandos, serão chamados todos os sprites que o jogo tiver
            spriteBatch.Draw(image, position, Color.White);
            spriteBatch.End();
            
            base.Draw(gameTime); //chama os updates que o FNA faz no background

        }
    }

}
