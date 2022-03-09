using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    public static class Input //Static classes can easily be accessed anywhere in our codebase. They always stay in memory so you should only do it for universal things like input.
    {
        private static KeyboardState keyboardState = Keyboard.GetState();
        private static KeyboardState lastKeyboardState;

        private static MouseState mouseState;
        private static MouseState lastMouseState;

        public static void Update()
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            lastMouseState = mouseState;
            mouseState = Mouse.GetState();
        }

        /// Checa se a tecla está pressionada        
        public static bool IsKeyDown(Keys input)
        {
            return keyboardState.IsKeyDown(input);
        }

        
        /// Checa se a tecla está sem ser pressionada               
        public static bool IsKeyUp(Keys input)
        {
            return keyboardState.IsKeyUp(input);
        }

        
        /// Verifica se o botão foi pressionado, se sim, evita que ele continue executando o comando
        /// evitando mudança de opção infinita        
        public static bool KeyPressed(Keys input)
        {
            if (keyboardState.IsKeyDown(input) == true && lastKeyboardState.IsKeyDown(input) == false)
                return true;
            else
                return false;
        }

        
        /// Retorna se o botão esquerdo do mouse está ou não pressionado        
        public static bool MouseLeftDown()
        {
            if (mouseState.LeftButton == ButtonState.Pressed)
                return true;
            else
                return false;
        }

        /// Retorna se o botão direito do mouse está ou não pressionado      
        public static bool MouseRightDown()
        {
            if (mouseState.RightButton == ButtonState.Pressed)
                return true;
            else
                return false;
        }

       
        /// Checa se houve click no botão esquerdo      
        public static bool MouseLeftClicked()
        {
            if (mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released)
                return true;
            else
                return false;
        }

        
        /// Checa se houve click no botão direito        
        public static bool MouseRightClicked()
        {
            if (mouseState.RightButton == ButtonState.Pressed && lastMouseState.RightButton == ButtonState.Released)
                return true;
            else
                return false;
        }

       
        /// Ajusta as coordenadas do mouse para virtual resolution e posição de cam.       
        public static Vector2 MousePositionCamera()
        {
            Vector2 mousePosition = Vector2.Zero;
            mousePosition.X = mouseState.X;
            mousePosition.Y = mouseState.Y;

            return ScreenToWorld(mousePosition);
        }

        
        /// pega a última posição do mouse e ajusta pra virtual resolution e posição da cam        
        public static Vector2 LastMousePositionCamera()
        {
            Vector2 mousePosition = Vector2.Zero;
            mousePosition.X = lastMouseState.X;
            mousePosition.Y = lastMouseState.Y;

            return ScreenToWorld(mousePosition);
        }

       
        /// Pega as coordenadas da tela (posição 2d aonde o mouse está na tela)
        /// e converte para uma posição no mundo (aonde tu clicou no mundo, tipo o mapa do terraria).         
        private static Vector2 ScreenToWorld(Vector2 input)
        {
            input.X -= Resolution.VirtualViewportX;
            input.Y -= Resolution.VirtualViewportY;

            return Vector2.Transform(input, Matrix.Invert(Camera.GetTransformMatrix()));
        }
    }
}
