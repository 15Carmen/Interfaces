namespace Ejercicio1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (entry.Text == "")
            //{
            //	entry.Text = "1";
            //}else
            //{
            //	double entrada = Convert.ToDouble(entry.Text);
            //	int entero = Convert.ToInt32(entrada);
            //	entry.Text = Convert.ToString(entero);
            //	//var numero = Convert.ToInt32(entry.Text);
            //	//entry.Text = Convert.ToString(numero);
            //}

            if (!int.TryParse(e.NewTextValue, out int value))
            {
                //((Entry)sender).Text = e.OldTextValue;
                entry.Text = e.OldTextValue;
            }
        }
    }
}