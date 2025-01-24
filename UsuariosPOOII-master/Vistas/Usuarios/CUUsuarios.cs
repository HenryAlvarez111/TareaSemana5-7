using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Usuarios.Controladores;
using Usuarios.Modelos;

namespace Usuarios.Vistas.Usuarios
{
    public partial class CUUsuarios : UserControl
    {
        public CUUsuarios()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            usuario_model nuevoUsuario = new usuario_model
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                Disponibilidad = chkDisponibilidad.Checked ? 1 : 0,
                Roles_id = (int)cmbRol.SelectedValue
            };

            usuarios_controller usuarioController = new usuarios_controller();
            string resultado = usuarioController.insertar(nuevoUsuario);

            if (resultado == "ok")
            {
                MessageBox.Show("Usuario guardado con éxito.");
            }
            else
            {
                MessageBox.Show("Hubo un error al guardar el usuario.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            chkDisponibilidad.Checked = false;
            cmbRol.SelectedIndex = -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int idUsuario = (int)lst_Usuarios.SelectedItem;

            usuarios_controller usuarioController = new usuarios_controller();
            string resultado = usuarioController.eliminar(idUsuario);

            if (resultado == "ok")
            {
                MessageBox.Show("Usuario eliminado con éxito.");
            }
            else
            {
                MessageBox.Show("Hubo un error al eliminar el usuario.");
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int idUsuario = (int)lst_Usuarios.SelectedItem;

            usuarios_controller usuarioController = new usuarios_controller();
            usuario_model usuario = usuarioController.uno(idUsuario);

            if (usuario != null)
            {
                txtUsername.Text = usuario.Username;
                txtPassword.Text = usuario.Password;
                chkDisponibilidad.Checked = usuario.Disponibilidad == 1;
                cmbRol.SelectedValue = usuario.Roles_id;
            }
            else
            {
                MessageBox.Show("Usuario no encontrado.");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CUUsuarios_Load(object sender, EventArgs e)
        {
            roles_controller rolesController = new roles_controller();
            List<roles_model> roles = rolesController.todos();

            cmbRol.DataSource = roles;
            cmbRol.DisplayMember = "Detalle";
            cmbRol.ValueMember = "Rol_Id";
        }
    }
}
