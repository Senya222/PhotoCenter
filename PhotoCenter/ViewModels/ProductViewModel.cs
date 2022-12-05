using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoCenter.ViewModels
{
    class ProductViewModel : ViewModelBase
    {
        public string SearchString { get; set; }
        public int ProductSort { get; set; } = 0;
        public ObservableCollection<MaterialFilter> Materials { get; set; }
        public ObservableCollection<MaterialFilter> TypePr { get; set; }
        public  ObservableCollection<Product> Products { get; set; }
        public ProductViewModel()
        {
            Products = new ObservableCollection<Product>();
            TypePr = new ObservableCollection<MaterialFilter>(DBContext.GetContext().TypeProduct.Select(p => new MaterialFilter() { TypeProduct = p}));
            Materials = new ObservableCollection<MaterialFilter>(DBContext.GetContext().Material.Select(p => new MaterialFilter() { Material = p}));
            GetProduct();
        }
        public void GetProduct()
        {
            try
            {
                Products.Clear();
                List<Product> product = DBContext.GetContext().Product.ToList();
                List<TypeProduct> typeProducts = TypePr.Where(p => p.IsChecked).Select(p => p.TypeProduct).ToList();
                List<Material> materials = Materials.Where(p => p.IsChecked).Select(p => p.Material).ToList();
                if (!String.IsNullOrWhiteSpace(SearchString))
                {
                    product = product.Where(n => n.Title.Contains(SearchString.Trim())).ToList();

                }
                if (materials.Count !=0)
                {
                    product = product.Where(p => materials.Contains(p.Material)).ToList();
                }
                if (typeProducts.Count != 0)
                {
                    product = product.Where(p => typeProducts.Contains(p.TypeProduct)).ToList();
                }
                switch (ProductSort)
                {
                    case 0:
                        product = product.OrderBy(p => p.Price).ToList();
                        break;
                    case 1:
                        product = product.OrderByDescending(p => p.Price).ToList();
                        break;
                }

                foreach (var r in product)
                {
                    Products.Add(r);
                }
            }
            catch
            {

            }

        }
    }
}
