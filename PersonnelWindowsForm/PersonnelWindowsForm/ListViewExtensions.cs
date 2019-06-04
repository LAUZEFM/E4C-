using PersonnelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PersonnelWindowsForm
{
    static class ListViewExtensions
    {
        public static ListViewItem AddPersonne(this ListView lv, Personne personne)
        {
            if (personne == null)
                return null;

            ListViewItem lvi = new ListViewItem(new string[] { personne.Id.ToString(), personne.Service.ToString(),
                                            personne.Nom, personne.Prenom, personne.SalaireBrut.ToString("C"),
                                            personne.SalaireNet.ToString("C"), personne.Service.Libelle });
            // On stocke l'objet Personne pour le réutiliser plus tard
            lvi.Tag = personne;
            lv.Items.Add(lvi);

            return lvi;

        }
        public static ListViewItem UpdatePersonne(this ListView lv, Personne personne)
        {
            if (personne == null)
                return null;

            ListViewItem lvi = lv.FindItemWithText(personne.Id.ToString());
            if (lvi != null)
            {
                lvi.SubItems[4].Text = personne.SalaireBrut.ToString("C");
                lvi.SubItems[5].Text = personne.SalaireNet.ToString("C");
                lvi.SubItems[6].Text = personne.Service.Libelle;
                lvi.Tag = personne;
            }

            return lvi;
        }

        public static bool SupprimerPersonne(this ListView lv, Personne personne)
        {
            ListViewItem lvi = lv.FindItemWithText(personne.Id.ToString());
            if (lvi != null)
            {
                lv.Items.Remove(lvi);
                return true;
            }

            return false;
        }

    }
}
