using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestGit.Core;

namespace TestSite
{
    public partial class Home : System.Web.UI.Page
    {
        const string UserItemKey = "UserItem";
        public User UserItem
        {
            get
            {
                return ViewState[UserItemKey] as User;
            }
            set
            {
                ViewState[UserItemKey] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshData();
            }
        }

        void RefreshData()
        {
            GridView.DataSource = TestGit.Core.User.LoadAllUsers();
            GridView.DataBind();
        }

        protected void LinkButton_User_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "New":
                    {
                        UserItem = new User();
                        Label_Id.Text = "new user";
                        TextBox_FirstName.Text = null;
                        TextBox_LastName.Text = null;
                        TextBox_EmailAddress.Text = null;

                        MultiView_User.SetActiveView(View_Edit);
                    }
                    break;

                case "Update":
                    {
                        if (int.TryParse(e.CommandArgument.ToString(), out int id))
                        {
                            UserItem = TestGit.Core.User.LoadUserByFilters(id);
                            Label_Id.Text = UserItem.UserId.ToString();
                            TextBox_FirstName.Text = UserItem.FirstName;
                            TextBox_LastName.Text = UserItem.LastName;
                            TextBox_EmailAddress.Text = UserItem.EmailAddress;

                            MultiView_User.SetActiveView(View_Edit);
                        }
                    }
                    break;

                case "View":
                    {
                        if(int.TryParse(e.CommandArgument.ToString(), out int id))
                        {
                            UserItem = TestGit.Core.User.LoadUserByFilters(id);
                            Label_DetailId.Text = UserItem.UserId.ToString();
                            TextBox_DetailFirstName.Text = UserItem.FirstName;
                            TextBox_DetailLastName.Text = UserItem.LastName;
                            TextBox_DetailEmail.Text = UserItem.EmailAddress;

                            MultiView_User.SetActiveView(View_Details);
                        }
                    }
                    break;
                case "Delete":
                    {
                        if (int.TryParse(e.CommandArgument.ToString(), out int id))
                        {
                            TestGit.Core.User.DeleteUser(id);
                            RefreshData();
                            UserItem = null;
                            MultiView_User.SetActiveView(View_Grid);
                        }
                    }
                    break;
                case "Save":
                    {
                        if(UserItem != null)
                        {
                            UserItem.FirstName = TextBox_FirstName.Text;
                            UserItem.LastName = TextBox_LastName.Text;
                            UserItem.EmailAddress = TextBox_EmailAddress.Text;
                            UserItem.SaveData();
                            RefreshData();
                            UserItem = null;
                            MultiView_User.SetActiveView(View_Grid);
                        }
                    }
                    break;

                case "Cancel":
                    {
                        UserItem = null;
                        MultiView_User.SetActiveView(View_Grid);
                    }
                    break;
            }
        }

        protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label id = GridView.Rows[e.RowIndex].FindControl("Label_UserId") as Label;
                UserItem = TestGit.Core.User.LoadUserByFilters(int.Parse(id.Text));
                Label_Id.Text = UserItem.UserId.ToString();
                TextBox_FirstName.Text = UserItem.FirstName;
                TextBox_LastName.Text = UserItem.LastName;
                TextBox_EmailAddress.Text = UserItem.EmailAddress;

                MultiView_User.SetActiveView(View_Edit);
        }
    }
}