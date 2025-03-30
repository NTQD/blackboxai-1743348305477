namespace FinanceApp
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvIncome = new System.Windows.Forms.DataGridView();
            this.dgvExpense = new System.Windows.Forms.DataGridView();
            this.lblIncomeTotal = new System.Windows.Forms.Label();
            this.lblExpenseTotal = new System.Windows.Forms.Label();
            this.lblNetTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).BeginInit();
            this.SuspendLayout();
            
            // dgvIncome
            this.dgvIncome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncome.Location = new System.Drawing.Point(20, 20);
            this.dgvIncome.Name = "dgvIncome";
            this.dgvIncome.Size = new System.Drawing.Size(400, 150);
            this.dgvIncome.TabIndex = 0;
            
            // dgvExpense
            this.dgvExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpense.Location = new System.Drawing.Point(20, 190);
            this.dgvExpense.Name = "dgvExpense";
            this.dgvExpense.Size = new System.Drawing.Size(400, 150);
            this.dgvExpense.TabIndex = 1;
            
            // lblIncomeTotal
            this.lblIncomeTotal.AutoSize = true;
            this.lblIncomeTotal.Location = new System.Drawing.Point(450, 20);
            this.lblIncomeTotal.Name = "lblIncomeTotal";
            this.lblIncomeTotal.Size = new System.Drawing.Size(100, 13);
            this.lblIncomeTotal.TabIndex = 2;
            this.lblIncomeTotal.Text = "Tổng thu: 0";
            
            // lblExpenseTotal
            this.lblExpenseTotal.AutoSize = true;
            this.lblExpenseTotal.Location = new System.Drawing.Point(450, 50);
            this.lblExpenseTotal.Name = "lblExpenseTotal";
            this.lblExpenseTotal.Size = new System.Drawing.Size(100, 13);
            this.lblExpenseTotal.TabIndex = 3;
            this.lblExpenseTotal.Text = "Tổng chi: 0";
            
            // lblNetTotal
            this.lblNetTotal.AutoSize = true;
            this.lblNetTotal.Location = new System.Drawing.Point(450, 80);
            this.lblNetTotal.Name = "lblNetTotal";
            this.lblNetTotal.Size = new System.Drawing.Size(100, 13);
            this.lblNetTotal.TabIndex = 4;
            this.lblNetTotal.Text = "Tổng cộng: 0";
            
            // ReportForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.lblNetTotal);
            this.Controls.Add(this.lblExpenseTotal);
            this.Controls.Add(this.lblIncomeTotal);
            this.Controls.Add(this.dgvExpense);
            this.Controls.Add(this.dgvIncome);
            this.Name = "ReportForm";
            this.Text = "Báo cáo tài chính";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvIncome;
        private System.Windows.Forms.DataGridView dgvExpense;
        private System.Windows.Forms.Label lblIncomeTotal;
        private System.Windows.Forms.Label lblExpenseTotal;
        private System.Windows.Forms.Label lblNetTotal;
    }
}