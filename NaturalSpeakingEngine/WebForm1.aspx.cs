using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Rhipe_WebApp1.Models;
using System.Web.UI.WebControls;

namespace Rhipe_WebApp1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string HTMLTextToUse;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //create the natural language class
            NaturalLanguage filterEngine = new NaturalLanguage();
            filterEngine.CleanRAWRequest(txtInput.Text.TrimStart().TrimEnd()); //read in the user input and process them

            //create the temporray shape list decided by the user
            List<Shapes> tempList = new List<Shapes>();
            tempList = filterEngine.GetDrawList(); //get the latest shapes to display in the temporary list

            //TODO:allow system to process multiple shapes
            //foreach (Shapes tmpShapes in tempList)
            //{
            //HTMLTextToUse += filterEngine.GenerateHTMLCanvasForShape(tmpShapes);
            //}
            HTMLTextToUse += filterEngine.GenerateHTMLCanvasForShape(tempList.Single());

            myControl.InnerHtml = HTMLTextToUse;
            txtInput.Text = "Draw a(n) <shape> with a(n) <measurement> of <amount> (and a(n) <measurement> of <amount>)";
            //filterEngine = null; //garbage collection
        }    
    }
}