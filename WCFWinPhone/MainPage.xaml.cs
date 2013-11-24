using System;
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
using Microsoft.Phone.Controls;
using WCFWinPhone.Proxy;

namespace WCFWinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Proxy.ProductClient proxy = new Proxy.ProductClient();
            proxy.GetProductByIDAsync(int.Parse(txtProductID.Text));
            proxy.GetProductByIDCompleted += new EventHandler<Proxy.GetProductByIDCompletedEventArgs>(proxy_GetProductByIDCompleted);
        }

        private void proxy_GetProductByIDCompleted(object sender, Proxy.GetProductByIDCompletedEventArgs e)
        {
            Product oProduct = e.Result;
            txtNombre.Text = oProduct.ProductName;
            txtCategoria.Text = oProduct.Category;
            txtPrecio.Text = oProduct.UnitPrice.ToString();
            txtStock.Text = oProduct.Stock.ToString();
        }
    }
}