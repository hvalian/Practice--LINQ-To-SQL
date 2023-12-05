using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LINQ_To_SQL
{
    public partial class Presenter : Form
    {
        private NorthwindDataContext northwindDataContext1 = new NorthwindDataContext();
        public Presenter()
        {
            InitializeComponent();
        }

        private void button_View_Click(object sender, EventArgs e)
        {
            Fetch f = new Fetch();

            listView.Items.Clear();

            List<ListViewItem> theList = f.GetOrders (comboBox_Customer.SelectedItem.ToString());

            for (int i = 0; i < theList.Count; i++) // Loop through List with for
            {

                listView.Items.Add(theList[i]);
            }
        }

        private void Presenter_Load(object sender, EventArgs e)
        {
            listView.Items.Clear();
            listView.Columns.Clear();
            listView.View = View.Details;
            listView.Columns.Add("Order Id");
            listView.Columns.Add("Order Date");
            listView.Columns.Add("Ship Date");
            listView.Columns.Add("Ship Name");
            listView.Columns.Add("Ship Address");
            listView.Columns.Add("Ship City");
            listView.Columns.Add("Ship Country");


            listView.Columns[0].Width = 75;
            listView.Columns[1].Width = 75;
            listView.Columns[2].Width = 75;
            listView.Columns[3].Width = 240;
            listView.Columns[4].Width = 240;
            listView.Columns[5].Width = 175;
            listView.Columns[6].Width = 175;

            menuItem_Option_LINQ.Checked = false;
            menuItem_Option_SQL.Checked = true;

            Fetch f = new Fetch();

            comboBox_Customer.Items.Clear();
            f.UseLINQ = true;
            List<string> theList = f.GetCustomerList(); // .GetCustomers();
            comboBox_Customer.DataSource = theList;
            //for (int i = 0; i < theList.Count; i++) // Loop through List with for
            //{

            //    comboBox_Customer.Items.Add(theList[i]);
            //}
        }


        private void menuItem_Option_LINQ_Click(object sender, EventArgs e)
        {
            menuItem_Option_LINQ.Checked =true;
            menuItem_Option_SQL.Checked = false;

        }

        private void menuItem_Option_SQL_Click(object sender, EventArgs e)
        {
            menuItem_Option_LINQ.Checked = false;
            menuItem_Option_SQL.Checked = true;
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }




    }
}
