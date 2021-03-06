﻿///
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
  /// Alternates between odd and even numbered lights.
  /// </summary>
  class AlternateSequence : Sequence
  {
    bool evenOn = false;

    public AlternateSequence(List<LightCircuit> circuits)
      : base(circuits)
    {
      TurnCircuitsOff();
    }

    public override void Next()
    {
      for (int i = 0; i < circuits.Count; i++)
      {
        if (i % 2 == 0)
          circuits[i].HasPower = evenOn;
        else
          circuits[i].HasPower = !evenOn;
      }
      evenOn = !evenOn;
    }
  }
}
