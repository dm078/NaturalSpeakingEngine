using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Rhipe_WebApp1.Models;

namespace Rhipe_WebApp1.Models
{
    public class NaturalLanguage
    {
        private Shapes repository = new Shapes();

        public Boolean CleanRAWRequest(string pRAWRequest)
        {
            Boolean endResults = false;

            //replace the unrequired texts and watch the space
            List<string> ReplaceString = new List<string>(new string[] { "Draw a ", "Draw an ", " with a", "and a ", " of" });

            string RAWRequest = pRAWRequest;

            //Clean up the other languages we don't need
            foreach (string temp in ReplaceString)
            {
                RAWRequest = RAWRequest.Replace(temp, "");
            }

            string[] FilteredRequest = RAWRequest.Split(' ');
            //it looks like circle radius 100
            
            //add the shape into the Temporary Draw List            
            switch (FilteredRequest[0].ToString().ToLower())
            {
                case "isosceles":
                    Shapes tmShape0 = new Shapes();
                    tmShape0.ShapeName = Enum.GetName(typeof(Shapes.AvailableShapes), 0); //"Isosceles Triangle"

                    if ((FilteredRequest[2].ToString().ToLower() == "width"))
                    {
                        tmShape0.Width = Convert.ToDecimal(FilteredRequest[3]);
                        tmShape0.Height = Convert.ToDecimal(FilteredRequest[5]);
                    }
                    else if ((FilteredRequest[2].ToString().ToLower() == "height"))
                    {
                        tmShape0.Width = Convert.ToDecimal(FilteredRequest[5]);
                        tmShape0.Height = Convert.ToDecimal(FilteredRequest[3]);
                    }
                    repository.AddShapeToDrawList(tmShape0);
                    break;
                case "scalene":
                    Shapes tmShape1 = new Shapes();
                    tmShape1.ShapeName = Enum.GetName(typeof(Shapes.AvailableShapes), 1); //"Scalene Triangle"                    

                    if ((FilteredRequest[2].ToString().ToLower() == "width"))
                    {
                        tmShape1.Width = Convert.ToDecimal(FilteredRequest[3]);
                        tmShape1.Height = Convert.ToDecimal(FilteredRequest[5]);
                    }
                    else if ((FilteredRequest[2].ToString().ToLower() == "height"))
                    {
                        tmShape1.Width = Convert.ToDecimal(FilteredRequest[5]);
                        tmShape1.Height = Convert.ToDecimal(FilteredRequest[3]);
                    }
                    repository.AddShapeToDrawList(tmShape1);
                    break;
                case "equilateral":
                    Shapes tmShape2 = new Shapes();
                    tmShape2.ShapeName = Enum.GetName(typeof(Shapes.AvailableShapes), 2); //"Equilateral Triangle"

                    if (FilteredRequest[2].ToString().ToLower() == "side")
                    {
                        tmShape2.Height = Convert.ToDecimal(FilteredRequest[4]);
                        tmShape2.Width = Convert.ToDecimal(FilteredRequest[4]);
                    }
                    repository.AddShapeToDrawList(tmShape2);

                    break;                
                case "rectangle":
                    Shapes tmShape3 = new Shapes();
                    tmShape3.ShapeName = Enum.GetName(typeof(Shapes.AvailableShapes), 3); //"Rectangle"
                    if ((FilteredRequest[1].ToString().ToLower() == "width"))
                    {
                        tmShape3.Width = Convert.ToDecimal(FilteredRequest[2]);
                        tmShape3.Height = Convert.ToDecimal(FilteredRequest[4]);
                    }
                    else if ((FilteredRequest[1].ToString().ToLower() == "height"))
                    {
                        tmShape3.Width = Convert.ToDecimal(FilteredRequest[4]);
                        tmShape3.Height = Convert.ToDecimal(FilteredRequest[2]);
                    }

                    repository.AddShapeToDrawList(tmShape3);
                    break;
                case "square":
                    Shapes tmShape4 = new Shapes();
                    tmShape4.ShapeName = Enum.GetName(typeof(Shapes.AvailableShapes), 4); //"Square"
                    if (FilteredRequest[1].ToString().ToLower() == "side")
                    {
                        tmShape4.Height = Convert.ToDecimal(FilteredRequest[3]);
                        tmShape4.Width = Convert.ToDecimal(FilteredRequest[3]);
                    }                   
                    repository.AddShapeToDrawList(tmShape4);
                    break;
                case "octagon":
                    Shapes tmShape5 = new Shapes();
                    tmShape5.ShapeName = Enum.GetName(typeof(Shapes.AvailableShapes), 5); //"Octagon"
                    if (FilteredRequest[1].ToString().ToLower() == "side")
                    {
                        tmShape5.Width = Convert.ToDecimal(FilteredRequest[3]);
                    }
                    repository.AddShapeToDrawList(tmShape5);

                    break;
                case "circle":
                    Shapes tmShape6 = new Shapes();
                    tmShape6.ShapeName = Enum.GetName(typeof(Shapes.AvailableShapes), 6); //"Circle"
                    if (FilteredRequest[1].ToString().ToLower() == "radius")
                    {
                        tmShape6.Radius = Convert.ToDecimal(FilteredRequest[2]);
                    }
                    repository.AddShapeToDrawList(tmShape6);

                    break;
                case "oval":
                    Shapes tmShape7 = new Shapes();
                    tmShape7.ShapeName = Enum.GetName(typeof(Shapes.AvailableShapes), 7); //"Oval"
                    if ((FilteredRequest[1].ToString().ToLower() == "width"))
                    {
                        tmShape7.Width = Convert.ToDecimal(FilteredRequest[2]);
                        tmShape7.Height = Convert.ToDecimal(FilteredRequest[4]);
                    }
                    else if ((FilteredRequest[1].ToString().ToLower() == "height"))
                    {
                        tmShape7.Width = Convert.ToDecimal(FilteredRequest[4]);
                        tmShape7.Height = Convert.ToDecimal(FilteredRequest[2]);
                    }

                    repository.AddShapeToDrawList(tmShape7);

                    break;
            }

            return endResults;
        }

