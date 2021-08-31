using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace MyApp4.Skia.Tizen
{
	class Program
{
	static void Main(string[] args)
	{
		var host = new TizenHost(() => new MyApp4.App(), args);
		host.Run();
	}
}
}
