namespace AppExamenAnimales
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

      

        private void btnEspecies_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EspeciePage());

        }

        private void btnAnimales_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AnimalPage());
        }
    }

}
