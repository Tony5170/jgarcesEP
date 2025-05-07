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
            DisplayAlert("Acerca de", " Aplicaci�n creada por: \n Jorge Antonio Garc�s Zambrano \n Desarrollo de Aplicaciones m�viles \n Paralelo: A", "OK");
        }

        private void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            if (usuarios.ContainsKey(txtUsuario.Text) && usuarios[txtUsuario.Text] == txtContrasena.Text)
            {
                Navigation.PushAsync(new Views.Registro(txtUsuario.Text));
            }
            else
            {
                DisplayAlert("Alerta", "Usuario o contrase�a incorrectos", "OK");
            }
        }
    }
}
