namespace PersonnelWindowsForm
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvPersonnel = new System.Windows.Forms.ListView();
            this.ContextMenuStripListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.ContextMenuStripListView.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvPersonnel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 100);
            this.panel1.TabIndex = 2;
            // 
            // lvPersonnel
            // 
            this.lvPersonnel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPersonnel.FullRowSelect = true;
            this.lvPersonnel.GridLines = true;
            this.lvPersonnel.Location = new System.Drawing.Point(0, 0);
            this.lvPersonnel.Name = "lvPersonnel";
            this.lvPersonnel.Size = new System.Drawing.Size(473, 100);
            this.lvPersonnel.TabIndex = 2;
            this.lvPersonnel.UseCompatibleStateImageBehavior = false;
            this.lvPersonnel.View = System.Windows.Forms.View.Details;
            this.lvPersonnel.SelectedIndexChanged += new System.EventHandler(this.lvPersonnel_SelectedIndexChanged);
            this.lvPersonnel.DoubleClick += new System.EventHandler(this.lvPersonnel_DoubleClick);
            // 
            // ContextMenuStripListView
            // 
            this.ContextMenuStripListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifierToolStripMenuItem,
            this.ajouterToolStripMenuItem,
            this.supprimerToolStripMenuItem});
            this.ContextMenuStripListView.Name = "ContextMenuStripListView";
            this.ContextMenuStripListView.Size = new System.Drawing.Size(130, 70);
            this.ContextMenuStripListView.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripListView_Opening);
            // 
            // modifierToolStripMenuItem
            // 
            this.modifierToolStripMenuItem.Name = "modifierToolStripMenuItem";
            this.modifierToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.modifierToolStripMenuItem.Text = "Modifier";
            this.modifierToolStripMenuItem.Click += new System.EventHandler(this.modifierToolStripMenuItem_Click);
            // 
            // ajouterToolStripMenuItem
            // 
            this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            this.ajouterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ajouterToolStripMenuItem.Text = "Ajouter";
            this.ajouterToolStripMenuItem.Click += new System.EventHandler(this.ajouterToolStripMenuItem_Click);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.supprimerToolStripMenuItem.Text = "Supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 429);
            this.ContextMenuStrip = this.ContextMenuStripListView;
            this.Controls.Add(this.panel1);
            this.Name = "FormMain";
            this.Text = "Gestion du personnel";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel1.ResumeLayout(false);
            this.ContextMenuStripListView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvPersonnel;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStripListView;
        private System.Windows.Forms.ToolStripMenuItem modifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
    }
}