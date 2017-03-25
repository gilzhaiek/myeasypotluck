<%@ Page Title="" Language="C#" MasterPageFile="~/Home/global.master" AutoEventWireup="true" CodeFile="EventDetails.aspx.cs" Inherits="EventDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    
<asp:Content ID="EventDetailsContent" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
  <asp:ToolkitScriptManager runat="server" ID="ScriptManager1" />
  <div id="frm-event_details">  
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
            <asp:Panel ID="PanelEventDetail" runat="server" CssClass="detailedPanel fl" Width="372px" Height="390px" style="margin-left:70px" >
                <div class="clearfix" style="margin:0px 0px 0px 20px;">
                    <asp:Label CssClass="clearfix wi10 fl"  ID="lblTopicEnter" runat="server" Text="Topic" style="margin-left:10px;margin-top:10px;"></asp:Label>
                    <br />
                    <asp:TextBox CssClass="clearfix fl w18 boxBorder"  ID="txtboxTopicEnter" runat="server" Width="330px" ></asp:TextBox>
                    
                    <br />
                    <asp:Label CssClass="clearfix fl wi10"  ID="Label1" runat="server" Text="Description" style="margin-left:10px;margin-top:10px;"></asp:Label>
                    
                    <br />
                    <asp:TextBox CssClass="clearfix fl w18 boxBorder"  ID="txtboxDescriptionEnter" runat="server"  Rows="5" TextMode="MultiLine" style="resize:none;" Width="330px" Height="80px"></asp:TextBox> 
                    
                    <br />
                </div>
                <div style="margin:0px 0px 0px 20px;width:350px;" class="clearfix fl">
                    <div style="margin-top:4px;padding-top:4px;">
                        <div class="fl" style="padding-top:4px;">Starts:</div>
                        <div class="fr" style="margin:0px 20px 0px 0px;">
                            <asp:TextBox runat="server"  CssClass="w16 dateTimeTextBox calendarTextBox boxBorder" Width="130" ID="inputRangeStartDate" autocomplete="off" ReadOnly="True"  />
                            <asp:CalendarExtender ID="calendarButtonExtenderTextBoxStart" Format="d-MMM-yyyy" runat="server" TargetControlID="inputRangeStartDate" FirstDayOfWeek="Monday" CssClass="calendarTheme" PopupPosition="TopLeft" />
                            <asp:TextBox ID="inputRangeStartTime"  runat="server" Text="" CssClass="w16 dateTimeTextBox timeTextBox boxBorder" Width="100"    ></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div style="margin-top:4px;padding-top:4px;" >
                        <div class="fl" style="padding-top:4px;">Finishes:</div>
                        <div class="fr" style="margin:0px 20px 0px 0px;">
                            <asp:TextBox runat="server"  CssClass="w16 dateTimeTextBox calendarTextBox boxBorder" Width="130" ID="inputRangeFinishDate" autocomplete="off" ReadOnly="True"  />
                            <asp:CalendarExtender ID="calendarButtonExtenderTextBoxFinish" Format="d-MMM-yyyy" runat="server" TargetControlID="inputRangeFinishDate" FirstDayOfWeek="Monday" CssClass="calendarTheme" PopupPosition="TopLeft"  />
                            <asp:TextBox ID="inputRangeFinishTime"  runat="server" Text="" CssClass="w16 dateTimeTextBox timeTextBox boxBorder" Width="100"  ></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div style="margin-top:4px;padding-top:4px;">
                        <div class="fl" style="padding-top:4px;">Location:</div>
                        <div class="fr" style="margin:0px 20px 0px 0px;">                    
                            <asp:TextBox runat="server" CssClass="w16 boxBorder" Width="236" ID="txtboxLocation" />
                        </div>
                    </div>
                   <div style="margin:4px 0px 0px 0px;" class="clearfix">
                        <div class="fl" style="margin-top:8px;">
	                        <label >Allow friends to add Items: </label>
	                    </div>
	                   <div  class="fl" style="margin:8px 0px 0px 10px;">
                            <p id="btnFriendsAddItems" style="margin:0px 0px 0px 0px;" class="yesNoButton" onmouseover="btnYesNoOver()" onmousedown="btnYesNoDown()" onmouseup="btnYesNoOver()" onmouseout="btnYesNoOut()" onclick="allowAddItemsClicked()"><a  >Friends Add Items Yes No</a></p>
                        </div>
                   </div>
	                                            
                    
                    <div style="margin:4px 0px 0px 0px;" class="clearfix">
                        <div class="fl" style="margin-top:8px;">
	                        <label >Friends need to bring a value of:</label>
	                        </div>
	                   <div  class="fr" style="margin:8px 20px 0px 0px;">
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
                    <br />

                    <div style="margin:4px 0px 0px 0px;" class="clearfix">
                        <div class="fl" style="margin-top:8px;">
	                        <label >The value of the items you bring:</label>
	                    </div>
	                    <div  class="fr" style="margin:8px 20px 0px 0px;">
                            <img id="eventMyTotalValueStar_1" alt=" " src="Icons/Star.png" style="margin-left:6px;" />
                            <img id="eventMyTotalValueStar_2" alt=" " src="Icons/Star.png" style="margin-left:6px;"  />
                            <img id="eventMyTotalValueStar_3" alt=" " src="Icons/Star.png" style="margin-left:6px;"  />
                            <img id="eventMyTotalValueStar_4" alt=" " src="Icons/Star.png" style="margin-left:6px;"  />
                        </div>
                    </div>

                    <div style="margin:0px 0px 0px 0px;" class="clearfix">
                        <div class="fl wib12" style="margin-top:2px;" >
	                        <label id="valueMsg" style="color:#E60000" ></label>
	                    </div>
                    </div>                    
                    <br />        
                    <div style="margin:6px 0px 0px 0px;width:300px" class="clearfix" >            
                        <p id="btnSaveEvent" style="margin:0px 0px 0px 0px;" class="fl saveEventButton" onmouseover="btnSaveEventOver()" onmousedown="btnSaveEventDown()" onmouseup="btnSaveEventOver()" onmouseout="btnSaveEventOut()" ><a  >Save Event</a></p>
                        <p id="btnPublicLink" style="margin:0px 10px 0px 0px;" class="fr publicLinkButton" onmouseover="btnPublicLinkOver()" onmousedown="btnPublicLinkDown()" onmouseup="btnPublicLinkOver()" onmouseout="btnPublicLinkOut()" ><a  >Public Link</a></p>                  
                    </div>
                    <br />
                </div>
            </asp:Panel>
            
            <!-- Friends -->
            <asp:Panel ID="PanelFriendsInvite" runat="server" CssClass="clearfix detailedPanel fl"  Width="372px" Height="141px" style="margin: 400px 0 0 70px" >
                <asp:Label CssClass="fl" ID="Label3" runat="server" style="margin: 6px 0 0 30px"  Text="Friends in this event"></asp:Label>
                <div id="friendsContainer" class="clearfix fl">
	                <div id="friendsBox" class="boxBorder" >
		                <div id="eventFriendsList" >
		                </div>
	                </div>            
	            </div>
                <div class="fl" style="margin:3px 0px 0px 10px; text-align: center; width:370px" >
                    <p id="btnFriendProfile" style="margin:0px;" class="fl friendProfileButton" onclick="btnFriendProfileClicked()" onmouseover="btnFriendProfileOver()" onmousedown="btnFriendProfileDown()" onmouseup="btnFriendProfileOver()" onmouseout="btnFriendProfileOut()" ><a  >Friend Profile</a></p>
                    <p id="btnRemoveFriend" style="margin:0px;" class="fl removeFriendButton" onclick="RemoveFriendClicked();" onmouseover="btnRemoveFriendOver()" onmousedown="btnRemoveFriendDown()" onmouseup="btnRemoveFriendOver()" onmouseout="btnRemoveFriendOut()" ><a  >Remove Friend</a></p>
                    <p id="btnAddFriend" style="margin:0px;" class="fl addFriendButton" onclick="AddFriendClicked();" onmouseover="btnAddFriendOver()" onmousedown="btnAddFriendDown()" onmouseup="btnAddFriendOver()" onmouseout="btnAddFriendOut()" ><a  >Add a Friend</a></p>
                </div>	            
            </asp:Panel>      
            
            <asp:Panel ID="PanelEventItems" runat="server" CssClass="detailedPanel fl" Width="416px" Height="420px" style="margin: 0px 0 0 460px">
                <asp:Label CssClass="fl wi10" ID="LabelItemsInEvent" runat="server" style="margin: 24px 0 0 20px"  Text="Items to bring"></asp:Label>
                <p id="btnCreateCustomItem" style="margin:5px 0px 0px 34px;" class="fl createCustomItemButton" onclick="btnCreateCustomItemClicked()" onmouseover="btnCreateCustomItemOver()" onmousedown="btnCreateCustomItemDown()" onmouseup="btnCreateCustomItemOver()" onmouseout="btnCreateCustomItemOut()" ><a  >Createa a Custom Item</a></p>
                <p id="btnAddMoreItems" style="margin:5px 3px 0px 0px;" class="fr addMoreItemsButton" onclick="btnAddMoreItemsClicked()" onmouseover="btnAddMoreItemsOver()" onmousedown="btnAddMoreItemsDown()" onmouseup="btnAddMoreItemsOver()" onmouseout="btnAddMoreItemsOut()" ><a  >Add more Items</a></p>
                <br />
                <div id="scrollContainer" class="clearfix" >
	                <div id="scrollBox" class="boxBorder" >
		                <div id="scrollItems" >
		                </div>
	                </div>            
	            </div>
	            <div>
	                <label class="fl" id="holdingsLabel" style="margin: 5px 0px 0 10px">Quantity Needed:&nbsp;</label>
	                <label class="fl" id="holdingsCount" style="margin: 5px 0px 0 10px">0</label>
	            </div>
                    <div id="holdingsContainer" class="fl">
	                    <div id="holdingsBox" class="boxBorder" >
		                    <div id="holdingsUsers">
		                    </div>
	                    </div>            
	                </div>
	                <div class="fl" style="margin:5px 0px 0px 14px;width:110px" >
	                    <div>
                            <div>
                                <p id="btnAddHolding" style="margin:0px;" class="fl plusButton " onclick="AddHoldingClick()" onmouseover="btnAddHoldingOver()"  onmousedown="btnAddHoldingDown()" onmouseup="btnAddHoldingOver()" onmouseout="btnAddHoldingOut()" ><a  >+</a></p>
                                <p id="btnDeleteHolding" style="margin:0px;" class="fl minusButton " onclick="RemoveHoldingClick()" onmouseover="btnDeleteHoldingOver()"  onmousedown="btnDeleteHoldingDown()" onmouseup="btnDeleteHoldingOver()" onmouseout="btnDeleteHoldingOut()" ><a  >-</a></p>
	                        </div>
	                        <div class="clearfix">
	                            <p id="btnHoldHolding" style="margin:0px 3px 0px 0px;" class="fr holdItemButton" onclick="HoldHoldingClick()" onmouseover="btnHoldItemOver()" onmousedown="btnHoldItemDown()" onmouseup="btnHoldItemOver()" onmouseout="btnHoldItemOut()" ><a  >I'll Bring It</a></p>
	                        </div>
	                    </div>
	                </div>
	            <div>
	            </div>
            </asp:Panel>
            <asp:Panel ID="PanelEventItemEdit" runat="server" CssClass="clearfix detailedPanel fl" Width="416px" Height="120px" style="margin: 421px 0 0 460px">
                <div id="itemEditContainer">
                    <div>
                        <label class="fl" id="Label2" style="margin: 5px 0px 0 10px">Edit Item</label>                    
                    </div>
	                <div >
	                    <img id="itemEditIcon" alt="Item Icon" src="Icons/a_big_star_24.png" class="clearfix fl"
	                        style="background:white; border:1px dashed; border-color:black; margin:6px 0px 5px 9px; padding:4px"
	                        onclick="NewItemIconClicked('itemEditIcon');" onmouseover="this.style.background='#B0E0E6'" onmouseout="this.style.background='white'"
	                        width="24" height="22" />
	                    <asp:TextBox CssClass="fl w18 boxBorder" MaxLength="22" ID="itemEditName" runat="server" Width="200px" style="margin:6px 0px 5px 10px; font-family:Arial, sans-serif; font-size:1.50em;" />
	                    <label class="fl" style="margin:13px 0px 0px 20px;">Value</label>
	                    <img id="itemEditValueStar_1" alt=" " src="Icons/Star.png" class="fl bigStar" 
	                        onmouseout="itemValueOut(gItemEditValueClicked, 'itemEditValueStar');" onmouseover="itemValueOver(1, 'itemEditValueStar');"
	                        onclick="itemEditValueClicked(1);" />
	                    <img id="itemEditValueStar_2" alt=" " src="Icons/Star.png" class="fl bigStar"  
	                        onmouseout="itemValueOut(gItemEditValueClicked, 'itemEditValueStar');" onmouseover="itemValueOver(2, 'itemEditValueStar');"
	                        onclick="itemEditValueClicked(2);" />
	                    <img id="itemEditValueStar_3" alt=" " src="Icons/Star.png" class="fl bigStar"  
	                        onmouseout="itemValueOut(gItemEditValueClicked, 'itemEditValueStar');" onmouseover="itemValueOver(3, 'itemEditValueStar');"
	                        onclick="itemEditValueClicked(3);" />
	                    <img id="itemEditValueStar_4" alt=" " src="Icons/Star.png" class="fl bigStar"
	                        onmouseout="itemValueOut(gItemEditValueClicked, 'itemEditValueStar');" onmouseover="itemValueOver(4, 'itemEditValueStar');"
	                        onclick="itemEditValueClicked(4);" />	                    
                    </div>
                    <div style="text-align: center;margin:0px 0px 0px 0px; width: 260px;">
                        <p id="btnDeleteItem" style="margin:10px 0px 0px 0px;" class="fl deleteItemButton" onmouseover="btnDeleteItemOver()" onmousedown="btnDeleteItemDown()" onmouseup="btnDeleteItemOver()" onmouseout="btnDeleteItemOut()" ><a  >Delete Item</a></p>
                        <p id="btnSaveItem" style="margin:10px 0px 0px 0px;" class="fr saveItemButton" onmouseover="btnSaveItemOver()" onmousedown="btnSaveItemDown()" onmouseup="btnSaveItemOver()" onmouseout="btnSaveItemOut()" ><a  >Save Item</a></p>
                    </div>
                </div>            
            </asp:Panel>
        </div>
        
        <!-- Add a custom item Popup Panel -->
        <asp:Panel ID="pnlPopCustomItem" runat="server" Style="display: none" CssClass="customItemOuterPopup">
            <asp:Panel ID="pnlPopCustomItemInnerOuter" runat="server" CssClass="customItemInnerOuterPopup" >
                <asp:Panel ID="pnlPopCustomItemInnerInner" runat="server" CssClass="customItemInnerInnerPopup" BackColor="#FDF8E3">
                    <div id="customItemContainer" style="width:400px; margin-top:20px;" >
		                    <div class="fl" style="width:400px;" >
		                        <label class="fl" id="Label7" style="margin: 6px 0px 0 10px">Icon: </label>
		                        <img id="customItemIcon" alt="Item Icon" src="Icons/a_big_star_24.png" class="fr"
		                            style="background:white; border:1px dashed; border-color:black; margin:0px 290px 0px 0px; padding:4px"
		                            onclick="NewItemIconClicked('customItemIcon');" onmouseover="this.style.background='#B0E0E6'" onmouseout="this.style.background='white'"
		                            width="24" height="24" />&nbsp;
		                    </div>
		                    <div class="fl" style="width:400px; margin-top:10px;">
		                        <label class="fl" id="Label8" style="margin: 6px 0px 0 10px">Name: </label>                    
		                        <asp:TextBox CssClass="fr w18 boxBorder" MaxLength="22" ID="customItemName" runat="server" Width="298px" style="margin:0px 24px 0px 0px; font-family:Arial, sans-serif; font-size:1.50em;" />
		                    </div>
		                    <div class="fl" style="width:400px; margin:10px 0px 20px 0px;">
		                        <label class="fl" id="Label9" style="margin: 6px 0px 0 10px">Value: </label>    
		                        <div class="fr" style="margin:-7px 240px 0px 0px;">
		                            <img id="customItemValueStar_1" alt=" " src="Icons/Star.png" class="fl bigStar"
		                                onmouseout="itemValueOut(gCustomItemValueClicked, 'customItemValueStar');" onmouseover="itemValueOver(1, 'customItemValueStar');"
		                                onclick="customItemValueClicked(1);" />
		                            <img id="customItemValueStar_2" alt=" " src="Icons/Star.png" class="fl bigStar"
		                                onmouseout="itemValueOut(gCustomItemValueClicked, 'customItemValueStar');" onmouseover="itemValueOver(2, 'customItemValueStar');"
		                                onclick="customItemValueClicked(2);" />
		                            <img id="customItemValueStar_3" alt=" " src="Icons/Star.png" class="fl bigStar"  
		                                onmouseout="itemValueOut(gCustomItemValueClicked, 'customItemValueStar');" onmouseover="itemValueOver(3, 'customItemValueStar');"
		                                onclick="customItemValueClicked(3);" />
		                            <img id="customItemValueStar_4" alt=" " src="Icons/Star.png" class="fl bigStar"  
		                                onmouseout="itemValueOut(gCustomItemValueClicked, 'customItemValueStar');" onmouseover="itemValueOver(4, 'customItemValueStar');"
		                                onclick="customItemValueClicked(4);" />
		                       </div>
		                    </div>
                    </div>
                    
                <div class="clearfix" >
                    <p style="text-align: center;">
                        <input id="btnAddCustomItem" value="Add" class="myButton" type="button" />
                        <asp:Button ID="btnCancelCustomItem" CssClass="myButton" runat="server" Text="Cancel" />
                    </p>
                </div>
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>
                
        <!-- Add an Item Popup Panel -->
        <asp:Panel ID="pnlPopNewItem" runat="server" Style="display: none" CssClass="newItemOuterPopup">
            <asp:Panel ID="pnlPopNewItemInnerOuter" runat="server" CssClass="newItemInnerOuterPopup" >
                <asp:Panel ID="pnlPopNewItemInnerInner" runat="server" CssClass="newItemInnerInnerPopup" BackColor="#FDF8E3">                   
                    <div id="newItemContainer">
                        <div id="newItemBox" >
                            <div id="newItemItems">
                            </div>
                        </div>            
                    </div>                
                    
                <div class="clearfix">
                    <p style="text-align: center;">
                        <input id="btnAddItem" value="Add" class="myButton" type="button" />
                        <asp:Button ID="btnCancelItem" CssClass="myButton" runat="server" Text="Cancel" />
                    </p>
                </div>
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>
        
        <!-- Icon Popup Panel -->
        <asp:Panel ID="pnlPopIcon" runat="server" Style="display: none" CssClass="iconOuterPopup">
            <asp:Panel ID="pnlPopIconInnerOuter" runat="server" CssClass="iconInnerOuterPopup" >
                <asp:Panel ID="pnlPopIconInnerInner" runat="server" CssClass="iconInnerInnerPopup" BackColor="#FDF8E3">        
                    <div id="iconContainer">
	                    <img id="chooseIcon" alt="wait" src="Icons128/pleasewait.png" class="clearfix"
	                        style="background:white; border:1px dashed; border-color:black; margin:6px 0px 5px 0px; padding:4px"
	                        width="128" height="128" />
                        <br />
	                        
                        <div id="iconBox" >
                            <div id="iconItems">
                            </div>
                        </div>            
                    </div>
                    
                <div class="clearfix">
                    <p style="text-align: center;">
                        <input id="btnChooseIcon" value="Choose" class="myButton" type="button" />
                        <asp:Button ID="btnCancelIcon" CssClass="myButton" runat="server" Text="Cancel" />
                    </p>
                </div>
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>
        
       
        <!-- Add Friend Popup Panel -->
        <asp:Panel ID="pnlPopAddFriend" runat="server" Style="display: none" CssClass="addFriendOuterPopup">
            <asp:Panel ID="pnlPopAddFriendInnerOuter" runat="server" CssClass="addFriendInnerOuterPopup" >
                <asp:Panel ID="pnlPopAddFriendInnerInner" runat="server" CssClass="addFriendInnerInnerPopup" BackColor="#FDF8E3">        
                    <div >
                        <asp:Label CssClass="fl" ID="Label5" runat="server" style="margin: 6px 0 0 30px"  Text="Pending Emails"></asp:Label>
                        <div id="friendInviteContainer" class="fl">                        
                            <div id="friendInviteBox" class="boxBorder">
                                <div id="friendInviteItems">
                                </div>
                            </div>
                        </div>
                        <br />
                        <asp:Label CssClass="fl" ID="Label4" runat="server" style="margin: 6px 0 0 30px"  Text="Create a new Invite (email)"></asp:Label>
                        <br />
                        <asp:TextBox CssClass="fl w18 boxBorder" ID="friendEmailTxtBox" runat="server" Width="240px" style="margin-left:20px; font-family:Arial, sans-serif; font-size:1.50em;" />
                        <input class="myButton fr" id="btnEmailInvite" onclick="emailInviteClicked();" value="Invite" style="margin: 6px 20px 0px 0px" type="button" />
                    </div>
                    
                    <div >
                        <asp:Label CssClass="fl" ID="Label6" runat="server" style="margin: 20px 0 0 30px"  Text="My Friends"></asp:Label>
                        <div id="addFriendContainer" class="fl" >                        
                            <div id="addFriendBox" class="boxBorder">
                                <div id="addFriendItems" >
                                </div>
                            </div>            
                        </div>
                        <p class="clearfix" style="text-align: center;" >
                            <input id="btnChooseAddFriend" value="Select" onclick="myFriendSelect();" class="myButton" style="margin-top: 5px;" type="button" />
                            <asp:Button ID="btnCancelAddFriend" CssClass="myButton" runat="server" style="margin-top: 5px;" Text="Cancel" />
                        </p>                    
                    </div>

                </asp:Panel>
            </asp:Panel>
        </asp:Panel>           
        
     
        <!-- Invite Friend Email Popup Panel -->
        <asp:Panel ID="pnlPopEmailInvite" runat="server" Style="display: none" CssClass="emailInviteOuterPopup">
            <asp:Panel ID="pnlPopEmailInviteInnerOuter" runat="server" CssClass="emailInviteInnerOuterPopup" >
                <asp:Panel ID="pnlPopEmailInviteInnerInner" runat="server" CssClass="emailInviteInnerInnerPopup" BackColor="#FDF8E3">        
					<div>
						<asp:Label CssClass="wb22" style="text-align: center; " ID="Label14" runat="server" Text="Email an Invitation"></asp:Label>
						<br />
					</div>
                    <div >
                        <asp:Label CssClass="fl" ID="Label124" runat="server" style="margin: 6px 0 0 30px"  Text="Subject:"></asp:Label>
                        <br />
                        <asp:TextBox CssClass="clearfix fl w16 boxBorder" ID="emailSubjectTxtBox" Width="380px" runat="server" style="margin-left:20px; font-family:Arial, sans-serif; font-size:1.0em;" />
                        <br />
                    </div>
                    
                    <div >
                        <asp:Label CssClass="clearfix fl" ID="Label16" runat="server" style="margin: 20px 0 0 30px"  Text="Invitation:"></asp:Label>
                        <br />
						<asp:TextBox CssClass="clearfix fl w14 boxBorder"  Width="380px" ID="emailBodyTxtBox" runat="server"  Rows="8" TextMode="MultiLine" style="resize:none;margin: 0px 20px 0 20px;" />
                        <br />
						
                        <p class="clearfix" style="text-align: center;" >
                            <input id="btnSendEmailInvite" value="Send" onclick="emailSendClicked();" class="myButton" style="margin-top: 15px;" type="button" />
                            <asp:Button ID="btnCancelEmailInvite" CssClass="myButton" runat="server" style="margin-top: 15px;" Text="Cancel" />
                        </p>                    
                    </div>

                </asp:Panel>
            </asp:Panel>
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
        
                
        <!-- Message Popup Panel -->
        <asp:Panel ID="pnlLoadingPopup" runat="server" Style="display: none;background-color: transparent; vertical-align: top; padding: 0px 0px 0px 0px;" CssClass="loadingPopup">
            <asp:Label ID="labelLoadingMsg" CssClass="wb24" runat="server" style="text-align: center;"  Text="Loading..." ></asp:Label>
        </asp:Panel>    
        
        <!-- Add a Custom Item -->
        <span style="display: none"><asp:Button ID="btnAddCustomItemHidden" runat="server" /></span>
        <asp:ModalPopupExtender ID="ModalPopupExtender7" runat="server"
        TargetControlID="btnAddCustomItemHidden" PopupControlID="pnlPopCustomItem" 
        OkControlID="btnAddCustomItem" CancelControlID="btnCancelCustomItem" DropShadow="False" 
            BackgroundCssClass="modelBackground">
        </asp:ModalPopupExtender>
        <asp:RoundedCornersExtender ID="RoundedCornersExtender11" runat="server" 
            TargetControlID="pnlPopCustomItemInnerOuter" BorderColor="black" Radius="8" Color="#000000">
        </asp:RoundedCornersExtender>        
        <asp:RoundedCornersExtender ID="RoundedCornersExtender12" runat="server" 
            TargetControlID="pnlPopCustomItemInnerInner" BorderColor="black" Radius="8" >
        </asp:RoundedCornersExtender>                  
                        
        <!-- Add an Item -->
        <span style="display: none"><asp:Button ID="btnAddMoreItemsHidden" runat="server" /></span>
        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
        TargetControlID="btnAddMoreItemsHidden" PopupControlID="pnlPopNewItem" 
        OkControlID="btnAddItem" CancelControlID="btnCancelItem" DropShadow="False" 
            BackgroundCssClass="modelBackground">
        </asp:ModalPopupExtender>
        <asp:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" 
            TargetControlID="pnlPopNewItemInnerOuter" BorderColor="black" Radius="8" Color="#000000">
        </asp:RoundedCornersExtender>        
        <asp:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" 
            TargetControlID="pnlPopNewItemInnerInner" BorderColor="black" Radius="8" >
        </asp:RoundedCornersExtender>
        
        <!-- Add an Icon -->
        <span style="display: none"><asp:Button ID="btnOpenIconPopup" runat="server" /></span>
        <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server"
        TargetControlID="btnOpenIconPopup" PopupControlID="pnlPopIcon" 
        OkControlID="btnChooseIcon" CancelControlID="btnCancelIcon" DropShadow="False" 
            BackgroundCssClass="modelBackground">
        </asp:ModalPopupExtender>
        <asp:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server" 
            TargetControlID="pnlPopIconInnerOuter" BorderColor="black" Radius="8" Color="#000000">
        </asp:RoundedCornersExtender>        
        <asp:RoundedCornersExtender ID="RoundedCornersExtender4" runat="server" 
            TargetControlID="pnlPopIconInnerInner" BorderColor="black" Radius="8" >
        </asp:RoundedCornersExtender>        
        
        <!-- Add a Friend -->
        <span style="display: none"><asp:Button ID="btnOpenAddFriendPopup" runat="server" /></span>        
        <asp:ModalPopupExtender ID="ModalPopupExtender3" runat="server"
        TargetControlID="btnOpenAddFriendPopup" PopupControlID="pnlPopAddFriend" 
        OkControlID="btnChooseAddFriend" CancelControlID="btnCancelAddFriend" DropShadow="False" 
            BackgroundCssClass="modelBackground">
        </asp:ModalPopupExtender>
        <asp:RoundedCornersExtender ID="RoundedCornersExtender5" runat="server" 
            TargetControlID="pnlPopAddFriendInnerOuter" BorderColor="black" Radius="8" Color="#000000">
        </asp:RoundedCornersExtender>        
        <asp:RoundedCornersExtender ID="RoundedCornersExtender6" runat="server" 
            TargetControlID="pnlPopAddFriendInnerInner" BorderColor="black" Radius="8" >
        </asp:RoundedCornersExtender> 
            
		<!-- Friend Email Invite -->
        <span style="display: none"><asp:Button ID="btnOpenEmailInvitePopup" runat="server" /></span>        
        <asp:ModalPopupExtender ID="ModalPopupExtender5" runat="server"
        TargetControlID="btnOpenEmailInvitePopup" PopupControlID="pnlPopEmailInvite" 
        OkControlID="btnSendEmailInvite" CancelControlID="btnCancelEmailInvite" DropShadow="False" 
            BackgroundCssClass="modelBackground">
        </asp:ModalPopupExtender>
        <asp:RoundedCornersExtender ID="RoundedCornersExtender9" runat="server" 
            TargetControlID="pnlPopEmailInviteInnerOuter" BorderColor="black" Radius="8" Color="#000000">
        </asp:RoundedCornersExtender>        
        <asp:RoundedCornersExtender ID="RoundedCornersExtender10" runat="server" 
            TargetControlID="pnlPopEmailInviteInnerInner" BorderColor="black" Radius="8" >
        </asp:RoundedCornersExtender> 
                        
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
        
        <!-- Msg Popup -->
        <span style="display: none"><asp:Button ID="btnOpenLoadingPopup" runat="server" /></span>        
        <span style="display: none"><asp:Button ID="btnCloseLoadingPopup" runat="server" /></span>        
        <asp:ModalPopupExtender ID="ModalPopupExtender6" runat="server"
        TargetControlID="btnOpenLoadingPopup" PopupControlID="pnlLoadingPopup" CancelControlID="btnCloseLoadingPopup" DropShadow="False" 
            BackgroundCssClass="modelBackground">
        </asp:ModalPopupExtender>        
                          
    </div>
        <div id="dvCopyRight" class="wb12" >This website and its content is copyright of MyEasyPotluck.com © 2010. All rights reserved.</div>   
     <script  type="text/javascript">
        var nameIconsLoaded;
        var iconsLoaded;
        var iconPopupLoaded;
        var myFriendUniqueID;
        var eventFriendUniqueID;
        var eventFriendFullName;
        var itemInEventUniqueID;
        var itemHoldingsUniqueID;
        var gCustomItemValueClicked = 0;
        var gItemEditValueClicked;
        var gEventTotalValueClicked = 0;

        function btnFriendProfileDown() { $('#btnFriendProfile>a').css("background-position", "0px -54px"); }
        function btnFriendProfileOut() { $('#btnFriendProfile>a').css("background-position", "0px 0px"); }
        function btnFriendProfileOver() { $('#btnFriendProfile>a').css("background-position", "0px -27px"); }
        function btnFriendProfileClicked() {}

        function btnRemoveFriendDown() { $('#btnRemoveFriend>a').css("background-position", "0px -54px"); }
        function btnRemoveFriendOut() { $('#btnRemoveFriend>a').css("background-position", "0px 0px"); }
        function btnRemoveFriendOver() { $('#btnRemoveFriend>a').css("background-position", "0px -27px"); }

        function btnAddFriendDown() { $('#btnAddFriend>a').css("background-position", "0px -54px"); }
        function btnAddFriendOut() { $('#btnAddFriend>a').css("background-position", "0px 0px"); }
        function btnAddFriendOver() { $('#btnAddFriend>a').css("background-position", "0px -27px"); }

        function btnCreateCustomItemDown() { $('#btnCreateCustomItem>a').css("background-position", "0px -67px"); }
        function btnCreateCustomItemOut() { $('#btnCreateCustomItem>a').css("background-position", "0px 0px"); }
        function btnCreateCustomItemOver() { $('#btnCreateCustomItem>a').css("background-position", "0px -34px"); }
        function btnCreateCustomItemClicked() {
            customItemValueClicked(0);
            $($get('<%=btnAddCustomItemHidden.ClientID%>')).click();
        }

        function btnAddMoreItemsDown() { $('#btnAddMoreItems>a').css("background-position", "0px -67px"); }
        function btnAddMoreItemsOut() { $('#btnAddMoreItems>a').css("background-position", "0px 0px"); }
        function btnAddMoreItemsOver() { $('#btnAddMoreItems>a').css("background-position", "0px -34px"); }
        function btnAddMoreItemsClicked()
        {
            if (nameIconsLoaded == 0) {
                LoadNewIcons();
            }

            $('#newItemItems :checked').each(function() {
                $(this).attr('checked', false);
            });
                    
            $($get('<%=btnAddMoreItemsHidden.ClientID%>')).click();
        }

        function btnAddHoldingDown() { $('#btnAddHolding>a').css("background-position", "0px -66px"); }
        function btnAddHoldingOut() { $('#btnAddHolding>a').css("background-position", "0px 0px"); }
        function btnAddHoldingOver() { $('#btnAddHolding>a').css("background-position", "0px -33px"); }

        function btnDeleteHoldingDown() { $('#btnDeleteHolding>a').css("background-position", "0px -66px"); }
        function btnDeleteHoldingOut() { $('#btnDeleteHolding>a').css("background-position", "0px 0px"); }
        function btnDeleteHoldingOver() { $('#btnDeleteHolding>a').css("background-position", "0px -33px"); }

        function btnSaveEventDown() { $('#btnSaveEvent>a').css("background-position", "0px -66px"); }
        function btnSaveEventOut() { $('#btnSaveEvent>a').css("background-position", "0px 0px"); }
        function btnSaveEventOver() { $('#btnSaveEvent>a').css("background-position", "0px -34px"); }

        function btnPublicLinkDown() { $('#btnPublicLink>a').css("background-position", "0px -66px"); }
        function btnPublicLinkOut() { $('#btnPublicLink>a').css("background-position", "0px 0px"); }
        function btnPublicLinkOver() { $('#btnPublicLink>a').css("background-position", "0px -34px"); }

        

        function btnDeleteItemDown() { $('#btnDeleteItem>a').css("background-position", "0px -66px"); }
        function btnDeleteItemOut() { $('#btnDeleteItem>a').css("background-position", "0px 0px"); }
        function btnDeleteItemOver() { $('#btnDeleteItem>a').css("background-position", "0px -34px"); }

        function btnSaveItemDown() { $('#btnSaveItem>a').css("background-position", "0px -66px"); }
        function btnSaveItemOut() { $('#btnSaveItem>a').css("background-position", "0px 0px"); }
        function btnSaveItemOver() { $('#btnSaveItem>a').css("background-position", "0px -34px"); }

        var allowFriendsAddItems = 1;
        function btnYesNoDown() {
            if(allowFriendsAddItems)
                $('#btnFriendsAddItems>a').css("background-position", "0px -46px");
            else
                $('#btnFriendsAddItems>a').css("background-position", "0px -23px");
        }
        function btnYesNoOut() {
            if (allowFriendsAddItems)
                $('#btnFriendsAddItems>a').css("background-position", "0px 0px");
            else
                $('#btnFriendsAddItems>a').css("background-position", "0px -69px");
        }
        function btnYesNoOver() {
            if (allowFriendsAddItems)
                $('#btnFriendsAddItems>a').css("background-position", "0px -23px");
            else
                $('#btnFriendsAddItems>a').css("background-position", "0px -46px");
        }
        function allowAddItemsClicked() {
            if (allowFriendsAddItems) {
                allowFriendsAddItems = 0;
            }
            else {
                allowFriendsAddItems = 1;
            }

            btnYesNoOver();
        }        

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
                 success: function(msg) {
                     if (msg.d.length != 1) {
                         PopMsgWindow(msg.d);
                     }
                     else {
                         if (msg.d == "1") {eventTotalValueClicked(1);}
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
                 success: function(msg) {
                     $('#eventFriendsList').append(msg.d);
                 },
                 error: AjaxFailed
             });

             $.ajax({
                 type: "POST",
                 url: "EventDetailsWebService.asmx/GetPendingEmailsString",
                 data: "{}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function(msg) {
                    $('#friendInviteItems').append(msg.d);
                 },
                 error: AjaxFailed
             });


             $.ajax({
                 type: "POST",
                 url: "EventDetailsWebService.asmx/GetFriendsString",
                 data: "{}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function(msg) {
                 $('#addFriendItems').append(msg.d);
                 },
                 error: AjaxFailed
             });             
                                     
             
             $.ajax({
                 type: "POST",
                 url: "EventDetailsWebService.asmx/GetScrollListString",
                 data: "{}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function(msg) {
                     $('#scrollItems').append(msg.d);
                     setTimeout(function() {
                         if (nameIconsLoaded == 0) {
                             LoadNewIcons();
                            }
                            
                         if (iconPopupLoaded == 0) {
                             LoadIconPopup();
                            }                            
                     }, 5000);
                 },
                 error: AjaxFailed
             });

             GetUserHoldingsValue();

             $('#btnHoldHolding>a').css("background-position", "0px -" + holdItemPos.toString() + "px");
             
             loadAnyTime();
        }
        
        function loadAnyTime() {
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
        
        function LoadIconPopup()
        {
            $.ajax({
                type: "POST",
                url: "EventDetailsWebService.asmx/PopulateIconPopup",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    if (iconPopupLoaded == 0) {
                        iconPopupLoaded = 1;
                        $('#iconItems').append(msg.d);
                    }
                },
                error: AjaxFailed
            });
        }

        function LoadNewIcons()
        {
            $.ajax({
                type: "POST",
                url: "EventDetailsWebService.asmx/GetNewItemPopupString",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    setTimeout(function() {
                        $('#newItemItems').append(msg.d);
                        nameIconsLoaded = 1;
                    }, 800);
                },
                error: AjaxFailed
            });            
        }              
        
        function AjaxSucceeded(result) {
            alert(result.d);  
        }

        function AjaxFailed(result) {
            $($get('<%=labelLoadingMsg.ClientID%>')).text("Loading...");
            $($get('<%=btnCloseLoadingPopup.ClientID%>')).click();
            alert(result.status + ' ' + result.statusText);
        }

        function emailSendClicked() {
            invitedEmail = $($get('<%=friendEmailTxtBox.ClientID%>')).val();
            emailSubject = $($get('<%=emailSubjectTxtBox.ClientID%>')).val();
            emailSubject = emailSubject.replace(/\"/g, "\\\"");
            emailBody = $($get('<%=emailBodyTxtBox.ClientID%>')).val();
            emailBody = emailBody.replace(/\"/g, "\\\"");

            $($get('<%=labelLoadingMsg.ClientID%>')).text("Sending...");
            
            $($get('<%=btnOpenLoadingPopup.ClientID%>')).click();
            $.ajax({
                type: "POST",
                url: "EventDetailsWebService.asmx/CreateEmailInvite",
                data: "{'email': '" + invitedEmail +
                        "','subject': \"" + emailSubject +
                        "\",'body': \"" + emailBody + "\"}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    $($get('<%=btnCloseLoadingPopup.ClientID%>')).click();
                    $($get('<%=labelLoadingMsg.ClientID%>')).text("Loading...");
                    retStr = msg.d;
                    if (retStr == "User is not Loaded") {
                        window.location.reload();
                    }
                    else {
                        if (retStr.indexOf('div') == -1) {
                            PopMsgWindow(retStr);
                        }
                        else
                        {
                            PopMsgWindow("An email was sent to " + invitedEmail);
                            $('#friendInviteItems').append(msg.d);
                        }
                    }
                },
                error: function(msg) {
                $($get('<%=btnCloseLoadingPopup.ClientID%>')).click();
                $($get('<%=labelLoadingMsg.ClientID%>')).text("Loading...");
                    PopMsgWindow(msg.d);
                }
            });
        }

        function emailInviteClicked() {
            $($get('<%=btnOpenLoadingPopup.ClientID%>')).click();
            
            invitedEmail =  $($get('<%=friendEmailTxtBox.ClientID%>')).val();
            $.ajax({
                type: "POST",
                url: "EventDetailsWebService.asmx/ValidateEmailRegex",
                data: "{'email': '" + invitedEmail + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    if (msg.d == invitedEmail) {
                        $.ajax({
                            type: "POST",
                            url: "EventDetailsWebService.asmx/GetUserFullName",
                            data: "{}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function(msg) {
                                fullName = msg.d;
                                emailSubject = "You are invited to " + $($get('<%=txtboxTopicEnter.ClientID%>')).val() + " potluck party";
                                emailBody = "Hi!\nI am inviting you to a potluck party I am planning.\nIt will be on " +
                                    $($get('<%=inputRangeStartDate.ClientID%>')).val() + " at " +
                                    $($get('<%=inputRangeStartTime.ClientID%>')).val() + "\n\n" +
                                    "Please login or signup here: www.myeasypotluck.com\n\n" +
                                    "Take care\n" + fullName;

                                $($get('<%=emailSubjectTxtBox.ClientID%>')).val(emailSubject);
                                $($get('<%=emailBodyTxtBox.ClientID%>')).val(emailBody);
                                $($get('<%=btnCloseLoadingPopup.ClientID%>')).click();
                                
                                $($get('<%=btnOpenEmailInvitePopup.ClientID%>')).click();
                            },
                            error: function(msg) {
                            $($get('<%=btnCloseLoadingPopup.ClientID%>')).click();
                                PopMsgWindow(msg.d);
                            }
                        });
                    }
                    else {
                        $($get('<%=btnCloseLoadingPopup.ClientID%>')).click();
                        PopMsgWindow(msg.d);
                    }
                },
                error: function(msg) {
                $($get('<%=btnCloseLoadingPopup.ClientID%>')).click();
                    PopMsgWindow(msg.d);
                }
            });
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
        
        function myFriendClicked(uniqueID) {
            if (myFriendUniqueID != 0) {
                $('#myfriend_' + myFriendUniqueID).css("background", "white");
            }
            $('#myfriend_' + uniqueID).css("background", "#DCDCDC");
            myFriendUniqueID = uniqueID;
        }

        function myFriendMouseOut(uniqueID) {
            if (myFriendUniqueID != uniqueID)
                $('#myfriend_' + uniqueID).css("background", "white");
            else
                $('#myfriend_' + uniqueID).css("background", "#DCDCDC");
        }

        function myFriendSelect() {
            if (myFriendUniqueID != 0) {
                $.ajax({
                    type: "POST",
                    url: "EventDetailsWebService.asmx/AddFriendToEvent",
                    data: "{'uniqueID': '" + myFriendUniqueID + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        if (msg.d.indexOf('div') == -1) {
                            PopMsgWindow(msg.d);
                        }
                        else {
                            $('#eventFriendsList').append(msg.d);
                        }
                    },
                    error: AjaxFailed
                });
            }
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
                success: function(msg) {
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
                error: function(msg) {
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
                    success: function(msg) {
                        if (msg.d == "success") {
                            $('#eventFriend_' + eventFriendUniqueID).animate({
                                height: 'toggle',
                                opacity: 0.0
                            }, 200, function() {
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
        function NewItemIconClicked(imgIconID) {
            gImageIconID = imgIconID;
            $($get('<%=btnOpenIconPopup.ClientID%>')).click();

            if (iconPopupLoaded == 0) {
                LoadIconPopup();
            }
        }

        function RemoveFriendClicked() {
            if (eventFriendUniqueID != 0) {
                yesPopup = "RmvFriend";
                PopYesNoWindow("Are you sure you want to remove " + eventFriendFullName);
            }
        }
        
        function AddFriendClicked() {
            $($get('<%=btnOpenAddFriendPopup.ClientID%>')).click();
        }

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
                success: function(msg) {
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
                                success: function(msg) {
                                    if (msg.d.indexOf('#') == -1) {
                                        PopMsgWindow(msg.d);
                                    }
                                    else {
                                        $('#IName_' + itemUniqueID).css("color", msg.d);
                                    }
                                },
                                error: function(msg) {
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
                error: function(msg) {
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
                    success: function(msg) {
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
                    success: function(msg) {
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
                success: function(msg) {
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
                    success: function(msg) {
                        if (msg.d == "Owner") {
                            $.ajax({
                                type: "POST",
                                url: "EventDetailsWebService.asmx/UnholdItemHolding",
                                data: "{'itemBaseUniqueID': '" + itemUID +
                                        "','holdingsUniqueID': '" + itemHoldingsUID + "'}",
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function(msg) {
                                UpdateHolding(itemUID);
                                    if (msg.d != "") {
                                        PopMsgWindow(msg.d);
                                    }
                                },
                                error: function(msg) {
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
                                success: function(msg) {
                                UpdateHolding(itemUID);
                                    if (msg.d != "") {
                                        PopMsgWindow(msg.d);
                                    }
                                },
                                error: function(msg) {
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
                    error: function(msg) {
                        $($get('<%=btnCloseLoadingPopup.ClientID%>')).click();
                        PopMsgWindow(msg.d);
                    }
                });     
            }
        }
        
        function newItemClicked(divName) {
            currentItemClicked = $('#newItemItems>div[id=' + divName + ']>input');
            if (currentItemClicked.is(':checked')) {
                currentItemClicked.attr('checked', false);
                $('#newItemItems>div[id=' + divName + ']>img:eq(0)').attr("src", "Images/global/chkF.png"); 
            }
            else {
                currentItemClicked.attr('checked', true);
                $('#newItemItems>div[id=' + divName + ']>img:eq(0)').attr("src", "Images/global/chkT.png"); 
            }
        }        

        function removeItemName(itemName, itemIcon) {
            $.ajax({
                type: "POST",
                url: "EventDetailsWebService.asmx/RemoveItemEvent",
                data: "{'itemName': '" + itemName +
                            "','iconLocation': '" + itemIcon + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                $('#newItemItems>div[id=__' + itemName + itemIcon + '__]').animate({
                        height: 'toggle',
                        opacity: 0.0
                        }, 200, function() {
                        $('#newItemItems>div[id=__' + itemName + itemIcon + '__]').remove();
                        });
                },
                error: AjaxFailed
            });
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

        function customItemValueClicked(starNumOut) {
            if (gCustomItemValueClicked == starNumOut)
                gCustomItemValueClicked = 0;
            else
                gCustomItemValueClicked = starNumOut;

            itemValueOver(gCustomItemValueClicked, 'customItemValueStar');
            itemValueOut(gCustomItemValueClicked, 'customItemValueStar');                
        }

        function itemEditValueClicked(starNumOut) {
            if (gItemEditValueClicked == starNumOut)
                gItemEditValueClicked = 0;
            else
                gItemEditValueClicked = starNumOut;

            itemValueOver(gItemEditValueClicked, 'itemEditValueStar');
            itemValueOut(gItemEditValueClicked, 'itemEditValueStar');
        }

        function eventTotalValueClicked(starNumOut) {
            if (gEventTotalValueClicked == starNumOut)
                gEventTotalValueClicked = 0;
            else
                gEventTotalValueClicked = starNumOut;

            itemValueOver(gEventTotalValueClicked, 'eventTotalValueStar');
            itemValueOut(gEventTotalValueClicked, 'eventTotalValueStar');

            GetUserHoldingsValue();
        }        

        function updateChooseIcon(largeIcon, iconSelected) {
            $('#chooseIcon').attr("src", largeIcon);
            $('#chooseIcon').attr("alt", iconSelected);
        }

        function addNewItem(itemIcon, itemName, itemValue) {
            if ($('#newItemItems>div[id=__' + itemName + itemIcon + '__]').length == 0) {
                $.ajax({
                    type: "POST",
                    url: "EventDetailsWebService.asmx/AddNewItemTypeEvent",
                    data: "{'itemName': '" + itemName +
                            "','iconLocation': '" + itemIcon +
                            "','value': '" + itemValue + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        $('#newItemItems').prepend(msg.d);
                    },
                    error: AjaxFailed
                });
            }

            $.ajax({
                type: "POST",
                url: "EventDetailsWebService.asmx/AddItemEvent",
                data: "{'itemName': '" + itemName +
                            "','iconLocation': '" + itemIcon +
                            "','itemValue': '" + itemValue + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    $("#scrollBox").animate({ scrollTop: $("#scrollItems").height() }, 400);
                    $('#scrollItems').append(msg.d);
                },
                error: AjaxFailed
            });
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

            $($get('<%=itemEditName.ClientID%>')).val(itemNameTmp);
            $('#itemEditIcon').attr("src", itemIconTmp);
            $('#itemEditIcon').attr("alt", itemUniqueIDTmp);

            gItemEditValueClicked = 0;
            itemEditValueClicked(valueTmp);

            SetItemHoldings(itemInEventUniqueID);
        }

        $(document).ready(function() {
            itemEditValueClicked(0);

            $("#btnSaveEvent").click(function(event) {
                fixedTopic = $($get('<%=txtboxTopicEnter.ClientID%>')).val().replace(/\"/g, "\\\"").replace(/\'/g, "\\\'");
                fixedDescription = $($get('<%=txtboxDescriptionEnter.ClientID%>')).val().replace(/\"/g, "\\\"").replace(/\'/g, "\\\'");
                fixedLocation = $($get('<%=txtboxLocation.ClientID%>')).val().replace(/\"/g, "\\\"").replace(/\'/g, "\\\'");

                $.ajax({
                    type: "POST",
                    url: "EventDetailsWebService.asmx/SaveEventDetails",
                    data: "{'topic': '" + fixedTopic +
                            "','description': '" + fixedDescription +
                            "','startDate': '" + $($get('<%=inputRangeStartDate.ClientID%>')).val() +
                            "','startTime': '" + $($get('<%=inputRangeStartTime.ClientID%>')).val() +
                            "','finishDate': '" + $($get('<%=inputRangeFinishDate.ClientID%>')).val() +
                            "','finishTime': '" + $($get('<%=inputRangeFinishTime.ClientID%>')).val() +
                            "','location': \"" + fixedLocation +
                            "\",'valueNeeded': '" + gEventTotalValueClicked + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        AjaxSucceeded(msg);
                    },
                    error: AjaxFailed
                });
            });

            $("#btnSaveItem").click(function(event) {
                $($get('<%=labelLoadingMsg.ClientID%>')).text("Saving...");
                $($get('<%=btnOpenLoadingPopup.ClientID%>')).click();

                var itemID = $('#itemEditIcon').attr("alt");
                var itemName = $($get('<%=itemEditName.ClientID%>')).val();
                var itemIcon = $('#itemEditIcon').attr("src");
                var itemValue = gItemEditValueClicked;
                $.ajax({
                    type: "POST",
                    url: "EventDetailsWebService.asmx/SaveItemEvent",
                    data: "{'uniqueID': '" + itemID +
                            "','itemName': '" + itemName +
                            "','itemValue': '" + itemValue +
                            "','itemIcon': '" + itemIcon + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        $('#IName_' + itemID).text(" " + itemName);
                        $('#scrollItems>div[id=' + itemID + ']').click(function(event) { ItemClicked(itemName, itemIcon, itemID, itemValue); });

                        $('#scrollItems>div[id=' + itemID + ']>img:eq(0)').attr("alt", itemName);
                        $('#scrollItems>div[id=' + itemID + ']>img:eq(0)').attr("src", itemIcon);

                        $('#scrollItems>div[id=' + itemID + ']>img:eq(1)').attr("alt", " ");
                        $('#scrollItems>div[id=' + itemID + ']>img:eq(1)').attr("src", "Icons/sStars" + itemValue.toString() + ".png");

                        $($get('<%=labelLoadingMsg.ClientID%>')).text("Loading...");
                        $($get('<%=btnCloseLoadingPopup.ClientID%>')).click();

                        GetUserHoldingsValue();
                    },
                    error: AjaxFailed
                });
            });


            $("#btnDeleteItem").click(function(event) {
                var itemID = $('#itemEditIcon').attr("alt");
                var itemIcon = $('#itemEditIcon').attr("src");
                var itemName = $($get('<%=itemEditName.ClientID%>')).val();
                $.ajax({
                    type: "POST",
                    url: "EventDetailsWebService.asmx/DeleteItemEvent",
                    data: "{'uniqueID': '" + itemID +
                            "','itemName': '" + itemName + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        $('#scrollItems>div[id=' + itemID + ']').animate({
                            height: 'toggle',
                            opacity: 0.0
                        }, 200, function() {
                            $('#newItemItems>div[id=' + itemID + ']').remove();

                            $($get('<%=itemEditName.ClientID%>')).val(" ");
                            $('#itemEditIcon').attr("src", "Icons/clearImage.png");
                            $('#itemEditIcon').attr("alt", " ");

                            gItemEditValueClicked = 0;
                            itemEditValueClicked(gItemEditValueClicked);

                            clearHoldingItems();
                            GetUserHoldingsValue();
                        });
                    },
                    error: AjaxFailed
                });
            });

            $("#btnAddItem").click(function(event) {
                $('#newItemItems :checked').each(function() {
                    var itemDetails = $(this).val().split("(#)");
                    addNewItem(itemDetails[1], itemDetails[0], itemDetails[2]);
                    $('#newItemItems>div[id=__' + itemDetails[0] + itemDetails[1] + '__]>img:eq(0)').attr("src", "Images/global/chkF.png");
                    $(this).attr('checked', false);
                });
            });

            $($get('<%=btnCancelItem.ClientID%>')).click(function(event) {
                $('#newItemItems :checked').each(function() {
                    var itemDetails = $(this).val().split("(#)");
                    $('#newItemItems>div[id=__' + itemDetails[0] + itemDetails[1] + '__]>img:eq(0)').attr("src", "Images/global/chkF.png");
                    $(this).attr('checked', false);
                });
            });
            
            
            $("#btnAddCustomItem").click(function(event) {
                var itemName = $($get('<%=customItemName.ClientID%>')).val();
                var itemIcon = $('#customItemIcon').attr("src");
                var itemValue = gCustomItemValueClicked;

                addNewItem(itemIcon, itemName, itemValue);
            });

            $("#btnChooseIcon").click(function(event) {
                var itemIcon = $('#chooseIcon').attr("alt");
                if (itemIcon != "wait") {
                    $('img[id=' + gImageIconID + ']').attr("src", itemIcon);
                }
            });
        });
        
     </script>
</asp:Content>