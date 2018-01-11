<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TestSite.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:MultiView ID="MultiView_User" runat="server" ActiveViewIndex="0">
                <asp:View ID="View_Grid" runat="server">
                    <asp:LinkButton ID="LinkButton_View" runat="server" OnCommand="LinkButton_User_Command"
                        CommandArgument='<%# Eval("UserId") %>' ToolTip="Create new user" CommandName="New">New user</asp:LinkButton>
                    <asp:GridView ID="GridView" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                        runat="server" AutoGenerateColumns="false" OnRowUpdating="GridView_RowUpdating">
                        <Columns>
                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <asp:Label ID="Label_UserId" runat="server" Text='<%#Eval("UserId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="FirstName" HeaderText="First Name" ItemStyle-Width="150" />
                            <asp:BoundField DataField="LastName" HeaderText="Last Name" ItemStyle-Width="150" />
                            <asp:BoundField DataField="EmailAddress" HeaderText="Email Address" ItemStyle-Width="150" />
                            <asp:TemplateField HeaderText="Action Commands">
                                <ItemTemplate>
                                    <asp:LinkButton BorderStyle="None" ID="LinkButton_View" runat="server" OnCommand="LinkButton_User_Command"
                                        CommandArgument='<%# Eval("UserId") %>' CommandName="View"
                                        ToolTip="View user">
                                View
                                    </asp:LinkButton>
                                    <asp:LinkButton BorderStyle="None" ID="LinkButton_Update" runat="server" OnCommand="LinkButton_User_Command"
                                        CommandArgument='<%# Eval("UserId") %>' CommandName="Update"
                                        ToolTip="Update user">
                                Update
                                    </asp:LinkButton>
                                    <asp:LinkButton BorderStyle="None" ID="LinkButton_Delete" runat="server" OnCommand="LinkButton_User_Command"
                                        CommandArgument='<%# Eval("UserId") %>' CommandName="Delete"
                                        ToolTip="Delete user">
                                Delete
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:View>

                <asp:View ID="View_Edit" runat="server">
                    <div>
                        <asp:Label runat="server">Id</asp:Label>
                        <asp:Label runat="server" ID="Label_Id" />
                        <asp:Label runat="server">First Name</asp:Label>
                        <asp:TextBox runat="server" ID="TextBox_FirstName" />
                        <asp:Label runat="server">Last Name</asp:Label>
                        <asp:TextBox runat="server" ID="TextBox_LastName" />
                        <asp:Label runat="server">Email Address</asp:Label>
                        <asp:TextBox runat="server" ID="TextBox_EmailAddress" />
                    </div>
                    <div>
                        <asp:LinkButton runat="server" OnCommand="LinkButton_User_Command"
                            CommandName="Cancel">
                                Cancel
                        </asp:LinkButton>

                        <asp:LinkButton runat="server" OnCommand="LinkButton_User_Command"
                            CommandName="Save">
                                Save
                        </asp:LinkButton>
                    </div>
                </asp:View>

                <asp:View ID="View_Details" runat="server">
                    <div>
                        <asp:Label runat="server">Id</asp:Label>
                        <asp:Label runat="server" ID="Label_DetailId" />
                        <asp:Label runat="server">First Name</asp:Label>
                        <asp:TextBox runat="server" ID="TextBox_DetailFirstName" />
                        <asp:Label runat="server">Last Name</asp:Label>
                        <asp:TextBox runat="server" ID="TextBox_DetailLastName" />
                        <asp:Label runat="server">Email Address</asp:Label>
                        <asp:TextBox runat="server" ID="TextBox_DetailEmail" />
                    </div>
                    <div>
                        <asp:LinkButton runat="server" OnCommand="LinkButton_User_Command"
                            CommandName="Cancel">
                                Cancel
                        </asp:LinkButton>
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </form>
</body>
</html>
