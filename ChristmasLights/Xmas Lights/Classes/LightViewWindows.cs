using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace JamesAllen.XmasLights.Classes
{
    public class LightViewWindows : ILightView
    {
        Graphics graphics;

        public LightViewWindows(Graphics graphics)
        {
            this.graphics = graphics;
        }

        public void Paint(Light light)
        {
            graphics.DrawImage(light.Image, light.Position);
        }
    }
}
