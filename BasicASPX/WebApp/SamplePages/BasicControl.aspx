<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BasicControl.aspx.cs" Inherits="WebApp.SamplePages.BasicControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <table align="center" style="width: 80%">
        <tr>
            <td aligh="right">Enter your choice (1-4):</td>
            <td>
                <asp:TextBox ID="TextBoxNumericChoice" runat="server"></asp:TextBox> &nbsp;&nbsp;
                <asp:Button Text="Submit Choice" ID="SubmitButton" runat="server" OnClick="SubmitButton_Click" />
            </td>
        </tr>
        <tr>
            <td aligh="right">
                <asp:Label ID="Label1" runat="server" Text="Choice (radiobuttonlist)" ForeColor="#0066FF" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonListChoice" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">Comp1008</asp:ListItem>
                    <asp:ListItem Value="2">Cpsc1517</asp:ListItem>
                    <asp:ListItem Value="3">Dmit2018</asp:ListItem>
                    <asp:ListItem Value="4">Dmit1508</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td aligh="right">
                <asp:Literal ID="Literal1" runat="server" Text="Programming software (via checkbox): "></asp:Literal>
            </td>
            <td>
                <asp:CheckBox ID="CheckBoxChoice" runat="server" Text="(active when checked)" Font-Bold="True"/>
            </td>
        </tr>
        <tr>
            <td aligh="right">
                <asp:Label ID="Label2" runat="server" Text="Display Label"></asp:Label>
            </td>
            <td>
                <asp:Label ID="DisplayReadOnly" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td aligh="right">
                <asp:Label ID="Label4" runat="server" Text="View Choice Collection"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="CollectionList" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="OutputMessage" runat="server" ></asp:Label>
            </td>            
        </tr>
    </table>

</asp:Content>
