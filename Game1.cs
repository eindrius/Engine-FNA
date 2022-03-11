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
        //da acesso às configurações gráficas do PC que está rodando esse jogo, como resoluções por ex.
        //pega todos os sprites diferentes e enfileira eles em um só batch e executar eles em uma iteration.
        GraphicsDeviceManager graphics; 
        SpriteBatch spriteBatch; 

        public List<GameObject> objects = new List<GameObject>();
        
        public Game1() 
        {
            graphics = new GraphicsDeviceManager(this); 
            Content.RootDirectory = "Content"; //seta a pasta raiz pro gerenciador de conteúdo. 
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
            graphics.IsFullScreen = false;
            
        }
       
        //inicializa as variáveis não gráficas(string, variáveis de data etc)
        protected override void Initialize() 
        {
            base.Initialize(); 
        }

        //carrega o conteúdo gráfico do jogo e game assets como audio
        protected override void LoadContent() 
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            LoadLevel();
        }

        //executado em cada frame do jogo, geralmente em 60fps,
        //cada frame roda as lógicas do jogo, como colisão, updates no mundo, etc. 
        protected override void Update(GameTime gameTime) 
        {
            Input.Update();
                                   
            base.Update(gameTime); //faz os updates das funções que o FNA roda no background
        }
        protected override void Draw(GameTime gameTime)
        {
            //seta cor de fundo no executável e da clear nos frames passados. executa a cada 1 frame.
            GraphicsDevice.Clear(Color.Black);
            //faz os sprites serem carregados do fundo para a frente onde 0 mais longe, 1 mais perto da tela
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend); 
            DrawObjects();           
            spriteBatch.End();
            //chama os updates que o FNA faz no background
            base.Draw(gameTime); 

        }

        public void LoadLevel()
        {
            objects.Add(new Player(new Vector2(800, 450)));
            LoadObjects();

        }

        public void LoadObjects()
        {
            for (int i = 0; i <objects.Count; i++)
            {
                objects[i].Initialize();
                objects[i].Load(Content);
            }

        }
        public void UpdateObjects()
        {
            for (int i = 0; i<objects.Count; i++)
            {
                objects[i].Update(objects);
            }
        }

        public void DrawObjects()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Draw(spriteBatch);
            }
        }
    }

}
