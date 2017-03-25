<%@ page title="" language="C#" masterpagefile="~/Home/global.master" autoeventwireup="true" inherits="Login, App_Web_ujphj1ma" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ToolkitScriptManager runat="server" ID="ScriptManager1" />
    <div id="fb-root"></div>
    <script src="http://connect.facebook.net/en_US/all.js"></script>
    <script type="text/javascript">
        FB.init({
        appId: '117303974961194',
            status: true, // check login status
            cookie: true, // enable cookies to allow the server to access the session
            xfbml: true  // parse XFBML
        });
        
    </script>    
    
    <div id="frm-login" style="position:relative;">
        <div id="headSpacer" class="clearfix">
            <div id="dvTabGeneralHome" class="fl dvTabGeneral" onclick="location.href='default.aspx';" ><a href="default.aspx" class="wb18 hlymnu">Home</a></div>
            <div id="dvTabGeneralAbout" class="fl dvTabGeneral" onclick="location.href='About.aspx';"><a href="About.aspx" class="wb18 hlymnu">About</a></div>
            <!---<div id="dvTabGeneralDirectory" class="fl dvTabGeneral" onclick="location.href='Directory.aspx';" ><a href="Directory.aspx" class="wb18 hlymnu">Directory</a></div> -->   
        </div>
        <div >
            <div id="login-txt" class="w22 clearfix">
                <i>“A potluck is a gathering of people where each<br/>
                person or group of people contributes a dish<br/>
                of food to be shared among the group”</i><br/><br/>

                MyEasyPotluck is a potluck event organizer.<br/>
                No longer you have to run around friends and <br/>
                family and try to organize what each person<br/>
                will bring.  No more headache, no more stress.<br/><br/>

                <div class="w26">No more: “TOO MUCH DESSERT, NOT ENOUGH PIE!”</div>
            </div>
            <br />
            <div class="login-box">
                <div style="padding:0px 0px 0px 350px; ">
                    <p id="btnNeedReminder" class="needReminder" style="margin:0px;" onclick="needReminderClicked()"
                    onmouseover="needReminderMouseOver()" onmousedown="needReminderMouseDown()" onmouseup="needReminderMouseOver()" onmouseout="needReminderMouseOut()" 
                     ><a  >Need a Reminder</a></p>        
                </div>
                <div class=" wb12" style="padding-top:4px;">
                    <div class="txt-bg-long fl">
                        <input class="w16" id="txtEmail" style="border:0; width:240px; height:21px;" type="text" name="Email" tabindex="1" />
                    </div>
                    <div class="txt-bg fl" style="margin-left:6px">
                        <input class="w16" id="txtPassword" style="border:0; width:150px; height:21px;" type="password" name="Password" tabindex="2" onkeydown="if (event.keyCode == 13) btnGoClicked();" />
                    </div>
                    <div class="fl" style="margin:1px 14px 0px 2px">
                        <p id="btnGo" class="goButton" style="margin:0px;" onclick="btnGoClicked()"
                        onmouseover="btnGoMouseOver()" onmousedown="btnGoMouseDown()" onmouseup="btnGoMouseOver()" onmouseout="btnGoMouseOut()" 
                         ><a  tabindex="3">Go</a></p>
                    </div>
                </div>
                <div class="clearfix w12">
                    <div class="fl" style="padding-left:10px"><i>Not a member?</i></div>
				    <div class="fl wb12" style="padding-left:3px"><i><a href="Signup.aspx" class="blue">click here to sign up</a></i></div>        
                    <div class="fl wb14" style="padding-left:30px;color:#991F00">
                     <label id="lblInvalidMsg" ></label>
                    </div>
                </div>
            </div>
            </div>
        
        <!-- Message Popup Panel -->
        <asp:Panel ID="pnlPopEmailReminder" runat="server" Style="display: none" CssClass="emailReminderOuterPopup">
            <asp:Panel ID="pnlPopEmailReminderInnerOuter" runat="server" CssClass="emailReminderInnerOuterPopup" >
                <asp:Panel ID="pnlPopEmailReminderInnerInner" runat="server" CssClass="emailReminderInnerInnerPopup" BackColor="#FDF8E3">        
                    <div style="margin:10px 20px 0px 20px;">
                        <asp:Label ID="labelEmailReminderPopup"  runat="server" style="text-align: center;"  Text="Please enter your email:" ></asp:Label>
                        <br />
                        <input class="w16" id="txtEmailReminder" style="width:280px; height:21px;margin-top:6px;" type="text" name="Email"/>
                        <br />
                        <label id="emailReminderLabel" ></label>
                        <p class="clearfix" style="text-align: center;" >
                            <input id="btnOkEmailReminderPopup" value="Send" onclick="OkEmailReminderPopupClick();" class="myButton" style="margin: 10px 0px 10px 0px;" type="button" />
                            <asp:Button ID="btnCancelEmailReminderPopup" CssClass="myButton" runat="server" style="margin: 10px 0px 10px 0px;" Text="Cancel"  />
                        </p>                    
                    </div>
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>
        
        <!-- EmailReminder Popup -->
        <span style="display: none">
            <asp:Button ID="btnOpenEmailReminderPopup" runat="server" />
            <asp:Button ID="btnCloseEmailReminderPopup" runat="server" />
        </span>
        <asp:ModalPopupExtender ID="ModalPopupExtender4" runat="server"
        TargetControlID="btnOpenEmailReminderPopup" PopupControlID="pnlPopEmailReminder" 
        OkControlID="btnCloseEmailReminderPopup" CancelControlID="btnCancelEmailReminderPopup" DropShadow="False" 
            BackgroundCssClass="modelBackground">
        </asp:ModalPopupExtender>
        <asp:RoundedCornersExtender ID="RoundedCornersExtender7" runat="server" 
            TargetControlID="pnlPopEmailReminderInnerOuter" BorderColor="black" Radius="8" Color="#000000">
        </asp:RoundedCornersExtender>        
        <asp:RoundedCornersExtender ID="RoundedCornersExtender8" runat="server" 
            TargetControlID="pnlPopEmailReminderInnerInner" BorderColor="black" Radius="8" >
        </asp:RoundedCornersExtender>          
                    
    <div id="dvLoginCopyRight" class="clearfix wb12">This website and its content is copyright of MyEasyPotluck.com © 2010. All rights reserved.</div>            
    </div>
    <script  type="text/javascript">
        var emailRegX = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
        
        function btnGoMouseDown() {$('#btnGo>a').css("background-position", "0 -103px");}
        function btnGoMouseOut() {$('#btnGo>a').css("background-position", "0 0px");}
        function btnGoMouseOver(){$('#btnGo>a').css("background-position", "0 -52px");}

        function needReminderMouseDown() { $('#btnNeedReminder>a').css("background-position", "0 -68px"); }
        function needReminderMouseOut() { $('#btnNeedReminder>a').css("background-position", "0 0px"); }
        function needReminderMouseOver() { $('#btnNeedReminder>a').css("background-position", "0 -34px"); }

        $(document).ready(function() {
            $('#txtEmail').focus();
        })

        function needReminderClicked() {
            $('#emailReminderLabel').text("");
            $($get('<%=btnOpenEmailReminderPopup.ClientID%>')).click();
        }

        function OkEmailReminderPopupClick() {
            var email = $('#txtEmailReminder').val();

            if (!emailRegX.test(email)) {
                $('#emailReminderLabel').text("Email address is illegal");
            }
            else {
                $.ajax({
                    type: "POST",
                    url: "LoginWebService.asmx/SendEmailReminder",
                    data: "{'email': '" + email + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        if (msg.d != "success") {
                            $('#emailReminderLabel').text(mdg.d);
                        }
                        else {
                            alert("Email with your password was sent!");
                            $('#emailReminderLabel').text("");
                            $($get('<%=btnCloseEmailReminderPopup.ClientID%>')).click();
                        }
                    },
                    error: function(msg) {
                        $('#emailReminderLabel').text(mdg.d);
                    }
                });
            }
        }
        
        function btnGoClicked() {            
            var email = $('#txtEmail').val();
            var password = $('#txtPassword').val();
            
            $.ajax({
                type: "POST",
                url: "LoginWebService.asmx/LoginUser",
                data: "{'email': '" + email + "','password': '" + password + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    if(msg.d == "success")
                    {
                        window.location.href = "EventBrief.aspx";
                    }
                    else
                    {
                        $('#lblInvalidMsg').text(msg.d);
                    }
                },
                error: function(msg) {
                    $('#lblInvalidMsg').text(msg.d);
                }
            });
        }

         
    </script>
</asp:Content>

