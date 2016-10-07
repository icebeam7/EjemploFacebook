using Xamarin.Forms;

namespace EjemploFacebook.Pages
{
    public class ProfilePage : BaseContentPage
    {
        public ProfilePage()
        {
            // Using messaging center to ensure that content only gets loaded once authentication is successful.
            MessagingCenter.Subscribe<App>(this, "Authenticated", (sender) => {
                Content = new Label()
                {
                    Text = "Profile Page",
                    XAlign = TextAlignment.Center,
                    YAlign = TextAlignment.Center
                };
            });
        }
    }
}
