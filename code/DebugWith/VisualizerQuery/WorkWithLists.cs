using ColorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace VisualizerQuery {
	internal class WorkWithLists {

		public IEnumerable<dynamic> GetGreenColors() {
			var colors = ColorSource.WebColors;
			var greens = colors
				.Where(color=>color.ColorFamily== ColorFamily.Green)
				.Where(color => color.GreenPercent > .5)
				.OrderBy(color => color.ColorName)
				.Select(color=>new { ColorName = color.ColorName, 
														 GreenPercent = color.GreenPercent});

			return greens.ToList();
		}

		public IEnumerable<WebColor> GetLowSaturationColors() {
			var colors = ColorSource.WebColors;

			var lowSats = colors.Where(x => x.HSL.Saturation < 16);
			return lowSats.ToList();
		}

	}
}
