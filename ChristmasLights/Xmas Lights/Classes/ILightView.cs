using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace JamesAllen.XmasLights.Classes
{
    public interface ILightView
    {
        void Paint(Light light);
    }
}
