using ColorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace VisualizerQuery {
	internal class WorkWithLists {

		public IEnumerable<WebColor> GetSat() { 
			var colors = ColorSource.WebColors;

		var reds = colors.Where(x => x.HSL.Saturation < 16);
			return reds.ToList();
		}

		public IEnumerable<WebColor> GetGreenColors() {
			var colors = ColorSource.WebColors;
			var q = colors
				.Where(color=>color.ColorFamily== ColorFamily.Green)
				.Where(color => color.GreenPercent > .5)
				.OrderBy(color => color.ColorName)
				.Select(color => color)
				;

			return q.ToList();
		}
		//.Select(color => new { ColorName = color.ColorName, GreenPercent = color.GreenPercent })

	}
}
