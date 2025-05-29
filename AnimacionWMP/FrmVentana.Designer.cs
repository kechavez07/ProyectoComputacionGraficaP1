namespace AnimacionFiguras
{
    partial class FrmVentana
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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            btnPausar = new Button();
            btnIniciar = new Button();
            btnDetener = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            btnAdelantar = new Button();
            btnRetroceder = new Button();
            progressBar1 = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaptionText;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(928, 488);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint_1;
            // 
            // btnPausar
            // 
            btnPausar.Location = new Point(95, 506);
            btnPausar.Name = "btnPausar";
            btnPausar.Size = new Size(75, 23);
            btnPausar.TabIndex = 2;
            btnPausar.Text = "Pausar";
            btnPausar.UseVisualStyleBackColor = true;
            btnPausar.Click += btnPausar_Click;
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(14, 506);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(75, 23);
            btnIniciar.TabIndex = 3;
            btnIniciar.Text = "Iniciar";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // btnDetener
            // 
            btnDetener.Location = new Point(176, 506);
            btnDetener.Name = "btnDetener";
            btnDetener.Size = new Size(75, 23);
            btnDetener.TabIndex = 4;
            btnDetener.Text = "Detener";
            btnDetener.UseVisualStyleBackColor = true;
            btnDetener.Click += btnDetener_Click;
            // 
            // btnAdelantar
            // 
            btnAdelantar.Location = new Point(310, 506);
            btnAdelantar.Name = "btnAdelantar";
            btnAdelantar.Size = new Size(75, 23);
            btnAdelantar.TabIndex = 5;
            btnAdelantar.Text = "Adelantar";
            btnAdelantar.UseVisualStyleBackColor = true;
            btnAdelantar.Click += btnAdelantar_Click;
            // 
            // btnRetroceder
            // 
            btnRetroceder.Location = new Point(391, 506);
            btnRetroceder.Name = "btnRetroceder";
            btnRetroceder.Size = new Size(75, 23);
            btnRetroceder.TabIndex = 6;
            btnRetroceder.Text = "Retroceder";
            btnRetroceder.UseVisualStyleBackColor = true;
            btnRetroceder.Click += btnRetroceder_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(492, 506);
            progressBar1.Maximum = 5000;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(448, 23);
            progressBar1.TabIndex = 7;
            // 
            // FrmVentana
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 549);
            Controls.Add(progressBar1);
            Controls.Add(btnRetroceder);
            Controls.Add(btnAdelantar);
            Controls.Add(btnDetener);
            Controls.Add(btnIniciar);
            Controls.Add(btnPausar);
            Controls.Add(pictureBox1);
            Name = "FrmVentana";
            Text = "FrmVentana";
            Load += FrmVentana_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnPausar;
        private Button btnIniciar;
        private Button btnDetener;
        private System.Windows.Forms.Timer timer1;
        private Button btnAdelantar;
        private Button btnRetroceder;
        private ProgressBar progressBar1;
    }
}