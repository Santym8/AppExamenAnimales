using ApiClientPackage;
using Models;

namespace AppExamenAnimales;

public partial class EspeciePage : ContentPage
{

    private String url = "https://utn-cloud-animales.azurewebsites.net/";


    public EspeciePage()
    {
        InitializeComponent();
    }



    public async void Post_Clicked(object sender, EventArgs e)
    {
        Especie especie = new Especie();
        especie.Nombre = txtName.Text;
        especie.Descripcion = txtDescription.Text;

        var result = ApiConsumer<Especie>.Create(url + "api/Especies", especie);

        if (result == null)
        {
            await DisplayAlert("Error", "Especie No Creada", "Error");
            return;
        }

        this.txtId.Text = result.Id.ToString();

        await DisplayAlert("Especie Creada", "Especie Creada con Id: " + result.Id, "Ok");
    }

    public async void Get_Clicked(object sender, EventArgs e)
    {
        int id = txtId.Text != null ? int.Parse(txtId.Text) : 0;
        var result = ApiConsumer<Especie>.Read(url + "api/Especies/", id);

        if (result == null || result.Id == 0)
        {
            await DisplayAlert("Error", "Especie No Encontrada", "Error");
            return;
        }

        txtName.Text = result.Nombre;
        txtDescription.Text = result.Descripcion;

        await DisplayAlert("Especie Encontrada", "Especie Encontrada con Id: " + result.Id, "Ok");
    }

    public async void Put_Clicked(object sender, EventArgs e)
    {
        int id = txtId.Text != null ? int.Parse(txtId.Text) : 0;

        Especie especie = new Especie();
        especie.Nombre = txtName.Text;
        especie.Descripcion = txtDescription.Text;
        especie.Id = id;

        var result = ApiConsumer<Especie>.Update(url + "api/Especies", especie.Id, especie);

        await DisplayAlert("Especie Actualizada", "Especie Actualizada", "Ok");
    }   

    public async void Delete_Clicked(object sender, EventArgs e)
    {
        int id = txtId.Text != null ? int.Parse(txtId.Text) : 0;

        ApiConsumer<Especie>.Delete(url + "/api/Especies", id);

        txtId.Text = "";
        txtName.Text = "";
        txtDescription.Text = "";

        await DisplayAlert("Especie Eliminada", "Especie Eliminada", "Ok");
    }

}