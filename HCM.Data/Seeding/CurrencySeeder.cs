namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data.Models;

    class CurrencySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Currencies.Any())
            {
                return;
            }

            var currencies = new List<Currency>
            {
        new Currency
        {
                Description = "United Arab Emirates Dirham",
                Abbreviation = "AED",
        },
        new Currency
        {
                Description = " Afghanistan Afghani",
                Abbreviation = "AFN",
        },
        new Currency
        {
                Description = "Albania Lek",
                Abbreviation = "ALL",
        },
        new Currency
        {
                Description = "Armenia Dram",
                Abbreviation = "AMD",
        },
        new Currency
        {
                Description = "Netherlands Antilles Guilder",
                Abbreviation = "ANG",
        },
        new Currency
        {
                Description = "Angola Kwanza",
                Abbreviation = "AOA",
        },
        new Currency
        {
                Description = "Argentina Peso",
                Abbreviation = "ARS",
        },
        new Currency
        {
                Description = "Australia Dollar",
                Abbreviation = "AUD",
        },
        new Currency
        {
                Description = "Aruba Guilder",
                Abbreviation = "AWG",
        },
        new Currency
        {
                Description = "Azerbaijan New Manat",
                Abbreviation = "AZN",
        },
        new Currency
        {
                Description = "Bosnia and Herzegovina Convertible Marka",
                Abbreviation = "BAM",
        },
        new Currency
        {
                Description = "Barbados Dollar",
                Abbreviation = "BBD",
        },
        new Currency
        {
                Description = "Bangladesh Taka",
                Abbreviation = "BDT",
        },
        new Currency
        {
                Description = "Bulgaria Lev",
                Abbreviation = "BGN",
        },
        new Currency
        {
                Description = "Bahrain Dinar",
                Abbreviation = "BHD",
        },
        new Currency
        {
                Description = "Burundi Franc",
                Abbreviation = "BIF",
        },
        new Currency
        {
                Description = "Bermuda Dollar",
                Abbreviation = "BMD",
        },
        new Currency
        {
                Description = "Brunei Darussalam Dollar",
                Abbreviation = "BND",
        },
        new Currency
        {
                Description = "Bolivia Boliviano",
                Abbreviation = "BOB",
        },
        new Currency
        {
                Description = "Brazil Real",
                Abbreviation = "BRL",
        },
        new Currency
        {
                Description = "Bahamas Dollar",
                Abbreviation = "BSD",
        },
        new Currency
        {
                Description = "Bhutan Ngultrum",
                Abbreviation = "BTN",
        },
        new Currency
        {
                Description = "Botswana Pula",
                Abbreviation = "BWP",
        },
        new Currency
        {
                Description = "Belarus Ruble",
                Abbreviation = "BYR",
        },
        new Currency
        {
                Description = "Belize Dollar",
                Abbreviation = "BZD",
        },
        new Currency
        {
                Description = "Canada Dollar",
                Abbreviation = "CAD",
        },
        new Currency
        {
                Description = "Congo/Kinshasa Franc",
                Abbreviation = "CDF",
        },
        new Currency
        {
                Description = "Switzerland Franc",
                Abbreviation = "CHF",
        },
        new Currency
        {
                Description = "Chile Peso",
                Abbreviation = "CLP",
        },
        new Currency
        {
                Description = "China Yuan Renminbi",
                Abbreviation = "CNY",
        },
        new Currency
        {
                Description = "Colombia Peso",
                Abbreviation = "COP",
        },
        new Currency
        {
                Description = "Costa Rica Colon",
                Abbreviation = "CRC",
        },
        new Currency
        {
                Description = "Cuba Convertible Peso",
                Abbreviation = "CUC",
        },
        new Currency
        {
                Description = "Cuba Peso",
                Abbreviation = "CUP",
        },
        new Currency
        {
                Description = "Cape Verde Escudo",
                Abbreviation = "CVE",
        },
        new Currency
        {
                Description = "Czech Republic Koruna",
                Abbreviation = "CZK",
        },
        new Currency
        {
                Description = "Djibouti Franc",
                Abbreviation = "DJF",
        },
        new Currency
        {
                Description = "Denmark Krone",
                Abbreviation = "DKK",
        },
        new Currency
        {
                Description = "Dominican Republic Peso",
                Abbreviation = "DOP",
        },
        new Currency
        {
                Description = "Algeria Dinar",
                Abbreviation = "DZD",
        },
        new Currency
        {
                Description = "Egypt Pound",
                Abbreviation = "EGP",
        },
        new Currency
        {
                Description = "Eritrea Nakfa",
                Abbreviation = "ERN",
        },
        new Currency
        {
                Description = "Ethiopia Birr",
                Abbreviation = "ETB",
        },
        new Currency
        {
                Description = "Euro Member Countries",
                Abbreviation = "EUR",
        },
        new Currency
        {
                Description = "Fiji Dollar",
                Abbreviation = "FJD",
        },
        new Currency
        {
                Description = "Falkland Islands (Malvinas) Pound",
                Abbreviation = "FKP",
        },
        new Currency
        {
                Description = "United Kingdom Pound",
                Abbreviation = "GBP",
        },
        new Currency
        {
                Description = "Georgia Lari",
                Abbreviation = "GEL",
        },
        new Currency
        {
                Description = "Guernsey Pound",
                Abbreviation = "GGP",
        },
        new Currency
        {
                Description = "Ghana Cedi",
                Abbreviation = "GHS",
        },
        new Currency
        {
                Description = "Gibraltar Pound",
                Abbreviation = "GIP",
        },
        new Currency
        {
                Description = "Gambia Dalasi",
                Abbreviation = "GMD",
        },
        new Currency
        {
                Description = "Guinea Franc",
                Abbreviation = "GNF",
        },
        new Currency
        {
                Description = "Guatemala Quetzal",
                Abbreviation = "GTQ",
        },
        new Currency
        {
                Description = "Guyana Dollar",
                Abbreviation = "GYD",
        },
        new Currency
        {
                Description = "Hong Kong Dollar",
                Abbreviation = "HKD",
        },
        new Currency
        {
                Description = "Honduras Lempira",
                Abbreviation = "HNL",
        },
        new Currency
        {
                Description = "Croatia Kuna",
                Abbreviation = "HRK",
        },
        new Currency
        {
                Description = "Haiti Gourde",
                Abbreviation = "HTG",
        },
        new Currency
        {
                Description = "Hungary Forint",
                Abbreviation = "HUF",
        },
        new Currency
        {
                Description = "Indonesia Rupiah",
                Abbreviation = "IDR",
        },
        new Currency
        {
                Description = "Israel Shekel",
                Abbreviation = "ILS",
        },
        new Currency
        {
                Description = "Isle of Man Pound",
                Abbreviation = "IMP",
        },
        new Currency
        {
                Description = "India Rupee",
                Abbreviation = "INR",
        },
        new Currency
        {
                Description = "Iraq Dinar",
                Abbreviation = "IQD",
        },
        new Currency
        {
                Description = "Iran Rial",
                Abbreviation = "IRR",
        },
        new Currency
        {
                Description = "Iceland Krona",
                Abbreviation = "ISK",
        },
        new Currency
        {
                Description = "Jersey Pound",
                Abbreviation = "JEP",
        },
        new Currency
        {
                Description = "Jamaica Dollar",
                Abbreviation = "JMD",
        },
        new Currency
        {
                Description = "Jordan Dinar",
                Abbreviation = "JOD",
        },
        new Currency
        {
                Description = "Japan Yen",
                Abbreviation = "JPY",
        },
        new Currency
        {
                Description = "Kenya Shilling",
                Abbreviation = "KES",
        },
        new Currency
        {
                Description = "Kyrgyzstan Som",
                Abbreviation = "KGS",
        },
        new Currency
        {
                Description = "Cambodia Riel",
                Abbreviation = "KHR",
        },
        new Currency
        {
                Description = "Comoros Franc",
                Abbreviation = "KMF",
        },
        new Currency
        {
                Description = "Korea (North) Won",
                Abbreviation = "KPW",
        },
        new Currency
        {
                Description = "Korea (South) Won",
                Abbreviation = "KRW",
        },
        new Currency
        {
                Description = "Kuwait Dinar",
                Abbreviation = "KWD",
        },
        new Currency
        {
                Description = "Cayman Islands Dollar",
                Abbreviation = "KYD",
        },
        new Currency
        {
                Description = "Kazakhstan Tenge",
                Abbreviation = "KZT",
        },
        new Currency
        {
                Description = "Laos Kip",
                Abbreviation = "LAK",
        },
        new Currency
        {
                Description = "Lebanon Pound",
                Abbreviation = "LBP",
        },
        new Currency
        {
                Description = "Sri Lanka Rupee",
                Abbreviation = "LKR",
        },
        new Currency
        {
                Description = "Liberia Dollar",
                Abbreviation = "LRD",
        },
        new Currency
        {
                Description = "Lesotho Loti",
                Abbreviation = "LSL",
        },
        new Currency
        {
                Description = "Libya Dinar",
                Abbreviation = "LYD",
        },
        new Currency
        {
                Description = "Morocco Dirham",
                Abbreviation = "MAD",
        },
        new Currency
        {
                Description = "Moldova Leu",
                Abbreviation = "MDL",
        },
        new Currency
        {
                Description = "Madagascar Ariary",
                Abbreviation = "MGA",
        },
        new Currency
        {
                Description = "Macedonia Denar",
                Abbreviation = "MKD",
        },
        new Currency
        {
                Description = "Myanmar (Burma) Kyat",
                Abbreviation = "MMK",
        },
        new Currency
        {
                Description = "Mongolia Tughrik",
                Abbreviation = "MNT",
        },
        new Currency
        {
                Description = "Macau Pataca",
                Abbreviation = "MOP",
        },
        new Currency
        {
                Description = "Mauritania Ouguiya",
                Abbreviation = "MRO",
        },
        new Currency
        {
                Description = "Mauritius Rupee",
                Abbreviation = "MUR",
        },
        new Currency
        {
                Description = "Maldives (Maldive Islands) Rufiyaa",
                Abbreviation = "MVR",
        },
        new Currency
        {
                Description = "Malawi Kwacha",
                Abbreviation = "MWK",
        },
        new Currency
        {
                Description = "Mexico Peso",
                Abbreviation = "MXN",
        },
        new Currency
        {
                Description = "Malaysia Ringgit",
                Abbreviation = "MYR",
        },
        new Currency
        {
                Description = "Mozambique Metical",
                Abbreviation = "MZN",
        },
        new Currency
        {
                Description = "Namibia Dollar",
                Abbreviation = "NAD",
        },
        new Currency
        {
                Description = "Nigeria Naira",
                Abbreviation = "NGN",
        },
        new Currency
        {
                Description = "Nicaragua Cordoba",
                Abbreviation = "NIO",
        },
        new Currency
        {
                Description = "Norway Krone",
                Abbreviation = "NOK",
        },
        new Currency
        {
                Description = "Nepal Rupee",
                Abbreviation = "NPR",
        },
        new Currency
        {
                Description = "New Zealand Dollar",
                Abbreviation = "NZD",
        },
        new Currency
        {
                Description = "Oman Rial",
                Abbreviation = "OMR",
        },
        new Currency
        {
                Description = "Panama Balboa",
                Abbreviation = "PAB",
        },
        new Currency
        {
                Description = "Peru Nuevo Sol",
                Abbreviation = "PEN",
        },
        new Currency
        {
                Description = "Papua New Guinea Kina",
                Abbreviation = "PGK",
        },
        new Currency
        {
                Description = "Philippines Peso",
                Abbreviation = "PHP",
        },
        new Currency
        {
                Description = "Pakistan Rupee",
                Abbreviation = "PKR",
        },
        new Currency
        {
                Description = "Poland Zloty",
                Abbreviation = "PLN",
        },
        new Currency
        {
                Description = "Paraguay Guarani",
                Abbreviation = "PYG",
        },
        new Currency
        {
                Description = "Qatar Riyal",
                Abbreviation = "QAR",
        },
        new Currency
        {
                Description = "Romania New Leu",
                Abbreviation = "RON",
        },
        new Currency
        {
                Description = "Serbia Dinar",
                Abbreviation = "RSD",
        },
        new Currency
        {
                Description = "Russia Ruble",
                Abbreviation = "RUB",
        },
        new Currency
        {
                Description = "Rwanda Franc",
                Abbreviation = "RWF",
        },
        new Currency
        {
                Description = "Saudi Arabia Riyal",
                Abbreviation = "SAR",
        },
        new Currency
        {
                Description = "Solomon Islands Dollar",
                Abbreviation = "SBD",
        },
        new Currency
        {
                Description = "Seychelles Rupee",
                Abbreviation = "SCR",
        },
        new Currency
        {
                Description = "Sudan Pound",
                Abbreviation = "SDG",
        },
        new Currency
        {
                Description = "Sweden Krona",
                Abbreviation = "SEK",
        },
        new Currency
        {
                Description = "Singapore Dollar",
                Abbreviation = "SGD",
        },
        new Currency
        {
                Description = "Saint Helena Pound",
                Abbreviation = "SHP",
        },
        new Currency
        {
                Description = "Sierra Leone Leone",
                Abbreviation = "SLL",
        },
        new Currency
        {
                Description = "Somalia Shilling",
                Abbreviation = "SOS",
        },
        new Currency
        {
                Description = "Seborga Luigino",
                Abbreviation = "SPL",
        },
        new Currency
        {
                Description = "Suriname Dollar",
                Abbreviation = "SRD",
        },
        new Currency
        {
                Description = "São Tomé and Príncipe Dobra",
                Abbreviation = "STD",
        },
        new Currency
        {
                Description = "El Salvador Colon",
                Abbreviation = "SVC",
        },
        new Currency
        {
                Description = "Syria Pound",
                Abbreviation = "SYP",
        },
        new Currency
        {
                Description = "Swaziland Lilangeni",
                Abbreviation = "SZL",
        },
        new Currency
        {
                Description = "Thailand Baht",
                Abbreviation = "THB",
        },
        new Currency
        {
                Description = "Tajikistan Somoni",
                Abbreviation = "TJS",
        },
        new Currency
        {
                Description = "Turkmenistan Manat",
                Abbreviation = "TMT",
        },
        new Currency
        {
                Description = "Tunisia Dinar",
                Abbreviation = "TND",
        },
        new Currency
        {
                Description = "Tonga Pa'anga",
                Abbreviation = "TOP",
        },
        new Currency
        {
                Description = "Turkey Lira",
                Abbreviation = "TRY",
        },
        new Currency
        {
                Description = "Trinidad and Tobago Dollar",
                Abbreviation = "TTD",
        },
        new Currency
        {
                Description = "Tuvalu Dollar",
                Abbreviation = "TVD",
        },
        new Currency
        {
                Description = "Taiwan New Dollar",
                Abbreviation = "TWD",
        },
        new Currency
        {
                Description = "Tanzania Shilling",
                Abbreviation = "TZS",
        },
        new Currency
        {
                Description = "Ukraine Hryvnia",
                Abbreviation = "UAH",
        },
        new Currency
        {
                Description = "Uganda Shilling",
                Abbreviation = "UGX",
        },
        new Currency
        {
                Description = "United States Dollar",
                Abbreviation = "USD",
        },
        new Currency
        {
                Description = "Uruguay Peso",
                Abbreviation = "UYU",
        },
        new Currency
        {
                Description = "Uzbekistan Som",
                Abbreviation = "UZS",
        },
        new Currency
        {
                Description = "Venezuela Bolivar",
                Abbreviation = "VEF",
        },
        new Currency
        {
                Description = "Viet Nam Dong",
                Abbreviation = "VND",
        },
        new Currency
        {
                Description = "Vanuatu Vatu",
                Abbreviation = "VUV",
        },
        new Currency
        {
                Description = "Samoa Tala",
                Abbreviation = "WST",
        },
        new Currency
        {
                Description = "Communauté Financière Africaine (BEAC) CFA Franc BEAC",
                Abbreviation = "XAF",
        },
        new Currency
        {
                Description = "East Caribbean Dollar",
                Abbreviation = "XCD",
        },
        new Currency
        {
                Description = "International Monetary Fund (IMF) Special Drawing Rights",
                Abbreviation = "XDR",
        },
        new Currency
        {
                Description = "Communauté Financière Africaine (BCEAO) Franc",
                Abbreviation = "XOF",
        },
        new Currency
        {
                Description = "Comptoirs Français du Pacifique (CFP) Franc",
                Abbreviation = "XPF",
        },
        new Currency
        {
                Description = "Yemen Rial",
                Abbreviation = "YER",
        },
        new Currency
        {
                Description = "South Africa Rand",
                Abbreviation = "ZAR",
        },
        new Currency
        {
                Description = "Zambia Kwacha",
                Abbreviation = "ZMW",
        },
        new Currency
        {
                Description = "Zimbabwe Dollar",
                Abbreviation = "ZWD",
        },
            };

            await dbContext.Currencies.AddRangeAsync(currencies);
            await dbContext.SaveChangesAsync();
        }
    }
}
