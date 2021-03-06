﻿using System;
using System.Collections.Generic;
using Klinik.Utils.DataBase;

namespace Klinik.Utils.BusinessOperations
{
    public class BaseOperation
    {
        /// <summary>
        /// Context
        /// </summary>
        public DbKlinik Context { get; set; }

        public BaseOperation()
        {
            Name = getShortName(GetType().ToString());
            Errors = new Dictionary<string, string>();
        }

        /// <summary>
        /// Name of bissnes operation
        /// </summary>
        public String Name
        {
            get;
            protected set;
        }
        public String RussianName
        {
            get;
            protected set;
        }

        public IDictionary<String, String> Errors
        {
            get;
            protected set;
        }

        public Boolean Success
        {
            get
            {
                return !(Errors.Count > 0);
            }
        }

        protected virtual void InTransaction()
        { }

        protected virtual void OnBeginTransaction()
        { }

        protected virtual void CloseTransaction()
        { }

        /// <summary>
        /// Excecute all transaction
        /// </summary>
        public void ExcecuteTransaction()
        {

            Context = new DbKlinik();

            OnBeginTransaction();
            //отрытие тр.
            InTransaction();
            //выполнение тр.

            CloseTransaction();
        }
        private static string getShortName(string str)
        {
            int start = str.LastIndexOf('.') + 1;
            int end = str.LastIndexOf("Operation");
            return str.Substring(start, end - start).ToLower();
        }
    }
}