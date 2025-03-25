using System;
using System.Windows.Forms;

namespace GestionClient
{
    public partial class FormularioNuevoClienteCorporativo : FormularioNuevoClienteBase
    {
        public FormularioNuevoClienteCorporativo() : base("Nuevo Cliente Corporativo")
        {
            btnAceptar.Click += BtnAceptarCorporativo_Click;
        }

        private void BtnAceptarCorporativo_Click(object sender, EventArgs e)
        {
            if (ValidarCamposBase())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
