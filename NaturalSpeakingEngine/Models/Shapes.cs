using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhipe_WebApp1.Models
{
    public class Shapes
    {
        public string ShapeName { get; set; }
        public decimal Radius { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        
        public enum AvailableShapes { 
            Isosceles_Triangle = 0,
            Scalene_Triangle = 1,
            Equilateral_Triangle = 2,
            Rectangle = 3,
            Square = 4,
            Octagon = 5,
            Circle = 6,
            Oval = 7
        };

        /// <summary>
        /// This is the temporary drawing list for the user
        /// </summary>
        private List<Shapes> DrawShapeList = new List<Shapes>
        { };
        
        /// <summary>
        /// Retrieve the list of shapes required by the user - in the temporary list
        /// </summary>
        /// <returns></returns>
        public List<Shapes> GetAllDrawShapeList()
        {
            return DrawShapeList;
        }

        /// <summary>
        /// Add a shape to the Draw list - temporary list
        /// </summary>
        /// <param name="pShape"></param>
        /// <returns></returns>
        public Boolean AddShapeToDrawList(Shapes pShape)
        {
            DrawShapeList.Add(pShape);
            return true;
        }

        ///TODO : Later on
        /// <summary>
        /// Remove a shape from the Draw list- temporary list
        /// </summary>
        /// <param name="pShape"></param>
        /// <returns></returns>
        public Boolean RemoveShapeInDrawList(Shapes pShape)
        {
            DrawShapeList.Remove(pShape);
            return true;
        }
    }
}