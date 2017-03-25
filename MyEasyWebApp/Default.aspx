<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyEasyWebApp._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <img alt="Welcome to MyeasyObjectPage" 
            src="../../../Images/MyEasyWelcomeBanner.png" 
            style="width: 972px; height: 50px" /><br />
    
    </div>
        <img alt="Existing User Login" src="../../../Images/exitsing_user.png" 
            style="width: 400px; height: 38px" />

    <asp:Login ID="ExistingUserLogin" runat="server" BackColor="#F1F0F0" 
        Height="123px" onauthenticate="ExistingUserLogin_Authenticate" 
        PasswordLabelText="Password" TitleText="" UserNameLabelText="Email" 
        Width="396px">
        <CheckBoxStyle Font-Bold="True" Font-Names="Aharoni" />
        <LoginButtonStyle Font-Bold="True" ForeColor="#252F88" />
    </asp:Login>  
    <p></p>
    <img alt="New User" src="../../../Images/new_user.png" 
        style="width: 400px; height: 38px" /><asp:CreateUserWizard 
        ID="CreateUserWizard1" runat="server" Width="396px" BackColor="#F1F0F0">
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" />
            <asp:CompleteWizardStep runat="server" />
        </WizardSteps>
    </asp:CreateUserWizard>
    </form>
</body>
</html>
