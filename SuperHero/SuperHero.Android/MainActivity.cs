using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;

namespace SuperHero.Droid
{
	[Activity(Label = "SuperHero", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);

			FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: false);

			global::Xamarin.Forms.Forms.SetFlags("Visual_Experimental");
			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
			global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);

#if GORILLA
			LoadApplication(
				UXDivers.Gorilla.Droid.Player.CreateApplication(
					this,
					new UXDivers.Gorilla.Config("Good Gorilla")
						.RegisterAssembly(typeof(SuperHero.App).Assembly)
						.RegisterAssembly(typeof(Xamarin.Forms.FormsMaterial).Assembly)						
						.RegisterAssemblyFromType<FFImageLoading.Transformations.BlurredTransformation>()
						.RegisterAssemblyFromType<FFImageLoading.Forms.CachedImage>()
					));
#else
			LoadApplication(new App());
#endif
		}

#if GORILLA
		public override bool OnKeyUp(Android.Views.Keycode keyCode, Android.Views.KeyEvent e)
		{
			if ((keyCode == Android.Views.Keycode.F1 || keyCode == Android.Views.Keycode.Menu || keyCode == Android.Views.Keycode.VolumeUp || keyCode == Android.Views.Keycode.VolumeDown || keyCode == Android.Views.Keycode.VolumeMute) && UXDivers.Gorilla.Coordinator.Instance != null)
			{
				UXDivers.Gorilla.ActionManager.ShowMenu();
				return true;
			}

			return base.OnKeyUp(keyCode, e);
		}

		private readonly static GestureDetector LongPressDetector = new GestureDetector(new UXDivers.Gorilla.Droid.LongPressGestureListener());

		public override bool DispatchTouchEvent(MotionEvent ev)
		{
			LongPressDetector.OnTouchEvent(ev);

			return base.DispatchTouchEvent(ev);
		}
#endif

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
		{
			Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}
	}
}