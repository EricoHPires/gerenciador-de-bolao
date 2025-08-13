namespace WindowsFormsApplication2B
{
    partial class frmPrincipal
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCadastrarParticipante = new System.Windows.Forms.Button();
            this.btnPontuacaoRodada = new System.Windows.Forms.Button();
            this.btnRegistrarPalpite = new System.Windows.Forms.Button();
            this.btnRankingTotal = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(20, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(247, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Bolão do Brasileirão 2025";
            // 
            // btnCadastrarParticipante
            // 
            this.btnCadastrarParticipante.Location = new System.Drawing.Point(12, 191);
            this.btnCadastrarParticipante.Name = "btnCadastrarParticipante";
            this.btnCadastrarParticipante.Size = new System.Drawing.Size(125, 37);
            this.btnCadastrarParticipante.TabIndex = 1;
            this.btnCadastrarParticipante.Text = "Cadastrar Participante";
            this.btnCadastrarParticipante.UseVisualStyleBackColor = true;
            this.btnCadastrarParticipante.Click += new System.EventHandler(this.btnCadastrarParticipante_Click);
            // 
            // btnPontuacaoRodada
            // 
            this.btnPontuacaoRodada.Location = new System.Drawing.Point(151, 277);
            this.btnPontuacaoRodada.Name = "btnPontuacaoRodada";
            this.btnPontuacaoRodada.Size = new System.Drawing.Size(125, 37);
            this.btnPontuacaoRodada.TabIndex = 2;
            this.btnPontuacaoRodada.Text = "Pontuação Por Rodada";
            this.btnPontuacaoRodada.UseVisualStyleBackColor = true;
            this.btnPontuacaoRodada.Click += new System.EventHandler(this.btnPontuacaoRodada_Click);
            // 
            // btnRegistrarPalpite
            // 
            this.btnRegistrarPalpite.Location = new System.Drawing.Point(12, 234);
            this.btnRegistrarPalpite.Name = "btnRegistrarPalpite";
            this.btnRegistrarPalpite.Size = new System.Drawing.Size(125, 37);
            this.btnRegistrarPalpite.TabIndex = 3;
            this.btnRegistrarPalpite.Text = "Registrar Palpite";
            this.btnRegistrarPalpite.UseVisualStyleBackColor = true;
            this.btnRegistrarPalpite.Click += new System.EventHandler(this.btnRegistrarPalpite_Click);
            // 
            // btnRankingTotal
            // 
            this.btnRankingTotal.Location = new System.Drawing.Point(12, 277);
            this.btnRankingTotal.Name = "btnRankingTotal";
            this.btnRankingTotal.Size = new System.Drawing.Size(125, 37);
            this.btnRankingTotal.TabIndex = 4;
            this.btnRankingTotal.Text = "Pontuação Total";
            this.btnRankingTotal.UseVisualStyleBackColor = true;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(151, 234);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(125, 37);
            this.btnCalcular.TabIndex = 5;
            this.btnCalcular.Text = "Calcular Pontuações";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 326);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.btnRankingTotal);
            this.Controls.Add(this.btnRegistrarPalpite);
            this.Controls.Add(this.btnPontuacaoRodada);
            this.Controls.Add(this.btnCadastrarParticipante);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmPrincipal";
            this.Text = "Página Inicial";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCadastrarParticipante;
        private System.Windows.Forms.Button btnPontuacaoRodada;
        private System.Windows.Forms.Button btnRegistrarPalpite;
        private System.Windows.Forms.Button btnRankingTotal;
        private System.Windows.Forms.Button btnCalcular;
    }
}

