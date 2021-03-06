﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Infrastracture
{
    public static class DbObjects
    {
        public static class BaseDbObjects
        {
            public static class Functions
            {
                public static class Users
                {
                    public const string users_getloginbyuserid = "fn_users_getloginbyuserid";
                    public const string users_getloginbyusertokens = "fn_users_getloginbyusertokens";
                }
                public static class Persons
                {
                    public const string persons_getdtosbyparameters = "fn_persons_getdtosbyparameters";
                }
                public static class Products
                {
                    public const string products_getdtosbyparameters = "fn_products_getdtosbyparameters";
                }

                public static class BillItems
                {
                    public const string billitems_getbyrelatedproductid = "fn_billitems_getbyrelatedproductid";
                }
                public static class ProductSubstances
                {
                    public const string productsubstances_anyprohibitedsubstance = "fn_productsubstances_anyprohibitedsubstance";
                }

                public static class InventoryEntries
                {
                    public const string inventoryentries_getdtosbyparameters = "fn_inventoryentries_getdtosbyparameters";
                }
            }
        }
    }
}
