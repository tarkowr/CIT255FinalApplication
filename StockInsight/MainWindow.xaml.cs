﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StockInsight.Model;
using StockInsight.BAL;

namespace StockInsight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Context context;
        private BusinessLayer bal;
        private string message;

        public MainWindow()
        {
            InitializeComponent();
            InstantiateFields();
            LoadInData();
        }

        /// <summary>
        /// Instantiate global fields
        /// </summary>
        private void InstantiateFields()
        {
            context = new Context();
            bal = new BusinessLayer(context);
        }

        /// <summary>
        /// Load in all of the required data for the dashboard window on its initial load
        /// </summary>
        private void LoadInData()
        {
            bal.ReadSavedWatchlist(out message);
            bal.GetAllStockCompanyData(out message);
            bal.GetAllStockDailyData(out message);
        }

        /// <summary>
        /// Exit Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Begin Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Begin_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard = new Dashboard(context, bal);
            this.Close();
            dashboard.ShowDialog();
        }

        /// <summary>
        /// Window Content Rendered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockInsight_ContentRendered(object sender, EventArgs e)
        {
            if (message != "" && message != null)
            {
                lbl_Error.Content = "WARNING: One or more errors ocurred while loading in data for this application.";
            }
        }
    }
}
