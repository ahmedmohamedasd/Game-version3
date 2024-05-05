namespace Game
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.panel_add = new System.Windows.Forms.Panel();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.lbl_ip = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.txt_game_id = new System.Windows.Forms.TextBox();
            this.lbl_game_id = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.panel_container = new System.Windows.Forms.Panel();
            this.btn_endGame = new System.Windows.Forms.Button();
            this.lbl_Camera2 = new System.Windows.Forms.Label();
            this.btn_Save_camera = new System.Windows.Forms.Button();
            this.cboDevice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Close_Timer = new System.Windows.Forms.Timer(this.components);
            this.btn_closing = new System.Windows.Forms.Button();
            this.comboBox_rotate = new System.Windows.Forms.ComboBox();
            this.lbl_rotate = new System.Windows.Forms.Label();
            this.panel_add.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.panel_container.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_add
            // 
            this.panel_add.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_add.Controls.Add(this.txt_ip);
            this.panel_add.Controls.Add(this.lbl_ip);
            this.panel_add.Controls.Add(this.btn_add);
            this.panel_add.Controls.Add(this.txt_game_id);
            this.panel_add.Controls.Add(this.lbl_game_id);
            this.panel_add.Location = new System.Drawing.Point(72, 109);
            this.panel_add.Name = "panel_add";
            this.panel_add.Size = new System.Drawing.Size(422, 193);
            this.panel_add.TabIndex = 9;
            // 
            // txt_ip
            // 
            this.txt_ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ip.Location = new System.Drawing.Point(127, 15);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(278, 29);
            this.txt_ip.TabIndex = 11;
            // 
            // lbl_ip
            // 
            this.lbl_ip.AutoSize = true;
            this.lbl_ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ip.Location = new System.Drawing.Point(3, 14);
            this.lbl_ip.Name = "lbl_ip";
            this.lbl_ip.Size = new System.Drawing.Size(35, 29);
            this.lbl_ip.TabIndex = 10;
            this.lbl_ip.Text = "IP";
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.White;
            this.btn_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(8, 118);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(397, 44);
            this.btn_add.TabIndex = 9;
            this.btn_add.Text = "Save";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            this.btn_add.MouseEnter += new System.EventHandler(this.btn_add_MouseEnter);
            this.btn_add.MouseLeave += new System.EventHandler(this.btn_add_MouseLeave);
            // 
            // txt_game_id
            // 
            this.txt_game_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_game_id.Location = new System.Drawing.Point(127, 71);
            this.txt_game_id.Name = "txt_game_id";
            this.txt_game_id.Size = new System.Drawing.Size(278, 29);
            this.txt_game_id.TabIndex = 8;
            // 
            // lbl_game_id
            // 
            this.lbl_game_id.AutoSize = true;
            this.lbl_game_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_game_id.Location = new System.Drawing.Point(3, 70);
            this.lbl_game_id.Name = "lbl_game_id";
            this.lbl_game_id.Size = new System.Drawing.Size(107, 29);
            this.lbl_game_id.TabIndex = 6;
            this.lbl_game_id.Text = "Game ID";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1170, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // Logo
            // 
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Logo.Location = new System.Drawing.Point(166, 15);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(229, 88);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 19;
            this.Logo.TabStop = false;
            // 
            // panel_container
            // 
            this.panel_container.Controls.Add(this.lbl_rotate);
            this.panel_container.Controls.Add(this.comboBox_rotate);
            this.panel_container.Controls.Add(this.btn_endGame);
            this.panel_container.Controls.Add(this.lbl_Camera2);
            this.panel_container.Controls.Add(this.btn_Save_camera);
            this.panel_container.Controls.Add(this.cboDevice);
            this.panel_container.Controls.Add(this.Logo);
            this.panel_container.Controls.Add(this.panel_add);
            this.panel_container.Location = new System.Drawing.Point(189, 88);
            this.panel_container.Name = "panel_container";
            this.panel_container.Size = new System.Drawing.Size(553, 632);
            this.panel_container.TabIndex = 20;
            // 
            // btn_endGame
            // 
            this.btn_endGame.BackColor = System.Drawing.Color.White;
            this.btn_endGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_endGame.Location = new System.Drawing.Point(72, 529);
            this.btn_endGame.Name = "btn_endGame";
            this.btn_endGame.Size = new System.Drawing.Size(406, 44);
            this.btn_endGame.TabIndex = 24;
            this.btn_endGame.Text = "End Game";
            this.btn_endGame.UseVisualStyleBackColor = false;
            this.btn_endGame.Click += new System.EventHandler(this.btn_endGame_Click);
            this.btn_endGame.MouseEnter += new System.EventHandler(this.btn_endGame_MouseEnter);
            this.btn_endGame.MouseLeave += new System.EventHandler(this.btn_endGame_MouseLeave);
            // 
            // lbl_Camera2
            // 
            this.lbl_Camera2.AutoSize = true;
            this.lbl_Camera2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Camera2.Location = new System.Drawing.Point(66, 342);
            this.lbl_Camera2.Name = "lbl_Camera2";
            this.lbl_Camera2.Size = new System.Drawing.Size(110, 31);
            this.lbl_Camera2.TabIndex = 23;
            this.lbl_Camera2.Text = "Camera";
            // 
            // btn_Save_camera
            // 
            this.btn_Save_camera.BackColor = System.Drawing.Color.White;
            this.btn_Save_camera.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save_camera.Location = new System.Drawing.Point(72, 460);
            this.btn_Save_camera.Name = "btn_Save_camera";
            this.btn_Save_camera.Size = new System.Drawing.Size(406, 44);
            this.btn_Save_camera.TabIndex = 22;
            this.btn_Save_camera.Text = "Save";
            this.btn_Save_camera.UseVisualStyleBackColor = false;
            this.btn_Save_camera.Click += new System.EventHandler(this.btn_Save_camera_Click);
            this.btn_Save_camera.MouseEnter += new System.EventHandler(this.btn_Save_camera_MouseEnter);
            this.btn_Save_camera.MouseLeave += new System.EventHandler(this.btn_Save_camera_MouseLeave);
            // 
            // cboDevice
            // 
            this.cboDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDevice.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDevice.FormattingEnabled = true;
            this.cboDevice.Location = new System.Drawing.Point(182, 347);
            this.cboDevice.Name = "cboDevice";
            this.cboDevice.Size = new System.Drawing.Size(296, 35);
            this.cboDevice.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "           ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Close_Timer
            // 
            this.Close_Timer.Interval = 3000;
            this.Close_Timer.Tick += new System.EventHandler(this.Close_Timer_Tick);
            // 
            // btn_closing
            // 
            this.btn_closing.Location = new System.Drawing.Point(783, 62);
            this.btn_closing.Name = "btn_closing";
            this.btn_closing.Size = new System.Drawing.Size(58, 44);
            this.btn_closing.TabIndex = 22;
            this.btn_closing.Text = "X";
            this.btn_closing.UseVisualStyleBackColor = true;
            this.btn_closing.Click += new System.EventHandler(this.btn_closing_Click);
            this.btn_closing.MouseEnter += new System.EventHandler(this.btn_closing_MouseEnter);
            this.btn_closing.MouseLeave += new System.EventHandler(this.btn_closing_MouseLeave);
            // 
            // comboBox_rotate
            // 
            this.comboBox_rotate.BackColor = System.Drawing.Color.White;
            this.comboBox_rotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_rotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_rotate.FormattingEnabled = true;
            this.comboBox_rotate.Location = new System.Drawing.Point(182, 401);
            this.comboBox_rotate.Name = "comboBox_rotate";
            this.comboBox_rotate.Size = new System.Drawing.Size(296, 37);
            this.comboBox_rotate.TabIndex = 25;
            // 
            // lbl_rotate
            // 
            this.lbl_rotate.AutoSize = true;
            this.lbl_rotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_rotate.Location = new System.Drawing.Point(66, 401);
            this.lbl_rotate.Name = "lbl_rotate";
            this.lbl_rotate.Size = new System.Drawing.Size(95, 31);
            this.lbl_rotate.TabIndex = 26;
            this.lbl_rotate.Text = "Rotate";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(883, 749);
            this.Controls.Add(this.btn_closing);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_container);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.panel_add.ResumeLayout(false);
            this.panel_add.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.panel_container.ResumeLayout(false);
            this.panel_container.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel_add;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox txt_game_id;
        private System.Windows.Forms.Label lbl_game_id;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Panel panel_container;
        private System.Windows.Forms.ComboBox cboDevice;
        private System.Windows.Forms.Button btn_Save_camera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer Close_Timer;
        private System.Windows.Forms.Label lbl_Camera2;
        private System.Windows.Forms.Button btn_closing;
        private System.Windows.Forms.Button btn_endGame;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.Label lbl_ip;
        private System.Windows.Forms.Label lbl_rotate;
        private System.Windows.Forms.ComboBox comboBox_rotate;
    }
}