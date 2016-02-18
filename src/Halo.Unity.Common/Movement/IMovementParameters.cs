using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Halo.Unity.Common
{
	/// <summary>
	/// Provides movement parameters.
	/// Allows for abstraction of input source (Network/Local/Rewind)
	/// </summary>
	public interface IMovementParameters
	{
		/// <summary>
		/// Desired Jump intensity.
		/// </summary>
		float JumpIntensity { get; }

		/// <summary>
		/// Desired movement speed.
		/// </summary>
		float MovementSpeed { get; }
    }
}
