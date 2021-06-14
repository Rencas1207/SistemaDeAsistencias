using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ORUSCURSO.Logica
{
  public  class Bases
    {
    
        public static void DiseñoDtv(ref DataGridView Listado)
        {
            Listado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Listado.BackgroundColor = Color.FromArgb(29, 29, 29);
            Listado.EnableHeadersVisualStyles = false;
            Listado.BorderStyle = BorderStyle.None;
            Listado.CellBorderStyle = DataGridViewCellBorderStyle.None;
            Listado.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            Listado.RowHeadersVisible = false;

            DataGridViewCellStyle cabecera = new DataGridViewCellStyle();
            cabecera.BackColor= Color.FromArgb(29, 29, 29);
            cabecera.ForeColor = Color.White;
            cabecera.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            Listado.ColumnHeadersDefaultCellStyle = cabecera;
        }
        public static void DiseñoDtvEliminar(ref DataGridView Listado)
        {
            foreach (DataGridViewRow row in Listado.Rows)
            {
                string estado;
                estado = row.Cells["Estado"].Value.ToString();
                if(estado=="ELIMINADO")
                {
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Strikeout | FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(255, 128, 128);
                }
            }
           
        }


        public static object Decimales(TextBox CajaTexto, KeyPressEventArgs e)
        {
            if((e.KeyChar=='.') || (e.KeyChar==',') )
            {
                e.KeyChar = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

            }
            if(char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if(char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar=='.' && (~CajaTexto.Text.IndexOf("."))!=0)
            {
                e.Handled = true;
            }
            else if(e.KeyChar=='.')
            {
                e.Handled = false;
            }
            else if(e.KeyChar==',')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            return null;
          

        }
    }
}
