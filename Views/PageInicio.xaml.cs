namespace Tarea_1._3_Aplicacion_de_Autores.Views;

public partial class PageInicio : ContentPage
{

    Controllers.AutorController AutorDB;

    public PageInicio()
	{
        AutorDB = new Controllers.AutorController();
		InitializeComponent();
	}

    public PageInicio(Controllers.AutorController dbpath)
    {      
        InitializeComponent();
        AutorDB = dbpath;
    }

    public async void Button_Clicked(object sender, EventArgs e)
    {
        // Validación para Entry (nombre)
        if (string.IsNullOrWhiteSpace(nombres.Text))
        {
            await DisplayAlert("Error", "Por favor, ingrese un nombre.", "OK");
            return;
        }

        // Validación para Picker (país)
        if (Pais.SelectedItem == null)
        {
            await DisplayAlert("Error", "Por favor, seleccione un país.", "OK");
            return;
        }

        string valorSeleccionado = (string)Pais.SelectedItem;

        var autor = new Models.Autor
        {
            Nombre = nombres.Text,
            Pais = valorSeleccionado
        };

        
        if (await AutorDB.AgregarAutor(autor) > 0)
        {
            await DisplayAlert("Éxito", $"Autor {autor.Nombre} guardado exitosamente.", "OK");

            // Limpiar contenido de Entry y Picker después de guardar
            nombres.Text = string.Empty;
            Pais.SelectedItem = null;
        }
            

    }

    public async void btnverlista_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Buscar());
    }
}