using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analisis_Hash.Extensions;
using Analisis_Hash.Functions;

namespace Analisis_Hash
{
    public partial class formHome : Form
    {
        private int modo;
        private string text, binText, binCripto;
        private Authentication authentication;

        public formHome()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            var cripto = "";

            toolStripStLblText.Text = "";
            toolStripStLblCompact.Text = "PROCESANDO...";
            Application.DoEvents();

            switch (modo)
            {
                case 0:
                    text = richTxtBxSource.Text;
                    binText = text.TextToBin(Encoding.UTF8);

                    binCripto = authentication.Sha256Hex(text);
                    binCripto = binCripto.HexToBin();
                    richTxtBxBinKey.Text = binCripto;

                    binCripto = binCripto.ToEqualize(binText, '0');

                    for (var i = 0; i < binText.Length; i++) cripto += binText[i] != binCripto[i] ? "1" : "0";

                    richTxtBxBinText.Text = binText;
                    richTxtBxCripto.Text = cripto;
                    toolStripStLblText.Text = text.Length.ToString();
                    toolStripStLblCompact.Text = "caracter(es) encriptado(s)";
                    //splitContSide.Panel2Collapsed = false;
                    break;
                case 1:
                    text = richTxtBxSource.Text;
                    binText = text.TextToBin(Encoding.UTF8);

                    binCripto = richTxtBxCripto.Text;

                    string hash = authentication.Sha256Hex(text);
                    //hash = binCripto.HexToBin();
                    //hash = binCripto.ToEqualize(binText, '0');

                    for (var i = 0; i < binText.Length; i++) cripto += binText[i] != binCripto[i] ? "1" : "0";

                    cripto = cripto.Substring(0, 256);
                    richTxtBxBinText.Text = hash;
                    richTxtBxBinKey.Text = cripto.BinToHex();
                    toolStripStLblText.Text = binText.Length.ToString();
                    toolStripStLblCompact.Text = "bit(s) desencriptado(s)";
                    //splitContSide.Panel2Collapsed = false;
                    break;
            }
        }

        private void formHome_Load(object sender, EventArgs e)
        {
            lblFilename.Text = "";
            toolStripStLblCompact.Text = "";
            toolStripStLblText.Text = "";

            splitContSide.Panel2Collapsed = true;

            radBtnText.Checked = true;
            btnProcess.Enabled = false;
            cmbBxMode.SelectedIndex = 0;

            authentication = new Authentication();
        }

        private void radBtnText_CheckedChanged(object sender, EventArgs e)
        {
            richTxtBxSource.ReadOnly = false;
            richTxtBxSource.Text = "";
            richTxtBxCripto.Text = "";

            btnFile.Enabled = false;
            lblFilename.Text = "";

            splitContSide.Panel2Collapsed = true;
        }

        private void radBtnFile_CheckedChanged(object sender, EventArgs e)
        {
            richTxtBxSource.ReadOnly = true;
            richTxtBxSource.Text = "";
            richTxtBxCripto.Text = "";

            btnFile.Enabled = true;

            splitContSide.Panel2Collapsed = true;
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                lblFilename.Text = openFileDialog.FileName;

                richTxtBxSource.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            splitContSide.Panel2Collapsed = !splitContSide.Panel2Collapsed;
            btnShow.Text = splitContSide.Panel2Collapsed ? "MOSTRAR" : "OCULTAR";
        }

        private void cmbBxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = sender as ComboBox;
            modo = cmb.SelectedIndex;
            switch (modo)
            {
                case 0:
                    richTxtBxCripto.ReadOnly = true;
                    richTxtBxCripto.Text = "";
                    break;
                case 1:
                    richTxtBxCripto.ReadOnly = false;
                    richTxtBxCripto.Text = "";
                    btnProcess.Enabled = false;
                    break;
            }
        }

        private void richTxtBx_TextChanged(object sender, EventArgs e)
        {
            if (!richTxtBxSource.Text.Equals("") && !(!richTxtBxCripto.Text.Equals("") ^ modo == 1))
            {
                btnProcess.Enabled = true;
                return;
            }

            btnProcess.Enabled = false;
        }

        private void toolStripStLblAuthor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desarrollado por: Óskar Calí\n\nOctubre 2019", "ABOUT", MessageBoxButtons.OK,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }
    }
}
