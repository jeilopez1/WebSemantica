using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Ontologia;

namespace WebApplication1.View
{
    public partial class index : System.Web.UI.Page
    {
        Ontology ontologia = new Ontology();
       


        protected void Page_Load(object sender, EventArgs e)
        {
           // ListaPacientes.Visible = false;

            if (!IsPostBack)
            {
               
            }
        }
        protected void searchOntology(object sender, EventArgs e)
        {


            if (ColorList.SelectedValue.Equals("Enfermedad")){

                ListView1.DataSource = ontologia.Enfermedad(search.Text);
                ListView1.DataBind();
            }
            else if (ColorList.SelectedValue.Equals("Paciente")) {
                enfermedadMedicamentoMedico.DataSource = ontologia.Paciente(search.Text);
                enfermedadMedicamentoMedico.DataBind();
            }
            else if (ColorList.SelectedValue.Equals("IPS"))
            {
                ips.DataSource = ontologia.IPS(search.Text);
                ips.DataBind();
            }
            else if (ColorList.SelectedValue.Equals("Medicamento"))
            {
                InfoPaciente.DataSource = ontologia.Medicamento(search.Text);
                InfoPaciente.DataBind();
            }



            else {
                ListViewResult.DataSource = ontologia.consultarDatosGenerales(search.Text);
                ListViewResult.DataBind();
            }


        }

        protected void ColorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            search.Visible = true;
            Button2.Visible = true;
            ListaPacientes.Visible = false;
            ListaMedico.Visible = false;
            ListaIPS.Visible = false;

            InfoPaciente.Visible = false;
            ListView1.Visible = false;
            ListViewResult.Visible = false;
            enfermedadMedicamentoMedico.Visible = false;
            ips.Visible = false;

            if (ColorList.SelectedValue == "Enfermedad")
            {
                ListView1.DataSource = new DataTable(null);
                ListView1.DataBind();
                ListView1.Visible = true;
            }
            else if (ColorList.SelectedValue == "Paciente")
            {
                enfermedadMedicamentoMedico.DataSource = new DataTable(null);
                enfermedadMedicamentoMedico.DataBind();
                enfermedadMedicamentoMedico.Visible = true;

            }
            else if (ColorList.SelectedValue == "IPS")
            {
                ips.DataSource = new DataTable(null);
                ips.DataBind();
                ips.Visible = true;


            }
            else if (ColorList.SelectedValue.Equals("Medicamento"))
            {
                InfoPaciente.DataSource = new DataTable(null);
                InfoPaciente.DataBind();
                InfoPaciente.Visible = true;

            }
            else if (ColorList.SelectedValue.Equals("BPaciente"))
            {

                ListaPacientes.Visible = true;
                ListaPacientes.DataSource = ontologia.ListaPaciente();
                ListaPacientes.DataBind();
                search.Visible = false;
                Button2.Visible = false;
            }

            else if (ColorList.SelectedValue.Equals("BMedico"))
            {

                ListaMedico.Visible = true;
                ListaMedico.DataSource = ontologia.ListaMedico();
                ListaMedico.DataBind();

                search.Visible = false;
                Button2.Visible = false;
            }
            else if (ColorList.SelectedValue.Equals("BIPS"))
            {

                ListaIPS.Visible = true;
                ListaIPS.DataSource = ontologia.ListaIPS();
                ListaIPS.DataBind();

                search.Visible = false;
                Button2.Visible = false;
            }

            else
            {
                ListViewResult.DataSource = new DataTable(null);
                ListViewResult.DataBind();
                ListViewResult.Visible = true;

            }
        }
    }
}