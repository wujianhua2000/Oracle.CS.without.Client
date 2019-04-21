using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FreeLinkOracle
{
    public partial class FormMain : Form
    {
        //.....................................................................
        /// <summary>
        /// 
        /// </summary>
        public FormMain( )
        {
            InitializeComponent( );
        }

        //.....................................................................
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click( object sender, EventArgs e )
        {
            HansOracle test = new HansOracle( );
            test.Test( );

            MessageBox.Show( test.Message );

            return;
        }

        //.....................................................................
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click( object sender, EventArgs e )
        {
            this.Close( );
        }

        //.....................................................................
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLoad_Click( object sender, EventArgs e )
        {
            HansOracle hans = new HansOracle( );
            List<Department> listing = hans.SelectBasic( );

            this.ListDept.DataSource = listing;
            this.ListDept.ValueMember = "Kurz";
            this.ListDept.DisplayMember = "Name";
            this.ListDept.Refresh( );

            //this.GridDept.DataBindings

            return;
        }

        private void FormMain_Load( object sender, EventArgs e )
        {

        }

        //.....................................................................
    }
}
