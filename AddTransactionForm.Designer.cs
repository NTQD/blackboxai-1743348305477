namespace FinanceApp
{
    partial class AddTransactionForm
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
            this.cmbIncomeCategory = new System.Windows.Forms.ComboBox();
            this.cmbExpenseCategory = new System.Windows.Forms.ComboBox();
            this.cmbWallet = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.rbIncome = new System.Windows.Forms.RadioButton();
            this.rbExpense = new System.Windows.Forms.RadioButton();
            this.pnlIncome = new System.Windows.Forms.Panel();
            this.pnlExpense = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Initialize all controls with proper properties
            // and layout here (omitted for brevity)
            // ...

            // AddTransactionForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlExpense);
            this.Controls.Add(this.pnlIncome);
            this.Name = "AddTransactionForm";
            this.Text = "Thêm giao dịch";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ComboBox cmbIncomeCategory;
        private System.Windows.Forms.ComboBox cmbExpenseCategory;
        private System.Windows.Forms.ComboBox cmbWallet;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.RadioButton rbIncome;
        private System.Windows.Forms.RadioButton rbExpense;
        private System.Windows.Forms.Panel pnlIncome;
        private System.Windows.Forms.Panel pnlExpense;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}