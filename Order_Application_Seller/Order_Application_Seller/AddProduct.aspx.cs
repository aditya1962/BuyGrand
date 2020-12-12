using System;
using System.Collections;
using System.Configuration;
using System.IO;

namespace Order_Application_Seller
{
    public partial class AddProduct : System.Web.UI.Page
    {
        AddProductReference.AddProductSoapClient addProductReference = new AddProductReference.AddProductSoapClient();
        AddProductReference.Category[] categoryList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"]==null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                categoryList = addProductReference.getCategoryNames();
                if (!IsPostBack)
                {
                    if (categoryList.Length > 0)
                    {
                        ArrayList category = new ArrayList();
                        for (int i = 0; i < categoryList.Length; i++)
                        {
                            string categoryName = categoryList[i].categoryName;
                            if (!(category.Contains(categoryName)))
                            {
                                category.Add(categoryName);
                            }
                            if (categoryList[i].categoryName.Equals(categoryList[0].categoryName))
                            {
                                SubCategory.Items.Add(categoryList[i].subcategoryName);
                            }
                        }
                        foreach (string categoryValue in category)
                        {
                            Category.Items.Add(categoryValue);
                        }
                    }
                    else
                    {
                        FormLoadError.Text = "Error in loading form for adding an item";
                        FormLoadError.Visible = true;
                        AddItemFormDiv.Visible = false;
                    }
                }
            }
        }

        protected void CategorySelected(object sender, EventArgs e)
        {
            SubCategory.Items.Clear();
            for (int i = 0; i < categoryList.Length; i++)
            {
                if (categoryList[i].categoryName.Equals(Category.SelectedItem.Value))
                {
                    SubCategory.Items.Add(categoryList[i].subcategoryName);
                }
            }
        }

        protected void AddItemBtn_Click(object sender, EventArgs e)
        {
            if (!ImageFile.HasFile || ImageFile.PostedFile.ContentLength < 0)
            {
                FileError.Text = "An image file has not been uploaded";
                FileError.Visible = true;
            }
            else
            {
                Tuple<int, String> result = UploadFile();
                if (result.Item1 == 1)
                {
                    int status = addProductReference.AddItem(Description.Text, Name.Text, Convert.ToInt32(Price.Text),
                        result.Item2, Convert.ToInt32(Quantity.Text), Category.SelectedValue, SubCategory.SelectedValue);
                    if (status == 0)
                    {
                        AddItemStatus.Text = "Could not add item";
                        AddItemStatus.Visible = true;
                    }
                    else
                    {
                        AddItemStatus.Text = "Item added successfully";
                        AddItemStatus.Visible = true;
                    }
                }
            }
        }

        private Tuple<int, string> UploadFile()
        {
            int status = 0;
            string fileName = "";
            if (!(ImageFile.PostedFile.ContentType.Equals("image/jpeg") ||
                    ImageFile.PostedFile.ContentType.Equals("image/png")))
            {
                FileError.Text = "File should be either in JPEG or PNG format";
                FileError.Visible = true;
            }
            else if (ImageFile.PostedFile.ContentLength > 3145728)
            {
                FileError.Text = "File size should be less than 3 MB";
                FileError.Visible = true;
            }
            else
            {
                string imageName = System.IO.Path.GetFileName(ImageFile.PostedFile.FileName);
                fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + imageName;
                string filePath = Server.MapPath("~") + ConfigurationManager.ConnectionStrings["UserFileUploadString"].ConnectionString +
                                    fileName;
                if (imageName.Length > 170)
                {
                    FileError.Text = "File name should be less than 170 characters";
                    FileError.Visible = true;
                }
                else if (File.Exists(filePath))
                {
                    FileError.Text = "Please choose a different file name";
                    FileError.Visible = true;
                }
                else
                {
                    try
                    {
                        ImageFile.PostedFile.SaveAs(filePath);
                        status = 1;
                    }
                    catch (Exception ex)
                    {
                        string message = "Could not upload file during adding item by user: " + Session["username"] + "\n" + ex.Message;
                        Logging.WriteLog(ex, "Error", message);
                    }
                }
            }
            Tuple<int, string> tuple = new Tuple<int, string>(status, fileName);
            return tuple;
        }
    }
}