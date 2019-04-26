namespace MiniTC
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonMove = new System.Windows.Forms.Button();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.userControlPanelRight = new MiniTC.UserControlPanel();
            this.userControlPanelLeft = new MiniTC.UserControlPanel();
            this.SuspendLayout();
            // 
            // buttonMove
            // 
            this.buttonMove.Location = new System.Drawing.Point(415, 73);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(62, 84);
            this.buttonMove.TabIndex = 2;
            this.buttonMove.Text = "Move";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(415, 163);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(62, 84);
            this.buttonCopy.TabIndex = 3;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(415, 253);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(62, 84);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // userControlPanelRight
            // 
            this.userControlPanelRight.CurrentPath = "";
            this.userControlPanelRight.Location = new System.Drawing.Point(483, 12);
            this.userControlPanelRight.Name = "userControlPanelRight";
            this.userControlPanelRight.SelectedIndex = -1;
            this.userControlPanelRight.Size = new System.Drawing.Size(397, 469);
            this.userControlPanelRight.TabIndex = 1;
            this.userControlPanelRight.SelectedListBox += new System.Action(this.userControlPanelRight_SelectedListBox);
            // 
            // userControlPanelLeft
            // 
            this.userControlPanelLeft.CurrentPath = "";
            this.userControlPanelLeft.Location = new System.Drawing.Point(12, 12);
            this.userControlPanelLeft.Name = "userControlPanelLeft";
            this.userControlPanelLeft.SelectedIndex = -1;
            this.userControlPanelLeft.Size = new System.Drawing.Size(397, 469);
            this.userControlPanelLeft.TabIndex = 0;
            this.userControlPanelLeft.SelectedListBox += new System.Action(this.userControlPanelLeft_SelectedListBox);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 487);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.buttonMove);
            this.Controls.Add(this.userControlPanelRight);
            this.Controls.Add(this.userControlPanelLeft);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControlPanel userControlPanelLeft;
        private UserControlPanel userControlPanelRight;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Button buttonDelete;
    }
}

