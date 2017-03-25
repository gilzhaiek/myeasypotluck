<%@ page title="" language="C#" masterpagefile="~/Home/global.master" autoeventwireup="true" inherits="About, App_Web_ujphj1ma" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="AboutContent" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
  <asp:ToolkitScriptManager runat="server" ID="ScriptManager1" />
    <div id="frm-about">
        <div id="headSpacer" class="clearfix">
            <div id="dvTabGeneralHome" class="fl dvTabGeneral" onclick="location.href='EventBrief.aspx';" ><a href="EventBrief.aspx" class="wb18 hlymnu">Home</a></div>
            <div id="dvTabGeneralAbout" class="fl dvTabGeneral" onclick="location.href='About.aspx';"><a href="About.aspx" class="wb18 hlymnu">About</a></div>
        </div>
        <div class="wide top">
            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
            <asp:LinkButton ID="lnkbtnlogout" runat="server" onclick="lnkbtnlogout_Click">logout</asp:LinkButton>
        </div>
        <div id="about-txt" class="w20 clearfix">
            <i class="w14">We are still in beta stage ;-)</i><br /><br /> 
            MyEasyPotluck is a potluck event organizer. <br/>
            MyEasyPotluck was developed to ease the trouble of making potlucks events.<br /><br />
            You can use it to organize BBQs, dinner parties, social gatherings and much more...<br />
            It is a social site - which means you can invite friends to actively participate in the event.<br />
            All you need to do is add items to your event and invite your friends to pick them up.<br />
            As time goes by, you can view your event and see who is taking what.<br /><br />
            To contact support, please use this form or email - <a href="mailto:support@myeasypotluck.com" >support@myeasypotluck.com</a>:<br />
            <div >
                <asp:Label CssClass="clearfix fl w14" ID="Label1" runat="server" style="margin: 18px 0 0 0px"  Text="From (email):"></asp:Label><br />
                <asp:TextBox CssClass="clearfix fl w16 boxBorder" ID="fromEmailTxtBox" Width="384px" runat="server" style=" font-family:Arial, sans-serif; font-size:1.0em;" /><br />
            </div>            
            <div >
                <asp:Label CssClass="clearfix fl w14" ID="Label124" runat="server" style="margin: 14px 0 0 0px"  Text="Subject:"></asp:Label><br />
                <asp:TextBox CssClass="clearfix fl w16 boxBorder" ID="emailSubjectTxtBox" Width="384px" runat="server" style=" font-family:Arial, sans-serif; font-size:1.0em;" /><br />
            </div>
            
            <div >
                <asp:Label CssClass="clearfix fl w14" ID="Label16" runat="server" style="margin: 14px 0 0 0px"  Text="Body:"></asp:Label><br />
				<asp:TextBox CssClass="clearfix fl w12 boxBorder"  Width="384px" ID="emailBodyTxtBox" runat="server"  Rows="6" TextMode="MultiLine" style="resize:none;" />
				
                <p class="fl clearfix" >
                    <input id="btnSendEmailInvite" value="Send" onclick="emailSendClicked();" class="myButton" style="margin: 10px 0px 0px 160px;" type="button" />
                </p>                    
            </div>
        </div>
        
        <!-- Message Popup Panel -->
        <asp:Panel ID="pnlSendingPopup" runat="server" Style="display: none;background-color: transparent; vertical-align: top; padding: 0px 0px 0px 0px;" CssClass="loadingPopup">
            <asp:Label ID="labelSendingMsg" CssClass="wb24" runat="server" style="text-align: center;"  Text="Sending..." ></asp:Label>
        </asp:Panel>          
        
        <!-- Message Popup Panel -->
        <asp:Panel ID="pnlPopMsg" runat="server" Style="display: none" CssClass="msgOuterPopup">
            <asp:Panel ID="pnlPopMsgInnerOuter" runat="server" CssClass="msgInnerOuterPopup" >
                <asp:Panel ID="pnlPopMsgInnerInner" runat="server" CssClass="msgInnerInnerPopup" BackColor="#FDF8E3">        
                    <div style="margin:10px 20px 0px 20px;">
                        <asp:Label ID="labelMsgPopup"  runat="server" style="text-align: center;"  Text=" " ></asp:Label>
                        <p class="clearfix" style="text-align: center;" >
                            <input id="btnOkMsgPopup" value="Ok" onclick="OkMsgPopupClick();" class="myButton" style="margin: 10px 0px 10px 0px;" type="button" />
                            <asp:Button ID="btnCancelMsgPopup" CssClass="myButton" runat="server" style="margin: 10px 0px 10px 0px;display: none;" Text="Cancel"  />
                        </p>                    
                    </div>
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>         
        
        <!-- Msg Popup -->
        <span style="display: none"><asp:Button ID="btnOpenSendingPopup" runat="server" /></span>        
        <span style="display: none"><asp:Button ID="btnCloseSendingPopup" runat="server" /></span>        
        <asp:ModalPopupExtender ID="ModalPopupExtender6" runat="server"
        TargetControlID="btnOpenSendingPopup" PopupControlID="pnlSendingPopup" CancelControlID="btnCloseSendingPopup" DropShadow="False" 
            BackgroundCssClass="modelBackground">
        </asp:ModalPopupExtender>   
                        
        <!-- Msg Popup -->
        <span style="display: none"><asp:Button ID="btnOpenMsgPopup" runat="server" /></span>        
        <asp:ModalPopupExtender ID="ModalPopupExtender4" runat="server"
        TargetControlID="btnOpenMsgPopup" PopupControlID="pnlPopMsg" 
        OkControlID="btnOkMsgPopup" CancelControlID="btnCancelMsgPopup" DropShadow="False" 
            BackgroundCssClass="modelBackground">
        </asp:ModalPopupExtender>
        <asp:RoundedCornersExtender ID="RoundedCornersExtender7" runat="server" 
            TargetControlID="pnlPopMsgInnerOuter" BorderColor="black" Radius="8" Color="#000000">
        </asp:RoundedCornersExtender>        
        <asp:RoundedCornersExtender ID="RoundedCornersExtender8" runat="server" 
            TargetControlID="pnlPopMsgInnerInner" BorderColor="black" Radius="8" >
        </asp:RoundedCornersExtender>         
                           
    </div>
     <div id="dvCopyRight" class="wb12">This website and its content is copyright of MyEasyPotluck.com © 2010. All rights reserved.</div>
     <script  type="text/javascript">
         function PopMsgWindow(msg) {
             yesPopup = "";
             $('#btnOkMsgPopup').val("Ok");
             $($get('<%=btnCancelMsgPopup.ClientID%>')).hide();
             $($get('<%=labelMsgPopup.ClientID%>')).text(msg);
             $($get('<%=btnOpenMsgPopup.ClientID%>')).click();
        }     
         
        function emailSendClicked() {
            fromEmail = $($get('<%=fromEmailTxtBox.ClientID%>')).val();
            emailSubject = $($get('<%=emailSubjectTxtBox.ClientID%>')).val();
            emailSubject = emailSubject.replace(/\"/g, "\\\"");
            emailBody = $($get('<%=emailBodyTxtBox.ClientID%>')).val();
            emailBody = emailBody.replace(/\"/g, "\\\"");

            $($get('<%=btnOpenSendingPopup.ClientID%>')).click();
            $.ajax({
                type: "POST",
                url: "LoginWebService.asmx/SendSupportEmail",
                data: "{'fromEmail': '" + fromEmail +
                        "','subject': \"" + emailSubject +
                        "\",'body': \"" + emailBody + "\"}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    $($get('<%=btnCloseSendingPopup.ClientID%>')).click();
                    retStr = msg.d;
                    PopMsgWindow(retStr);
                },
                error: function(msg) {
                    $($get('<%=btnCloseSendingPopup.ClientID%>')).click();
                    PopMsgWindow("Sending has failed (please use support@myeasypotluck.com for now)");
                }
            });
        }
    </script>
</asp:Content>        