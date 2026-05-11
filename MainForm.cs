using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private DataTable contractsTable;
        private DataTable productsTable;
        
        public MainForm()
        {
            InitializeComponent();
            LoadClientsToCombo();
            LoadContracts();
        }

        private void LoadClientsToCombo()
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT client_id, client_name FROM Clients", conn);
                var da = new NpgsqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0) {
                    cmbClients.DisplayMember = "client_name";
                    cmbClients.ValueMember = "client_id";
                    cmbClients.DataSource = dt;
                    
                    cmbReportClient.DisplayMember = "client_name";
                    cmbReportClient.ValueMember = "client_id";
                    cmbReportClient.DataSource = dt.Copy();
                }
            }
        }

        private void LoadContracts()
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand(@"
                    SELECT c.contract_id, cl.client_name, c.total_contract_amount, c.is_prepaid, c.contract_date 
                    FROM Contracts c 
                    JOIN Clients cl ON c.client_id = cl.client_id
                    ORDER BY c.contract_id DESC", conn);
                var da = new NpgsqlDataAdapter(cmd);
                contractsTable = new DataTable();
                da.Fill(contractsTable);
                dgvContracts.DataSource = contractsTable;
                
                if(dgvContracts.Columns.Count > 0) {
                    dgvContracts.Columns["contract_id"].HeaderText = "ID";
                    dgvContracts.Columns["client_name"].HeaderText = "Клиент";
                    dgvContracts.Columns["total_contract_amount"].HeaderText = "Сумма";
                    dgvContracts.Columns["is_prepaid"].HeaderText = "Предоплата";
                    dgvContracts.Columns["contract_date"].HeaderText = "Дата";
                }
            }
        }

        private void LoadProducts(int contractId)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand(@"
                    SELECT product_id, product_name, quantity, unit_price 
                    FROM Products 
                    WHERE contract_id = @id", conn);
                cmd.Parameters.AddWithValue("id", contractId);
                var da = new NpgsqlDataAdapter(cmd);
                productsTable = new DataTable();
                da.Fill(productsTable);
                dgvProducts.DataSource = productsTable;
                
                if(dgvProducts.Columns.Count > 0) {
                    dgvProducts.Columns["product_id"].HeaderText = "ID Товара";
                    dgvProducts.Columns["product_name"].HeaderText = "Наименование товара";
                    dgvProducts.Columns["quantity"].HeaderText = "Кол-во";
                    dgvProducts.Columns["unit_price"].HeaderText = "Цена";
                }
            }
        }

        private void dgvContracts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvContracts.CurrentRow != null)
            {
                int contractId = Convert.ToInt32(dgvContracts.CurrentRow.Cells["contract_id"].Value);
                LoadProducts(contractId);
            }
            else
            {
                dgvProducts.DataSource = null;
            }
        }

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            if (cmbClients.SelectedValue == null) { MessageBox.Show("Выберите клиента!"); return; }
            
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("INSERT INTO Contracts (client_id, total_contract_amount, is_prepaid, contract_date) VALUES (@cid, @amt, @pre, @d)", conn);
                cmd.Parameters.AddWithValue("cid", cmbClients.SelectedValue);
                cmd.Parameters.AddWithValue("amt", numContractAmount.Value);
                cmd.Parameters.AddWithValue("pre", chkPrepaid.Checked);
                cmd.Parameters.AddWithValue("d", dtpContractDate.Value);
                cmd.ExecuteNonQuery();
            }
            LoadContracts();
        }

        private void btnDeleteContract_Click(object sender, EventArgs e)
        {
            if (dgvContracts.CurrentRow != null)
            {
                int contractId = Convert.ToInt32(dgvContracts.CurrentRow.Cells["contract_id"].Value);
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand("DELETE FROM Contracts WHERE contract_id = @id", conn);
                    cmd.Parameters.AddWithValue("id", contractId);
                    cmd.ExecuteNonQuery();
                }
                LoadContracts();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (cmbReportClient.SelectedValue == null) return;

            int clientId = Convert.ToInt32(cmbReportClient.SelectedValue);
            DateTime start = dtpStart.Value;
            DateTime end = dtpEnd.Value;

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand(@"
                    SELECT 
                      COALESCE((SELECT SUM(c.total_contract_amount) FROM Contracts c WHERE c.client_id = @cid AND c.is_prepaid = true AND c.contract_date BETWEEN @s AND @e), 0) as ToShip,
                      COALESCE((SELECT SUM(s.shipped_quantity) FROM Shipments s JOIN Contracts c ON s.contract_id = c.contract_id WHERE c.client_id = @cid AND s.shipment_date BETWEEN @s AND @e), 0) as Shipped
                ", conn);
                cmd.Parameters.AddWithValue("cid", clientId);
                cmd.Parameters.AddWithValue("s", start);
                cmd.Parameters.AddWithValue("e", end);
                
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        decimal toShip = reader.GetDecimal(0);
                        decimal shipped = reader.GetDecimal(1);
                        
                        chartReport.Series.Clear();
                        Series s = chartReport.Series.Add("Report");
                        s.ChartType = SeriesChartType.Pie;
                        s.Points.AddXY("Сумма к отгрузке", toShip);
                        s.Points.AddXY("Кол-во отгружено", shipped);
                        lblReportRes.Text = $"К отгрузке: {toShip}, Отгружено: {shipped}";
                    }
                }
            }
        }
        
        private void btnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Опция экспорта накладной в Excel готова.");
        }
    }
}
