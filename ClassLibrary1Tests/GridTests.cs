using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridLibrary;

namespace ClassLibrary1.Tests
{
    [TestClass()]
    public class GridTests
    {
        [TestMethod()]
        public void ValidGridTest()
        {
            var grid = new Grid(5, 10);
            Assert.IsNotNull(grid);
            Assert.AreEqual(grid.Height, 5);
            Assert.AreEqual(grid.Width, 10);
        }

        [TestMethod()]
        public void HeightLessThan5GridTest()
        {
            Assert.ThrowsException<ApplicationException>(() => new Grid(1, 5));
        }

        [TestMethod()]
        public void HeightMoreThan25GridTest()
        {
            Assert.ThrowsException<ApplicationException>(() => new Grid(30, 5));
        }

        [TestMethod()]
        public void WidthLessThan5GridTest()
        {
            Assert.ThrowsException<ApplicationException>(() => new Grid(5, 1));
        }

        [TestMethod()]
        public void WidthMoreThan25GridTest()
        {
            Assert.ThrowsException<ApplicationException>(() => new Grid(5, 30));
        }

        [TestMethod()]
        public void Add_Rectangle_Test()
        {
            var grid = new Grid(25, 25);
            var rectangle = new Rectangle(5, 10, new System.Drawing.Point(1, 1));

            grid.Add(rectangle);
            
            Assert.IsTrue(grid.Shapes.Count == 1);
        }

        [TestMethod()]
        public void Add_Circle_Test()
        {
            var grid = new Grid(25, 25);
            var circle = new Circle(5, new System.Drawing.Point(1, 1));

            grid.Add(circle);

            Assert.IsTrue(grid.Shapes.Count == 1);
        }

        [TestMethod()]
        public void Add_Rectangle_Invalid_XPosition_Test()
        {
            var grid = new Grid(25, 25);
            var rectangle = new Rectangle(5, 6, new System.Drawing.Point(20, 20));

            Assert.ThrowsException<ApplicationException>(() => grid.Add(rectangle));
        }

        [TestMethod()]
        public void Add_Rectangle_Invalid_YPosition_Test()
        {
            var grid = new Grid(25, 25);
            var rectangle = new Rectangle(6, 5, new System.Drawing.Point(1, 20));

            Assert.ThrowsException<ApplicationException>(() => grid.Add(rectangle));
        }

        [TestMethod()]
        public void Add_Rectangle_NoOverlapping_Test()
        {
            var grid = new Grid(7, 11);
            var rectangle1 = new Rectangle(4, 3, new System.Drawing.Point(1, 1));
            var rectangle2 = new Rectangle(2, 6, new System.Drawing.Point(2, 5));
            var rectangle3 = new Rectangle(4, 4, new System.Drawing.Point(6, 0));
            var circle = new Circle(5, new System.Drawing.Point(1, 1));

            grid.Add(rectangle1);
            grid.Add(circle);
            grid.Add(rectangle2);
            grid.Add(rectangle3);
            Assert.IsTrue(grid.Shapes.Count == 4);

        }

        [TestMethod()]
        public void Add_Rectangle_Overlapping_1_Test()
        {
            var grid = new Grid(25, 25);
            var rectangle1 = new Rectangle(4, 3, new System.Drawing.Point(1, 1));
            var rectangle2 = new Rectangle(2, 6, new System.Drawing.Point(2, 4));

            grid.Add(rectangle1);
            Assert.ThrowsException<ApplicationException>(() => grid.Add(rectangle2));
        }

        [TestMethod()]
        public void Add_Rectangle_Overlapping_2_Test()
        {
            var grid = new Grid(25, 25);
            var rectangle1 = new Rectangle(5, 5, new System.Drawing.Point(1, 1));
            var rectangle2 = new Rectangle(5, 5, new System.Drawing.Point(2, 2));

            grid.Add(rectangle1);
            Assert.ThrowsException<ApplicationException>(() => grid.Add(rectangle2));
        }


        [TestMethod()]
        public void RemoveRectangle_Test()
        {
            var grid = new Grid(7, 11);
            var rectangle1 = new Rectangle(4, 3, new System.Drawing.Point(1, 1));
            var rectangle2 = new Rectangle(2, 6, new System.Drawing.Point(2, 5));
            var rectangle3 = new Rectangle(4, 4, new System.Drawing.Point(5, 0));

            grid.Add(rectangle1);
            grid.Add(rectangle2);
            grid.Add(rectangle3);

            grid.Remove(new System.Drawing.Point(1, 1));
            grid.Remove(new System.Drawing.Point(2, 5));

            Assert.IsTrue(grid.Shapes.Count == 1);
        }

        [TestMethod()]
        public void RemoveRectangle1_Test()
        {
            var grid = new Grid(7, 11);
            var rectangle1 = new Rectangle(4, 3, new System.Drawing.Point(1, 1));
            var rectangle2 = new Rectangle(2, 6, new System.Drawing.Point(2, 5));
            var rectangle3 = new Rectangle(4, 4, new System.Drawing.Point(5, 0));

            grid.Add(rectangle1);
            grid.Add(rectangle2);
            grid.Add(rectangle3);

            grid.Remove(new System.Drawing.Point(2, 5));

            Assert.IsTrue(grid.Shapes.Count == 1);
        }


    }
}