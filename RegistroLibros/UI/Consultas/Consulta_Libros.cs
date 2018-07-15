using RegistroLibros.BLL;
using RegistroLibros.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroLibros.UI.Consultas
{
    public partial class Consulta_Libros : Form
    {
        public Consulta_Libros()
        {
            InitializeComponent();
        }

        private void BuscarFiltrobutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Libros, bool>> filter = x => 1 == 1;
            int id;
            switch (FiltrarcomboBox.SelectedIndex)
            {
                case 0://LibroId
                    id = Convert.ToInt32(FiltrartextBox.Text);
                    filter = x => x.LibroId == id
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;

                case 1://Descripcion
                    filter = x => x.Descripcion.Contains(FiltrartextBox.Text)
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;

                case 2://Siglas
                    filter = x => x.Siglas.Contains(FiltrartextBox.Text)
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
            }

            ConsultadataGridView.DataSource = LibrosBLL.GetList(filter);
        }
    }
}
