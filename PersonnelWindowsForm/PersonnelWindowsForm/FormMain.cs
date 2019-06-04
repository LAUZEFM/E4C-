using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonnelLibrary;

namespace PersonnelWindowsForm
{
    public partial class FormMain : Form
    {
        // La classe Entreprise contenant le personnel
        Entreprise entreprise = Entreprise.GetInstance();
        public FormMain()
        {
            
            // Au début on entre les valeurs en dur
            Service production = new Service(1, "Production");
            entreprise.AjouterService(production);
            Service compta = new Service(2, "Comptabilité");
            entreprise.AjouterService(compta);
            Service direction = new Service(3, "Direction");
            entreprise.AjouterService(direction);

            entreprise.AjouterPersonne(new Employe(1, "DUPONT", "Charles", new DateTime(1998, 04, 12), 1500, production, 30));
            entreprise.AjouterPersonne(new Employe(2, "KERBAN", "Henry", new DateTime(1981, 09, 24), 1500, production, 30));
            entreprise.AjouterPersonne(new Employe(3, "CHAMPOT", "Paul", new DateTime(1981, 09, 17), 1500, production, 30));
            entreprise.AjouterPersonne(new Cadre(4, "JOULIE", "Alexandre", new DateTime(1987, 11, 21), 2100, compta, 100, Cadre.TypeStatut.Financier));
            entreprise.AjouterPersonne(new Cadre(5, "MITAUT", "Marcel", new DateTime(1972, 03, 04), 6000, direction, 2000, Cadre.TypeStatut.Administratif));

            InitializeComponent();


        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            // Chargement des employés
            foreach (Personne personne in entreprise.Personnes)
            {
                // Ajout de l'élément au ListView avec la méthode d'extension
                lvPersonnel.AddPersonne(personne);
            }
            
            // Version ListView
            lvPersonnel.Columns.Clear();
            // Ajout des colonnes
            lvPersonnel.Columns.Add(new ColumnHeader() { Name = "Id", Text = "Id", Width = 30 });
            lvPersonnel.Columns.Add(new ColumnHeader() { Name = "Statut", Text = "Statut", Width = 80 });
            lvPersonnel.Columns.Add(new ColumnHeader() { Name = "Nom", Text = "Nom", Width = 120 });
            lvPersonnel.Columns.Add(new ColumnHeader() { Name = "Prenom", Text = "Prénom", Width = 100 });
            lvPersonnel.Columns.Add(new ColumnHeader() { Name = "SalaireBrut", Text = "Salaire brut", Width = 80 });
            lvPersonnel.Columns.Add(new ColumnHeader() { Name = "SalaireNet", Text = "Salaire net", Width = 80 });
            lvPersonnel.Columns.Add(new ColumnHeader() { Name = "Service", Text = "Service", Width = 120 });

            lvPersonnel.Items.Clear();
            // Chargement des employés
            foreach (Personne personne in entreprise.Personnes)
            {
                // Création de l'élément à ajouter au ListView
                ListViewItem lvi = new ListViewItem(new string[] { personne.Id.ToString(), personne.Service.ToString(),
                                    personne.Nom, personne.Prenom, personne.SalaireBrut.ToString("C"),
                                    personne.SalaireNet.ToString("C"), personne.Service.Libelle });
                // On stocke l'objet Personne pour le réutiliser plus tard
                lvi.Tag = personne;

                // Ajout de l'élément
                lvPersonnel.Items.Add(lvi);
            }

        }
        private void ModifierPersonne(Personne personne)
        {
            // Création du formulaire
            FormEditPersonne form = new FormEditPersonne(personne);
            // Appel du formualire en mode "Modal"
            if (form.ShowDialog() == DialogResult.OK)
            {
                // L'utilisateur a cliqué sur le bouton Valider
                // Validation du formulaire : modification dans la listview
                if (lvPersonnel.UpdatePersonne(personne) == null)
                {
                    MessageBox.Show("L'employé n'a pas pu être modifié", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void lvPersonnel_DoubleClick(object sender, EventArgs e)
        {
            modifierToolStripMenuItem_Click(sender, e);

            FormEditPersonne form = new FormEditPersonne();
            if (form.ShowDialog() == DialogResult.OK)
            {
                // L'utilisateur a cliqué sur le bouton Valider
                // On recharge la listview
            }
            // Obtention de la liste des éléments sélectionnés
            ListView.SelectedListViewItemCollection selected = lvPersonnel.SelectedItems;
            // On regarde si 1 seul élément a été sélectionné
            if (selected.Count == 1)
            {
                // On récupère l'objet dans la propriété Tag pour le "caster" en objet Personne
                ModifierPersonne(selected[0].Tag as Personne);
            }

        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Obtention de la liste des éléments sélectionnés
            ListView.SelectedListViewItemCollection selected = lvPersonnel.SelectedItems;
            // On regarde si 1 seul élément a été sélectionné
            if (selected.Count == 1)
            {
                // On récupère l'objet dans la propriété Tag pour le "caster" en objet Personne
                ModifierPersonne(selected[0].Tag as Personne);
            }
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AjoutPersonne();
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Obtention de la liste des éléments sélectionnés
            ListView.SelectedListViewItemCollection selected = lvPersonnel.SelectedItems;
            // On regarde si 1 seul élément a été sélectionné
            if (selected.Count == 1)
            {
                // On récupère l'objet dans la propriété Tag pour le "caster" en objet Personne
                SupprimerPersonne(selected[0].Tag as Personne);
            }
        }
        private void SupprimerPersonne(Personne personne)
        {
            string message = string.Format("Voulez-vous supprimer la personne {0}-{1} ?", personne.Id, personne.Nom);
            if (MessageBox.Show(message, "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                // Suppression dans l'bejt "entreprise"
                if (entreprise.SupprimerPersonne(personne))
                {
                    // Suppression dans la listview
                    lvPersonnel.SupprimerPersonne(personne);

                }
                else
                {
                    MessageBox.Show("L'employé n'a pas pu être supprimé", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AjoutPersonne()
        {
            // Création du formulaire
            FormEditPersonne form = new FormEditPersonne(null);
            // Appel du formualire en mode "Modal"
            if (form.ShowDialog() == DialogResult.OK)
            {
                // Validation du formulaire : modification dans la listview
                if (lvPersonnel.AddPersonne(form.PersonneEnCours) == null)
                {
                    MessageBox.Show("L'employé n'a pas pu être ajouté", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ContextMenuStripListView_Opening(object sender, CancelEventArgs e)
        {
            // Obtention de la liste des éléments sélectionnés
            ListView.SelectedListViewItemCollection selected = lvPersonnel.SelectedItems;
            // On regarde si 1 seul élément a été sélectionné
            modifierToolStripMenuItem.Enabled = supprimerToolStripMenuItem.Enabled = (selected.Count == 1);

        }

        private void lvPersonnel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
