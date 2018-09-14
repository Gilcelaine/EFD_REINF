using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Xml;

namespace EFD_REINF.Models
{
    public class Xml
    {
        public static string CaminhoDadosXML(string caminho)
        {
            if (caminho.IndexOf("\\bin\\Debug") != 0)
            {
                caminho = caminho.Replace("\\bin\\Debug", "");
            }
            return caminho;
        }
        //private void SalvarXml(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        using (DataSet dsResultado = new DataSet())
        //        {
        //            dsResultado.ReadXml(CaminhoDadosXML(caminho) + @"Dados\Produtos.xml");
        //            if (dsResultado.Tables.Count == 0)
        //            {
        //                //cria uma instância do Produto e atribui valores às propriedades
        //                Produto oProduto = new Produto();
        //                oProduto.Codigo = Convert.ToInt32(txtCodigoProduto.Text);
        //                oProduto.Nome = txtNomeProduto.Text;
        //                oProduto.Preco = Convert.ToDecimal(txtPreco.Text);
        //                oProduto.Estoque = Convert.ToInt32(txtEstoque.Text);
        //                oProduto.Descricao = txtDescricao.Text;
        //                XmlTextWriter writer = new XmlTextWriter(CaminhoDadosXML(caminho) + @"Dados\Produtos.xml", System.Text.Encoding.UTF8);
        //                writer.WriteStartDocument(true);
        //                writer.Formatting = Formatting.Indented;
        //                writer.Indentation = 2;
        //                writer.WriteStartElement("Produtos");
        //                writer.WriteStartElement("Produto");
        //                writer.WriteStartElement("Codigo");
        //                writer.WriteString(oProduto.Codigo.ToString());
        //                writer.WriteEndElement();
        //                writer.WriteStartElement("Nome");
        //                writer.WriteString(oProduto.Nome);
        //                writer.WriteEndElement();
        //                writer.WriteStartElement("Preco");
        //                writer.WriteString(oProduto.Preco.ToString());
        //                writer.WriteEndElement();
        //                writer.WriteStartElement("Estoque");
        //                writer.WriteString(oProduto.Estoque.ToString());
        //                writer.WriteEndElement();
        //                writer.WriteStartElement("Descricao");
        //                writer.WriteString(oProduto.Descricao);
        //                writer.WriteEndElement();
        //                writer.WriteEndElement();
        //                writer.WriteEndDocument();
        //                writer.Close();
        //                dsResultado.ReadXml(CaminhoDadosXML(caminho) + @"Dados\Produtos.xml");
        //            }
        //            else
        //            {
        //                //inclui os dados no DataSet
        //                dsResultado.Tables[0].Rows.Add(dsResultado.Tables[0].NewRow());
        //                dsResultado.Tables[0].Rows[dsResultado.Tables[0].Rows.Count - 1]["Codigo"] = txtCodigoProduto.Text;
        //                dsResultado.Tables[0].Rows[dsResultado.Tables[0].Rows.Count - 1]["Nome"] = txtNomeProduto.Text.ToUpper();
        //                dsResultado.Tables[0].Rows[dsResultado.Tables[0].Rows.Count - 1]["Preco"] = txtPreco.Text;
        //                dsResultado.Tables[0].Rows[dsResultado.Tables[0].Rows.Count - 1]["Estoque"] = txtEstoque.Text;
        //                dsResultado.Tables[0].Rows[dsResultado.Tables[0].Rows.Count - 1]["Descricao"] = txtDescricao.Text;
        //                dsResultado.AcceptChanges();
        //                //--  Escreve para o arquivo XML final usando o método Write
        //                dsResultado.WriteXml(CaminhoDadosXML(caminho) + @"Dados\Produtos.xml", XmlWriteMode.IgnoreSchema);
        //            }
        //            //exibe os dados no datagridivew 
        //           // dgvDados.DataSource = dsResultado.Tables[0];
        //          //  MessageBox.Show("Dados salvos com sucesso.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //       //MessageBox.Show("Erro " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        public string caminho { get; set; }

        public static string CreateXML(Object obj)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UnicodeEncoding(false, false);
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (StringWriter textWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, obj);
                }
                return textWriter.ToString();
            }
        }
        public class XMLAtributos : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value == null) return false;
                IList<PropertyInfo> propriedades = new List<PropertyInfo>(value.GetType().GetProperties());

                foreach (PropertyInfo propriedade in propriedades)
                {
                    object valor = propriedade.GetValue(value, null);
                    if (valor == null)
                    {
                        propriedade.SetValue(value, " ", null);
                    }
                }
                return true;
            }
        }
    }
}