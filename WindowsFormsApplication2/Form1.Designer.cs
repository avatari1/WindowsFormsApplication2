namespace WindowsFormsApplication2
{
    partial class Main_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_form));
            this.start_btn = new System.Windows.Forms.Button();
            this.stop_btn = new System.Windows.Forms.Button();
            this.folder_field = new System.Windows.Forms.Label();
            this.choose_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.exit_btn = new System.Windows.Forms.Button();
            this.alphabox = new System.Windows.Forms.TextBox();
            this.trayicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Counterlvl = new System.Windows.Forms.Label();
            this.Counterbox = new System.Windows.Forms.TextBox();
            this.Counter_btn = new System.Windows.Forms.Button();
            this.alpha_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(18, 27);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(75, 23);
            this.start_btn.TabIndex = 0;
            this.start_btn.Text = "Start";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // stop_btn
            // 
            this.stop_btn.Enabled = false;
            this.stop_btn.Location = new System.Drawing.Point(18, 56);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(75, 23);
            this.stop_btn.TabIndex = 1;
            this.stop_btn.Text = "Stop";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // folder_field
            // 
            this.folder_field.AutoSize = true;
            this.folder_field.BackColor = System.Drawing.SystemColors.Control;
            this.folder_field.Location = new System.Drawing.Point(106, 15);
            this.folder_field.Name = "folder_field";
            this.folder_field.Size = new System.Drawing.Size(16, 13);
            this.folder_field.TabIndex = 4;
            this.folder_field.Text = "...";
            // 
            // choose_btn
            // 
            this.choose_btn.Location = new System.Drawing.Point(3, 10);
            this.choose_btn.Name = "choose_btn";
            this.choose_btn.Size = new System.Drawing.Size(86, 23);
            this.choose_btn.TabIndex = 2;
            this.choose_btn.Text = "Choose Folder";
            this.choose_btn.UseVisualStyleBackColor = true;
            this.choose_btn.Click += new System.EventHandler(this.choose_btn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.choose_btn);
            this.panel1.Controls.Add(this.folder_field);
            this.panel1.Location = new System.Drawing.Point(18, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 43);
            this.panel1.TabIndex = 5;
            // 
            // exit_btn
            // 
            this.exit_btn.BackgroundImage = global::epayments.Properties.Resources.exit41;
            this.exit_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exit_btn.Location = new System.Drawing.Point(280, 27);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(56, 49);
            this.exit_btn.TabIndex = 3;
            this.exit_btn.UseVisualStyleBackColor = true;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // alphabox
            // 
            this.alphabox.Enabled = false;
            this.alphabox.Location = new System.Drawing.Point(18, 155);
            this.alphabox.Name = "alphabox";
            this.alphabox.Size = new System.Drawing.Size(135, 20);
            this.alphabox.TabIndex = 6;
            this.alphabox.Text = "ΑMPxxxxxxKKKKK";
            this.alphabox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // trayicon
            // 
            this.trayicon.BalloonTipText = "The Application remains open in Tray. DOUble click to restore, right click to clo" +
    "se";
            this.trayicon.ContextMenuStrip = this.contextMenuStrip1;
            this.trayicon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayicon.Icon")));
            this.trayicon.Text = "epayments renamer";
            this.trayicon.Visible = true;
            this.trayicon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayicon_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 26);
            this.contextMenuStrip1.Text = "Onomatizer";
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.exitToolStripMenuItem.Text = "Exit Application";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Counterlvl
            // 
            this.Counterlvl.AutoSize = true;
            this.Counterlvl.Location = new System.Drawing.Point(230, 157);
            this.Counterlvl.Name = "Counterlvl";
            this.Counterlvl.Size = new System.Drawing.Size(44, 13);
            this.Counterlvl.TabIndex = 7;
            this.Counterlvl.Text = "Counter";
            // 
            // Counterbox
            // 
            this.Counterbox.Enabled = false;
            this.Counterbox.Location = new System.Drawing.Point(280, 155);
            this.Counterbox.Name = "Counterbox";
            this.Counterbox.Size = new System.Drawing.Size(42, 20);
            this.Counterbox.TabIndex = 8;
            this.Counterbox.Text = "1";
            this.Counterbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Counter_btn
            // 
            this.Counter_btn.Location = new System.Drawing.Point(324, 152);
            this.Counter_btn.Name = "Counter_btn";
            this.Counter_btn.Size = new System.Drawing.Size(40, 23);
            this.Counter_btn.TabIndex = 9;
            this.Counter_btn.Text = "Edit";
            this.Counter_btn.UseVisualStyleBackColor = true;
            this.Counter_btn.Click += new System.EventHandler(this.Counter_btn_Click);
            // 
            // alpha_btn
            // 
            this.alpha_btn.Location = new System.Drawing.Point(159, 152);
            this.alpha_btn.Name = "alpha_btn";
            this.alpha_btn.Size = new System.Drawing.Size(40, 23);
            this.alpha_btn.TabIndex = 10;
            this.alpha_btn.Text = "Edit";
            this.alpha_btn.UseVisualStyleBackColor = true;
            this.alpha_btn.Click += new System.EventHandler(this.alpha_btn_Click);
            // 
            // Main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 189);
            this.Controls.Add(this.alpha_btn);
            this.Controls.Add(this.Counter_btn);
            this.Controls.Add(this.Counterbox);
            this.Controls.Add(this.Counterlvl);
            this.Controls.Add(this.alphabox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.stop_btn);
            this.Controls.Add(this.start_btn);
            this.Name = "Main_form";
            this.Text = "epayment renamer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Button stop_btn;
        private System.Windows.Forms.Button exit_btn;
        private System.Windows.Forms.Label folder_field;
        private System.Windows.Forms.Button choose_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox alphabox;
        private System.Windows.Forms.NotifyIcon trayicon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label Counterlvl;
        private System.Windows.Forms.TextBox Counterbox;
        private System.Windows.Forms.Button Counter_btn;
        private System.Windows.Forms.Button alpha_btn;
    }
}

