<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContestEntry.aspx.cs" Inherits="WebApp.SamplePages.ContestEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>Contest Entry</h1>
    </div>

    <div class="row col-md-12">
        <div class="alert alert-info">
            <blockquote style="font-style: italic">
                This illustrates some simple controls to fill out an entry form for a contest. 
                This form will use basic bootstrap formatting and illustrate Validation.
            </blockquote>
            <p>
                Please fill out the following form to enter the contest. This contest is only available to residents in Western Canada.
            </p>

        </div>
    </div>
    <asp:RequiredFieldValidator ID="RequiredFieldFirstName" runat="server" ErrorMessage="First Name is required" Display="None" SetFocusOnError="true" ControlToValidate="FirstName" ForeColor="Firebrick"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldLastName" runat="server" ErrorMessage="First Name is required" Display="None" SetFocusOnError="true" ControlToValidate="LastName" ForeColor="Firebrick"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldStreetAddress1" runat="server" ErrorMessage="StreetAddress1 is required" Display="None" SetFocusOnError="true" ControlToValidate="StreetAddress1" ForeColor="Firebrick"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldCity" runat="server" ErrorMessage="City is required" Display="None" SetFocusOnError="true" ControlToValidate="City" ForeColor="Firebrick"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldPostalCode" runat="server" ErrorMessage="PostalCode is required" Display="None" SetFocusOnError="true" ControlToValidate="PostalCode" ForeColor="Firebrick"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldEmailAddress" runat="server" ErrorMessage="EmailAddress is required" Display="None" SetFocusOnError="true" ControlToValidate="EmailAddress" ForeColor="Firebrick"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldCheckAnswer" runat="server" ErrorMessage="Please supplier an answer to CheckAnswer" Display="None" SetFocusOnError="true" ControlToValidate="CheckAnswer" ForeColor="Firebrick"></asp:RequiredFieldValidator>
    
    <asp:RangeValidator ID="DemoStreetAddress2" runat="server" ControlToValidate="StreetAddress2" Display="None" ErrorMessage="Rangetest simulate" MaximumValue="5" MinimumValue="1" Type="Double"></asp:RangeValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionPostalCode" ControlToValidate="PostalCode" runat="server" Display="None" SetFocusOnError="true" ForeColor="Firebrick" ErrorMessage="Postal Code must be in right expression" ValidationExpression="[a-zA-Z][0-9][a-zA-Z][0-9][a-zA-Z][0-9]"></asp:RegularExpressionValidator>
    <asp:CompareValidator ID="CompareEmailAddress" runat="server" Operator="DataTypeCheck" ControlToValidate="EmailAddress" Display="None" Type="String" ErrorMessage="CompareValidatoemailr"></asp:CompareValidator>
    <asp:CompareValidator ID="CompareCheckAnswer" runat="server" Operator="Equal" ControlToValidate="CheckAnswer" Display="None" Type="Integer" ErrorMessage="incorrect check answer(15)" ValueToCompare="15"></asp:CompareValidator>
<%--    <asp:CompareValidator ID="ComparePasswerd" runat="server" Operator="Equal" ControlToValidate="ConfirmPassword" Display="None" Type="String" ErrorMessage="Does not match password" SetFocusOnError="True" ControlToCompare="Password"></asp:CompareValidator>--%>
    <%-- validation summar control --%>
    <asp:ValidationSummary ID="ValidationSummaryControl" HeaderText="Error Message" runat="server" />
    <div class="row">
        <div class ="col-md-6">
            <fieldset class="form-horizontal" type="Double">
                <legend>Application Form</legend>

                <asp:Label ID="Label1" runat="server" Text="First Name"
                     AssociatedControlID="FirstName"></asp:Label>
                <asp:TextBox ID="FirstName" runat="server" 
                    ToolTip="Enter your first name." MaxLength="25"></asp:TextBox> 
                  
                 <asp:Label ID="Label6" runat="server" Text="Last Name"
                     AssociatedControlID="LastName"></asp:Label>
                <asp:TextBox ID="LastName" runat="server" 
                    ToolTip="Enter your last name." MaxLength="25"></asp:TextBox> 
                        
                <asp:Label ID="Label3" runat="server" Text="Street Address 1"
                     AssociatedControlID="StreetAddress1"></asp:Label>
                <asp:TextBox ID="StreetAddress1" runat="server" 
                    ToolTip="Enter your street address." MaxLength="75"></asp:TextBox> 
                  
                  <asp:Label ID="Label7" runat="server" Text="Street Address 2"
                     AssociatedControlID="StreetAddress2"></asp:Label>
                <asp:TextBox ID="StreetAddress2" runat="server" 
                    ToolTip="Enter your additional street address." MaxLength="75"></asp:TextBox> 
                  <br />
                 <asp:Label ID="Label8" runat="server" Text="City"
                     AssociatedControlID="City"></asp:Label>
                <asp:TextBox ID="City" runat="server" 
                    ToolTip="Enter your City name" MaxLength="50"></asp:TextBox> 
                  
                 <asp:Label ID="Label9" runat="server" Text="Province"
                     AssociatedControlID="Province"></asp:Label>
                <asp:DropDownList ID="Province" runat="server" Width="75px">
                    <asp:ListItem Value="AB" Text="AB"></asp:ListItem>
                     <asp:ListItem Value="BC" Text="BC"></asp:ListItem>
                     <asp:ListItem Value="MN" Text="MN"></asp:ListItem>
                     <asp:ListItem Value="SK" Text="SK"></asp:ListItem>
                </asp:DropDownList>
                  
                 <asp:Label ID="Label10" runat="server" Text="Postal Code"
                     AssociatedControlID="PostalCode"></asp:Label>
                <asp:TextBox ID="PostalCode" runat="server" 
                    ToolTip="Enter your postal code"  MaxLength="6"></asp:TextBox> 
                 
                <asp:Label ID="Label2" runat="server" Text="Email"
                     AssociatedControlID="EmailAddress"></asp:Label>
                <asp:TextBox ID="EmailAddress" runat="server" 
                    ToolTip="Enter your email address"
                     TextMode="Email"></asp:TextBox> 
                  
              </fieldset>   
           <p>Note: You must agree to the contest terms in order to be entered.
               <br />
               <asp:CheckBox ID="Terms" runat="server" Text="I agree to the terms of the contest" />
           </p>

            <p>
                Enter your answer to the following calculation instructions:<br />
                Multiply 15 times 6<br />
                Add 240<br />
                Divide by 11<br />
                Subtract 15<br />
                <asp:TextBox ID="CheckAnswer" runat="server" ></asp:TextBox>
            </p>
        </div>
        <div class="col-md-6">   
            <div class="col-md-offset-2">
                <p>
                    <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />&nbsp;&nbsp;
                    <asp:Button ID="Clear" runat="server" Text="Clear" CausesValidation="true" OnClick="Clear_Click"  />
                </p>
                <asp:Label ID="Message" runat="server" ></asp:Label><br />
                
                <br />
                <hr style="width=5px;"/>
                <asp:GridView ID="EntryList" runat="server"></asp:GridView>
            </div>
        </div>
    </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
