using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using System.Security.Cryptography.X509Certificates;

namespace EmployeeUI
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            try
            {
                string certPath = Path.Combine(Android.App.Application.Context.GetExternalFilesDir(null)?.AbsolutePath ?? "", "employee_api.crt");

                if (!File.Exists(certPath))
                {
                    using (var assetStream = Resources.OpenRawResource(Microsoft.Maui.Resource.Raw.employee_api))
                    using (var fileStream = File.Create(certPath))
                    {
                        assetStream.CopyTo(fileStream);
                    }

                    Log.Info("MainActivity", "Certificate copied to: " + certPath);
                }
                else
                {
                    Log.Info("MainActivity", "Certificate already exists at: " + certPath);
                }

                var trustedCert = X509CertificateLoader.LoadCertificateFromFile(certPath);

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (request, cert, chain, errors) =>
                {
                    return true;
                };

                var httpClient = new HttpClient(handler);
                Log.Info("MainActivity", "HttpClient configured successfully.");
            }
            catch (Exception ex)
            {
                Log.Error("MainActivity", "Error loading certificate: " + ex.Message);
            }
        }
    }
}
