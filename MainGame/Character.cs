using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MainGame
{
    public enum EntityLinkType
    {
        Rigid = 0,
        Elastic
    }

    public class EntityNode
    {
        // This should be configurable
        private const string _textureName = "body-test";
        public IList<EntityNode> Links { get; set; }
        public Texture2D Texture { get; set; }
        public EntityLinkType LinkType { get; set; }
        public Vector2 RelativePos { get; set; }

        public void LoadContent(ContentManager cm)
        {
            this.Texture = cm.Load<Texture2D>(EntityNode._textureName);
            foreach (var node in this.Links)
            {
                node.LoadContent(cm);
            }
        }

        public void Draw(SpriteBatch sb, Vector2 parentPos)
        {
            sb.Draw(Texture, RelativePos + parentPos, Color.White);
            foreach (var node in this.Links)
            {
                node.Draw(sb, RelativePos + parentPos);
            }
        }
    }
}