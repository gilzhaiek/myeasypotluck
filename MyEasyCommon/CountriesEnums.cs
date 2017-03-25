﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace MyEasy.Common
{
	public enum ECountry
	{
		[StringValue("")]				eCountryNULL,
		[StringValue("Albania")]		eCountryAL,
		[StringValue("Algeria")]		eCountryDZ,
		[StringValue("American Samoa")]	eCountryAS,
		[StringValue("Andorra")]		eCountryAD,
		[StringValue("Angola")]			eCountryAO,
		[StringValue("Anguilla")]		eCountryAI,
		[StringValue("Antarctica")]		eCountryAQ,
		[StringValue("Antigua And Barbuda")]		eCountryAG,
		[StringValue("Argentina")]		eCountryAR,
		[StringValue("Armenia")]		eCountryAM,
		[StringValue("Aruba")]			eCountryAW,
		[StringValue("Australia")]		eCountryAU,
		[StringValue("Austria")]		eCountryAT,
		[StringValue("Azerbaijan")]		eCountryAZ,
		[StringValue("Bahamas")]		eCountryBS,
		[StringValue("Bahrain")]		eCountryBH,
		[StringValue("Bangladesh")]		eCountryBD,
		[StringValue("Barbados")]		eCountryBB,
		[StringValue("Belarus")]		eCountryBY,
		[StringValue("Belgium")]		eCountryBE,
		[StringValue("Belize")]			eCountryBZ,
		[StringValue("Benin")]			eCountryBJ,
		[StringValue("Bermuda")]		eCountryBM,
		[StringValue("Bhutan")]			eCountryBT,
		[StringValue("Bolivia")]		eCountryBO,
		[StringValue("Bosnia And Herzegowina")]		eCountryBA,
		[StringValue("Botswana")]		eCountryBW,
		[StringValue("Bouvet Island")]	eCountryBV,
		[StringValue("Brazil")]			eCountryBR,
		[StringValue("British Indian Ocean Territory")]			eCountryIO,
		[StringValue("Brunei Darussalam")]			eCountryBN,
		[StringValue("Bulgaria")]		eCountryBG,
		[StringValue("Burkina Faso")]	eCountryBF,
		[StringValue("Burundi")]		eCountryBI,
		[StringValue("Cambodia")]		eCountryKH,
		[StringValue("Cameroon")]		eCountryCM,
		[StringValue("Canada")]			eCountryCA,
		[StringValue("Cape Verde")]		eCountryCV,
		[StringValue("Cayman Islands")]	eCountryKY,
		[StringValue("Central African Republic")]	eCountryCF,
		[StringValue("Chad")]			eCountryTD,
		[StringValue("Chile")]			eCountryCL,
		[StringValue("China")]			eCountryCN,
		[StringValue("Christmas Island")]			eCountryCX,
		[StringValue("Cocos (Keeling) Islands")]	eCountryCC,
		[StringValue("Colombia")]		eCountryCO,
		[StringValue("Comoros")]		eCountryKM,
		[StringValue("Congo")]			eCountryCG,
		[StringValue("Cook Islands")]	eCountryCK,
		[StringValue("Costa Rica")]		eCountryCR,
		[StringValue("Cote D'Ivoire")]	eCountryCI,
		[StringValue("Croatia (Hrvatska)")]		eCountryHR,
		[StringValue("Cuba")]			eCountryCU,
		[StringValue("Cyprus")]			eCountryCY,
		[StringValue("Czech Republic")]	eCountryCZ,
		[StringValue("Denmark")]		eCountryDK,
		[StringValue("Djibouti")]		eCountryDJ,
		[StringValue("Dominica")]		eCountryDM,
		[StringValue("Dominican Republic")]		eCountryDO,
		[StringValue("East Timor")]		eCountryTP,
		[StringValue("Ecuador")]		eCountryEC,
		[StringValue("Egypt")]			eCountryEG,
		[StringValue("El Salvador")]	eCountrySV,
		[StringValue("Equatorial Guinea")]		eCountryGQ,
		[StringValue("Eritrea")]		eCountryER,
		[StringValue("Estonia")]		eCountryEE,
		[StringValue("Ethiopia")]		eCountryET,
		[StringValue("Falkland Islands (Malvinas)")]		eCountryFK,
		[StringValue("Faroe Islands")]	eCountryFO,
		[StringValue("Fiji")]			eCountryFJ,
		[StringValue("Finland")]		eCountryFI,
		[StringValue("France")]			eCountryFR,
		[StringValue("French Guiana")]	eCountryGF,
		[StringValue("French Polynesia")]		eCountryPF,
		[StringValue("French Southern Territories")]		eCountryTF,
		[StringValue("Gabon")]			eCountryGA,
		[StringValue("Gambia")]			eCountryGM,
		[StringValue("Georgia")]		eCountryGE,
		[StringValue("Germany")]		eCountryDE,
		[StringValue("Ghana")]			eCountryGH,
		[StringValue("Gibraltar")]		eCountryGI,
		[StringValue("Greece")]			eCountryGR,
		[StringValue("Greenland")]		eCountryGL,
		[StringValue("Grenada")]		eCountryGD,
		[StringValue("Guadeloupe")]		eCountryGP,
		[StringValue("Guam")]			eCountryGU,
		[StringValue("Guatemala")]		eCountryGT,
		[StringValue("Guinea")]			eCountryGN,
		[StringValue("Guinea-Bissau")]	eCountryGW,
		[StringValue("Guyana")]			eCountryGY,
		[StringValue("Haiti")]			eCountryHT,
		[StringValue("Heard And Mc Donald Islands")]		eCountryHM,
		[StringValue("Holy See (Vatican City State)")]		eCountryVA,
		[StringValue("Honduras")]		eCountryHN,
		[StringValue("Hong Kong")]		eCountryHK,
		[StringValue("Hungary")]		eCountryHU,
		[StringValue("Icel And")]		eCountryIS,
		[StringValue("India")]			eCountryIN,
		[StringValue("Indonesia")]		eCountryID,
		[StringValue("Iran (Islamic Republic Of)")]		eCountryIR,
		[StringValue("Iraq")]			eCountryIQ,
		[StringValue("Ireland")]		eCountryIE,
		[StringValue("Israel")]			eCountryIL,
		[StringValue("Italy")]			eCountryIT,
		[StringValue("Jamaica")]		eCountryJM,
		[StringValue("Japan")]			eCountryJP,
		[StringValue("Jordan")]			eCountryJO,
		[StringValue("Kazakhstan")]		eCountryKZ,
		[StringValue("Kenya")]			eCountryKE,
		[StringValue("Kiribati")]		eCountryKI,
		[StringValue("Korea, Dem People'S Republic")]		eCountryKP,
		[StringValue("Korea, Republic Of")]		eCountryKR,
		[StringValue("Kuwait")]			eCountryKW,
		[StringValue("Kyrgyzstan")]		eCountryKG,
		[StringValue("Lao People'S Dem Republic")]		eCountryLA,
		[StringValue("Latvia")]			eCountryLV,
		[StringValue("Lebanon")]		eCountryLB,
		[StringValue("Lesotho")]		eCountryLS,
		[StringValue("Liberia")]		eCountryLR,
		[StringValue("Libyan Arab Jamahiriya")]		eCountryLY,
		[StringValue("Liechtenstein")]	eCountryLI,
		[StringValue("Lithuania")]		eCountryLT,
		[StringValue("Luxembourg")]		eCountryLU,
		[StringValue("Macau")]			eCountryMO,
		[StringValue("Macedonia")]		eCountryMK,
		[StringValue("Madagascar")]		eCountryMG,
		[StringValue("Malawi")]			eCountryMW,
		[StringValue("Malaysia")]		eCountryMY,
		[StringValue("Maldives")]		eCountryMV,
		[StringValue("Mali")]			eCountryML,
		[StringValue("Malta")]			eCountryMT,
		[StringValue("Marshall Islands")]		eCountryMH,
		[StringValue("Martinique")]		eCountryMQ,
		[StringValue("Mauritania")]		eCountryMR,
		[StringValue("Mauritius")]		eCountryMU,
		[StringValue("Mayotte")]		eCountryYT,
		[StringValue("Mexico")]			eCountryMX,
		[StringValue("Micronesia, Federated States")]		eCountryFM,
		[StringValue("Moldova, Republic Of")]		eCountryMD,
		[StringValue("Monaco")]			eCountryMC,
		[StringValue("Mongolia")]		eCountryMN,
		[StringValue("Montserrat")]		eCountryMS,
		[StringValue("Morocco")]		eCountryMA,
		[StringValue("Mozambique")]		eCountryMZ,
		[StringValue("Myanmar")]		eCountryMM,
		[StringValue("Namibia")]		eCountryNA,
		[StringValue("Nauru")]			eCountryNR,
		[StringValue("Nepal")]			eCountryNP,
		[StringValue("Netherlands")]	eCountryNL,
		[StringValue("Netherlands Ant Illes")]		eCountryAN,
		[StringValue("New Caledonia")]	eCountryNC,
		[StringValue("New Zealand")]	eCountryNZ,
		[StringValue("Nicaragua")]		eCountryNI,
		[StringValue("Niger")]			eCountryNE,
		[StringValue("Nigeria")]		eCountryNG,
		[StringValue("Niue")]			eCountryNU,
		[StringValue("Norfolk Island")]		eCountryNF,
		[StringValue("Northern Mariana Islands")]		eCountryMP,
		[StringValue("Norway")]			eCountryNO,
		[StringValue("Oman")]			eCountryOM,
		[StringValue("Pakistan")]		eCountryPK,
		[StringValue("Palau")]			eCountryPW,
		[StringValue("Panama")]			eCountryPA,
		[StringValue("Papua New Guinea")]		eCountryPG,
		[StringValue("Paraguay")]		eCountryPY,
		[StringValue("Peru")]			eCountryPE,
		[StringValue("Philippines")]	eCountryPH,
		[StringValue("Pitcairn")]		eCountryPN,
		[StringValue("Poland")]			eCountryPL,
		[StringValue("Portugal")]		eCountryPT,
		[StringValue("Puerto Rico")]	eCountryPR,
		[StringValue("Qatar")]			eCountryQA,
		[StringValue("Reunion")]		eCountryRE,
		[StringValue("Romania")]		eCountryRO,
		[StringValue("Russian Federation")]		eCountryRU,
		[StringValue("Rwanda")]			eCountryRW,
		[StringValue("Saint Kitts And Nevis")]		eCountryKN,
		[StringValue("Saint Lucia")]	eCountryLC,
		[StringValue("Saint Vincent, The Grenadines")]		eCountryVC,
		[StringValue("Samoa")]			eCountryWS,
		[StringValue("San Marino")]		eCountrySM,
		[StringValue("Sao Tome And Principe")]		eCountryST,
		[StringValue("Saudi Arabia")]	eCountrySA,
		[StringValue("Senegal")]		eCountrySN,
		[StringValue("Seychelles")]		eCountrySC,
		[StringValue("Sierra Leone")]	eCountrySL,
		[StringValue("Singapore")]		eCountrySG,
		[StringValue("Slovakia (Slovak Republic)")]	eCountrySK,
		[StringValue("Slovenia")]		eCountrySI,
		[StringValue("Solomon Islands")]			eCountrySB,
		[StringValue("Somalia")]		eCountrySO,
		[StringValue("South Africa")]	eCountryZA,
		[StringValue("South Georgia , S Sandwich Is.")]		eCountryGS,
		[StringValue("Spain")]			eCountryES,
		[StringValue("Sri Lanka")]		eCountryLK,
		[StringValue("St. Helena")]		eCountrySH,
		[StringValue("St. Pierre And Miquelon")]	eCountryPM,
		[StringValue("Sudan")]			eCountrySD,
		[StringValue("Suriname")]		eCountrySR,
		[StringValue("Svalbard, Jan Mayen Islands")]		eCountrySJ,
		[StringValue("Swaziland")]		eCountrySZ,
		[StringValue("Sweden")]			eCountrySE,
		[StringValue("Switzerland")]	eCountryCH,
		[StringValue("Syrian Arab Republic")]		eCountrySY,
		[StringValue("Taiwan")]			eCountryTW,
		[StringValue("Tajikistan")]		eCountryTJ,
		[StringValue("Tanzania, United Republic Of")]		eCountryTZ,
		[StringValue("Thailand")]		eCountryTH,
		[StringValue("Togo")]			eCountryTG,
		[StringValue("Tokelau")]		eCountryTK,
		[StringValue("Tonga")]			eCountryTO,
		[StringValue("Trinidad And Tobago")]		eCountryTT,
		[StringValue("Tunisia")]		eCountryTN,
		[StringValue("Turkey")]			eCountryTR,
		[StringValue("Turkmenistan")]	eCountryTM,
		[StringValue("Turks And Caicos Islands")]	eCountryTC,
		[StringValue("Tuvalu")]			eCountryTV,
		[StringValue("Uganda")]			eCountryUG,
		[StringValue("Ukraine")]		eCountryUA,
		[StringValue("United Arab Emirates")]		eCountryAE,
		[StringValue("United Kingdom")]	eCountryGB,
		[StringValue("United States")]	eCountryUS,
		[StringValue("United States Minor Is.")]	eCountryUM,
		[StringValue("Uruguay")]		eCountryUY,
		[StringValue("Uzbekistan")]		eCountryUZ,
		[StringValue("Vanuatu")]		eCountryVU,
		[StringValue("Venezuela")]		eCountryVE,
		[StringValue("Vietnam")]		eCountryVN,
		[StringValue("Virgin Islands (British)")]	eCountryVG,
		[StringValue("Virgin Islands (U.S.)")]		eCountryVI,
		[StringValue("Wallis And Futuna Islands")]	eCountryWF,
		[StringValue("Western Sahara")]	eCountryEH,
		[StringValue("Yemen")]			eCountryYE,
		[StringValue("Yugoslavia")]		eCountryYU,
		[StringValue("Zaire")]			eCountryZR,
		[StringValue("Zambia")]			eCountryZM,
		[StringValue("Zimbabwe")]		eCountryZW,
		eCountrySize
	}

	public static class CountriesEnums
	{
		public static Collection<String> GetCountriesStrings()
		{
			Collection<String> retCollectionStr = new Collection<string>();

			for(int i = 1; i < (int)ECountry.eCountrySize; i++)
			{
				retCollectionStr.Add(StringValueClass.GetStringValue((ECountry)i));
			}

			return retCollectionStr;
		}

	}
}