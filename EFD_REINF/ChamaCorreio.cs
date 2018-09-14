using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFD_REINF.Models;
using EFD_REINF.Controllers;

namespace EFD_REINF
{
    public partial class ChamaCorreio : Form
    {
        public ChamaCorreio()
        {
            InitializeComponent();
        }

        private void btn_chamar_Click(object sender, EventArgs e)
        {           
            Cep cep = new Cep();
            Endereco end = new Endereco();

            cep.Codigo = txt_texto.Text;

            CorreiosControl corr = new CorreiosControl();           
          
        }

       
    }
}
