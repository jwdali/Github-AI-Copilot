using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlderLib {
	internal class BatchProcessor {
		// Naïve batch processor: filters out zeros, inverts bytes,
		// and returns a fresh array
		public static byte[] ProcessBatch(List<byte[]> batches) {
			// 1) Dynamic list with default capacity -> lots of resizes
			var buffer = new List<byte>();

			// 2) Nested loops do filtering and copying
			foreach (var chunk in batches)
			{
				foreach (var b in chunk)
				{
					if (b != 0)
					{
						buffer.Add(b);
					}
				}
			}

			// 3) Second pass over the list to invert each byte
			for (int i = 0; i < buffer.Count; i++)
			{
				buffer[i] = (byte)~buffer[i];
			}

			// 4) Final allocation to produce the return value
			return buffer.ToArray();
		}
	}
}
