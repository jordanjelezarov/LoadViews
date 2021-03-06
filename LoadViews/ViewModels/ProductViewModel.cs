﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LoadViews
{
    public class ProductViewModel: ObservableObject, IPageViewModel
    {
        private int productId;
        private ProductModel currentProduct;
        private ICommand getProductCommand;
        private ICommand saveProductCommand;

        public string Name
        {
            get { return "Products"; }
        }

        public int ProductId
        {
            get { return productId; }
            set
            {
                if (value != productId)
                {
                    productId = value;
                    OnPropertyChanged("ProductId");
                }
            }
        }

        public ProductModel CurrentProduct
        {
            get { return currentProduct; }
            set
            {
                if (value != currentProduct)
                {
                    currentProduct = value;
                    OnPropertyChanged("CurrentProduct");
                }
            }
        }

        public ICommand GetProductCommand
        {
            get
            {
                if (getProductCommand == null)
                {
                    getProductCommand = new RelayCommand(
                        param => GetProduct(),
                        param => ProductId > 0
                    );
                }
                return getProductCommand;
            }
        }

        public ICommand SaveProductCommand
        {
            get
            {
                if (saveProductCommand == null)
                {
                    saveProductCommand = new RelayCommand(
                        param => SaveProduct(),
                        param => (CurrentProduct != null)
                    );
                }
                return saveProductCommand;
            }
        }

        private void GetProduct()
        {
            ProductModel p = new ProductModel();
            p.ProductId = ProductId;
            p.ProductName = "Test Product";
            p.UnitPrice = 10;
            CurrentProduct = p;
        }

        private void SaveProduct()
        {
            MessageBox.Show("Saved");
        }
    }
}
