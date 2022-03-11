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
    public class GameObject
    {
        protected Texture2D image;
        public Vector2 position;
        public Color drawColor = Color.White;
        //permite dar escala para os objetos
        public float scale = 1f, rotation = 0f; 
        //controla a profundidade das imagens
        public float layerDepth = .5f;
        //ativa e desativa os objetos da tela. Ex: caso tu destrua algo, tu pode desativar pra tirar da tela
        public bool active = true; 
        protected Vector2 center;

        public GameObject()
        {

        }

        public virtual void Initialize()
        {

        }
        //carrega os objetos, sprites, etc. conforme solicitado
        public virtual void Load(ContentManager content) 
        {
            CalculateCenter();

        }

        //lista os objetos do game
        public virtual void Update(List<GameObject> objects) 
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (image != null && active == true)
                spriteBatch.Draw(image, position, null, drawColor, rotation, Vector2.Zero, scale, SpriteEffects.None, layerDepth);
        }
        
        //calcula o centro do objeto/sprite/etc toda vez que ele é carregado
        private void CalculateCenter() 
        {
            if (image == null)
                return;
            center.X = image.Width / 2;
            center.Y = image.Height / 2;
        }
    }
}
