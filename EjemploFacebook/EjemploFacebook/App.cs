using EjemploFacebook.Pages;
using System;
using Xamarin.Forms;

namespace EjemploFacebook
{
	public class App : Application
	{
        // just a singleton pattern so I can have the concept of an app instance
        static volatile App _Instance;
        static object _SyncRoot = new Object();
        public static App Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_SyncRoot)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new App();
                            _Instance.OAuthSettings =
                                new OAuthSettings(
                                    clientId: "122272601571382",        // your OAuth2 client id 
                                    scope: "",
                                    //authorizeUrl: "https://api.instagram.com/oauth/authorize/",  	// the auth URL for the service
                                    authorizeUrl: "https://m.facebook.com/dialog/oauth/",
                                    redirectUrl: "http://www.facebook.com/connect/login_success.html");   // the redirect URL for the service

                            // If you'd like to know more about how to integrate with an OAuth provider, 
                            // I personally like the Instagram API docs: http://instagram.com/developer/authentication/
                        }
                    }
                }

                return _Instance;
            }
        }

        public OAuthSettings OAuthSettings { get; private set; }

        NavigationPage _NavPage;

        public Page GetMainPage()
        {
            var profilePage = new ProfilePage();

            _NavPage = new NavigationPage(profilePage);

            return _NavPage;
        }

        public bool IsAuthenticated
        {
            get { return !string.IsNullOrWhiteSpace(_Token); }
        }

        string _Token;
        public string Token
        {
            get { return _Token; }
        }

        public void SaveToken(string token)
        {
            _Token = token;

            // broadcast a message that authentication was successful
            MessagingCenter.Send<App>(this, "Authenticated");
        }

        public Action SuccessfulLoginAction
        {
            get
            {
                return new Action(() => _NavPage.Navigation.PopModalAsync());
            }
        }
        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
