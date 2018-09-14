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
    public partial class IntegraReinf : Form
    {
        public IntegraReinf()
        {
            InitializeComponent();
        }
        private void IntegraReinf_Load(object sender, EventArgs e)
        {
            CarregaTelaInicial();
        }
        private void btn_salvar_Click(object sender, EventArgs e)
        {
            bool retorno =true;

            EmpresaCliente cliente = new EmpresaCliente();
            InformacoesContribuinteControl cont = new InformacoesContribuinteControl();
            RetencoesFonteControl rent = new RetencoesFonteControl();
            RetencoesFonte teste = new RetencoesFonte();
            cliente.Ano = "";

            cliente.Dominio = txt_dominio.Text;
            cliente.UsuarioSinacor = txt_usuario.Text;
            cliente.SenhaSinacor = txt_senha.Text;
            cliente.CodigoEmpresa = Convert.ToInt16(txt_codigo_empresa.Text);
            cliente.caminho = txt_caminho.Text;
            cliente.Ano = txt_Ano.Text;            

           
            string dataInicialFormatada = MontaData(cbo_DataIni.SelectedValue.ToString(), cliente.Ano);
            string dataFinalFormatada = MontaData(cbo_DataFim.SelectedValue.ToString(), cliente.Ano);

          
           retorno = ValidaCampos(cliente);

           if(retorno == true)
           { 
               if (rdn_1000.Checked == true)
               {
                   cliente.NomeContatoContri = txt_contato.Text;
                   cliente.CPFContatoContri = txt_cpf.Text;
                   cliente.TelefoneContatoContr = txt_ddd_fone.Text + txt_fone.Text;
                   cliente.CelularContatoContr = txt_ddd_cel.Text + txt_celular.Text;
                   cliente.EmailContatoContr = txt_email.Text;

                   if (rdn_EmpresaNaoObrigadaECD.Checked == true)
                       cliente.indDesoneracao = "0";

                   if (rdn_EmpresaObrigadaECD.Checked == true)
                       cliente.indDesoneracao = "1";

                   if (rdn_NaoAplicavel.Checked == true)
                       cliente.indDesoneracao = "0";

                   if (rdn_LeiEnquadrada.Checked == true)
                       cliente.indDesoneracao = "1";

                   retorno = cont.RetornaReinfContribuinte(cliente);
                   if (retorno == true)
                   {
                       MessageBox.Show("Imposto R1000 gerado com sucesso!");
                       return;
                   }
               }
               else if (rdn_2070.Checked == true)
               {
                   if (ckb_refificadora.Checked == true)
                   {
                       cliente.Retifico = 1;
                       cliente.Recibo = txt_Recibo.Text;
                   m}

                   retorno = rent.AdicionarXml(teste,cliente.caminho,"teste.xml"); 
                    //  retorno = rent.RetornaReinfFonte(cliente);
                   if (retorno == true)
                   {
                       MessageBox.Show("Imposto R2070 gerado com sucesso!");
                       return;
                   }
               }
               else
               {
                   MessageBox.Show("Escolher pelo menos um dos impostos");
                   return;
               }
           }           
        }		   
        private void btn_caminho_Click(object sender, EventArgs e)
        {
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txt_caminho.Text = fdlg.SelectedPath + "\\";
            }
        }       
        public void CarregaTelaInicial()
        {
            rdn_2070.Checked = true;
            rdn_NaoAplicavel.Checked = true;
            rdn_EmpresaObrigadaECD.Checked = true;
            txt_codigo_empresa.Text = "4";
            txt_Ano.Text = "2018";
            txt_usuario.Text = "glsilva";
            txt_senha.Text = "remanso@35";            
         
            CarregaMesInicial();
            CarregaMesFinal();
        }
         public static IEnumerable<DateTime> GetDiasNoMes(int mes, int? ano = null)
        {
              ano = ano ?? DateTime.Now.Year;
              
             return Enumerable.Range(1, System.DateTime.DaysInMonth(2018, mes))  // Dias: 1, 2 ... 31 etc. É um IEnumerable<int>
                       .Select(dia => new DateTime(2018, mes, dia)); // Mapeia as datas;
        }  
        public void CarregaMesInicial()
        {
            List<Calendario> list = new List<Calendario>();
            list.Add(new Calendario { IDMes = 00, NomeMes = "Selecione" });
            list.Add(new Calendario { IDMes = 01, NomeMes = "Janeiro" });
            list.Add(new Calendario { IDMes = 02, NomeMes = "Fevereiro" });
            list.Add(new Calendario { IDMes = 03, NomeMes = "Março" });
            list.Add(new Calendario { IDMes = 04, NomeMes = "Abril" });
            list.Add(new Calendario { IDMes = 05, NomeMes = "Maio" });
            list.Add(new Calendario { IDMes = 06, NomeMes = "Junho" });
            list.Add(new Calendario { IDMes = 07, NomeMes = "Julho" });
            list.Add(new Calendario { IDMes = 08, NomeMes = "Agosto" });
            list.Add(new Calendario { IDMes = 09, NomeMes = "Setembro" });
            list.Add(new Calendario { IDMes = 10, NomeMes = "Oububro" });
            list.Add(new Calendario { IDMes = 11, NomeMes = "Novembro" });
            list.Add(new Calendario { IDMes = 12, NomeMes = "Dezembro" });


            cbo_DataIni.DataSource = list;
            cbo_DataIni.DisplayMember = "NomeMes";
            cbo_DataIni.ValueMember = "IDMes";         
        }
        
        public void CarregaMesFinal()
        {
            List<Calendario> list = new List<Calendario>();
            list.Add(new Calendario { IDMes = 00, NomeMes = "Selecione" });
            list.Add(new Calendario { IDMes = 01, NomeMes = "Janeiro" });
            list.Add(new Calendario { IDMes = 02, NomeMes = "Fevereiro" });
            list.Add(new Calendario { IDMes = 03, NomeMes = "Março" });
            list.Add(new Calendario { IDMes = 04, NomeMes = "Abril" });
            list.Add(new Calendario { IDMes = 05, NomeMes = "Maio" });
            list.Add(new Calendario { IDMes = 06, NomeMes = "Junho" });
            list.Add(new Calendario { IDMes = 07, NomeMes = "Julho" });
            list.Add(new Calendario { IDMes = 08, NomeMes = "Agosto" });
            list.Add(new Calendario { IDMes = 09, NomeMes = "Setembro" });
            list.Add(new Calendario { IDMes = 10, NomeMes = "Oububro" });
            list.Add(new Calendario { IDMes = 11, NomeMes = "Novembro" });
            list.Add(new Calendario { IDMes = 12, NomeMes = "Dezembro" });

            cbo_DataFim.DataSource = list;
            cbo_DataFim.DisplayMember = "NomeMes";
            cbo_DataFim.ValueMember = "IDMes";
        }
       
        public string MontaData(string mes, string ano)
        {
            // 01/01/2018
            string dataFormatada = "01/" + mes + "/" + ano;

            return dataFormatada;
        }
        public bool ValidaCampos(EmpresaCliente cliente)
        {
            bool retorno = true;
            if (rdn_1000.Checked == true)
            {
                if ( cliente.NomeContatoContri  == "")
                {
                    MessageBox.Show("Nome do contato no contribuinte não pode ser em branco");
                    retorno = false;
                }
                  if ( cliente.CPFContatoContri == "")
                {
                    MessageBox.Show("CPF do contato no contribuinte não pode ser em branco");
                    retorno = false;
                }
                  if (cliente.TelefoneContatoContr == "" && cliente.CelularContatoContr == "")
                {
                    MessageBox.Show("Telefone do contato no contribuinte não pode ser em branco");
                    retorno = false;
                }
                if (cliente.CelularContatoContr  == "")
                {
                    MessageBox.Show("Celular do contato no contribuinte não pode ser em branco");
                    retorno = false;
                }
                if (cliente.EmailContatoContr == "")
                {
                    MessageBox.Show("E-mail do contato no contribuinte não pode ser em branco");
                    retorno = false;
                }                  
                
            }
            if (rdn_2070.Checked == true)
            {
                if (ckb_refificadora.Checked== true)
                {
                    if (cliente.Recibo == "")
                    {
                        MessageBox.Show("E-mail do contato no contribuinte não pode ser em branco");
                        retorno = false;
                    } 
                }
               
            }
            if (cliente.UsuarioSinacor == "")
            {
                MessageBox.Show("Usuário em branco");
                retorno = false;
            }
            if (cliente.SenhaSinacor == "")
            {
                MessageBox.Show("Senha em branco");
                retorno = false;
            }
            if (cliente.caminho == "")
            {
                MessageBox.Show("Necessita passar o caminho");
                retorno = false;
            }
            if (cbo_DataIni.SelectedValue.ToString() == "0" && cbo_DataFim.SelectedValue.ToString() == "0" && cliente.Ano == "")
            {
                MessageBox.Show("Data Inicial  ou Data Final ou Ano em branco, por favor inserir data");
                retorno = false;
            }

            return retorno;
        }

        private void rdn_1000_CheckedChanged(object sender, EventArgs e)
        {
            pnlR1000.Visible = true;
            pnlR2070.Visible = false;
        }
        private void rdn_2070_CheckedChanged(object sender, EventArgs e)
        {
            pnlR1000.Visible = false;
            pnlR2070.Visible = true;

        }
    }
}