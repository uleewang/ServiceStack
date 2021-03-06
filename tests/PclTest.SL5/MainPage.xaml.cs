﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using PclTest.ServiceModel;
using ServiceStack;

namespace PclTest.SL5
{
    public partial class MainPage : UserControl
    {
        private JsonServiceClient client;

        public MainPage()
        {
            InitializeComponent();
            Sl5PclExportClient.Configure();
            client = new JsonServiceClient("http://localhost:81/");
        }

        private void btnGoSync_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    var response = client.Get(new Hello { Name = txtName.Text });
            //    lblResults.Text = response.Result;
            //}
            //catch (Exception ex)
            //{
            //    lblResults.Text = ex.ToString();
            //}
        }

        private void btnGoAsync_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                client.GetAsync(new Hello { Name = txtName.Text })
                    .Success(r => lblResults.Content = r.Result)
                    .Error(ex => lblResults.Content = ex.ToString());
            }
            catch (Exception ex)
            {
                lblResults.Content = ex.ToString();
            }
        }
    }
}
