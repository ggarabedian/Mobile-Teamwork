namespace PersonalOrganiser.Views.Tasker
{
    using System;

    using Windows.Media.Capture;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;
    using Windows.UI.Xaml.Media.Imaging;

    using ViewModels.Tasker;

    public sealed partial class AddNewTaskPage : Page
    {
        public AddNewTaskPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
        }
        public AddNewTaskPageViewModel ViewModel => this.DataContext as AddNewTaskPageViewModel;

        private async void CaptureImage(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var camera = new CameraCaptureUI();

            var image = await camera.CaptureFileAsync(CameraCaptureUIMode.Photo);


            if (image != null)
            {
                capturedImage.Source = new BitmapImage(new Uri(image.Path));
                capturedImage.Tag = image.Path;
            }
        }
    }
}
