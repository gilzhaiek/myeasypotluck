<%@ page title="" language="C#" masterpagefile="~/Home/global.master" autoeventwireup="true" inherits="MyProfile, App_Web_ujphj1ma" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="ProfileContent" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
  <asp:ToolkitScriptManager runat="server" ID="ScriptManager1" />
    <div id="frm-profile">
        <div id="headSpacer" class="clearfix">
            <div id="dvTabGeneralHome" class="fl dvTabGeneral" onclick="location.href='EventBrief.aspx';" ><a href="EventBrief.aspx" class="wb18 hlymnu">Home</a></div>
            <div id="dvTabGeneralAbout" class="fl dvTabGeneral" onclick="location.href='About.aspx';"><a href="About.aspx" class="wb18 hlymnu">About</a></div>
            <div id="dvTabGeneralProfile" class="fl dvTabGeneral" onclick="location.href='MyProfile.aspx';"><a href="MyProfile.aspx" class="wb18 hlymnu">Profile</a></div>
            <!-- <div id="dvTabGeneralFriends" class="fl dvTabGeneral" onclick="location.href='EventBrief.aspx';"><a href="EventBrief.aspx" class="wb18 hlymnu">Friends</a></div> -->
        </div>
        <div class="wide top">
            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
            <asp:LinkButton ID="lnkbtnlogout" runat="server" onclick="lnkbtnlogout_Click">logout</asp:LinkButton>
        </div>
        <div class="fl" style="margin:36px 0px 0px 100px; width:750px;" >
            <div class=" profileSpacer">
                <div class=" profileLabels" >Email</div>
                <div class="profileTxtBg fl">                    
                    <input class="fl w16 profileTxtBox" id="txtEmail" autocomplete="off" type="text" name="Email" tabindex="1" />
                    <p id="validateEmail" class="fl validateButton" style="margin-top:4px; padding-left:30px;"><a >Ok</a></p>
                </div>
            </div>
            <div class=" profileSpacer">
                <div class=" profileLabels" >First Name</div>
                <div class="profileTxtBg fl">                    
                    <input class="fl w16 profileTxtBox" id="txtFirstName" autocomplete="off" type="text" name="FirstName" tabindex="2" />
                    <p id="validateFirstName" class="fl validateButton" style="margin-top:4px; padding-left:30px;" ><a >Ok</a></p>
                </div>
            </div>
            <div class=" profileSpacer">
                <div class=" profileLabels" >Last Name</div>
                <div class="profileTxtBg fl">                    
                    <input class="fl w16 profileTxtBox" id="txtLastName" autocomplete="off" type="text" name="LastName" tabindex="3" />
                    <p id="validateLastName" class="fl validateButton" style="margin-top:4px; padding-left:30px;" ><a >Ok</a></p>
                </div>
            </div>
           <div class="  profileSpacer">
                <div class=" profileLabels" >Gender</div>
                <div class="profileTxtBg fl">                    
                    <select class="fl w16 inputBox" name="Gender" id="drpDwnLstGender" tabindex="4" style="margin:0px 0px 0px 15px;width:200px">
                        <option value="EGender_0" selected="selected"></option>
                        <option value="EGender_1">Male</option>
                        <option value="EGender_2">Female</option>
                    </select>
                </div>
            </div>
           <div class=" profileSpacer">
                <div class="profileLabels" >Country</div>
                <div class="profileTxtBg fl">                    
                    <select class="fl w16 inputBox" name="Country" id="drpDwnLstCountry" tabindex="5" style="margin:0px 0px 0px 15px;width:200px">
                        <option value="ECountry_0" selected="selected"></option>
                    </select>
                </div>
            </div>
            <div class=" profileSpacer" >
                <div class="profileLabels" >New Password</div>
                <div class="profileTxtBg fl" style="width:500px">                    
                    <input class="fl w16 profileTxtBox" id="txtPassword1" autocomplete="off" type="password" name="Password" tabindex="6" />
                    <p id="validatePassword1" class="fl passwordTooShortButton" style="margin-top:4px; padding-left:30px;" ><a >Ok</a></p>
                </div>
            </div>            
            <div class=" profileSpacer">
                <div class=" profileLabels" >Validate Password</div>
                <div class="profileTxtBg fl" >                    
                    <input class="fl w16 profileTxtBox" id="txtPassword2" autocomplete="off" type="password" name="Password" tabindex="7" />
                    <p id="validatePassword2" class="fl validateButton" style="margin-top:4px; padding-left:30px;" ><a >Ok</a></p>
                </div>
            </div>            

        </div>
        <div class="clearfix" id="dvbtnsignup">
                <div class="signup-spacer">
                    <div class="fl wb18" style="padding-left:300px;margin-top:0px;color:#991F00">
                    <label id="lblMsg" ></label>
                    </div>
                </div>
            <div class="signup-spacer" style="padding-right:240px; padding-top:10px;" >
                <p id="btnSaveMe" class="saveMeButton" onclick="btnSaveMeClicked()" onmouseover="btnSaveMeOver()" onmousedown="btnSaveMeDown()" onmouseup="btnSaveMeOver()" onmouseout="btnSaveMeOut()" ><a tabindex="7">Save</a></p>
            </div>
        </div>
    </div>
    <div id="dvCopyRight" class="wb12">This website and its content is copyright of MyEasyPotluck.com © 2010. All rights reserved.</div>           
    <script  type="text/javascript"> 
        var emailRegX = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
        var nameRegX = /^[a-zA-Z''-'\s]{1,40}$/;

        function btnSaveMeDown() { $('#btnSaveMe>a').css("background-position", "0px -102px"); }
        function btnSaveMeOut() { $('#btnSaveMe>a').css("background-position", "0px 0px"); }
        function btnSaveMeOver() { $('#btnSaveMe>a').css("background-position", "0px -51px"); }
        function btnSaveMeClicked() {
            var email = $('#txtEmail').val();
            var firstName = $('#txtFirstName').val();
            var lastName = $('#txtLastName').val();
            var password1 = $("#txtPassword1").val();
            var password2 = $("#txtPassword2").val();
            var country = $("#drpDwnLstCountry").val();
            var gender = $("#drpDwnLstGender").val();

            var validateFailed = 0;

            if (!emailRegX.test(email)) {
                validateFailed = 1;
                $('#validateEmail>a').css("background-position", "0px -32px");
            }

            if (!nameRegX.test(firstName)) {
                validateFailed = 1;
                $('#validateFirstName>a').css("background-position", "0px -32px");
            }

            if (!nameRegX.test(lastName)) {
                validateFailed = 1;
                $('#validateLastName>a').css("background-position", "0px -32px");
            }

            if ((password1.length < 6) && (password1 > 0)) {
                validateFailed = 1;
                $('#validatePassword1>a').css("background-position", "0px -15px");
            }

            if (password1 != password2) {
                validateFailed = 1;
                $('#validatePassword2>a').css("background-position", "0px -32px");
            }

            if (validateFailed == 0) {
                var fixedFirstName = firstName.replace(/\"/g, "\\\"").replace(/\'/g, "\\\'");
                var fixedLastName = lastName.replace(/\"/g, "\\\"").replace(/\'/g, "\\\'");

                $.ajax({
                    type: "POST",
                    url: "LoginWebService.asmx/UpdateUser",
                    data: "{'email': '" + email +
                        "','password': '" + password1 +
                        "','firstName': \"" + fixedFirstName +
                        "\",'lastName': \"" + fixedLastName +
                        "\",'gender': '" + gender +
                        "','country': '" + country + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                    if (msg.d != "Success") {
                            AjaxSucceeded(msg);

                        }
                        else {
                            $($get('<%=lblName.ClientID%>')).text("Hello " + fixedFirstName + " " + fixedLastName);
                            $('#lblMsg').text(msg.d);
                        }
                    },
                    error: function(msg) {
                    }
                });
            }            
        }

        var emailValidateFunc = function() {
            if (emailRegX.test($('#txtEmail').val())) {
                $('#validateEmail>a').css("background-position", "0px -15px");
            }
            else {
                $('#validateEmail>a').css("background-position", "0px 0px");
            }
        }

        var firstNameValidateFunc = function() {
            if (nameRegX.test($('#txtFirstName').val())) {
                $('#validateFirstName>a').css("background-position", "0px -15px");
            }
            else {
                $('#validateFirstName>a').css("background-position", "0px 0px");
            }
        }

        var lastNameValidateFunc = function() {
        if (nameRegX.test($('#txtLastName').val())) {
                $('#validateLastName>a').css("background-position", "0px -15px");
            }
            else {
                $('#validateLastName>a').css("background-position", "0px 0px");
            }
        }        

        var passwordValidateFunc = function() {
            if ($('#txtPassword1').val() == "") {
                $('#validatePassword1>a').css("background-position", "0px 0px");
            }
            else {
                if ($("#txtPassword1").val().length < 6) {
                    $('#validatePassword1>a').css("background-position", "0px -15px");
                    $('#validatePassword2>a').css("background-position", "0px 0px");
                }
                else {
                    $('#validatePassword1>a').css("background-position", "0px 0px");
                    if (($('#txtPassword1').val() != "") && ($('#txtPassword2').val() != "")) {
                        if ($('#txtPassword1').val() != $('#txtPassword2').val()) {
                            $('#validatePassword2>a').css("background-position", "0px -32px");
                        }
                        else {
                            $('#validatePassword2>a').css("background-position", "0px -15px");
                        }
                    }
                    else {
                        $('#validatePassword2>a').css("background-position", "0px 0px");
                    }
                }
            }
        }

        $(document).ready(function() {
            $("#txtEmail").focus();
            $("#txtEmail").keyup(emailValidateFunc);
            $("#txtEmail").blur(emailValidateFunc);

            $("#txtFirstName").keyup(firstNameValidateFunc);
            $("#txtFirstName").blur(firstNameValidateFunc);

            $("#txtLastName").keyup(lastNameValidateFunc);
            $("#txtLastName").blur(lastNameValidateFunc);

            $("#txtPassword1").keyup(passwordValidateFunc);
            $("#txtPassword1").blur(passwordValidateFunc);

            $("#txtPassword2").keyup(passwordValidateFunc);
            $("#txtPassword2").blur(passwordValidateFunc);

            $.ajax({
                type: "POST",
                url: "LoginWebService.asmx/GetCountryOptions",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    $("#drpDwnLstCountry").append(msg.d);

                    $.ajax({
                        type: "POST",
                        url: "LoginWebService.asmx/GetUserProfile",
                        data: "{}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function(msg) {
                            var retStr = msg.d;
                            if (msg.d.indexOf('#') == -1) {
                                alert(msg.d);
                            }
                            else {
                                var userProfile = msg.d.split("(#)");

                                $("#txtEmail").val(userProfile[0]);
                                $("#txtFirstName").val(userProfile[1]);
                                $("#txtLastName").val(userProfile[2]);
                                $("#drpDwnLstGender").val(userProfile[3]);
                                $("#drpDwnLstCountry").val(userProfile[4]);

                                emailValidateFunc();
                                firstNameValidateFunc();
                                lastNameValidateFunc();
                            }
                        },
                        error: function(msg) {
                        }
                });                    
                },
                error: function(msg) {
                }
            });
        });

        function AjaxSucceeded(result) {
            alert(result.d);
        }        
        
    </script>        
</asp:Content>