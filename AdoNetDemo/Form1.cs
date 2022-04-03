using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = txbName.Text,
                StockAmount = Convert.ToInt32(txbStockAmount.Text),
                UnitPrice = Convert.ToDecimal(txbUnitPrice.Text),
                

            });
            LoadProducts();
            MessageBox.Show("Product Added!!!");
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                UnitPrice = Convert.ToDecimal(tbNameUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbStockAmountUpdate.Text),
                Name = tbNameUpdate.Text

            };

            _productDal.Update(product);
            LoadProducts();
            MessageBox.Show("Product updated");

        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbNameUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
            tbStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value);
            _productDal.Delete(id);
            MessageBox.Show("Product Deleted!!!");
            LoadProducts();
            
        }
    }
}
