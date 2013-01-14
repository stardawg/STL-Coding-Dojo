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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using JamesAllen.XmasLights.Classes;
using JamesAllen.XmasLights.Properties;

namespace JamesAllen.XmasLights
{
  /// <summary>
  /// Christmas Lights
  /// 
  /// The graphics are thanks to:
  /// http://www.webdesignerwall.com/general/free-christmas-icons-for-you/
  /// </summary>
  public partial class Main : Form
  {
    [DllImport("User32.dll")]
    private static extern IntPtr GetDC(IntPtr hwnd);

    [DllImport("User32.dll")]
    private static extern void ReleaseDC(IntPtr dc);

    private List<Light> lights;
    private List<LightCircuit> circuits;
    private Sequence programSequence;
    private delegate void InvalidateDelegate();
    private IntPtr desktopDC;

    /// <summary>
    /// Constructor.
    /// </summary>
    public Main()
    {
      InitializeComponent();
      InitializeLights();
      LoadSettings(); // Must be after initialize lights
      backgroundWorker.RunWorkerAsync();
      this.WindowState = FormWindowState.Minimized;
    }

    /// <summary>
    /// Destructor.
    /// </summary>
    ~Main()
    {
      if (desktopDC != null)
        ReleaseDC(desktopDC);
    }

    /// <summary>
    /// Load settings from the app.config file.
    /// </summary>
    private void LoadSettings()
    {
      switch(Settings.Default.Sequence)
      {
        case 0:
          programSequence = new AlternateSequence(circuits);
          break;

        case 1:
          programSequence = new ColorSequence(circuits);
          break;

        case 2:
          programSequence = new FlashSequence(circuits);
          break;
      }
    }

    /// <summary>
    /// Save settings to the app.config file.
    /// </summary>
    /// <param name="sequence"></param>
    private void SaveSettings(int sequence)
    {
      Settings.Default.Sequence = sequence;
      Settings.Default.Save();
    }

    private void InitializeLights()
    {
      // Get handle to desktop
      desktopDC = GetDC(IntPtr.Zero);

      // Create some objects
      lights = new List<Light>();
      circuits = new List<LightCircuit>();
      LightCircuit circuit1 = new LightCircuit();
      LightCircuit circuit2 = new LightCircuit();
      LightCircuit circuit3 = new LightCircuit();
      LightCircuit circuit4 = new LightCircuit();

      // Create list of lights
      int width = Screen.PrimaryScreen.Bounds.Width;
      for (int i = 0; i < width; i = i + 100)
      {
        switch ((i / 100) % 4)
        {
          case 0:
            lights.Add(new Light(i, 5, circuit1, Light.LightColor.Red, Light.LightShape.Oval));
            break;

          case 1:
            lights.Add(new Light(i, 5, circuit2, Light.LightColor.Green, Light.LightShape.Oval));
            break;

          case 2:
            lights.Add(new Light(i, 5, circuit3, Light.LightColor.Yellow, Light.LightShape.Oval));
            break;

          case 3:
            lights.Add(new Light(i, 5, circuit4, Light.LightColor.Purple, Light.LightShape.Oval));
            break;
        }
      }

      // Create light of light circuits
      circuits.Add(circuit1);
      circuits.Add(circuit2);
      circuits.Add(circuit3);
      circuits.Add(circuit4);
    }

    /// <summary>
    /// Handles the exit menu click.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mnuHandler_Click(object sender, EventArgs e)
    {
      ToolStripMenuItem item = (ToolStripMenuItem)sender;
      switch (item.Name)
      {
        case "mnuAlternate":
          SaveSettings(0);
          LoadSettings();
          break;

        case "mnuColors":
          SaveSettings(1);
          LoadSettings();
          break;

        case "mnuFlash":
          SaveSettings(2);
          LoadSettings();
          break;

        case "mnuExit":
          backgroundWorker.CancelAsync();
          Application.Exit();
          break;

        default:
          // todo - Maybe we should warn the user
          break;
      }
    }

    /// <summary>
    /// Paints onto the desktop.
    /// </summary>
    private void PaintDesktop()
    {
        BufferedGraphicsContext currentContext;
        BufferedGraphics myBuffer;
        currentContext = BufferedGraphicsManager.Current;

        myBuffer = currentContext.Allocate(Graphics.FromHdc(desktopDC), new Rectangle(0, 0, Screen.PrimaryScreen.Bounds.Width, 50));
      
        var g = myBuffer.Graphics;
      {
        using (Pen pen = new Pen(Brushes.Green))
        {
          // For each light
          foreach (Light light in lights)
          {
            // Draw light
            //light.Paint(g);
              ILightView lightView = new LightViewWindows(g);
              lightView.Paint(light);

            // Draw wire
            Point p1 = new Point(light.Position.X + 20, light.Position.Y);
            Point p2 = new Point(p1.X + 50, p1.Y + 20);
            Point p3 = new Point(p1.X + 100, p1.Y);
            g.DrawCurve(pen, new Point[] { p1, p2, p3 }, 1);
          }
        }
      }
        myBuffer.Render();
    }

    /// <summary>
    /// Forces the app to repaint periodically and switchs circuits on/off.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      while (!backgroundWorker.CancellationPending)
      {
        // Flash circuits
        programSequence.Next();

        // Repaint
        PaintDesktop();

        // Sleep
        Thread.Sleep(500);
      }
    }
  }
}
