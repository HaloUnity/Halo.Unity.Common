using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halo.Unity.Common
{
	internal static class DebugExtensions
	{
		internal static void ThrowIfNull<TType>(this TType instance)
			where TType : class
		{
			if (instance == null)
				throw new ArgumentNullException(nameof(instance), "Instance of Type: " + typeof(TType).ToString() + " was null. Cannot be null.");
		}
	}
}
