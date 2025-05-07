namespace jgarcesEP.Views;

public partial class Resumen : ContentPage
{
	public Resumen(string usuario)
	{
		InitializeComponent();
        lblUsuario.Text = "Usuario Conectado: " + usuario;
    }
    public Resumen(string nombre, string apellido, string va, string fecha, string ciudad, string montoInicial, string cuotaMensual, string pagoTotal)
    {
        InitializeComponent();

        txtNombre.Text = nombre;
        txtApellido.Text = apellido;
        txtVA.Text = va;
        txtFecha.Text = fecha;
        txtCiudad.Text = ciudad;
        txtMontoInicial.Text = montoInicial;
        txtCuotaMensual.Text = cuotaMensual;
        txtPagoTotal.Text = pagoTotal;
    }

    private void btnCerrarSesion_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.Login());
    }
}