using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Borderlands2D
{
    class TextureManager
    {
        private static readonly Dictionary<string, Texture2D> TEXTURES = new Dictionary<string, Texture2D>(); 

        public static void LoadContent(ContentManager cm, string textureDir)
        {
            if(string.IsNullOrEmpty(textureDir))
                throw new ArgumentException("textureDir must not be null or empty!");

            foreach (var dir in Directory.GetDirectories(textureDir))
                LoadContent(cm, dir);

            foreach (var file in Directory.GetFiles(textureDir).Where(file => Regex.IsMatch(file, "\\.png|\\.jpeg")))
                TEXTURES.Add(file.Split('.')[0].Substring(textureDir.Length+1), cm.Load<Texture2D>(file));
        }

        public static Texture2D Get(string path)
        {
            if(!TEXTURES.ContainsKey(path))
                throw new ArgumentException("No Texture found for path: " + path);
            return TEXTURES[path];
        }
    }
}
