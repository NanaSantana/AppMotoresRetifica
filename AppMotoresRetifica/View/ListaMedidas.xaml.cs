using System.Linq;
using AppMotoresRetifica.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using System.Text;

namespace AppMotoresRetifica.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaMedidas : ContentPage
    {
        ObservableCollection<Motor> lista_medidas = new ObservableCollection<Motor>();

        public ListaMedidas()
        {
            InitializeComponent();

            lst_motores.ItemsSource = lista_medidas;
        }

        private void ToolbarItem_Clicked_Novo(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new FormularioCadastro());
            }
            catch(Exception ex)
            {
                DisplayAlert("ops", ex.Message, "OK");
            }

        }

        protected override void OnAppearing()
        {
            if (lista_medidas.Count == 0)
            {
                System.Threading.Tasks.Task.Run(async () =>
                {
                    List<Motor> temp = await App.Database.GetAll();

                    foreach (Motor item in temp)
                    {
                        lista_medidas.Add(item);
                    }

                    ref_carregando.IsRefreshing = false;
                });
            }
        }

        //AAAA PAREREI AQUI

        private void lst_motores_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}