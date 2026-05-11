namespace WindowsFormsApp1
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvContracts = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeleteContract = new System.Windows.Forms.Button();
            this.btnAddContract = new System.Windows.Forms.Button();
            this.dtpContractDate = new System.Windows.Forms.DateTimePicker();
            this.chkPrepaid = new System.Windows.Forms.CheckBox();
            this.numContractAmount = new System.Windows.Forms.NumericUpDown();
            this.cmbClients = new System.Windows.Forms.ComboBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblReportRes = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.cmbReportClient = new System.Windows.Forms.ComboBox();
            this.chartReport = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numContractAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartReport)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(950, 600);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(942, 574);
            this.tabPage1.Text = "Договоры и Товары";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // Panel1
            this.splitContainer1.Panel1.Controls.Add(this.dgvContracts);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // Panel2
            this.splitContainer1.Panel2.Controls.Add(this.dgvProducts);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            // 
            // dgvContracts
            // 
            this.dgvContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContracts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContracts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContracts.SelectionChanged += new System.EventHandler(this.dgvContracts_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDeleteContract);
            this.panel1.Controls.Add(this.btnAddContract);
            this.panel1.Controls.Add(this.dtpContractDate);
            this.panel1.Controls.Add(this.chkPrepaid);
            this.panel1.Controls.Add(this.numContractAmount);
            this.panel1.Controls.Add(this.cmbClients);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Height = 50;
            // 
            // btnAddContract
            // 
            this.btnAddContract.Location = new System.Drawing.Point(550, 10);
            this.btnAddContract.Text = "Добавить";
            this.btnAddContract.Click += new System.EventHandler(this.btnAddContract_Click);
            // 
            // btnDeleteContract
            // 
            this.btnDeleteContract.Location = new System.Drawing.Point(650, 10);
            this.btnDeleteContract.Text = "Удалить";
            this.btnDeleteContract.Click += new System.EventHandler(this.btnDeleteContract_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Height = 30;
            // 
            // label1
            // 
            this.label1.Text = "Товары по выбранному договору:";
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.AutoSize = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chartReport);
            this.tabPage2.Controls.Add(this.btnExport);
            this.tabPage2.Controls.Add(this.lblReportRes);
            this.tabPage2.Controls.Add(this.btnReport);
            this.tabPage2.Controls.Add(this.dtpEnd);
            this.tabPage2.Controls.Add(this.dtpStart);
            this.tabPage2.Controls.Add(this.cmbReportClient);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(942, 574);
            this.tabPage2.Text = "Отчеты и Накладные";
            // 
            // cmbReportClient
            // 
            this.cmbReportClient.Location = new System.Drawing.Point(10, 10);
            this.cmbReportClient.Size = new System.Drawing.Size(200, 21);
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(220, 10);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(430, 10);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(640, 10);
            this.btnReport.Text = "Сформировать отчет";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // lblReportRes
            // 
            this.lblReportRes.AutoSize = true;
            this.lblReportRes.Location = new System.Drawing.Point(10, 50);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(10, 80);
            this.btnExport.Size = new System.Drawing.Size(200, 30);
            this.btnExport.Text = "Экспорт накладной в Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // chartReport
            // 
            chartArea1.Name = "ChartArea1";
            this.chartReport.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartReport.Legends.Add(legend1);
            this.chartReport.Location = new System.Drawing.Point(250, 50);
            this.chartReport.Name = "chartReport";
            this.chartReport.Size = new System.Drawing.Size(500, 400);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.tabControl1);
            this.Text = "База Данных: Реализация Товаров (Азарян)";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numContractAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartReport)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvContracts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteContract;
        private System.Windows.Forms.Button btnAddContract;
        private System.Windows.Forms.DateTimePicker dtpContractDate;
        private System.Windows.Forms.CheckBox chkPrepaid;
        private System.Windows.Forms.NumericUpDown numContractAmount;
        private System.Windows.Forms.ComboBox cmbClients;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblReportRes;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.ComboBox cmbReportClient;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartReport;
    }
}
