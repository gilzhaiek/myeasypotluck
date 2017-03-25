<%@ page title="" language="C#" masterpagefile="~/Home/global.master" autoeventwireup="true" inherits="EventView, App_Web_ujphj1ma" %>

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

        <asp:Content ID="EventViewContent" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <asp:ToolkitScriptManager runat="server" ID="ScriptManager1" />
            <div id="frm-event_details">
                <div id="headSpacer" class="clearfix">
                    <div id="dvTabGeneralHome" class="fl dvTabGeneral" onclick="location.href='EventBrief.aspx';"><a href="EventBrief.aspx" class="wb18 hlymnu">Home</a></div>
                    <div id="dvTabGeneralAbout" class="fl dvTabGeneral" onclick="location.href='About.aspx';"><a href="About.aspx" class="wb18 hlymnu">About</a></div>
                    <div id="dvTabGeneralProfile" class="fl dvTabGeneral" onclick="location.href='MyProfile.aspx';"><a href="MyProfile.aspx" class="wb18 hlymnu">Profile</a></div>
                    <!-- <div id="dvTabGeneralFriends" class="fl dvTabGeneral" onclick="location.href='EventBrief.aspx';"><a href="EventBrief.aspx" class="wb18 hlymnu">Friends</a></div>-->
                </div>
                <div class="wide top">
                    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                    <asp:LinkButton ID="lnkbtnlogout" runat="server" onclick="lnkbtnlogout_Click">logout</asp:LinkButton>
                </div>

                <!--- Hidden stuff -->
                <div style="display: none">
                    <img alt="hidden1" src="Icons/Star.png" width="1" height="1" style="opacity:0.4; filter:alpha(opacity=40);" />
                    <img alt="hidden2" src="Icons/StarH.png" width="1" height="1" style="opacity:0.4; filter:alpha(opacity=40);" />
                    <img alt="hidden3" src="Icons/DeleteX.png" width="1" height="1" style="opacity:0.4; filter:alpha(opacity=40);" />
                    <img alt="hidden3" src="Icons/DeleteXh.png" width="1" height="1" style="opacity:0.4; filter:alpha(opacity=40);" />
                    <img alt="hidden4" src="Images/global/chkF.png" width="1" height="1" style="opacity:0.4; filter:alpha(opacity=40);" />
                    <img alt="hidden5" src="Images/global/chkT.png" width="1" height="1" style="opacity:0.4; filter:alpha(opacity=40);" />
                    <img alt="sStars0Hidden" src="Icons/sStars0.png" width="1" height="1" style="opacity:0.4; filter:alpha(opacity=40);" />
                    <img alt="sStars1Hidden" src="Icons/sStars1.png" width="1" height="1" style="opacity:0.4; filter:alpha(opacity=40);" />
                    <img alt="sStars2Hidden" src="Icons/sStars2.png" width="1" height="1" style="opacity:0.4; filter:alpha(opacity=40);" />
                    <img alt="sStars3Hidden" src="Icons/sStars3.png" width="1" height="1" style="opacity:0.4; filter:alpha(opacity=40);" />
                    <img alt="sStars4Hidden" src="Icons/sStars4.png" width="1" height="1" style="opacity:0.4; filter:alpha(opacity=40);" />
                </div>

                <div class="clearfix fl">
                    <asp:Panel ID="PanelEventDetail" runat="server" CssClass="detailedPanel fl" Width="372px" Height="390px" style="margin-left:70px">
                        <div class="clearfix" style="margin:0px 0px 0px 20px;">
                            <asp:Label CssClass="clearfix wi10 fl" ID="lblTopicEnter" runat="server" Text="Topic" style="margin-left:10px;margin-top:10px;"></asp:Label>
                            <br />
                            <asp:TextBox CssClass="clearfix fl w18 boxBorder" ID="txtboxTopicEnter" runat="server" Width="330px" ReadOnly="True" BorderStyle="None"
                                BackColor="Transparent" Enabled="True"></asp:TextBox>

                            <br />
                            <asp:Label CssClass="clearfix fl wi10" ID="Label1" runat="server" Text="Description" style="margin-left:10px;margin-top:10px;"></asp:Label>

                            <br />
                            <asp:TextBox CssClass="clearfix fl w18 boxBorder" ID="txtboxDescriptionEnter" runat="server" Rows="5" TextMode="MultiLine"
                                style="resize:none;" Width="330px" Height="100px" ReadOnly="True" BackColor="Transparent"></asp:TextBox>

                            <br />
                        </div>
                        <div style="margin:110px 0px 0px 20px;" class="clearfix">
                            <div style="margin:20px 0px 0px 0px;">
                                <div class="fl">Starts:</div>
                                <div class="fr" style="margin:0px 20px 0px 0px;">
                                    <asp:TextBox runat="server" CssClass="w16 dateTimeTextBox boxBorder" Width="130" ID="inputRangeStartDate" autocomplete="off"
                                        ReadOnly="True" BorderStyle="None" BackColor="Transparent" />
                                    <asp:TextBox ID="inputRangeStartTime" runat="server" Text="" CssClass="w16 dateTimeTextBox boxBorder" Width="100" ReadOnly="True"
                                        BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                                </div>
                            </div>

                            <div style="margin:4px 0px 0px 0px;" class="clearfix">
                                <div class="fl">Finishes:</div>
                                <div class="fr" style="margin:0px 20px 0px 0px;">
                                    <asp:TextBox runat="server" CssClass="w16 dateTimeTextBox  boxBorder" Width="130" ID="inputRangeFinishDate" autocomplete="off"
                                        ReadOnly="True" BorderStyle="None" BackColor="Transparent" />
                                    <asp:TextBox ID="inputRangeFinishTime" runat="server" Text="" CssClass="w16 dateTimeTextBox  boxBorder" Width="100" ReadOnly="True"
                                        BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                                </div>
                            </div>

                            <div style="margin:4px 0px 0px 0px;" class="clearfix">
                                <div class="fl">Location:</div>
                                <div class="fr" style="margin:0px 20px 0px 0px;">
                                    <asp:TextBox runat="server" CssClass="w16 boxBorder" Width="236" ID="txtboxLocation" ReadOnly="True" BorderStyle="None" BackColor="Transparent"
                                    />
                                </div>
                            </div>

                            <div style="margin:4px 0px 0px 0px;" class="clearfix">
                                <div class="fl" style="margin-top:8px;">
                                    <label>Friends need to bring a value of:</label>
                                </div>
                                <div class="fr" style="margin:8px 20px 0px 0px;">
                                    <img id="eventTotalValueStar_1" alt=" " src="Icons/Star.png" style="margin-left:6px;" />
                                    <img id="eventTotalValueStar_2" alt=" " src="Icons/Star.png" style="margin-left:6px;" />
                                    <img id="eventTotalValueStar_3" alt=" " src="Icons/Star.png" style="margin-left:6px;" />
                                    <img id="eventTotalValueStar_4" alt=" " src="Icons/Star.png" style="margin-left:6px;" />
                                </div>
                            </div>
                            <br />

                            <div style="margin:4px 0px 0px 0px;" class="clearfix">
                                <div class="fl" style="margin-top:8px;">
                                    <label>The value of the items you bring:</label>
                                </div>
                                <div class="fr" style="margin:8px 20px 0px 0px;">
                                    <img id="eventMyTotalValueStar_1" alt=" " src="Icons/Star.png" style="margin-left:6px;" />
                                    <img id="eventMyTotalValueStar_2" alt=" " src="Icons/Star.png" style="margin-left:6px;" />
                                    <img id="eventMyTotalValueStar_3" alt=" " src="Icons/Star.png" style="margin-left:6px;" />
                                    <img id="eventMyTotalValueStar_4" alt=" " src="Icons/Star.png" style="margin-left:6px;" />
                                </div>
                            </div>

                            <div style="margin:0px 0px 0px 0px;" class="clearfix">
                                <div class="fl wib12" style="margin-top:2px;">
                                    <label id="valueMsg" style="color:#E60000"></label>
                                </div>
                            </div>
                            <br />
                        </div>
                    </asp:Panel>

                    <!-- Friends -->
                    <asp:Panel ID="PanelFriendsInvite" runat="server" CssClass="clearfix detailedPanel fl" Width="372px" Height="141px" style="margin: 400px 0 0 70px">
                        <asp:Label CssClass="fl" ID="Label3" runat="server" style="margin: 6px 0 0 30px" Text="Friends in this event"></asp:Label>
                        <div id="friendsContainer" class="clearfix fl">
                            <div id="friendsBox" class="boxBorder">
                                <div id="eventFriendsList">
                                </div>
                            </div>
                        </div>
                        <div class="fl" style="margin:-12px 0px 0px 20px; text-align: center; width:370px">
                            <p id="btnFriendProfile" class="fl friendProfileButton" onclick="btnFriendProfileClicked()" onmouseover="btnFriendProfileOver()"
                                onmousedown="btnFriendProfileDown()" onmouseup="btnFriendProfileOver()" onmouseout="btnFriendProfileOut()"><a>Friend Profile</a></p>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="PanelEventItems" runat="server" CssClass="detailedPanel fl" Width="416px" Height="540px" style="margin: 0px 0 0 460px">
                        <asp:Label CssClass="fl wi14" ID="LabelItemsInEvent" runat="server" style="margin: 14px 0 0 20px" Text="Items to bring"></asp:Label>
                        <br />
                        <div id="scrollContainer" class="clearfix">
                            <div id="scrollViewBox" class="boxBorder">
                                <div id="scrollItems">
                                </div>
                            </div>
                        </div>
                        <div style="margin-top:10px;">
                            <label class="fl" id="holdingsLabel" style="margin: 5px 0px 0 10px">Quantity Needed:&nbsp;</label>
                            <label class="fl" id="holdingsCount" style="margin: 5px 0px 0 10px">0</label>
                        </div>
                        <div id="holdingsContainer" class="fl">
                            <div id="holdingsBox" class="boxBorder">
                                <div id="holdingsUsers">
                                </div>
                            </div>
                        </div>
                        <div class="fl" style="margin:-10px 0px 0px 14px;">
                            <div>
                                <div class="clearfix">
                                    <p id="btnHoldHolding" style="margin:34px 3px 0px 0px;" class="fr holdItemButton" onclick="HoldHoldingClick()" onmouseover="btnHoldItemOver()"
                                        onmousedown="btnHoldItemDown()" onmouseup="btnHoldItemOver()" onmouseout="btnHoldItemOut()"><a>I'll Bring It</a></p>
                                </div>
                            </div>
                        </div>
                        <div>
                        </div>
                    </asp:Panel>
                </div>

                <!-- Message Popup Panel -->
                <asp:Panel ID="pnlPopMsg" runat="server" Style="display: none" CssClass="msgOuterPopup">
                    <asp:Panel ID="pnlPopMsgInnerOuter" runat="server" CssClass="msgInnerOuterPopup">
                        <asp:Panel ID="pnlPopMsgInnerInner" runat="server" CssClass="msgInnerInnerPopup" BackColor="#FDF8E3">
                            <div style="margin:10px 20px 0px 20px;">
                                <asp:Label ID="labelMsgPopup" runat="server" style="text-align: center;" Text=" "></asp:Label>
                                <p class="clearfix" style="text-align: center;">
                                    <input id="btnOkMsgPopup" value="Ok" onclick="OkMsgPopupClick();" class="myButton" style="margin: 10px 0px 10px 0px;" type="button"
                                    />
                                    <asp:Button ID="btnCancelMsgPopup" CssClass="myButton" runat="server" style="margin: 10px 0px 10px 0px;display: none;" Text="Cancel"
                                    />
                                </p>
                            </div>
                        </asp:Panel>
                    </asp:Panel>
                </asp:Panel>


                <!-- Message Popup Panel -->
                <asp:Panel ID="pnlLoadingPopup" runat="server" Style="display: none;background-color: transparent; vertical-align: top; padding: 0px 0px 0px 0px;"
                    CssClass="loadingPopup">
                    <asp:Label ID="labelLoadingMsg" CssClass="wb24" runat="server" style="text-align: center;" Text="Loading..."></asp:Label>
                </asp:Panel>

                <!-- Msg Popup -->
                <span style="display: none"><asp:Button ID="btnOpenMsgPopup" runat="server" /></span>
                <asp:ModalPopupExtender ID="ModalPopupExtender4" runat="server" TargetControlID="btnOpenMsgPopup" PopupControlID="pnlPopMsg"
                    OkControlID="btnOkMsgPopup" CancelControlID="btnCancelMsgPopup" DropShadow="False" BackgroundCssClass="modelBackground">
                </asp:ModalPopupExtender>
                <asp:RoundedCornersExtender ID="RoundedCornersExtender7" runat="server" TargetControlID="pnlPopMsgInnerOuter" BorderColor="black"
                    Radius="8" Color="#000000">
                </asp:RoundedCornersExtender>
                <asp:RoundedCornersExtender ID="RoundedCornersExtender8" runat="server" TargetControlID="pnlPopMsgInnerInner" BorderColor="black"
                    Radius="8">
                </asp:RoundedCornersExtender>

                <!-- Msg Popup -->
                <span style="display: none"><asp:Button ID="btnOpenLoadingPopup" runat="server" /></span>
                <span style="display: none"><asp:Button ID="btnCloseLoadingPopup" runat="server" /></span>
                <asp:ModalPopupExtender ID="ModalPopupExtender6" runat="server" TargetControlID="btnOpenLoadingPopup" PopupControlID="pnlLoadingPopup"
                    CancelControlID="btnCloseLoadingPopup" DropShadow="False" BackgroundCssClass="modelBackground">
                </asp:ModalPopupExtender>

            </div>
            <div id="dvCopyRight" class="wb12">This website and its content is copyright of MyEasyPotluck.com © 2010. All rights reserved.</div>
            <script type="text/javascript">
                                                                                  var nameIconsLoaded;
                                                                                  var iconsLoaded;
                                                                                  var iconPopupLoaded;
                                                                                  var myFriendUniqueID;
                                                                                  var eventFriendUniqueID;
                                                                                  var eventFriendFullName;
                                                                                  var itemInEventUniqueID;
                                                                                  var itemHoldingsUniqueID;
                                                                                  var gCustomItemValueClicked = 0;
                                                                                  var gEventTotalValueClicked = 0;

                                                                                  function btnFriendProfileDown() { $('#btnFriendProfile>a').css("background-position", "0px -54px"); }
                                                                                  function btnFriendProfileOut() { $('#btnFriendProfile>a').css("background-position", "0px 0px"); }
                                                                                  function btnFriendProfileOver() { $('#btnFriendProfile>a').css("background-position", "0px -27px"); }
                                                                                  function btnFriendProfileClicked() { }

                                                                                  var holdItemPos = 176;
                                                                                  function clearHoldingItems() {
                                                                                      itemHoldingsUniqueID = 0;
                                                                                      holdItemPos = 176;
                                                                                      $('#holdingsUsers').empty();
                                                                                      $('#holdingsCount').text("");
                                                                                      btnHoldItemOut();
                                                                                  }

                                                                                  function btnHoldItemDown() {
                                                                                      if (holdItemPos < 151) {
                                                                                          pos = holdItemPos + 51;
                                                                                          $('#btnHoldHolding>a').css("background-position", "0px -" + pos.toString() + "px");
                                                                                      }
                                                                                  }
                                                                                  function btnHoldItemOut() {
                                                                                      pos = holdItemPos;
                                                                                      $('#btnHoldHolding>a').css("background-position", "0px -" + pos.toString() + "px");
                                                                                  }
                                                                                  function btnHoldItemOver() {
                                                                                      if (holdItemPos < 151) {
                                                                                          pos = holdItemPos + 26;
                                                                                          $('#btnHoldHolding>a').css("background-position", "0px -" + pos.toString() + "px");
                                                                                      }
                                                                                  }

                                                                                  function pageLoad() {
                                                                                      nameIconsLoaded = 0;
                                                                                      iconsLoaded = 0;
                                                                                      iconPopupLoaded = 0;
                                                                                      myFriendUniqueID = 0;
                                                                                      eventFriendUniqueID = 0;
                                                                                      itemInEventUniqueID = 0;
                                                                                      eventFriendFullName = "";
                                                                                      itemHoldingsUniqueID = 0;

                                                                                      $.ajax({
                                                                                          type: "POST",
                                                                                          url: "EventDetailsWebService.asmx/GetEventTotalValueNeeded",
                                                                                          data: "{}",
                                                                                          contentType: "application/json; charset=utf-8",
                                                                                          dataType: "json",
                                                                                          success: function (msg) {
                                                                                              if (msg.d.length != 1) {
                                                                                                  PopMsgWindow(msg.d);
                                                                                              }
                                                                                              else {
                                                                                                  if (msg.d == "1") { eventTotalValueClicked(1); }
                                                                                                  else if (msg.d == "2") { eventTotalValueClicked(2); }
                                                                                                  else if (msg.d == "3") { eventTotalValueClicked(3); }
                                                                                                  else if (msg.d == "4") { eventTotalValueClicked(4); }
                                                                                              }
                                                                                          },
                                                                                          error: AjaxFailed
                                                                                      });

                                                                                      $.ajax({
                                                                                          type: "POST",
                                                                                          url: "EventDetailsWebService.asmx/GetEventFriendsString",
                                                                                          data: "{}",
                                                                                          contentType: "application/json; charset=utf-8",
                                                                                          dataType: "json",
                                                                                          success: function (msg) {
                                                                                              $('#eventFriendsList').append(msg.d);
                                                                                          },
                                                                                          error: AjaxFailed
                                                                                      });

                                                                                      $.ajax({
                                                                                          type: "POST",
                                                                                          url: "EventDetailsWebService.asmx/GetScrollListString",
                                                                                          data: "{}",
                                                                                          contentType: "application/json; charset=utf-8",
                                                                                          dataType: "json",
                                                                                          success: function (msg) {
                                                                                              $('#scrollItems').append(msg.d);
                                                                                          },
                                                                                          error: AjaxFailed
                                                                                      });

                                                                                      GetUserHoldingsValue();

                                                                                      $('#btnHoldHolding>a').css("background-position", "0px -" + holdItemPos.toString() + "px");

                                                                                  }

                                                                                  function AjaxSucceeded(result) {
                                                                                      alert(result.d);
                                                                                  }

                                                                                  function AjaxFailed(result) {
                                                                                      $($get('<%=labelLoadingMsg.ClientID%>')).text("Loading...");
                                                                                      $($get('<%=btnCloseLoadingPopup.ClientID%>')).click();
                                                                                      alert(result.status + ' ' + result.statusText);
                                                                                  }

                                                                                  function EventFriendClicked(uniqueID, fullName) {
                                                                                      if (eventFriendUniqueID != 0) {
                                                                                          $('#eventFriend_' + eventFriendUniqueID).css("background", "white");
                                                                                      }
                                                                                      $('#eventFriend_' + uniqueID).css("background", "#DCDCDC");
                                                                                      eventFriendUniqueID = uniqueID;
                                                                                      eventFriendFullName = fullName;
                                                                                  }

                                                                                  function EventFriendMouseOut(uniqueID) {
                                                                                      if (eventFriendUniqueID != uniqueID)
                                                                                          $('#eventFriend_' + uniqueID).css("background", "white");
                                                                                      else
                                                                                          $('#eventFriend_' + uniqueID).css("background", "#DCDCDC");
                                                                                  }

                                                                                  function ItemHoldingsClicked(uniqueID) {
                                                                                      var itemUID = itemInEventUniqueID;

                                                                                      if (itemHoldingsUniqueID != 0) {
                                                                                          $('#itemHoldings_' + itemHoldingsUniqueID).css("background", "white");
                                                                                      }
                                                                                      $('#itemHoldings_' + uniqueID).css("background", "#DCDCDC");

                                                                                      itemHoldingsUniqueID = uniqueID;

                                                                                      $.ajax({
                                                                                          type: "POST",
                                                                                          url: "EventDetailsWebService.asmx/ItemHoldingsStatus",
                                                                                          data: "{'itemUniqueID': '" + itemUID + "','holdingsUniqueID': '" + uniqueID + "'}",
                                                                                          contentType: "application/json; charset=utf-8",
                                                                                          dataType: "json",
                                                                                          success: function (msg) {
                                                                                              if (msg.d == "Owner") {
                                                                                                  holdItemPos = 75;
                                                                                              }
                                                                                              else if (msg.d == "Taken") {
                                                                                                  holdItemPos = 176;
                                                                                              }
                                                                                              else if (msg.d == "Free") {
                                                                                                  holdItemPos = 0;
                                                                                              }
                                                                                              else {
                                                                                                  PopMsgWindow(msg.d);
                                                                                              }
                                                                                              btnHoldItemOut();
                                                                                          },
                                                                                          error: function (msg) {
                                                                                              PopMsgWindow(msg.d);
                                                                                          }
                                                                                      });
                                                                                  }

                                                                                  function ItemHoldingsMouseOut(uniqueID) {
                                                                                      if (itemHoldingsUniqueID != uniqueID)
                                                                                          $('#itemHoldings_' + uniqueID).css("background", "white");
                                                                                      else
                                                                                          $('#itemHoldings_' + uniqueID).css("background", "#DCDCDC");
                                                                                  }

                                                                                  var yesPopup;
                                                                                  function OkMsgPopupClick() {
                                                                                      if (yesPopup == "RmvFriend") {
                                                                                          $.ajax({
                                                                                              type: "POST",
                                                                                              url: "EventDetailsWebService.asmx/RemoveFriendFromEvent",
                                                                                              data: "{'uniqueID': '" + eventFriendUniqueID + "'}",
                                                                                              contentType: "application/json; charset=utf-8",
                                                                                              dataType: "json",
                                                                                              success: function (msg) {
                                                                                                  if (msg.d == "success") {
                                                                                                      $('#eventFriend_' + eventFriendUniqueID).animate({
                                                                                                          height: 'toggle',
                                                                                                          opacity: 0.0
                                                                                                      }, 200, function () {
                                                                                                          $('#eventFriend_' + eventFriendUniqueID).remove();
                                                                                                      });
                                                                                                  }
                                                                                                  else {
                                                                                                      PopMsgWindow(msg.d);
                                                                                                  }
                                                                                              },
                                                                                              error: AjaxFailed
                                                                                          });
                                                                                      }
                                                                                      yesPopup = "";
                                                                                  }

                                                                                  function PopMsgWindow(msg) {
                                                                                      yesPopup = "";
                                                                                      $('#btnOkMsgPopup').val("Ok");
                                                                                      $($get('<%=btnCancelMsgPopup.ClientID%>')).hide();
                                                                                      $($get('<%=labelMsgPopup.ClientID%>')).text(msg);
                                                                                      $($get('<%=btnOpenMsgPopup.ClientID%>')).click();
                                                                                  }

                                                                                  function ReloadMsgWindow() {
                                                                                      PopMsgWindow("Error: Please reload (F5) this page");
                                                                                  }

                                                                                  function PopYesNoWindow(msg) {
                                                                                      $('#btnOkMsgPopup').val("Yes");
                                                                                      $($get('<%=btnCancelMsgPopup.ClientID%>')).show();
                                                                                      $($get('<%=labelMsgPopup.ClientID%>')).text(msg);
                                                                                      $($get('<%=btnOpenMsgPopup.ClientID%>')).click();
                                                                                  }

                                                                                  var gImageIconID;

                                                                                  function ItemInEventMouseOut(uniqueID) {
                                                                                      if (itemInEventUniqueID != uniqueID)
                                                                                          $('#scrollItems>div[id=' + uniqueID + ']').css("background", "white");
                                                                                      else
                                                                                          $('#scrollItems>div[id=' + uniqueID + ']').css("background", "#DCDCDC");
                                                                                  }

                                                                                  function SetItemHoldings(itemUniqueID) {
                                                                                      itemHoldingsUniqueID = 0;

                                                                                      $.ajax({
                                                                                          type: "POST",
                                                                                          url: "EventDetailsWebService.asmx/GetItemHoldings",
                                                                                          data: "{'uniqueID': '" + itemUniqueID + "'}",
                                                                                          contentType: "application/json; charset=utf-8",
                                                                                          dataType: "json",
                                                                                          success: function (msg) {
                                                                                              clearHoldingItems();

                                                                                              if (msg.d != "") {
                                                                                                  if (msg.d.indexOf('div') == -1) {
                                                                                                      PopMsgWindow(msg.d);
                                                                                                  }
                                                                                                  else {
                                                                                                      $('#holdingsUsers').append(msg.d);

                                                                                                      holdItemPos = 151;
                                                                                                      btnHoldItemOut();

                                                                                                      var numOfHoldings = msg.d.split("<span>").length - 1;
                                                                                                      var numOfUserHoldings = numOfHoldings - (msg.d.split("nbsp;Still Needed").length - 1);
                                                                                                      $('#holdingsCount').text(numOfUserHoldings + " out of " + numOfHoldings);

                                                                                                      $('#IHoldings_' + itemUniqueID).text(numOfUserHoldings + "/" + numOfHoldings);

                                                                                                      if (numOfUserHoldings == numOfHoldings) {
                                                                                                          $('#IHoldings_' + itemUniqueID).css("color", "#008000");
                                                                                                      }
                                                                                                      else {
                                                                                                          $('#IHoldings_' + itemUniqueID).css("color", "#E60000");
                                                                                                      }

                                                                                                      $.ajax({
                                                                                                          type: "POST",
                                                                                                          url: "EventDetailsWebService.asmx/GetHoldingColor",
                                                                                                          data: "{'itemUniqueID': '" + itemUniqueID + "'}",
                                                                                                          contentType: "application/json; charset=utf-8",
                                                                                                          dataType: "json",
                                                                                                          success: function (msg) {
                                                                                                              if (msg.d.indexOf('#') == -1) {
                                                                                                                  PopMsgWindow(msg.d);
                                                                                                              }
                                                                                                              else {
                                                                                                                  $('#IName_' + itemUniqueID).css("color", msg.d);
                                                                                                              }
                                                                                                          },
                                                                                                          error: function (msg) {
                                                                                                              PopMsgWindow(msg.d);
                                                                                                          }
                                                                                                      });

                                                                                                  }
                                                                                              }
                                                                                              else {
                                                                                                  $('#IHoldings_' + itemUniqueID).text("0/0");
                                                                                                  $('#holdingsCount').text("0");
                                                                                                  $('#IName_' + itemUniqueID).css("color", "#000000");
                                                                                              }
                                                                                          },
                                                                                          error: function (msg) {
                                                                                              clearHoldingItems();
                                                                                              PopMsgWindow(msg.d);
                                                                                          }

                                                                                      });
                                                                                  }

                                                                                  function AddHoldingClick() {
                                                                                      var itemUID = itemInEventUniqueID;

                                                                                      if (itemUID != 0) {
                                                                                          $.ajax({
                                                                                              type: "POST",
                                                                                              url: "EventDetailsWebService.asmx/AddEmptyItemHolding",
                                                                                              data: "{'uniqueID': '" + itemUID + "'}",
                                                                                              contentType: "application/json; charset=utf-8",
                                                                                              dataType: "json",
                                                                                              success: function (msg) {
                                                                                                  if (msg.d != "") {
                                                                                                      PopMsgWindow(msg.d);
                                                                                                  }
                                                                                              },
                                                                                              error: AjaxFailed
                                                                                          });

                                                                                          GetUserHoldingsValue();

                                                                                          SetItemHoldings(itemUID);
                                                                                      }
                                                                                  }

                                                                                  function RemoveHoldingClick() {
                                                                                      var itemUID = itemInEventUniqueID;
                                                                                      var itemHoldingsUID = itemHoldingsUniqueID;

                                                                                      if (itemHoldingsUID != 0) {
                                                                                          $.ajax({
                                                                                              type: "POST",
                                                                                              url: "EventDetailsWebService.asmx/RemoveItemHolding",
                                                                                              data: "{'itemBaseUniqueID': '" + itemUID +
                                                                                              "','holdingsUniqueID': '" + itemHoldingsUID + "'}",
                                                                                              contentType: "application/json; charset=utf-8",
                                                                                              dataType: "json",
                                                                                              success: function (msg) {
                                                                                                  if (msg.d != "") {
                                                                                                      PopMsgWindow(msg.d);
                                                                                                  }
                                                                                              },
                                                                                              error: AjaxFailed
                                                                                          });

                                                                                          GetUserHoldingsValue();

                                                                                          SetItemHoldings(itemUID);
                                                                                      }
                                                                                  }

                                                                                  function GetUserHoldingsValue() {
                                                                                      var userHoldingsValue = 0;

                                                                                      $.ajax({
                                                                                          type: "POST",
                                                                                          url: "EventDetailsWebService.asmx/GetUserHoldingsValue",
                                                                                          data: "{}",
                                                                                          contentType: "application/json; charset=utf-8",
                                                                                          dataType: "json",
                                                                                          success: function (msg) {
                                                                                              if (msg.d == "reload") {
                                                                                                  ReloadMsgWindow();
                                                                                                  return;
                                                                                              }
                                                                                              userHoldingsValue = msg.d.match(/\d+/);

                                                                                              itemValueOver(userHoldingsValue, 'eventMyTotalValueStar');
                                                                                              itemValueOut(userHoldingsValue, 'eventMyTotalValueStar');

                                                                                              if (userHoldingsValue < gEventTotalValueClicked) {
                                                                                                  var underValue = gEventTotalValueClicked - userHoldingsValue;
                                                                                                  if (underValue == 1)
                                                                                                      $('#valueMsg').text("You need to bring more items - you still need 1 star");
                                                                                                  else
                                                                                                      $('#valueMsg').text("You need to bring more items - you still need " + underValue.toString() + " stars");
                                                                                              }
                                                                                              else if (userHoldingsValue > gEventTotalValueClicked) {
                                                                                                  extraValue = userHoldingsValue - gEventTotalValueClicked;
                                                                                                  if (extraValue == 1)
                                                                                                      $('#valueMsg').text("FYI: You are bringing more then you need (" + extraValue.toString() + " extra star)");
                                                                                                  else
                                                                                                      $('#valueMsg').text("FYI: You are bringing more then you need (" + extraValue.toString() + " extra stars)");
                                                                                              }
                                                                                              else
                                                                                                  $('#valueMsg').text("");
                                                                                          },
                                                                                          error: AjaxFailed
                                                                                      });
                                                                                  }

                                                                                  function UpdateHolding(itemUID) {
                                                                                      btnHoldItemOut();
                                                                                      GetUserHoldingsValue();
                                                                                      SetItemHoldings(itemUID);
                                                                                  }

                                                                                  function HoldHoldingClick() {
                                                                                      var itemUID = itemInEventUniqueID;
                                                                                      var itemHoldingsUID = itemHoldingsUniqueID;

                                                                                      if (itemHoldingsUID != 0) {
                                                                                          $($get('<%=btnOpenLoadingPopup.ClientID%>')).click();
                                                                                          $.ajax({
                                                                                              type: "POST",
                                                                                              url: "EventDetailsWebService.asmx/ItemHoldingsStatus",
                                                                                              data: "{'itemUniqueID': '" + itemUID + "','holdingsUniqueID': '" + itemHoldingsUID + "'}",
                                                                                              contentType: "application/json; charset=utf-8",
                                                                                              dataType: "json",
                                                                                              success: function (msg) {
                                                                                                  if (msg.d == "Owner") {
                                                                                                      $.ajax({
                                                                                                          type: "POST",
                                                                                                          url: "EventDetailsWebService.asmx/UnholdItemHolding",
                                                                                                          data: "{'itemBaseUniqueID': '" + itemUID +
                                                                                                          "','holdingsUniqueID': '" + itemHoldingsUID + "'}",
                                                                                                          contentType: "application/json; charset=utf-8",
                                                                                                          dataType: "json",
                                                                                                          success: function (msg) {
                                                                                                              UpdateHolding(itemUID);
                                                                                                              if (msg.d != "") {
                                                                                                                  PopMsgWindow(msg.d);
                                                                                                              }
                                                                                                          },
                                                                                                          error: function (msg) {
                                                                                                              UpdateHolding(itemUID);
                                                                                                              PopMsgWindow(msg.d);
                                                                                                          }
                                                                                                      });
                                                                                                  }
                                                                                                  else if (msg.d == "Taken") {
                                                                                                  }
                                                                                                  else if (msg.d == "Free") {
                                                                                                      $.ajax({
                                                                                                          type: "POST",
                                                                                                          url: "EventDetailsWebService.asmx/HoldItemHolding",
                                                                                                          data: "{'itemBaseUniqueID': '" + itemUID +
                                                                                                          "','holdingsUniqueID': '" + itemHoldingsUID + "'}",
                                                                                                          contentType: "application/json; charset=utf-8",
                                                                                                          dataType: "json",
                                                                                                          success: function (msg) {
                                                                                                              UpdateHolding(itemUID);
                                                                                                              if (msg.d != "") {
                                                                                                                  PopMsgWindow(msg.d);
                                                                                                              }
                                                                                                          },
                                                                                                          error: function (msg) {
                                                                                                              UpdateHolding(itemUID);
                                                                                                              PopMsgWindow(msg.d);
                                                                                                          }
                                                                                                      });
                                                                                                  }
                                                                                                  else {
                                                                                                      PopMsgWindow(msg.d);
                                                                                                  }

                                                                                                  $($get('<%=btnCloseLoadingPopup.ClientID%>')).click();
                                                                                              },
                                                                                              error: function (msg) {
                                                                                                  $($get('<%=btnCloseLoadingPopup.ClientID%>')).click();
                                                                                                  PopMsgWindow(msg.d);
                                                                                              }
                                                                                          });
                                                                                      }
                                                                                  }

                                                                                  function ItemClicked(itemName, itemIcon, itemUniqueID, value) {
                                                                                      itemNameTmp = itemName;
                                                                                      itemIconTmp = itemIcon;
                                                                                      itemUniqueIDTmp = itemUniqueID;
                                                                                      valueTmp = value;

                                                                                      if (itemInEventUniqueID != 0) {
                                                                                          $('#scrollItems>div[id=' + itemInEventUniqueID + ']').css("background", "white");
                                                                                      }
                                                                                      $('#scrollItems>div[id=' + itemUniqueIDTmp + ']').css("background", "#DCDCDC");
                                                                                      itemInEventUniqueID = itemUniqueIDTmp;

                                                                                      SetItemHoldings(itemInEventUniqueID);
                                                                                  }

                                                                                  function itemValueOver(starNumOver, starsID) {
                                                                                      if (starNumOver > 0)
                                                                                      { $('img[id=' + starsID + '_1]').attr("src", "Icons/StarH.png"); }
                                                                                      if (starNumOver > 1)
                                                                                      { $('img[id=' + starsID + '_2]').attr("src", "Icons/StarH.png"); }
                                                                                      if (starNumOver > 2)
                                                                                      { $('img[id=' + starsID + '_3]').attr("src", "Icons/StarH.png"); }
                                                                                      if (starNumOver > 3)
                                                                                      { $('img[id=' + starsID + '_4]').attr("src", "Icons/StarH.png"); }
                                                                                  }

                                                                                  function itemValueOut(clickedValue, starsID) {
                                                                                      if (clickedValue < 1)
                                                                                      { $('img[id=' + starsID + '_1]').attr("src", "Icons/Star.png"); }
                                                                                      if (clickedValue < 2)
                                                                                      { $('img[id=' + starsID + '_2]').attr("src", "Icons/Star.png"); }
                                                                                      if (clickedValue < 3)
                                                                                      { $('img[id=' + starsID + '_3]').attr("src", "Icons/Star.png"); }
                                                                                      if (clickedValue < 4)
                                                                                      { $('img[id=' + starsID + '_4]').attr("src", "Icons/Star.png"); }
                                                                                  }

                                                                                  function eventTotalValueClicked(starNumOut) {
                                                                                      if (gEventTotalValueClicked == starNumOut)
                                                                                          gEventTotalValueClicked = 0;
                                                                                      else
                                                                                          gEventTotalValueClicked = starNumOut;

                                                                                      itemValueOver(gEventTotalValueClicked, 'eventTotalValueStar');
                                                                                      itemValueOut(gEventTotalValueClicked, 'eventTotalValueStar');
                                                                                  }
            </script>
        </asp:Content>