using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TradeFlowers.Pages.Reports
{
    public partial class FormReportTest : Form
    {
        public FormReportTest()
        {
            InitializeComponent();
        }

        private void FormReportTest_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "wwwunifloragroup_tradeDataSet.view_product". При необходимости она может быть перемещена или удалена.
            this.view_productTableAdapter.Fill(this.wwwunifloragroup_tradeDataSet.view_product);

            this.reportViewer1.RefreshReport();
        }
    }
}
