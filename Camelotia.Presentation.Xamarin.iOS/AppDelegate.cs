using Camelotia.Presentation.Interfaces;
using Camelotia.Presentation.ViewModels;
using Camelotia.Presentation.Xamarin;
using Camelotia.Services.Providers;
using Camelotia.Services.Storages;
using System.Reactive.Concurrency;
using Blank.Services;
using Xamarin.Forms;
using Foundation;
using ReactiveUI;
using UIKit;

namespace Blank
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Forms.Init();
            LoadApplication(new App(BuildMainViewModel()));
            return base.FinishedLaunching(application, launchOptions);
        }

        private IMainViewModel BuildMainViewModel()
        {
            var currentThread = CurrentThreadScheduler.Instance;
            var mainThread = RxApp.MainThreadScheduler;
            var cache = new AkavacheTokenStorage();

            return new MainViewModel(
                (provider, files, auth) => new ProviderViewModel(auth, files, currentThread, mainThread, provider),
                provider => new AuthViewModel(
                    new DirectAuthViewModel(currentThread, mainThread, provider),
                    new HostAuthViewModel(currentThread, mainThread, provider),
                    new OAuthViewModel(currentThread, mainThread, provider),
                    currentThread,
                    mainThread,
                    provider
                ),
                new ProviderStorage(
                    new VkontakteFileSystemProvider(cache),
                    new YandexFileSystemProvider(
                        new AppleAuthenticator(), cache
                    ),
                    new FtpFileSystemProvider(),
                    new SftpFileSystemProvider(),
                    new GitHubFileSystemProvider()
                ),
                new AppleFileManager(),
                currentThread,
                mainThread
            );
        }
    }
}


