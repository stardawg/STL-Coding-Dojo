///
/// Copyright © 2010 James Allen
///
/// This program is free software; you can redistribute it and/or modify
/// it under the terms of the GNU General Public License as published by
/// the Free Software Foundation; either version 2 of the License, or
/// (at your option) any later version.
///
/// This program is distributed in the hope that it will be useful,
/// but WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
/// GNU General Public License for more details.
///
/// You should have received a copy of the GNU General Public License
/// along with this program; if not, write to the Free Software
/// Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301 USA
///
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

namespace JamesAllen.XmasLights.Classes
{
  /// <summary>
  /// Represents an instance of a christmas tree light.
  /// </summary>
  public class Light
  {
    public enum LightColor { Red, Green, Yellow, Blue, Purple };
    public enum LightShape { Oval };
    private Image imageOn;
    private Image imageOff;
    private Point position;
    private LightCircuit circuit;
    private LightColor color;
    private LightShape shape;
    
    public Point Position
    {
      get { return position; }
      set { position = value; }
    }

    public Image Image
    {
      get
      {
        if (circuit.HasPower)
          return imageOn;
        else
          return imageOff;
      }
    }

    public Light(int x, int y, LightCircuit circuit, LightColor color, LightShape shape)
    {
      Assembly assembly = Assembly.GetExecutingAssembly();
      string lightName = Enum.GetName(color.GetType(), color).ToLower();
      string resourceOn = string.Format("JamesAllen.XmasLights.Images.{0}_on.png", lightName);
      string resourceOff = string.Format("JamesAllen.XmasLights.Images.{0}_off.png", lightName);
      Stream streamOn = assembly.GetManifestResourceStream(resourceOn);
      Stream streamOff = assembly.GetManifestResourceStream(resourceOff);
      imageOn = (Image)Bitmap.FromStream(streamOn);
      imageOff = (Image)Bitmap.FromStream(streamOff);
      this.position = new Point(x, y);
      this.circuit = circuit;
      this.color = color;
      this.shape = shape;
    }

    public void Paint(Graphics g)
    {
      g.DrawImage(this.Image, this.Position);
    }
  }
}
