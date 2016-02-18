using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halo.Unity.Common
{
	/// <summary>
	/// Provides movement input services.
	/// Allows for abstraction of input source (Network/Local/Rewind)
	/// </summary>
	public interface IMovementInput
	{
		/// <summary>
		/// Current vertical axis value.
		/// </summary>
		float VerticalAxis { get; }
		
		/// <summary>
		/// Current horizontal axis value.
		/// </summary>
		float HorizontalAxis { get; }

		/// <summary>
		/// Indicates if a jump has been requested.
		/// If a jump has been requested then it consumes the internal jump request.
		/// </summary>
		/// <returns>True if a jump has been requested.</returns>
		bool TryConsumeJumpRequest();
    }
}
