// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SELStudentApp.Presentation;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class ProfilePage : Page
{
    public ProfilePage()
    {
        this.InitializeComponent();
    }

    private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
    {

    }

    private void Image_ImageFailed_1(object sender, ExceptionRoutedEventArgs e)
    {
        var image = (Image)sender;
        image.Visibility = Visibility.Collapsed;
        NoProfilePicture.Visibility = Visibility.Visible;
    }
}
