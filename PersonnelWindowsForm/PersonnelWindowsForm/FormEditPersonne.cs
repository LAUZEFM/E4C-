using System;
using PersonnelLibrary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonnelWindowsForm;



namespace PersonnelWindowsForm
{
    public partial class FormEditPersonne : Form
    {
        // Définition du mode d'ouverture de la fenêtre
        public enum FormPersonneMode { Ajout, Modification };
        // Mode d'ouverture de la fenêtre
        FormPersonneMode mode;

        // La classe Entreprise contenant le personnel
        private Entreprise entreprise = Entreprise.GetInstance();

        private Personne personne = null;
        public FormEditPersonne(Personne personne)
            :this(personne, FormPersonneMode.Modification)
        {

        }
        public FormEditPersonne(Personne personne, FormPersonneMode mode)
        {


            InitializeComponent();

            this.personne = personne;
        

            // La liste des services est affichée dans le ComboBox
            // la source est la liste des services
            cbService.DataSource = personne.Service;
            // DisplayMember est la propriété affichée, ici : la propriété Libelle de l'objet Personne
            cbService.DisplayMember = "Libelle";
            // ValueMember est la propriété pour obtenir la valeur du ComboBox
            cbService.ValueMember = "Id";

            // On vérifie si nous avons bien un objet Personne;
            if (personne != null)
            {
                this.personne = personne;
                this.txtId.Text = personne.Id.ToString();
                this.txtNom.Text = personne.Nom;
                this.txtPrenom.Text = personne.Prenom;
                this.dtPickerDateDenaissance.Value = personne.DateDeNaissance;
                this.txtSalBrut.Text = personne.SalaireBrut.ToString();

                // Sélection du service de la personne en cours
                cbService.SelectedItem = personne.Service;
            }

            // Il faut cloner l'objet sinon toutes les modifications effectuées
            // seront directement enregistrées. Or nous voulons valider les modifications
            // uniquement lorsque l'utilisateur clique sur OK
            this.personne = personne.Clone();
            this.txtId.Text = personne.Id.ToString();
            this.txtNom.Text = personne.Nom;
            this.txtPrenom.Text = personne.Prenom;
            this.dtPickerDateDenaissance.Value = personne.DateDeNaissance;
            this.txtSalBrut.Text = personne.SalaireBrut.ToString();
            UpdateMode(mode);
        }
        private void UpdateMode(FormPersonneMode mode)
        {
            this.mode = mode;

            switch (mode)
            {
                case FormPersonneMode.Ajout:
                    this.Text = "Ajout d'un employé";
                    txtNom.Enabled = txtPrenom.Enabled = dtPickerDateDenaissance.Enabled = true;
                    btnNouveau.Enabled = false;

                    txtId.Text = "0";
                    txtNom.Text = "";
                    txtPrenom.Text = "";
                    txtSalBrut.Text = "1500";
                    break;

                case FormPersonneMode.Modification:
                    this.Text = "Modification d'un employé";
                    // On vérifie si nous avons bien un objet Personne
                    if (personne != null)
                    {
                        this.personne = personne.Clone();
                        this.txtId.Text = personne.Id.ToString();
                        this.txtNom.Text = personne.Nom;
                        this.txtPrenom.Text = personne.Prenom;
                        this.dtPickerDateDenaissance.Value = personne.DateDeNaissance;
                        this.txtSalBrut.Text = personne.SalaireBrut.ToString();

                        // Sélection du service de la personne en cours
                        cbService.SelectedItem = personne.Service;
                    }
                    break;
            }
        }

        private void txtSalBrut_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSalBrut.Text))
            {
                this.personne.SalaireBrut = Convert.ToDouble(txtSalBrut.Text);
                txtSalNet.Text = this.personne.SalaireNet.ToString();
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Nous validons les changements dans l'objet Entreprise
            if (personne != null)
            {
                // Mise à jour du service
                personne.Service = (cbService.SelectedItem as Service);
                entreprise.ModifierPersonne(personne);

                // La valeur renvoyé est donc OK
                this.DialogResult = DialogResult.OK;
            }
            else
                this.DialogResult = DialogResult.Cancel;

            switch (this.mode)
            {
                case FormPersonneMode.Ajout:
                    try
                    {
                        Personne.TypePersonneEnum statut = (Personne.TypePersonneEnum)Enum.Parse(typeof(Personne.TypePersonneEnum), cbType.SelectedItem.ToString()); ;
                        switch (statut)
                        {
                            case Personne.TypePersonneEnum.Employe:
                                personne = new Employe(0, txtNom.Text, txtPrenom.Text, dtPickerDateDenaissance.Value, Convert.ToDouble(txtSalaireBrut.Text), cbService.SelectedItem as Service, 0);
                                break;
                            case Personne.TypePersonneEnum.Cadre:
                                personne = new Cadre(0, txtNom.Text, txtPrenom.Text, dtPickerDateDenaissance.Value, Convert.ToDouble(txtSalaireBrut.Text), cbService.SelectedItem as Service, 0);
                                break;

                        }
                        personne.SalaireBrut = Convert.ToDouble(txtSalaireBrut.Text);

                        // On ajoute la personne à l’objet entreprise
                        personne = entreprise.AjouterPersonne(personne);

                        // La valeur renvoyée est donc OK
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur : " + ex.Message);
                        this.DialogResult = DialogResult.Cancel;

                    }
                    break;
                case FormPersonneMode.Modification:
                    if (personne != null)
                    {
                        // Mise à jour du service
                        personne.Service = (cbService.SelectedItem as Service);
                        // On modifie la personne dans l’objet entreprise
                        entreprise.ModifierPersonne(personne);

                        // La valeur renvoyé est donc OK
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        this.DialogResult = DialogResult.Cancel;
                    break;
            }

        }

        private void FormEditPersonne_Load(object sender, EventArgs e)
        {

        }
    }
}
