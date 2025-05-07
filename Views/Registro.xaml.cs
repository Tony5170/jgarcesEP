namespace jgarcesEP.Views;

public partial class Registro : ContentPage
{
	public Registro(string usuario)
	{
		InitializeComponent();
        lblUsuario.Text = "Usuario Conectado: " + usuario;
    }

    private async void btnPagoMensual_Clicked(object sender, EventArgs e)
    {
        if (!await ValidarCampos())
            return;

        const double costoUPS = 300.0;
        const double interesPorcentaje = 0.05;
        const int numeroCuotas = 3;
        const double minimoInicial = costoUPS * 0.15;

        if (!double.TryParse(txtMontoIncial.Text, out double montoInicial))
        {
            await DisplayAlert("Error", "Ingrese un monto inicial válido.", "OK");
            return;
        }

        if (montoInicial < minimoInicial)
        {
            await DisplayAlert("Error", $"El monto inicial debe ser al menos {minimoInicial:C2}.", "OK");
            return;
        }

        if (montoInicial > costoUPS)
        {
            await DisplayAlert("Error", $"El monto inicial no puede ser mayor al costo del UPS (${costoUPS}).", "OK");
            return;
        }



        double interes = costoUPS * interesPorcentaje;
        double saldoRestante = costoUPS - montoInicial + interes;
        double cuotaMensual = saldoRestante / numeroCuotas;

        txtcuotamensual.Text = cuotaMensual.ToString("F2");
        lblUsuario.Text = "";
    }


    private async void btnResumen_Clicked(object sender, EventArgs e)
    {
        if (!await ValidarCampos())
            return;

        const double costoUPS = 300.0;
        const double interesPorcentaje = 0.05;
        const int numeroCuotas = 3;

        if (!double.TryParse(txtMontoIncial.Text, out double montoInicial))
        {
            await DisplayAlert("Error", "Ingrese un monto inicial válido.", "OK");
            return;
        }

        if (montoInicial < costoUPS * 0.15 || montoInicial > costoUPS)
        {
            await DisplayAlert("Error", $"El monto inicial debe ser entre {costoUPS * 0.15:C2} y {costoUPS:C2}.", "OK");
            return;
        }

        double interes = costoUPS * interesPorcentaje;
        double saldoRestante = costoUPS - montoInicial + interes;
        double cuotaMensual = saldoRestante / numeroCuotas;
        double pagoTotal = montoInicial + saldoRestante;

        string nombre = txtNombre.Text;
        string apellido = txtApellido.Text;
        string va = pkVA.SelectedItem?.ToString() ?? "";
        string fecha = pkfecha.Date.ToString("dd/MM/yyyy");
        string ciudad = pkCiudad.SelectedItem?.ToString() ?? "";
        string cuotaMensualStr = cuotaMensual.ToString("F2");
        string pagoTotalStr = pagoTotal.ToString("F2");

        await Navigation.PushAsync(new Resumen(
            nombre,
            apellido,
            va,
            fecha,
            ciudad,
            montoInicial.ToString("F2"),
            cuotaMensualStr,
            pagoTotalStr
        ));
    }


    private async Task<bool> ValidarCampos()
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            await DisplayAlert("Error", "El nombre es obligatorio.", "OK");
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtApellido.Text))
        {
            await DisplayAlert("Error", "El apellido es obligatorio.", "OK");
            return false;
        }

        if (pkVA.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Debe seleccionar un valor de VA.", "OK");
            return false;
        }

        if (pkCiudad.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Debe seleccionar una ciudad.", "OK");
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtMontoIncial.Text))
        {
            await DisplayAlert("Error", "El monto inicial es obligatorio.", "OK");
            return false;
        }

        return true;
    }


}