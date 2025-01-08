// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

using SELStudentApp.ViewModels;

namespace SELStudentApp.Presentation;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class ClassDetailPage : Page
{
    public ClassDetailViewModel ViewModel => (ClassDetailViewModel)DataContext;

    public ClassDetailPage()
    {
        this.InitializeComponent();
    }
}
