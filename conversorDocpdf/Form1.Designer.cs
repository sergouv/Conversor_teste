namespace conversorDocpdf
{
    partial class Form1
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
            this.btn_origem = new System.Windows.Forms.Button();
            this.btn_destino = new System.Windows.Forms.Button();
            this.btn_converter = new System.Windows.Forms.Button();
            this.lbl_origem = new System.Windows.Forms.Label();
            this.lbl_destino = new System.Windows.Forms.Label();
            this.chk_replace = new System.Windows.Forms.CheckBox();
            this.fbd_1 = new System.Windows.Forms.FolderBrowserDialog();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.lbl_a_converter = new System.Windows.Forms.Label();
            this.lbl_progresso = new System.Windows.Forms.Label();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chk_remover_numeracao = new System.Windows.Forms.CheckBox();
            this.lbl_atual = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_origem
            // 
            this.btn_origem.Location = new System.Drawing.Point(12, 26);
            this.btn_origem.Name = "btn_origem";
            this.btn_origem.Size = new System.Drawing.Size(118, 23);
            this.btn_origem.TabIndex = 1;
            this.btn_origem.Text = "Pasta Origem";
            this.toolTip1.SetToolTip(this.btn_origem, "Pasta onde estão os manuais. Pode conter outras sub-pastas com mais manuais");
            this.btn_origem.UseVisualStyleBackColor = true;
            this.btn_origem.Click += new System.EventHandler(this.btn_origem_Click);
            // 
            // btn_destino
            // 
            this.btn_destino.Location = new System.Drawing.Point(12, 70);
            this.btn_destino.Name = "btn_destino";
            this.btn_destino.Size = new System.Drawing.Size(118, 23);
            this.btn_destino.TabIndex = 2;
            this.btn_destino.Text = "Pasta Destino";
            this.toolTip1.SetToolTip(this.btn_destino, "Pasta a colocar todos os manuais convertidos em PDF");
            this.btn_destino.UseVisualStyleBackColor = true;
            this.btn_destino.Click += new System.EventHandler(this.btn_destino_Click);
            // 
            // btn_converter
            // 
            this.btn_converter.Location = new System.Drawing.Point(12, 110);
            this.btn_converter.Name = "btn_converter";
            this.btn_converter.Size = new System.Drawing.Size(118, 23);
            this.btn_converter.TabIndex = 3;
            this.btn_converter.Text = "Converter";
            this.toolTip1.SetToolTip(this.btn_converter, "Iniciar a conversão");
            this.btn_converter.UseVisualStyleBackColor = true;
            this.btn_converter.Click += new System.EventHandler(this.btn_converter_Click);
            // 
            // lbl_origem
            // 
            this.lbl_origem.BackColor = System.Drawing.SystemColors.Info;
            this.lbl_origem.Location = new System.Drawing.Point(146, 27);
            this.lbl_origem.Name = "lbl_origem";
            this.lbl_origem.Size = new System.Drawing.Size(267, 23);
            this.lbl_origem.TabIndex = 4;
            // 
            // lbl_destino
            // 
            this.lbl_destino.BackColor = System.Drawing.SystemColors.Info;
            this.lbl_destino.Location = new System.Drawing.Point(146, 70);
            this.lbl_destino.Name = "lbl_destino";
            this.lbl_destino.Size = new System.Drawing.Size(267, 23);
            this.lbl_destino.TabIndex = 5;
            // 
            // chk_replace
            // 
            this.chk_replace.AutoSize = true;
            this.chk_replace.Location = new System.Drawing.Point(149, 116);
            this.chk_replace.Name = "chk_replace";
            this.chk_replace.Size = new System.Drawing.Size(114, 17);
            this.chk_replace.TabIndex = 6;
            this.chk_replace.Text = "Substituir Ficheiros";
            this.chk_replace.UseVisualStyleBackColor = true;
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(137, 211);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(416, 23);
            this.progress.TabIndex = 7;
            this.progress.Visible = false;
            // 
            // lbl_a_converter
            // 
            this.lbl_a_converter.AutoSize = true;
            this.lbl_a_converter.Location = new System.Drawing.Point(68, 215);
            this.lbl_a_converter.Name = "lbl_a_converter";
            this.lbl_a_converter.Size = new System.Drawing.Size(62, 13);
            this.lbl_a_converter.TabIndex = 8;
            this.lbl_a_converter.Text = "A converter";
            this.lbl_a_converter.Visible = false;
            // 
            // lbl_progresso
            // 
            this.lbl_progresso.AutoSize = true;
            this.lbl_progresso.Location = new System.Drawing.Point(145, 244);
            this.lbl_progresso.Name = "lbl_progresso";
            this.lbl_progresso.Size = new System.Drawing.Size(49, 13);
            this.lbl_progresso.TabIndex = 9;
            this.lbl_progresso.Text = "1 de 243";
            this.lbl_progresso.Visible = false;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(277, 240);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(118, 23);
            this.btn_cancelar.TabIndex = 10;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Visible = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // chk_remover_numeracao
            // 
            this.chk_remover_numeracao.AutoSize = true;
            this.chk_remover_numeracao.Checked = true;
            this.chk_remover_numeracao.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_remover_numeracao.Location = new System.Drawing.Point(286, 116);
            this.chk_remover_numeracao.Name = "chk_remover_numeracao";
            this.chk_remover_numeracao.Size = new System.Drawing.Size(127, 17);
            this.chk_remover_numeracao.TabIndex = 11;
            this.chk_remover_numeracao.Text = "Remover Numeração";
            this.chk_remover_numeracao.UseVisualStyleBackColor = true;
            this.chk_remover_numeracao.Visible = false;
            // 
            // lbl_atual
            // 
            this.lbl_atual.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_atual.Location = new System.Drawing.Point(12, 145);
            this.lbl_atual.Name = "lbl_atual";
            this.lbl_atual.Size = new System.Drawing.Size(541, 63);
            this.lbl_atual.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 282);
            this.Controls.Add(this.lbl_atual);
            this.Controls.Add(this.chk_remover_numeracao);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.lbl_progresso);
            this.Controls.Add(this.lbl_a_converter);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.chk_replace);
            this.Controls.Add(this.lbl_destino);
            this.Controls.Add(this.lbl_origem);
            this.Controls.Add(this.btn_converter);
            this.Controls.Add(this.btn_destino);
            this.Controls.Add(this.btn_origem);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conversor de manuais para PDFs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_origem;
        private System.Windows.Forms.Button btn_destino;
        private System.Windows.Forms.Button btn_converter;
        private System.Windows.Forms.Label lbl_origem;
        private System.Windows.Forms.Label lbl_destino;
        private System.Windows.Forms.CheckBox chk_replace;
        private System.Windows.Forms.FolderBrowserDialog fbd_1;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label lbl_a_converter;
        private System.Windows.Forms.Label lbl_progresso;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chk_remover_numeracao;
        private System.Windows.Forms.Label lbl_atual;
    }
}

