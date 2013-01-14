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
using System.Collections.Generic;

namespace JamesAllen.XmasLights.Classes
{
  /// <summary>
  /// Represents a particular pattern of lighting.
  /// </summary>
  abstract class Sequence
  {
    protected List<LightCircuit> circuits;

    public Sequence(List<LightCircuit> circuits)
    {
      this.circuits = circuits;
    }

    /// <summary>
    /// Turns all circuits off.
    /// </summary>
    protected void TurnCircuitsOff()
    {
      foreach (LightCircuit circuit in circuits)
      {
        circuit.HasPower = false;
      }
    }

    /// <summary>
    /// Turns all circuits off.
    /// </summary>
    protected void TurnCircuitsOn()
    {
      foreach (LightCircuit circuit in circuits)
      {
        circuit.HasPower = true;
      }
    }

    public abstract void Next();
  }
}
