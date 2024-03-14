using System.Collections.ObjectModel;
using AppMauiListaCompras;
using AppMauiListaCompras.Models;
namespace AppMauiListaCompras
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        ObservableCollection<Produto> Lista_Produtos = new ObservableCollection<Produto>();

        public MainPage()
        {
            InitializeComponent();
            lst_produtos.ItemsSource = Lista_Produtos;
        }

        private void ToolbarItem_Clicked_Somar (object sender, EventArgs e)
        {
            double soma = Lista_Produtos.Sum(i => (i.Preco * i.Quantidade));
            string msg = $"O total é {soma:C}";
            DisplayAlert("Somatória", msg, "Fechar");
        }

        protected override void OnAppearing()
        {
           if (Lista_Produtos.Count == 0)
           {
                Task.Run(async () =>
                {
                    List<Produto> tmp = await App.Db.GetAll();
                    foreach (Produto p in tmp)
                    {
                        Lista_Produtos.Add(p);
                    }
                });
           }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string q = e.NewTextValue;
            Lista_Produtos.Clear();
            Task.Run(async () =>
            {
                List<Produto> tmp = await App.Db.Search(q);
                foreach (Produto p in tmp)
                {
                    Lista_Produtos.Add(p);
                }


            });
        }

        private void ref_carregando_Refreshing(object sender, EventArgs e)
        {
            Lista_Produtos.Clear();
            Task.Run(async () =>
            {
                List<Produto> tmp = await App.Db.GetAll();
                foreach (Produto p in tmp)
                {
                    Lista_Produtos.Add(p);
                }
            });
            ref_carregando.IsRefreshing = false;
        }

        private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void MenuItem_Clicked_Remover(object sender, EventArgs e)
        {

        }
    }
}
