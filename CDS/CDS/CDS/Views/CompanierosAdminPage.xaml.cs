using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDS.Models;
using CDS.Services;
using CDS.ViewModels;
using Plugin.TextToSpeech;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CDS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompanierosAdminPage : ContentPage
    {
        DocenteService docenteService;
        List<Docente> doclist;
        public CompanierosAdminPage()
        {
            InitializeComponent();
            docenteService = new DocenteService();
            //BindingContext = new ViewModels.CompaDosViewModel();
            cargar();
        }

        private void Listdocentes_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var studdent = e.Item as docentes;
            DisplayAlert("Docente", studdent.Nombrec + "\n" + studdent.Correo, "Aceptar");
            CrossTextToSpeech.Current.Speak(studdent.Nombrec + studdent.Informacion);
        }

        private void Listdocentes_Refreshing(object sender, EventArgs e)
        {
            cargar();
        }
        async void cargar()
        {
            doclist = await docenteService.GetDocentesAsync();
            docenteList.ItemsSource = doclist.OrderBy(item => item.idDocente).ToList();

        }
        /*
        private async void OnUpdate(object sender, EventArgs e)
        {
            try
                {
                    var mi = ((MenuItem)sender);
                    Docente docenteActualizar = (Docente)mi.CommandParameter;
                    //docenteActualizar.nombreLogin = txtNome.Text;
                    //docenteActualizar.idDocente = txtCategoria.Text;
                    await docenteService.UpdateDocenteAsync(docenteActualizar);
                    cargar();
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", ex.Message, "OK");
                }
            
            
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            try
            {
                var mi = ((MenuItem)sender);
                Docente docenteDelete = (Docente)mi.CommandParameter;
                await docenteService.DeleteDocenteAsync(docenteDelete);
                
                cargar();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }*/

        private void listaProdutos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var doc = e.SelectedItem as Docente;
            var studdent = e.SelectedItem as docentes;
            DisplayAlert("Docente", doc.docente + "\n" + doc.nombreMateria, "Aceptar");
            CrossTextToSpeech.Current.Speak(doc.docente + doc.nombreMateria);
            /* txtNome.Text = produto.Nome;
            txtCategoria.Text = produto.Categoria;
            txtPreco.Text = produto.Preco.ToString(); */
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
    
}
