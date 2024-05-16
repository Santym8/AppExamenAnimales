using ApiClientPackage;
using Models;

namespace AppExamenAnimales;

public partial class AnimalPage : ContentPage
{
    private String url = "https://utn-cloud-animales.azurewebsites.net/";


    public AnimalPage()
	{
		InitializeComponent();
	}

	public async void Post_Clicked(object sender, EventArgs e)
	{
        Especie especie = ApiConsumer<Especie>.Read(url + "api/Especies", int.Parse(txtEspecieId.Text));

        if (especie == null || especie.Id == 0)
        {
            await DisplayAlert("Error", "Especie No Encontrada", "Error");
            return;
        }


        Animal animal = new Animal();
        animal.Nombre = txtName.Text;
        animal.EspecieId = int.Parse(txtEspecieId.Text);


        var result = ApiConsumer<Animal>.Create(url + "api/Animals", animal);

        if (result == null || result.Id == 0)
        {
            await DisplayAlert("Error", "Animal No Creado", "Error");
            return;
        }

        this.txtId.Text = result.Id.ToString();

        await DisplayAlert("Animal Creado", "Animal Creado con Id: " + result.Id, "Ok");
    }

    public async void Get_Clicked(object sender, EventArgs e)
    {
        int id = txtId.Text != null ? int.Parse(txtId.Text) : 0;
        var result = ApiConsumer<Animal>.Read(url + "api/Animals/", id);

        if (result == null || result.Id == 0)
        {
            await DisplayAlert("Error", "Animal No Encontrado", "Error");
            return;
        }

        txtName.Text = result.Nombre;
        txtEspecieId.Text = result.EspecieId.ToString();

        await DisplayAlert("Animal Encontrado", "Animal Encontrado con Id: " + result.Id, "Ok");
    }

    public async void Put_Clicked(object sender, EventArgs e)
    {

        Especie especie = ApiConsumer<Especie>.Read(url + "api/Especies", int.Parse(txtEspecieId.Text));

        if (especie == null || especie.Id == 0)
        {
            await DisplayAlert("Error", "Especie No Encontrada", "Error");
            return;
        }


        int id = txtId.Text != null ? int.Parse(txtId.Text) : 0;

        Animal animal = new Animal();
        animal.Nombre = txtName.Text;
        animal.EspecieId = int.Parse(txtEspecieId.Text);
        animal.Id = id;

        var result = ApiConsumer<Animal>.Update(url + "api/Animals", id, animal);

        await DisplayAlert("Animal Actualizado", "Animal Actualizado", "Ok");
    }

    public async void Delete_Clicked(object sender, EventArgs e)
    {

        int id = txtId.Text != null ? int.Parse(txtId.Text) : 0;

        ApiConsumer<Animal>.Delete(url + "/api/Animals", id);

        await DisplayAlert("Animal Eliminado", "Animal Eliminado con Id: " + id, "Ok");

        this.txtId.Text = "";
        this.txtName.Text = "";
        this.txtEspecieId.Text = "";
    }
}