        /// <summary>
        /// Generate the HTML Canvas and Javascript for the Shape & details provided
        /// </summary>
        /// <param name="pShapes"></param>
        /// <returns></returns>
        public string GenerateHTMLCanvasForShape(Shapes pShapes)
        {
            StringBuilder tempResults = new StringBuilder();
            String FinalResults = "";

            if ( pShapes.ShapeName == Enum.GetName(typeof(Shapes.AvailableShapes), 0)) //"Isosceles Triangle"
            {
                tempResults.Append("<canvas id = \"myCanvas\" width = \"" + pShapes.Width.ToString() + "\" height = \"" + pShapes.Height.ToString() + "\" >Your browser does not support the HTML5 canvas tag.</canvas>");
                tempResults.Append("<script>");
                tempResults.Append("var canvas = document.getElementById(\"myCanvas\");");
                tempResults.Append("var ctx = canvas.getContext('2d');");
                tempResults.Append("drawEqTriangle(ctx, " + pShapes.Width.ToString() + ", canvas.width/2, canvas.height/2);");
                tempResults.Append("function drawEqTriangle(ctx, side, cx, cy) {");
                //tempResults.Append("var h = side * (Math.sqrt(3) / 2);");
                tempResults.Append("var h = " + pShapes.Height.ToString() + ";");
                tempResults.Append("ctx.strokeStyle = \"#ff0000\";");
                tempResults.Append("ctx.save();");
                tempResults.Append("ctx.translate(cx, cy);");
                tempResults.Append("ctx.beginPath();");
                tempResults.Append("ctx.moveTo(0, -h / 2);");
                tempResults.Append("ctx.lineTo(-side / 2, h / 2);");
                tempResults.Append("ctx.lineTo(side / 2, h / 2);");
                tempResults.Append("ctx.lineTo(0, -h / 2);");
                tempResults.Append("ctx.stroke();");                
                tempResults.Append("ctx.closePath();");
                tempResults.Append("ctx.save();}");
                tempResults.Append("</script>");
            }
             else if (pShapes.ShapeName == Enum.GetName(typeof(Shapes.AvailableShapes), 1)) //"Scalene Triangle"
            {
                decimal tempCalc = new decimal();
                tempCalc = pShapes.Height * 2;
                tempResults.Append("<canvas id = \"myCanvas\" width = \"" + pShapes.Width.ToString() + "\" height = \"" + tempCalc.ToString() + "\" >Your browser does not support the HTML5 canvas tag.</canvas>");
                tempResults.Append("<script>");
                tempResults.Append("var canvas = document.getElementById(\"myCanvas\");");
                tempResults.Append("var context = canvas.getContext(\"2d\");");
                tempResults.Append("context.beginPath();");
                tempResults.Append("context.moveTo(1, 1);");
                tempResults.Append("context.lineTo(1, " + pShapes.Height.ToString() + ");");
                tempResults.Append("context.lineTo(" + pShapes.Width.ToString() + ", " + pShapes.Width.ToString() + ");");
                tempResults.Append("context.closePath();");
                tempResults.Append("context.stroke();");                
                tempResults.Append("</script>");
            }
            else if (pShapes.ShapeName == Enum.GetName(typeof(Shapes.AvailableShapes), 2)) //"Equilateral Triangle"
            {                
                tempResults.Append("<canvas id=\"canvas\" width=\"" + pShapes.Width.ToString() + "\" height=\"" + pShapes.Width.ToString() + "\"></canvas>");
                tempResults.Append("<script>");
                tempResults.Append("var canvas = document.getElementById('canvas');");
                tempResults.Append("var ctx = canvas.getContext('2d');");
                tempResults.Append("drawEqTriangle(ctx, " + pShapes.Width.ToString() + ", canvas.width / 2, canvas.height / 2);");
                tempResults.Append("function drawEqTriangle(ctx, side, cx, cy) {");
                tempResults.Append("var h = side * (Math.sqrt(3) / 2);");
                tempResults.Append("ctx.strokeStyle = \"#000\";");
                tempResults.Append("ctx.fillStyle = '#FFF';");
                tempResults.Append("ctx.save();");
                tempResults.Append("ctx.translate(cx, cy);");
                tempResults.Append("ctx.beginPath();");
                tempResults.Append("ctx.moveTo(0, -h / 2);");
                tempResults.Append("ctx.lineTo(-side / 2, h / 2);");
                tempResults.Append("ctx.lineTo(side / 2, h / 2);");
                tempResults.Append("ctx.lineTo(0, -h / 2);");
                tempResults.Append("ctx.stroke();");
                tempResults.Append("ctx.fill();");
                tempResults.Append("ctx.closePath();");
                tempResults.Append("ctx.save();");
                tempResults.Append("}");
                tempResults.Append("</script>");
            }
            else if (pShapes.ShapeName == Enum.GetName(typeof(Shapes.AvailableShapes), 3)) //"Rectangle"
            {                
                tempResults.Append("<canvas id=\"myCanvas\" width=\"" + pShapes.Width.ToString() + "\" height=\"" + pShapes.Height.ToString() + "\" style=\"border: 1px solid #000000;\"></canvas>");
            }
            else if (pShapes.ShapeName == Enum.GetName(typeof(Shapes.AvailableShapes), 4)) //"Square"
            {                
                tempResults.Append("<canvas id=\"myCanvas\" width=\"" + pShapes.Width.ToString() + "\" height=\"" + pShapes.Height.ToString() + "\" style=\"border: 1px solid #000000;\"></canvas>");
            }
            else if (pShapes.ShapeName == Enum.GetName(typeof(Shapes.AvailableShapes), 5)) //"Octagon"
            {
                decimal tempCalc = new decimal();
                tempCalc = pShapes.Width * 2;
                tempResults.Append("<canvas id = \"myCanvas\" width = \"" + tempCalc.ToString() + "\" height = \"" + tempCalc.ToString() + "\" >Your browser does not support the HTML5 canvas tag.</canvas>");
                tempResults.Append("<script>");
                tempResults.Append("var canvas = document.getElementById(\"myCanvas\");");
                tempResults.Append("var ctx = canvas.getContext(\"2d\");");
                tempResults.Append("ctx.strokeStyle = \"#000000\";");
                tempResults.Append("ctx.lineWidth = 1;");                
                tempResults.Append("var numberOfSides = 8,size = " + pShapes.Width.ToString() + ",Xcenter = " + pShapes.Width.ToString() + ",Ycenter = " + pShapes.Width.ToString() + "; ");
                tempResults.Append("ctx.beginPath();");
                tempResults.Append("ctx.moveTo (Xcenter +  size * Math.cos(0), Ycenter +  size *  Math.sin(0));   ");
                tempResults.Append("for (var i = 1; i <= numberOfSides; i += 1) ");
                tempResults.Append("{ ctx.lineTo (Xcenter + size * Math.cos(i * 2 * Math.PI / numberOfSides), Ycenter + size * Math.sin(i * 2 * Math.PI / numberOfSides)); }");
                tempResults.Append("ctx.stroke();");                
                tempResults.Append("</script>");
            }
            else if (pShapes.ShapeName == Enum.GetName(typeof(Shapes.AvailableShapes), 6)) //"Circle"
            {
                decimal tempCalc = new decimal();
                tempCalc = pShapes.Radius * 2;
                tempResults.Append("<canvas id = \"myCanvas\" width = \"" + tempCalc.ToString()  + "\" height = \"" + tempCalc.ToString() + "\" >Your browser does not support the HTML5 canvas tag.</canvas>");
                tempResults.Append("<script>");
                tempResults.Append("var c = document.getElementById(\"myCanvas\");");
                tempResults.Append("var ctx = c.getContext(\"2d\");");
                tempResults.Append("ctx.beginPath();");
                tempCalc = tempCalc / 2;                
                tempResults.Append("ctx.arc(" + tempCalc.ToString() + "," + tempCalc.ToString() + ","+ pShapes.Radius.ToString() + ",0,2*Math.PI);");
                tempResults.Append("ctx.stroke();</script>");                
            }
            else if (pShapes.ShapeName == Enum.GetName(typeof(Shapes.AvailableShapes), 7)) //"Oval"
            {
                decimal tempCalc = new decimal();
                decimal tempCalc2 = new decimal();
                tempCalc = pShapes.Width * 2;
                tempCalc2 = pShapes.Height * 2;
                tempResults.Append("<canvas id = \"myCanvas\" width = \"" + tempCalc.ToString() + "\" height = \"" + tempCalc2.ToString() + "\" >Your browser does not support the HTML5 canvas tag.</canvas>");
                tempResults.Append("<script>");
                tempResults.Append("var canvas = document.getElementById(\"myCanvas\");");
                tempResults.Append("if (canvas.getContext)");
                tempResults.Append("{");
                tempResults.Append("var ctx = canvas.getContext('2d');");
                tempResults.Append("drawEllipse(ctx, 10, 10, " + pShapes.Width.ToString() + ", " + pShapes.Height.ToString() + ");");
                tempResults.Append("}");
                tempResults.Append("function drawEllipse(ctx, x, y, w, h) {");
                tempResults.Append("var kappa = .5522848,ox = (w / 2) * kappa, oy = (h / 2) * kappa, xe = x + w,ye = y + h,xm = x + w / 2,ym = y + h / 2;");
                tempResults.Append("ctx.beginPath();");
                tempResults.Append("ctx.moveTo(x, ym);");
                tempResults.Append("ctx.bezierCurveTo(x, ym - oy, xm - ox, y, xm, y);");
                tempResults.Append("ctx.bezierCurveTo(xm + ox, y, xe, ym - oy, xe, ym);");
                tempResults.Append("ctx.bezierCurveTo(xe, ym + oy, xm + ox, ye, xm, ye);");
                tempResults.Append("ctx.bezierCurveTo(xm - ox, ye, x, ym + oy, x, ym);");
                tempResults.Append(" ctx.stroke();}");
                tempResults.Append("</script>");                
            }

            FinalResults = tempResults.ToString();
            return FinalResults;
        }

        public List<Shapes> GetDrawList()
        {
            return repository.GetAllDrawShapeList();
        }
    }
}