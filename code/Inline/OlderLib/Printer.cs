using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlderLib {
	public class ColorPrinter : IBigPrinter {
		public ColorPrinter() {
			PrinterName = String.Empty;
		}
		public string PrinterName { get; set; }
		// The color printer can print.
		// But it doesn't have copy or scan capabilities.
		public void PrintDoc() {
		Console.WriteLine("Color printer printing document...");
		}
		// Color printer does not scan, so this 
		// method is irrelevant .
		public void ScanDoc() {
			throw new NotImplementedException();
		}
		public void CopyDoc() {
			throw new NotImplementedException();
		}


	}

	// remove the IBigPrinter interface and replace
	// with three interfaces (IPrintDevice, IPrinter, IScanner)
	// use interface inheritance IPrinter and IScanner implement the IPrintDevice
	public interface IBigPrinter {

		public string PrinterName { get; set; }
		public void PrintDoc();
		public void ScanDoc();
		public void CopyDoc();
		
	}
}
