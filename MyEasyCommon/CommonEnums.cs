using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyEasy.Common
{
	public enum ETitle
	{
		eMr,
		eMrs,
		eMs,
		eDr,
		eProf,
		eTitleNull
	};

    public enum EGender
    {
		eGenderNull,
		[StringValue("Male")]		eMale,
		[StringValue("Female")]		eFemale,
		eGenderSize 
    };

	public enum EResourceType
	{
		eEvent,
		eObject,
		eResourceTypeNull
	}

	public enum EResourcePriority
	{
		eLow		= 2,
		eNormal		= 7,
		eHigh		= 12,
		eHighest	= 15,
		eResourcePriorityNull
	}

    public enum EPrivacyType
    {
        ePrivate = 2,
        eProtected = 5,
        ePublic = 10,
        ePrivacyTypeNull
    }

	public enum EHoldingPermissions
	{
		eParticipator	= 1 << 0,	// Can Hold Items
		eViewer			= 1	<< 1,	// Only Views Items
		eModifier		= 1	<< 2,	// Modifies the Items/Events
		eController		= 1	<< 3,	// Admin
		eHoldingPermissionsNull = 1 << 31
	}

	public enum EHoldingApprovel
	{
		eNotApprovedYet,
		eApproved,
		eNotApproved,
		eHoldingApprovelNull
	}

	public enum EInvitationStatus
	{
		eInvitationPending,
		eInvitationAccepted,
		eInvitationRejected,
		eInvitationNull
	}
}
