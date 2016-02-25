using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using GaleProjects.ServiceReference1;
using GaleProjects.Models;


namespace GaleProjects
{
    public partial class Monitor : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindstate();

                if (txtDate.Text.Equals(string.Empty))
                {
                    txtDate.Text = DateTime.Now.ToShortDateString();
                }
            }
        }

        protected void llboxSate_OnSelectedIndexChangedEvent(object sender, EventArgs e)
        {
            Session["code"] = null;
            string filepath = Server.MapPath("~/Monitor/City.xml");

            txtActual.ReadOnly = false;
            txtVariance.ReadOnly = false;
            var myDocument = new XmlDocument();
            myDocument.Load(filepath);
            var nodes = myDocument.GetElementsByTagName("item");
            var resultNodes = new List<XmlNode>();
            List<City> list = new List<City>();

            foreach (XmlNode node in nodes)
            {
                if (node.Attributes != null && node.Attributes["Statid"] != null && node.Attributes["Statid"].Value == llbState.SelectedValue)
                    list.Add(new City(Convert.ToInt16(node.Attributes["Cityid"].Value),
                    node.Attributes["City"].Value.ToString(), Convert.ToInt16(node.Attributes["Statid"].Value)));
            }

            Session["code"] = llbState.SelectedItem.Text.ToString().Substring(0, 2).ToUpper();
            llbCity.DataSource = list;
            llbCity.DataTextField = "Cityname";
            llbCity.DataValueField = "Cityid";
            llbCity.DataBind();
            clear();
        }
        public void Bindstate()
        {

            //  string filepath = Server.MapPath("~/mckhci.xml");

            XDocument lbSrc = xmlfile("State.xml");// XDocument.Load(filepath);
            List<State> _lbList = new List<State>();

            foreach (XElement item in lbSrc.Descendants("item"))
            {
                _lbList.Add(new State
                {
                    Stateid = Convert.ToInt32(item.FirstAttribute.Value),
                    States = item.LastAttribute.Value,

                });
            }
            llbState.DataSource = _lbList;
            llbState.DataTextField = "States";
            llbState.DataValueField = "Stateid";
            llbState.DataBind();

        }


        protected void llbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["codestation"] = Session["code"] + "-" + llbCity.SelectedItem.Text.ToString().Substring(0, 2).ToUpper() + "-" + llbCity.SelectedValue.ToString();
            Service1Client service = new Service1Client();
            txtStationCode.Text = Session["codestation"].ToString();
            txtPredicted.Text = service.GetData(Session["codestation"].ToString());

            txtActual.Text = string.Empty;
            txtVariance.Text = string.Empty;
            txtActual.ReadOnly = false;
            txtVariance.ReadOnly = false;
        }

        protected void txtActual_TextChanged(object sender, EventArgs e)
        {
            int sVariance = Convert.ToInt16(txtPredicted.Text) - Convert.ToInt16(txtActual.Text);
            txtVariance.Text = sVariance.ToString();
            Calculation objCalc = new Calculation();
            txtVariance.ForeColor = objCalc.txtcolors(sVariance);
            txtActual.ReadOnly = false;
            txtVariance.ReadOnly = false;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (validation())
                {


                    string filepath = Server.MapPath("~/Monitor/Save.xml");

                    XDocument lbSrc = XDocument.Load(filepath);

                    XElement root = new XElement("item");
                    lbSrc.Element("configuration").Add(root);
                    root.Add(new XAttribute("Stateid", llbState.SelectedValue.ToString()));
                    root.Add(new XAttribute("State", llbState.SelectedItem.Text.ToString()));
                    root.Add(new XAttribute("City", llbCity.SelectedItem.Text.ToString()));
                    root.Add(new XAttribute("cityid", llbCity.SelectedValue.ToString()));
                    root.Add(new XAttribute("Stationcode", txtStationCode.Text));
                    root.Add(new XAttribute("predicted", txtPredicted.Text));
                    root.Add(new XAttribute("Actual", txtActual.Text));
                    root.Add(new XAttribute("Date", txtDate.Text));
                    root.Add(new XAttribute("Variance", txtVariance.Text));
                    lbSrc.Save(filepath);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Information has been saved successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('station code, predicted value, Actual value, Variance should not be empty');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error occurs while saving the information. Please try again.');", true);

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            clear();
        }

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filepath = Server.MapPath("~/Monitor/Save.xml");
                string selectedDate = Request.Form[txtDate.UniqueID];

                var myDocument = new XmlDocument();
                myDocument.Load(filepath);
                var nodes = myDocument.GetElementsByTagName("item");
                var resultNodes = new List<XmlNode>();


                foreach (XmlNode node in nodes)
                {
                    if (node.Attributes["Date"].Value == txtDate.Text && node.Attributes["Stateid"].Value == llbState.SelectedValue && node.Attributes["cityid"].Value == llbCity.SelectedValue)
                    {

                        txtPredicted.Text = node.Attributes["predicted"].Value;
                        txtActual.Text = node.Attributes["Actual"].Value;
                        txtVariance.Text = node.Attributes["Variance"].Value;
                        txtActual.ReadOnly = true;
                        txtVariance.ReadOnly = true;

                    }



                }


            }
            catch (Exception ex)
            { ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error while fetching data');", true); }
        }

        public XDocument xmlfile(string filename)
        {
            string filepath = Server.MapPath("~/Monitor/" + filename);

            XDocument lbSrc = XDocument.Load(filepath);
            return lbSrc;
        }
        public void clear()
        {
            txtStationCode.Text = string.Empty;
            txtPredicted.Text = string.Empty;
            txtDate.Text = DateTime.Now.ToShortDateString();
            txtVariance.Text = string.Empty;
            txtActual.Text = string.Empty;
            if (Session["codestation"] != null)
            {
                Session["codestation"] = null;
            }
        }
        public bool validation()
        {
            bool valid = true;
            if (llbState.SelectedItem == null)
            {
                valid = false;
            }
            if (llbCity.SelectedItem == null)
            {
                valid = false;
            }
            if (txtPredicted.Text.Equals(string.Empty))
            {
                valid = false;
            }
            if (txtActual.Text.Equals(string.Empty))
            {
                valid = false;
            }
            if (txtVariance.Text.Equals(string.Empty))
            {
                valid = false;
            }
            return valid;
        }

    }
}
