using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DelSole.XamUtilities.Samples.PicturesFromByteArray
{
    public partial class ShowPicturePage : ContentPage
    {
        private Employee Employee { get; set; }
        public ShowPicturePage()
        {
            InitializeComponent();
            this.Employee = new Employee();
            this.BindingContext = this.Employee;
        }

        private async void PickButton_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error", "Picking photos is not supported on this device.", "OK");
                return;
            }

            var imageFile = await CrossMedia.Current.PickPhotoAsync();
            if (imageFile == null) return;

            using (var memoryStream = new MemoryStream())
            {
                imageFile.GetStream().CopyTo(memoryStream);

                this.Employee.Picture = memoryStream.ToArray();

                imageFile.Dispose();

            }
        }
    }
}
