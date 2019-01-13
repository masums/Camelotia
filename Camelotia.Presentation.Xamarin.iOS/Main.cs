using Blank;
using UIKit;

namespace Camelotia.Presentation.Xamarin.iOS
{
    public sealed class Application
    {
        public static void Main(string[] args) => UIApplication.Main(args, null, nameof(AppDelegate));
    }
}