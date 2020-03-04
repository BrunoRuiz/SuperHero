
using Foundation;
using UIKit;

namespace SuperHero.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {       
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            global::Xamarin.Forms.Forms.SetFlags("Visual_Experimental");
            global::Xamarin.Forms.Forms.Init();
            global::Xamarin.Forms.FormsMaterial.Init();
            LoadApplication(new App());

#if GORILLA
            LoadApplication(
                UXDivers.Gorilla.iOS.Player.CreateApplication(
                    new UXDivers.Gorilla.Config("Good Gorilla")
                        .RegisterAssembly(typeof(SuperHero.App).Assembly)
                        .RegisterAssembly(typeof(Xamarin.Forms.FormsMaterial).Assembly)
                        .RegisterAssemblyFromType<FFImageLoading.Transformations.BlurredTransformation>()
                        .RegisterAssemblyFromType<FFImageLoading.Forms.CachedImage>()
                    ));
#else
			LoadApplication(new App());
#endif

            return base.FinishedLaunching(app, options);
        }
    }
}
