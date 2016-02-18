using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halo.Unity.Common
{
	/// <summary>
	/// Implementer is a simulation object that can be stepped forward in time.
	/// </summary>
	public interface ITimeSimulation
	{
		/// <summary>
		/// Simulate forward by the desired delta.
		/// </summary>
		/// <param name="dt">Time delta.</param>
        void Simulate(float dt);
	}
}
