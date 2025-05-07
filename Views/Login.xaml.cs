namespace jgarcesEP.Views
{
    public partial class Login : ContentPage
    {
        private Dictionary<string, string> usuarios = new Dictionary<string, string>
        {
            { "estudiante2025", "moviles" },
            { "uisrael", "2025" },
            { "sistemas", "2025_1" }
        };

        public Login()
        {
            InitializeComponent();
        }

        private void btnacercade_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Acerca de", " Aplicación creada por: \n Jorge Antonio Garcés Zambrano \n Desarrollo de Aplicaciones móviles \n Paralelo: A", "OK");
        }

        private void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            if (usuarios.ContainsKey(txtUsuario.Text) && usuarios[txtUsuario.Text] == txtContrasena.Text)
            {
                Navigation.PushAsync(new Views.Registro(txtUsuario.Text));
            }
            else
            {
                DisplayAlert("Alerta", "Usuario o contraseña incorrectos", "OK");
            }
        }
    }
}
