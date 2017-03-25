<%@ page title="" language="C#" masterpagefile="~/Home/global.master" autoeventwireup="true" inherits="Signup, App_Web_ujphj1ma" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div id="frm-signup">
            <div id="headSpacer" class="clearfix">
                <div id="dvTabGeneralHome" class="fl dvTabGeneral" onclick="location.href='default.aspx';"><a href="default.aspx" class="wb18 hlymnu">Home</a></div>
                <div id="dvTabGeneralAbout" class="fl dvTabGeneral" onclick="location.href='default.aspx';"><a href="default.aspx" class="wb18 hlymnu">About</a></div>
                <!---<div id="dvTabGeneralDirectory" class="fl dvTabGeneral" onclick="location.href='Directory.aspx';" ><a href="Directory.aspx" class="wb18 hlymnu">Directory</a></div> -->
            </div>
            <div class="fl signup-container">
                <div class="clearfix signup-spacer">
                    <div class="txt-bg fl">
                        <input class="fl w16 inputBox" id="txtEmail" autocomplete="off" style="border:0; width:190px; height:21px; margin-left:18px;"
                            type="text" name="Email" tabindex="1" />
                        <p id="validateEmail" class="fr validateButton" style="margin-top:0px; padding-left:30px;"><a>Ok</a></p>
                    </div>
                    <div>
                    </div>
                </div>
                <div class="clearfix signup-spacer">
                    <div class="txt-bg fl">
                        <input class="fl w16 inputBox" id="txtFullName" autocomplete="off" type="text" name="Name" tabindex="2" />
                        <p id="validateName" class="fr validateButton" style="margin-top:0px; padding-left:30px;"><a>Ok</a></p>
                    </div>
                </div>
                <div class="clearfix signup-spacer">
                    <div class="txt-bg fl">
                        <select class="fl w16 inputBox" name="Gender" id="drpDwnLstGender" tabindex="3">
                    <option value="EGender_0" selected="selected"></option>
                    <option value="EGender_1">Male</option>
                    <option value="EGender_2">Female</option>
                </select>
                    </div>
                </div>
                <div class="clearfix signup-spacer">
                    <div class="txt-bg fl">
                        <select class="fl w16 inputBox" name="Country" id="drpDwnLstCountry" tabindex="4">
                    <option value="ECountry_0" selected="selected"></option>
                </select>
                    </div>
                </div>
                <div class="clearfix signup-spacer">
                    <div class="txt-bg-password fl">
                        <input class="fl w16 inputBox" id="txtPassword1" autocomplete="off" type="password" name="Password" tabindex="5" />
                        <p id="validatePassword1" class="fr passwordTooShortButton" style="margin-top:0px; padding-left:30px;"><a>Ok</a></p>
                    </div>
                </div>
                <div class="clearfix signup-spacer">
                    <div class="txt-bg fl">
                        <input class="fl w16 inputBox" id="txtPassword2" autocomplete="off" type="password" name="Password" tabindex="6" />
                        <p id="validatePassword2" class="fr validateButton" style="margin-top:0px; padding-left:30px;"><a>Ok</a></p>
                    </div>
                </div>
            </div>
            <div class="clearfix" id="dvbtnsignup">
                <div class="signup-spacer">
                    <div class="fl wb14" style="padding-left:180px;margin-top:-6px;color:#991F00">
                        <label id="lblInvalidMsg"></label>
                    </div>
                </div>
                <div class="signup-spacer" style="padding-right:240px; padding-top:1px;">
                    <p id="btnCreateMe" class="createMeButton" onclick="btnCreateMeClicked()" onmouseover="btnCreateMeOver()" onmousedown="btnCreateMeDown()"
                        onmouseup="btnCreateMeOver()" onmouseout="btnCreateMeOut()"><a tabindex="7">Create Me</a></p>
                </div>
            </div>
        </div>
        <div id="dvCopyRight" class="wb12">This website and its content is copyright of MyEasyPotluck.com © 2010. All rights reserved.</div>

        <script type="text/javascript">
                                   var emailRegX = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
                                   var fullNameRegX = /^[a-zA-Z''-']+[\s]+[a-zA-Z]*[a-zA-Z''-'\s]$/;

                                   function btnCreateMeDown() { $('#btnCreateMe>a').css("background-position", "0px -102px"); }
                                   function btnCreateMeOut() { $('#btnCreateMe>a').css("background-position", "0px 0px"); }
                                   function btnCreateMeOver() { $('#btnCreateMe>a').css("background-position", "0px -51px"); }
                                   function btnCreateMeClicked() {
                                       var email = $('#txtEmail').val();
                                       var fullName = $('#txtFullName').val();
                                       var password1 = $("#txtPassword1").val();
                                       var password2 = $("#txtPassword2").val();
                                       var country = $("#drpDwnLstCountry").val();
                                       var gender = $("#drpDwnLstGender").val();

                                       var validateFailed = 0;

                                       if (!emailRegX.test(email)) {
                                           validateFailed = 1;
                                           $('#validateEmail>a').css("background-position", "0px -32px");
                                       }

                                       if (!fullNameRegX.test(fullName)) {
                                           validateFailed = 1;
                                           $('#validateName>a').css("background-position", "0px -32px");
                                       }

                                       if (password1.length < 6) {
                                           validateFailed = 1;
                                           $('#validatePassword1>a').css("background-position", "0px -15px");
                                       }

                                       if (password1 != password2) {
                                           validateFailed = 1;
                                           $('#validatePassword2>a').css("background-position", "0px -32px");
                                       }

                                       if (validateFailed == 0) {
                                           var fixedFullName = fullName.replace(/\"/g, "\\\"").replace(/\'/g, "\\\'");

                                           $.ajax({
                                               type: "POST",
                                               url: "LoginWebService.asmx/CreateUser",
                                               data: "{'email': '" + email +
                                               "','password': '" + password1 +
                                               "','fullName': \"" + fixedFullName +
                                               "\",'gender': '" + gender +
                                               "','country': '" + country + "'}",
                                               contentType: "application/json; charset=utf-8",
                                               dataType: "json",
                                               success: function (msg) {
                                                   if (msg.d == "success") {
                                                       window.location.href = "EventBrief.aspx";
                                                   }
                                                   else {
                                                       $('#lblInvalidMsg').text(msg.d);
                                                   }
                                               },
                                               error: function (msg) {
                                               }
                                           });
                                       }
                                   }

                                   var emailValidateFunc = function () {
                                       if (emailRegX.test($('#txtEmail').val())) {
                                           $('#validateEmail>a').css("background-position", "0px -15px");
                                       }
                                       else {
                                           $('#validateEmail>a').css("background-position", "0px 0px");
                                       }
                                   }

                                   var fullNameValidateFunc = function () {
                                       if (fullNameRegX.test($('#txtFullName').val())) {
                                           $('#validateName>a').css("background-position", "0px -15px");
                                       }
                                       else {
                                           $('#validateName>a').css("background-position", "0px 0px");
                                       }
                                   }

                                   var passwordValidateFunc = function () {
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


                                   $(document).ready(function () {
                                       $("#txtEmail").focus();
                                       $("#txtEmail").keyup(emailValidateFunc);
                                       $("#txtEmail").blur(emailValidateFunc);

                                       $("#txtFullName").keyup(fullNameValidateFunc);
                                       $("#txtFullName").blur(fullNameValidateFunc);

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
                                           success: function (msg) {
                                               $("#drpDwnLstCountry").append(msg.d);
                                           },
                                           error: function (msg) {
                                           }
                                       });
                                   });
        </script>

    </asp:Content>