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
    //herda tudo da classe GameObject
    public class Player : GameObject 
    {
        public Player()
        {

        }

        public Player(Vector2 inputPosition)
        {
            position = inputPosition;

        }
        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Load(ContentManager content)
        {
            image = TextureLoader.Load("sprite", content);
            base.Load(content);
        }

        public override void Update(List<GameObject> objects)
        {
            CheckInput();
            base.Update(objects);
        }
        
        public void CheckInput()
        {
            if (Input.IsKeyDown(Keys.D) == true)
                position.X += 5;
            else if (Input.IsKeyDown(Keys.A) == true)
                position.X -= 5;
            if (Input.IsKeyDown(Keys.S) == true)
                position.Y += 5;
            else if (Input.IsKeyDown(Keys.W) == true)
                position.Y -= 5;
        }
    }
}
