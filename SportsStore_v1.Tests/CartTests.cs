using System.Linq;
using SportsStore_v1.Models;
using Xunit;

namespace SportsStore_v1.Tests
{
    public class CartTest{
        
        [Fact]
        public void Can_Add_New_Lines()
        {
            Product p1 = new Product{ ProductId=1,Name="p1"};
            Product p2 = new Product{ ProductId=2,Name="p2"};

            Cart target = new Cart();
            target.AddItem(p1,1);
            target.AddItem(p2,2);

            CartLine[] results = target.Lines.ToArray();

            Assert.Equal(2,results.Length);
            Assert.Equal(p1,results[0].Product);
            Assert.Equal(p2,results[1].Product);
        }

        [Fact]
        public void  Can_Add_Quantity_For_Existing_Lines(){
            Product p1 = new Product{ ProductId=1,Name="p1"};
            Product p2 = new Product{ ProductId=2,Name="p2"};

            Cart target = new Cart();

            target.AddItem(p1,5);
            target.AddItem(p2,5);
            target.AddItem(p1,6);

            CartLine[] results = target.Lines
                                    .OrderBy(c => c.Product.ProductId)
                                    .ToArray();

            Assert.Equal(2,results.Length); 
            Assert.Equal(11,results[0].Quantity);
            Assert.Equal(5,results[1].Quantity);

        }

        [Fact]
        public void Calculate_Cart_Total(){
            Product p1 = new Product{ ProductId=1,Name="p1",Price=300M};
            Product p2 = new Product{ ProductId=2,Name="p2",Price=250M};

            Cart target = new Cart();

            target.AddItem(p1,1);
            target.AddItem(p2,1);

            decimal results = target.ComputeTotalValue();
            Assert.Equal(550,results); 
        }

        [Fact]
        public void Can_Remove_Line(){
            Product p1 = new Product{ ProductId=1,Name="p1",Price=300M};
            Product p2 = new Product{ ProductId=2,Name="p2",Price=250M};

            Cart target = new Cart();

            target.AddItem(p1,5);
            target.AddItem(p2,5);
            target.AddItem(p1,6);

            target.RemoveLine(p1);

            CartLine[] results = target.Lines.ToArray();

            Assert.Equal(1,results.Length);

        }

        [Fact]
        public void Can_Clear_Lines(){
            Product p1 = new Product{ ProductId=1,Name="p1",Price=300M};
            Product p2 = new Product{ ProductId=2,Name="p2",Price=250M};

            Cart target = new Cart();

            target.AddItem(p1,5);
            target.AddItem(p2,5);
            target.AddItem(p1,6);

            target.Clear();

            CartLine[] results = target.Lines.ToArray();

            Assert.Equal(0,results.Count());

        }
    }
}