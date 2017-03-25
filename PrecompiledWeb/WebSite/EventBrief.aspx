<%@ page title="" language="C#" masterpagefile="~/Home/global.master" autoeventwireup="true" inherits="EventBrief, App_Web_ujphj1ma" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="EventBriefContent" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
  <asp:ToolkitScriptManager runat="server" ID="ScriptManager1" />
    <div id="frm-event_brief">
        <div id="headSpacer" class="clearfix">
            <div id="dvTabGeneralHome" class="fl dvTabGeneral" onclick="location.href='EventBrief.aspx';" ><a href="EventBrief.aspx" class="wb18 hlymnu">Home</a></div>
            <div id="dvTabGeneralAbout" class="fl dvTabGeneral" onclick="location.href='About.aspx';"><a href="About.aspx" class="wb18 hlymnu">About</a></div>
            <div id="dvTabGeneralProfile" class="fl dvTabGeneral" onclick="location.href='MyProfile.aspx';"><a href="MyProfile.aspx" class="wb18 hlymnu">Profile</a></div>
            <!-- <div id="dvTabGeneralFriends" class="fl dvTabGeneral" onclick="location.href='EventBrief.aspx';"><a href="EventBrief.aspx" class="wb18 hlymnu">Friends</a></div>-->
        </div>
        <div class="wide top">
            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
            <asp:LinkButton ID="lnkbtnlogout" runat="server" onclick="lnkbtnlogout_Click">logout</asp:LinkButton>
        </div>
        
        <!--- Hidden stuff -->
        <div style="display: none" >
            <img alt="hidden1" src="Icons/Star.png" width="1" height="1" style="opacity:0.4; filter:alpha(opacity=40);" />
            <img alt="hidden2" src="Icons/StarH.png" width="1" height="1" style="opacity:0.4; filter:alpha(opacity=40);" />
        </div>         
        
        
        <asp:Panel ID="PanelEvent" runat="server"  BorderColor="White" BorderStyle="Dotted" BorderWidth="1" Width="800px" Height="424px">
            <div class="fl" style="margin:6px 0px 0px 87px; position:relative;" >
                <p id="btnAddNewEvent" class="addNewEventButton" onclick="btnAddNewEventClicked()" onmouseover="btnAddNewEventOver()" onmousedown="btnAddNewEventDown()" onmouseup="btnAddNewEventOver()" onmouseout="btnAddNewEventOut()" ><a  >Create an Event</a></p>
            </div>
            <div class="clearfix">
                
                <div class="fl" style="margin:6px 0px 0px 20px">
                    <div id="eventsContainer">
	                    <div id="eventsBox" class="boxBorder" >
		                    <div id="eventsItems">
		                    </div>
	                    </div>            
	                </div>	
                </div>
                
                <div class="fl" style="margin:6px 0px 0px 30px; text-align:left;">
                    <div id="eventDetailsContainer">
	                    <div id="eventDetailsBox" class="boxBorder" >
		                    <div id="eventDetailsItems">
		                        <div class="fl EventDetail" >
		                            <div id="eventDetailTopic" class="EventDetail" style="text-align: center; font-size:1.5em; height:32px; padding-top:4px;" ><span></span></div>
		                        </div>
		                        <br />		                    
		                        <div class="fl EventDetail" >
		                            <div class="lEventDetail" >From</div>
		                            <div id="eventDetailFrom" class="rEventDetail" ><span></span></div>
		                        </div>
		                        <br />
		                        <div class="fl EventDetail" >
		                            <div class="lEventDetail" >To</div>
		                            <div id="eventDetailTo" class="rEventDetail" ><span></span></div>
		                        </div>
		                        <br />                    
		                        <div class="fl EventDetail" >
		                            <div class="lEventDetail" >Friends</div>
		                            <div id="eventDetailFriendsCount" class="rEventDetail" ><span></span></div>
		                        </div>
		                        <br />
		                        <div class="fl EventDetail" >
		                            <div class="lEventDetail" >Items</div>
		                            <div id="eventDetailsItemsCount" class="rEventDetail" ><span></span></div>
		                        </div>		                        
		                        <br />
		                        <div class="fl EventDetail" >
		                            <div class="lEventDetail" >Holdings</div>
		                            <div id="eventDetailsHoldingsCount" class="rEventDetail" ><span></span></div>
		                        </div>
		                        <div class="fl EventDetail" >
		                            <div class="lEventDetail" >Location</div>
		                            <div id="eventDetailsLocation" class="rEventDetail" ><span></span></div>
		                        </div>
		                        <div class="fl EventDetail" >
		                            <div class="lEventDetail" >Event ID</div>
		                            <div id="eventDetailsUID" class="rEventDetail" ><span></span></div>
		                        </div>
		                        
		                    </div>
	                    </div>            
	                </div>	
                </div>
                <div class="clearfix fl" style="margin:6px 0px 0px 430px;width:350px;" >
                    <p id="btnDeleteEvent" class="fl deleteEventButton" onclick="btnDeleteEventClicked()" onmouseover="btnDeleteEventOver()" onmousedown="btnDeleteEventDown()" onmouseup="btnDeleteEventOver()" onmouseout="btnDeleteEventOut()" ><a  >Add a new event</a></p>
                    <p id="btnOpenEvent" style="margin-left:30px;" class="fl openEventButton" onclick="btnOpenEventClicked()" onmouseover="btnOpenEventOver()" onmousedown="btnOpenEventDown()" onmouseup="btnOpenEventOver()" onmouseout="btnOpenEventOut()" ><a  >Add a new event</a></p>
                </div>          
            </div>
        </asp:Panel>
        
        <asp:Panel ID="InvitationPanel" runat="server" BorderColor="White" BorderStyle="Dotted" BorderWidth="1" Width="800px" Height="116px">
            <asp:Label CssClass="fl" ID="Label3" runat="server" style="margin: 0px 0pt 3pt 30px"  Text="Events Invitations"></asp:Label>
            <br />
            <div id="invitesContainer" class="clearfix fl">
                <div id="invitesBox" class="boxBorder" >
	                <div id="invitationList" >
	                </div>
                </div>            
            </div>
            <div class="fr" style="margin:0px 290px 0px 0px; text-align: center; width:150px; padding:0px;" >
                <p id="btnAcceptInvite" class="fl acceptInviteButton" style="margin-top:10px;"
                onclick="btnAcceptInviteClicked();" onmouseover="btnAcceptInviteOver()" onmousedown="btnAcceptInviteDown()" onmouseup="btnAcceptInviteOver()" onmouseout="btnAcceptInviteOut()" ><a  >Accept Invite</a></p>
                <p id="btnRejectInvite" class="fl rejectInviteButton" style="margin-top:10px;"
                onclick="btnRejectInviteClicked();" onmouseover="btnRejectInviteOver()" onmousedown="btnRejectInviteDown()" onmouseup="btnRejectInviteOver()" onmouseout="btnRejectInviteOut()" ><a  >Reject Invite</a></p>
            </div>	            
        </asp:Panel>
        
        <!-- Add New Event Popup Panel -->
        <asp:Panel ID="pnlPopNewEvent" runat="server" Style="display: none" CssClass="outerPopup">
            <asp:Panel ID="pnlPopInnerOuter" runat="server" CssClass="innerOuterPopup" >
                <asp:Panel ID="pnlPopInnerInner" runat="server" CssClass="innerInnerPopup" BackColor="#FDF8E3">
                <asp:Panel ID="Panel1" runat="server" Style="margin:20px 20px 20px 20px" BackColor="Transparent">
                
                <div class="clearfix" style="margin:20px 0px 0px 0px">
                    <asp:Label CssClass="w18"  ID="lblTopicEnter" runat="server" Text="Event Topic"></asp:Label>
                    <asp:Panel ID="pnlRoundedTopic" runat="server" BackColor="White" Height="30px" >
                        <asp:TextBox CssClass="w18"  ID="txtboxTopicEnter" runat="server" 
                        BorderColor="Transparent" Width="300px"></asp:TextBox>
                    </asp:Panel>  
                </div>
                <br />
                <div class="clearfix" style="margin:6px 0px 0px 0px">
                    <asp:Label CssClass="w18"  ID="lblDescriptionEnter" runat="server" Text="Event Description"></asp:Label>
                    <asp:Panel ID="pnlRoundedDescription" runat="server" BackColor="White" Height="110px" >
                    <asp:TextBox CssClass="w18"  ID="txtboxDescriptionEnter" runat="server" 
                        BorderColor="Transparent" Rows="5" style="resize:none;" TextMode="MultiLine" 
                        Width="330px" ></asp:TextBox> 
                    </asp:Panel>                     
                </div>
                 <br />
                <div class="fl">
                    <br />Starts:&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox runat="server"  CssClass="w16 dateTimeTextBox calendarTextBox" Width="130" ID="inputRangeStartDate" autocomplete="off" ReadOnly="True"  BackColor="Transparent"  />
                    <asp:CalendarExtender ID="calendarButtonExtenderTextBoxStart" Format="d-MMM-yyyy" runat="server" TargetControlID="inputRangeStartDate" FirstDayOfWeek="Monday" CssClass="calendarTheme" PopupPosition="TopLeft" OnClientDateSelectionChanged="onStartDateSelected" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="inputRangeStartTime"  runat="server" Text="10:00 AM" CssClass="w16 dateTimeTextBox timeTextBox" Width="100"   BackColor="Transparent" onchange="javascript: onStartDateSelected();" ></asp:TextBox>
                </div>
                <div class="fl">
                    <br />Finishes: 
                    <input id="inputRangeFinishDateHidden" type="hidden" runat="server" />
                    <asp:TextBox runat="server"  CssClass="w16 dateTimeTextBox calendarTextBox" Width="130" ID="inputRangeFinishDate" autocomplete="off" ReadOnly="True"  BackColor="Transparent"  />
                    <asp:CalendarExtender ID="calendarButtonExtenderTextBoxFinish" Format="d-MMM-yyyy" runat="server" TargetControlID="inputRangeFinishDate" FirstDayOfWeek="Monday" CssClass="calendarTheme" PopupPosition="TopLeft" OnClientDateSelectionChanged="onFinishDateSelected" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="inputRangeFinishTime"  runat="server" Text="11:00 AM" CssClass="w16 dateTimeTextBox timeTextBox" Width="100"   BackColor="Transparent" ></asp:TextBox>
                </div>
                <br />
                <div class="clearfix">
                    <div class="fl" style="margin-top:20px;">
                        <label >Friends need to bring a value of:</label>
                        </div>
                   <div  class="fr" style="margin:20px 20px 0px 0px;">
                        <img id="eventTotalValueStar_1" alt=" " src="Icons/Star.png" style="margin-left:6px;"
                            onmouseout="itemValueOut(gEventTotalValueClicked, 'eventTotalValueStar');" onmouseover="itemValueOver(1, 'eventTotalValueStar');"
                            onclick="eventTotalValueClicked(1);" />
                        <img id="eventTotalValueStar_2" alt=" " src="Icons/Star.png" style="margin-left:6px;"  
                            onmouseout="itemValueOut(gEventTotalValueClicked, 'eventTotalValueStar');" onmouseover="itemValueOver(2, 'eventTotalValueStar');"
                            onclick="eventTotalValueClicked(2);" />
                        <img id="eventTotalValueStar_3" alt=" " src="Icons/Star.png" style="margin-left:6px;"  
                            onmouseout="itemValueOut(gEventTotalValueClicked, 'eventTotalValueStar');" onmouseover="itemValueOver(3, 'eventTotalValueStar');"
                            onclick="eventTotalValueClicked(3);" />
                        <img id="eventTotalValueStar_4" alt=" " src="Icons/Star.png" style="margin-left:6px;"
                            onmouseout="itemValueOut(gEventTotalValueClicked, 'eventTotalValueStar');" onmouseover="itemValueOver(4, 'eventTotalValueStar');"
                            onclick="eventTotalValueClicked(4);" />	                    
                    </div>
                </div>
                <div class="fl" style="margin-top:20px;">
                    <label >Add event to directory:&nbsp;</label><input type="checkbox" name="eventInDirectory" value="eventInDir" checked="checked" /><br />
                </div>
                </asp:Panel>
                <div class="clearfix">
                    <br />
                    <p style="text-align: center;">
                        <input id="btnAddEvent" value="Add" class="myButton" type="button" onclick="AddEventClick();"/>
                        <input id="btnCancelEvent" value="Cancel" class="myButton" type="button" />
                    </p>
                </div>
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>    
        
        <!-- Delete Popup Panel -->
        <asp:Panel ID="pnlPopDeleteEvent" runat="server" Style="display: none" CssClass="outerPopup">
            <asp:Panel ID="pnlPopDeleteInnerOuter" runat="server" CssClass="innerOuterPopup" >
                <asp:Panel ID="pnlPopDeleteInnerInner" runat="server" CssClass="innerInnerPopup" BackColor="#FDF8E3">
                <asp:Panel ID="Panel5" runat="server" Style="margin:20px 20px 20px 20px" BackColor="Transparent">
                <div class="clearfix" style="margin:20px 0px 0px 0px">
                    <asp:Label CssClass="w18"  ID="lblDeleteMsg" runat="server" Text="Are you sure you want to delete the event "></asp:Label>
                    <br />
                    <asp:Label CssClass="wb20"  ID="lblDeleteMsgTopic" runat="server" Text=""  ></asp:Label>
                </div>
                </asp:Panel>
                <div class="clearfix">
                    <p style="text-align: center;">
                        <input id="btnDeleteYes" value="Yes" class="myButton" type="button" onclick="btnDeleteEventConfirmClicked();"/>
                        <asp:Button ID="btnDeleteCancel" runat="server" Text="Cancel" />
                    </p>
                </div>
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>  
                       
        <!-- Add New Event Panel -->
        <span style="display: none"><asp:Button ID="btnAddNewEventHidden" runat="server" /></span>        
        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
        TargetControlID="btnAddNewEventHidden" PopupControlID="pnlPopNewEvent" 
            CancelControlID="btnCancelEvent" DropShadow="False" 
            BackgroundCssClass="modelBackground">
        </asp:ModalPopupExtender>
        <asp:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" 
            TargetControlID="pnlPopInnerOuter" BorderColor="black" Radius="8" Color="#000000">
        </asp:RoundedCornersExtender>        
        <asp:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" 
            TargetControlID="pnlPopInnerInner" BorderColor="black" Radius="8" >
        </asp:RoundedCornersExtender>
        
        <!-- Delete Panel Extender -->
        <span style="display: none"><asp:Button ID="btnDeleteEventHidden" runat="server" /></span>        
        <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server"
        TargetControlID="btnDeleteEventHidden" PopupControlID="pnlPopDeleteEvent" 
            CancelControlID="btnDeleteCancel" DropShadow="False" 
            BackgroundCssClass="modelBackground">
        </asp:ModalPopupExtender>
        <asp:RoundedCornersExtender ID="RoundedCornersExtender5" runat="server" 
            TargetControlID="pnlPopDeleteInnerOuter" BorderColor="black" Radius="8" Color="#000000">
        </asp:RoundedCornersExtender>        
        <asp:RoundedCornersExtender ID="RoundedCornersExtender6" runat="server" 
            TargetControlID="pnlPopDeleteInnerInner" BorderColor="black" Radius="8" >
        </asp:RoundedCornersExtender>
        
        <asp:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server" 
            TargetControlID="pnlRoundedTopic" BorderColor="black" Radius="6" >
        </asp:RoundedCornersExtender>      
        <asp:RoundedCornersExtender ID="RoundedCornersExtender4" runat="server" 
            TargetControlID="pnlRoundedDescription" BorderColor="black" Radius="6" >
        </asp:RoundedCornersExtender>            
        
    </div>
    <div id="dvCopyRight" class="wb12" >This website and its content is copyright of MyEasyPotluck.com © 2010. All rights reserved.</div>       
    <script  type="text/javascript">
        var anyTimeLoaded = 0;
        var eventSelectedUniqueID = 0;
        var gEventTotalValueClicked = 0;
        var finishDateClicked = 0;
        var invitedEventSelectedUniqueID = 0;
        
        function pageLoad() {
            eventSelectedUniqueID = 0;
            invitedEventSelectedUniqueID = 0;

            $.ajax({
                type: "POST",
                url: "EventBriefWebService.asmx/GetEventsHTMLStr",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    $('#eventsItems').append(msg.d);

                    setTimeout(function() { btnAddNewEventGlow(); }, 2100);
                    setTimeout(function() { btnAddNewEventOut(); }, 2400);
                    setTimeout(function() { btnAddNewEventGlow(); }, 2700);
                    setTimeout(function() { btnAddNewEventOut(); }, 3000);
                    setTimeout(function() { btnAddNewEventGlow(); }, 3300);
                    setTimeout(function() { btnAddNewEventOut(); }, 3600);
                    setTimeout(function() { btnAddNewEventGlow(); }, 3900);
                    setTimeout(function() { btnAddNewEventOut(); }, 4200);                    
                    
                },
                error: AjaxFailed
            });

            $.ajax({
                type: "POST",
                url: "EventBriefWebService.asmx/GetInvitationsHTMLStr",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    $('#invitationList').append(msg.d);
                },
                error: AjaxFailed
            });            
        }

        function EventClicked(uniqueID) {
            if (eventSelectedUniqueID != 0) {
                if (eventSelectedUniqueID != uniqueID) {
                    $('#event_h_' + eventSelectedUniqueID).css("background", "#F0F8FF");

                    if ($('#event_d_' + eventSelectedUniqueID).is(":visible")) {
                        $('#event_d_' + eventSelectedUniqueID).animate({
                            height: 'toggle',
                            opacity: 0.0
                        }, 200, function() {
                            $('#event_d_' + eventSelectedUniqueID).hide();
                        });
                    }
                }
            }

            eventSelectedUniqueID = uniqueID;

            $.ajax({
                type: "POST",
                url: "EventBriefWebService.asmx/SetCurrentEvent",
                data: "{'uniqueID': \"" + eventSelectedUniqueID + "\"}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                },
                error: AjaxFailed
            });              

            if ($('#event_d_' + uniqueID).is(":visible")) {
                $('#event_d_' + uniqueID).animate({
                    height: 'toggle',
                    opacity: 0.0
                }, 200, function() {
                    $('#event_d_' + uniqueID).hide();
                });
            }
            else {
                $('#event_d_' + uniqueID).animate({
                    height: 'toggle',
                    opacity: 1.0
                }, 200, function() {
                    $('#event_d_' + uniqueID).show();
                });
            }          

            $.ajax({
                type: "POST",
                url: "EventBriefWebService.asmx/GetCurrentEventTopic",
                data: "{'uniqueID': \"" + eventSelectedUniqueID + "\"}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    $('#eventDetailTopic>span').text(msg.d);
                    $($get('<%=lblDeleteMsgTopic.ClientID%>')).text("\"" + msg.d + "\"");
                },
                error: AjaxFailed
            });            

            $.ajax({
                type: "POST",
                url: "EventBriefWebService.asmx/GetCurrentEventDetails",
                data: "{'uniqueID': \"" + eventSelectedUniqueID + "\"}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                if (msg.d.indexOf('(#)') != -1) {
                        var eventDetails = msg.d.split("(#)");
                        
                        $('#eventDetailFrom>span').text(eventDetails[0]);
                        $('#eventDetailTo>span').text(eventDetails[1]);
                        $('#eventDetailFriendsCount>span').text(eventDetails[2]);
                        $('#eventDetailsItemsCount>span').text(eventDetails[3]);
                        $('#eventDetailsHoldingsCount>span').text(eventDetails[4]);
                        $('#eventDetailsLocation>span').text(eventDetails[5]);
                        $('#eventDetailsUID>span').text(eventDetails[6]);

                        setTimeout(function() { btnOpenEventGlow(); }, 100);
                        setTimeout(function() { btnOpenEventOut(); }, 400);
                        setTimeout(function() { btnOpenEventGlow(); }, 700);
                        setTimeout(function() { btnOpenEventOut(); }, 1000);
                        setTimeout(function() { btnOpenEventGlow(); }, 1300);
                        setTimeout(function() { btnOpenEventOut(); }, 1600);                         
                    }
                },
                error: AjaxFailed
            });
        }

        function btnAcceptInviteClicked() {
            if (invitedEventSelectedUniqueID != 0) {
                $.ajax({
                    type: "POST",
                    url: "EventBriefWebService.asmx/AcceptInvite",
                    data: "{'uniqueID': \"" + invitedEventSelectedUniqueID + "\"}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        window.location.href = "EventBrief.aspx";
                    },
                    error: AjaxFailed
                });             
            }
        }

        function btnRejectInviteClicked() {
            if (invitedEventSelectedUniqueID != 0) {
                $.ajax({
                    type: "POST",
                    url: "EventBriefWebService.asmx/RejectInvite",
                    data: "{'uniqueID': \"" + invitedEventSelectedUniqueID + "\"}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        window.location.href = "EventBrief.aspx";
                    },
                    error: AjaxFailed
                });
            }
        }
        
        function InvitationClicked(uniqueID) {
            if (invitedEventSelectedUniqueID != 0) {
                if (invitedEventSelectedUniqueID != uniqueID) {
                    $('#invited_' + invitedEventSelectedUniqueID).css("background", "#F0F8FF");
                }
            }

            invitedEventSelectedUniqueID = uniqueID;
        }

        function btnAcceptInviteDown() { $('#btnAcceptInvite>a').css("background-position", "0px -54px"); }
        function btnAcceptInviteOut() { $('#btnAcceptInvite>a').css("background-position", "0px 0px"); }
        function btnAcceptInviteOver() { $('#btnAcceptInvite>a').css("background-position", "0px -27px"); }

        function btnRejectInviteDown() { $('#btnRejectInvite>a').css("background-position", "0px -54px"); }
        function btnRejectInviteOut() { $('#btnRejectInvite>a').css("background-position", "0px 0px"); }
        function btnRejectInviteOver() { $('#btnRejectInvite>a').css("background-position", "0px -27px"); }

        function InvitationMouseOut(uniqueID) {
            if (invitedEventSelectedUniqueID != uniqueID) {
                $('#invited_' + uniqueID).css("background", "#F0F8FF");
            }
            else {
                $('#invited_' + uniqueID).css("background", "#DCDCDC");
            }
        }

        function InvitationMouseOver(uniqueID) {
            $('#invited_' + uniqueID).css("background", "#B0E0E6");
        }
        
        function EventMouseOut(uniqueID) {
            if (eventSelectedUniqueID != uniqueID) {
                $('#event_h_' + uniqueID).css("background", "#F0F8FF");
            }
            else {
                $('#event_h_' + uniqueID).css("background", "#DCDCDC");
                $('#event_d_' + uniqueID).css("background", "#EAEAEA");
            }
        }

        function EventMouseOver(uniqueID) {
            $('#event_h_' + uniqueID).css("background", "#B0E0E6");
            $('#event_d_' + uniqueID).css("background", "#D0ECF0");
        }

        function btnOpenEventDown() { $('#btnOpenEvent>a').css("background-position", "0px -66px"); }
        function btnOpenEventOut() { $('#btnOpenEvent>a').css("background-position", "0px 0px"); }
        function btnOpenEventOver() { $('#btnOpenEvent>a').css("background-position", "0px -34px"); }
        function btnOpenEventGlow() { $('#btnOpenEvent>a').css("background-position", "0px -100px"); }
        function btnOpenEventClicked() {
            if (eventSelectedUniqueID != 0) {
                $.ajax({
                    type: "POST",
                    url: "EventBriefWebService.asmx/SetCurrentEvent",
                    data: "{'uniqueID': \"" + eventSelectedUniqueID + "\"}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        window.location.href = "EventDetails.aspx";
                    },
                    error: AjaxFailed
                });     
            }
        }

        function btnDeleteEventDown() { $('#btnDeleteEvent>a').css("background-position", "0px -66px"); }
        function btnDeleteEventOut() { $('#btnDeleteEvent>a').css("background-position", "0px 0px"); }
        function btnDeleteEventOver() { $('#btnDeleteEvent>a').css("background-position", "0px -34px"); }
        function btnDeleteEventClicked() {
            if (eventSelectedUniqueID != 0) {                
                $($get('<%=btnDeleteEventHidden.ClientID%>')).click();
            }
        }

        function btnDeleteEventConfirmClicked() {
            if (eventSelectedUniqueID != 0) {

                $.ajax({
                    type: "POST",
                    url: "EventBriefWebService.asmx/DeleteEvent",
                    data: "{'uniqueID': \"" + eventSelectedUniqueID + "\"}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        window.location.href = "EventBrief.aspx";
                    },
                    error: AjaxFailed
                });
            }
        }

        function onStartDateSelected() {
            if (finishDateClicked == 1)
                return;
                
            $.ajax({
                type: "POST",
                url: "EventBriefWebService.asmx/GetFinishDate",
                data: "{'startDate': '" + $($get('<%=inputRangeStartDate.ClientID%>')).val() +
                        "','startTime': '" + $($get('<%=inputRangeStartTime.ClientID%>')).val() +
                        "','finishDate': '" + $($get('<%=inputRangeFinishDate.ClientID%>')).val() +
                        "','finishTime': '" + $($get('<%=inputRangeFinishTime.ClientID%>')).val() + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    if (msg.d != "") {
                        var dateTime = msg.d.split("!");
                        var startCalendar = $find('<%=calendarButtonExtenderTextBoxStart.ClientID%>');
                        var selectedDate = startCalendar.get_selectedDate();
                        
                        var finishCalendar = $find('<%=calendarButtonExtenderTextBoxFinish.ClientID%>');
                        finishCalendar.set_selectedDate(selectedDate);
                        
                        $($get('<%=inputRangeFinishTime.ClientID%>')).val(dateTime[1]);
                    }
                },
                error: AjaxFailed
            });        
        }

        function onFinishDateSelected() {
            finishDateClicked = 1;
        }

        function btnAddNewEventDown() { $('#btnAddNewEvent>a').css("background-position", "0px -102px"); }
        function btnAddNewEventOut() { $('#btnAddNewEvent>a').css("background-position", "0px 0px"); }
        function btnAddNewEventOver() { $('#btnAddNewEvent>a').css("background-position", "0px -51px"); }
        function btnAddNewEventGlow() { $('#btnAddNewEvent>a').css("background-position", "0px -151px"); }
        function btnAddNewEventClicked() {
            $($get('<%=btnAddNewEventHidden.ClientID%>')).click();
            loadAnyTime();
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

        function AddEventClick() {
            var topic = $($get('<%=txtboxTopicEnter.ClientID%>')).val().replace(/\"/g, "\\\"").replace(/\'/g, "\\\'");
            var description = $($get('<%=txtboxDescriptionEnter.ClientID%>')).val().replace(/\"/g, "\\\"").replace(/\'/g, "\\\'");
            var value = gEventTotalValueClicked.toString();
            var isPublic = "0";
            
            if($('input[name=eventInDirectory]').attr('checked'))
                isPublic = "1";

            $.ajax({
                type: "POST",
                url: "EventBriefWebService.asmx/CreateNewEvent",
                data: "{'topic': '" + topic +
                        "','description': '" + description +
                        "','startDate': '" + $($get('<%=inputRangeStartDate.ClientID%>')).val() +
                        "','startTime': '" + $($get('<%=inputRangeStartTime.ClientID%>')).val() +
                        "','finishDate': '" + $($get('<%=inputRangeFinishDate.ClientID%>')).val() +
                        "','finishTime': '" + $($get('<%=inputRangeFinishTime.ClientID%>')).val() +
                        "','value': '" + value +
                        "','isPublic': '" + isPublic + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    if (msg.d == "Success")
                        window.location.href = "EventDetails.aspx";
                    else
                        AjaxSucceeded(msg);
                },
                error: AjaxFailed
            });
        }     

        function loadAnyTime() {
            //debugger;
            if (anyTimeLoaded == 0) {
                setTimeout(function() {
                    $($get('<%=inputRangeStartTime.ClientID%>')).AnyTime_picker(
                    {
                        format: "%h:%i %p", labelTitle: "Start Time", labelHour: "Hour", labelMinute: "Minute"
                    });
                    
                    $($get('<%=inputRangeFinishTime.ClientID%>')).AnyTime_picker(
                    {
                        format: "%h:%i %p", labelTitle: "Finish Time", labelHour: "Hour", labelMinute: "Minute"
                    });
                }, 100);
            }
            anyTimeLoaded = 1;
        }

        function AjaxSucceeded(result) {
            alert(result.d);
        }

        function AjaxFailed(result) {
            alert(result.status + ' ' + result.statusText);
        }

        $(document).ready(function() {

            
        })                 
     </script>
</asp:Content>

