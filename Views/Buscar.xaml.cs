namespace Tarea_1._3_Aplicacion_de_Autores.Views;
using Tarea_1._3_Aplicacion_de_Autores.Controllers;
using Tarea_1._3_Aplicacion_de_Autores.Models;

public partial class Buscar : ContentPage
{

    private AutorController autorController;

    public Buscar()
    {
        InitializeComponent();
        autorController = new AutorController();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        // Obtener el texto de búsqueda del Entry
        string textoBusqueda = SearchText.Text;

        // Realizar la búsqueda de autores utilizando el método del controlador
        List<Autor> autoresEncontrados = await autorController.BuscarAutores(textoBusqueda);

        // Actualizar la lista de autores en la CollectionView
        ListaAutor.ItemsSource = autoresEncontrados;
    }

    private void ListaAutor_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        ListaAutor.ItemsSource = await App.Database.ObtenerListaAutores();
    }


}