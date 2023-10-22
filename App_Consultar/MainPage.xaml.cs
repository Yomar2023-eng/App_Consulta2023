using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App_Consultar
{
    public partial class MainPage : ContentPage
    {
        ApisPeru apisPeru = new ApisPeru(); 
        public MainPage()
        {
            InitializeComponent();
        }

        private void ver_Clicked(object sender, EventArgs e)
        {
            ConsultarCliente();

        }

        private void ConsultarCliente()
        {
            try
            {
                if (ConsultarDoc.Text.Length == 11)
                {
                    dynamic respuesta = apisPeru.Get("https://api.apis.net.pe/v1/ruc?numero=" + ConsultarDoc.Text + "");
                
                    Nombre.Text = respuesta.nombre.ToString();
                    apPaterno.Text = respuesta.estado.ToString();
                    apMaterno.Text = respuesta.condicion.ToString();


                }

                if (ConsultarDoc.Text.Length == 8)
                {
                    dynamic respuesta = apisPeru.Get("https://api.apis.net.pe/v1/dni?numero=" + ConsultarDoc.Text + "");

                    Nombre.Text = respuesta.nombres.ToString();
                    apPaterno.Text = respuesta.apellidoPaterno.ToString();
                    apMaterno.Text = respuesta.apellidoMaterno.ToString();


                }


            }
            catch

            (Exception ex)
            { }
        }

    }
    
}
