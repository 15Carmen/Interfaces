namespace Ejercicio1
{
    public partial class MainPage : ContentPage
    {
      
        public MainPage()
        {
            InitializeComponent();
        }

        private void entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (!int.TryParse(e.NewTextValue, out int value))
            {
                entry.Text = e.OldTextValue;
            }
        }
    }
}