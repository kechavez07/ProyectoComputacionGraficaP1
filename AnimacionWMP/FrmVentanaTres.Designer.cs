namespace AnimacionFiguras
{
    partial class FrmVentanaTres
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
            progressBar1 = new ProgressBar();
            btnRetroceder = new Button();
            btnAdelantar = new Button();
            btnDetener = new Button();
            btnIniciar = new Button();
            btnPausar = new Button();
            pictureBox1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(493, 508);
            progressBar1.Maximum = 5000;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(448, 23);
            progressBar1.TabIndex = 21;
            // 
            // btnRetroceder
            // 
            btnRetroceder.Location = new Point(392, 508);
            btnRetroceder.Name = "btnRetroceder";
            btnRetroceder.Size = new Size(75, 23);
            btnRetroceder.TabIndex = 20;
            btnRetroceder.Text = "Retroceder";
            btnRetroceder.UseVisualStyleBackColor = true;
            btnRetroceder.Click += btnRetroceder_Click;
            // 
            // btnAdelantar
            // 
            btnAdelantar.Location = new Point(311, 508);
            btnAdelantar.Name = "btnAdelantar";
            btnAdelantar.Size = new Size(75, 23);
            btnAdelantar.TabIndex = 19;
            btnAdelantar.Text = "Adelantar";
            btnAdelantar.UseVisualStyleBackColor = true;
            btnAdelantar.Click += btnAdelantar_Click;
            // 
            // btnDetener
            // 
            btnDetener.Location = new Point(177, 508);
            btnDetener.Name = "btnDetener";
            btnDetener.Size = new Size(75, 23);
            btnDetener.TabIndex = 18;
            btnDetener.Text = "Detener";
            btnDetener.UseVisualStyleBackColor = true;
            btnDetener.Click += btnDetener_Click;
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(15, 508);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(75, 23);
            btnIniciar.TabIndex = 17;
            btnIniciar.Text = "Iniciar";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // btnPausar
            // 
            btnPausar.Location = new Point(96, 508);
            btnPausar.Name = "btnPausar";
            btnPausar.Size = new Size(75, 23);
            btnPausar.TabIndex = 16;
            btnPausar.Text = "Pausar";
            btnPausar.UseVisualStyleBackColor = true;
            btnPausar.Click += btnPausar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaptionText;
            pictureBox1.Location = new Point(13, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(928, 488);
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // FrmVentanaTres
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(954, 545);
            Controls.Add(progressBar1);
            Controls.Add(btnRetroceder);
            Controls.Add(btnAdelantar);
            Controls.Add(btnDetener);
            Controls.Add(btnIniciar);
            Controls.Add(btnPausar);
            Controls.Add(pictureBox1);
            Name = "FrmVentanaTres";
            Text = "FrmVentanaTres";
            Load += FrmVentanaTres_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar1;
        private Button btnRetroceder;
        private Button btnAdelantar;
        private Button btnDetener;
        private Button btnIniciar;
        private Button btnPausar;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
    }
}