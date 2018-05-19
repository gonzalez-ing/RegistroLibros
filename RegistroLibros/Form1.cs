using RegistroLibros.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroLibros
{
    public partial class Form1 : Form
    {
        Libros libros;
        public Form1()
        {
            InitializeComponent();
            libros = new Libros();
            TipoIdcomboBox.DataSource = Enum.GetValues(typeof(TipoId.Tipo));
        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            SiglastextBox.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Libros libros;
            bool Paso = false;

            //todo: llamar la validacion.

            libros = LlenaClase();

            //Determinar si es Guardar o Modificar
            if (IdnumericUpDown.Value == 0)
                Paso = BLL.LibrosBLL.Guardar(libros);
            else
                Paso = BLL.LibrosBLL.Modificar(LlenaClase());

            //Informar el resultado
            if (Paso)
                MessageBox.Show("Guardado!!", "Excelente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar!!", "Hay Problemas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (BLL.LibrosBLL.Eliminar(id))
                MessageBox.Show("Eliminado!!", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar!!", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Libros libros = BLL.LibrosBLL.Buscar(id);

            if (libros != null)
            {
                DescripciontextBox.Text = libros.Descripcion;
                SiglastextBox.Text = libros.Siglas;
            }
            else
                MessageBox.Show("No se encontro!", "Hay Problemas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private Libros LlenaClase()
        {
            Libros libros = new Libros();

            libros.LibroId = Convert.ToInt32(IdnumericUpDown.Value);
            libros.Descripcion = DescripciontextBox.Text;
            libros.Siglas = SiglastextBox.Text;

            return libros;
        }

        private bool Validar()
        {
            bool HayErrores = false;
            //todo: quitar los mensajes de los errores que ya no estan.

            if (String.IsNullOrWhiteSpace(DescripciontextBox.Text))
            {
                MyerrorProvider.SetError(DescripciontextBox,
                    "No debes dejar la descripcion vacio");
                HayErrores = true;
            }

            //todo: validar demas campos
            return HayErrores;
        }
    }

}
